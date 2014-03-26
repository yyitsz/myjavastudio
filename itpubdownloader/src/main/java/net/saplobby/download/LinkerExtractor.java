package net.saplobby.download;

import java.io.PrintStream;
import java.io.UnsupportedEncodingException;
import java.net.URLDecoder;
import java.util.Set;
import java.util.TreeSet;
import org.htmlparser.Node;
import org.htmlparser.NodeFilter;
import org.htmlparser.Parser;
import org.htmlparser.filters.AndFilter;
import org.htmlparser.filters.HasAttributeFilter;
import org.htmlparser.filters.HasParentFilter;
import org.htmlparser.filters.HasSiblingFilter;
import org.htmlparser.filters.NodeClassFilter;
import org.htmlparser.filters.OrFilter;
import org.htmlparser.filters.TagNameFilter;
import org.htmlparser.tags.LinkTag;
import org.htmlparser.util.NodeList;
import org.htmlparser.util.ParserException;
import org.htmlparser.util.SimpleNodeIterator;

public class LinkerExtractor {

    public static void main(String[] args) {
        extractThreadWithAttachment("http://www.itpub.net/forum.php?mod=forumdisplay&fid=61&orderby=dateline&filter=dateline&dateline=604800&orderby=dateline");
    }

    public static void extractKeyWordText(String url, String keyword) {
        try {
            Parser parser = new Parser(url);

            parser.setEncoding("gb2312");

            NodeList list = parser.parse(null);

            processNodeList(list, keyword);
        } catch (ParserException e) {
            e.printStackTrace();
        }
    }

    private static void processNodeList(NodeList list, String keyword) {
        SimpleNodeIterator iterator = list.elements();
        while (iterator.hasMoreNodes()) {
            Node node = iterator.nextNode();

            NodeList childList = node.getChildren();

            if (childList == null) {
                String result = node.toPlainTextString();

                if (result.indexOf(keyword) != -1) {
                    System.out.println(result);
                }
            } else {
                processNodeList(childList, keyword);
            }
        }
    }

    public static Set<String> extractThreadWithAttachment(String url) {
        try {
            Set links = new TreeSet();
            Parser parser = new Parser(url);
            parser.setEncoding("gbk");

            TagNameFilter imgfilter = new TagNameFilter("img");
            HasAttributeFilter downloadfilter = new HasAttributeFilter("title",
                    "附件");
            HasAttributeFilter linkClassfilter = new HasAttributeFilter(
                    "class", "xst");
            AndFilter attachImgfilter = new AndFilter(imgfilter, downloadfilter);
            TagNameFilter afilter = new TagNameFilter("a");
            HasSiblingFilter hasSiblingFilter = new HasSiblingFilter(
                    attachImgfilter);
            AndFilter linkfilter = new AndFilter(new NodeFilter[]{afilter,
                        hasSiblingFilter, linkClassfilter});
            NodeList list = parser.extractAllNodesThatMatch(linkfilter);
            System.out.println(list.size());
            for (int i = 0; i < list.size(); i++) {
                Node tag = list.elementAt(i);
                if ((tag instanceof LinkTag)) {
                    LinkTag link = (LinkTag) tag;
                    String linkUrl = link.getLink();
                    System.out.println(linkUrl);
                    String url1 = URLDecoder.decode(linkUrl, "utf-8")
                            .replaceAll("&amp;", "&");
                    System.out.println(url1);
                    links.add(url1);
                }
            }
            return links;
        } catch (ParserException e) {
            e.printStackTrace();
        } catch (UnsupportedEncodingException e) {
            e.printStackTrace();
        }
        return null;
    }

    public static Set<ItpubAttachmentLink> extracLinks(String url, LinkFilter filter) {
        Set links = new TreeSet();
        try {
            Parser parser = new Parser(url);
            parser.setEncoding("gbk");

            NodeFilter frameFilter = new NodeFilter() {
                @Override
                public boolean accept(Node node) {
                    if (node.getText().startsWith("frame src=")) {
                        return true;
                    }
                    return false;
                }
            };
            OrFilter linkFilter = new OrFilter(new NodeClassFilter(
                    LinkTag.class), frameFilter);
            TagNameFilter pTagFilter = new TagNameFilter("p");
            HasAttributeFilter attP = new HasAttributeFilter("class", "attnm");
            AndFilter attachmentPTag = new AndFilter(pTagFilter, attP);
            TagNameFilter afilter = new TagNameFilter("a");
            HasParentFilter attPAsParent = new HasParentFilter(attachmentPTag);
            AndFilter finalAttLink = new AndFilter(afilter, attPAsParent);

            NodeList list = parser.extractAllNodesThatMatch(afilter);
            for (int i = 0; i < list.size(); i++) {
                Node tag = list.elementAt(i);
                if ((tag instanceof LinkTag)) {
                    LinkTag link = (LinkTag) tag;
                    String linkUrl = link.getLink();
                    String linkName = link.getLinkText();
                    if (filter.accept(linkUrl, linkName)) {
                        ItpubAttachmentLink l = new ItpubAttachmentLink(
                                linkUrl, linkName);
                        links.add(l);
                    }
                }
            }
        } catch (ParserException e) {
            e.printStackTrace();
        }
        return links;
    }
}

