package net.saplobby.download;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.FileReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.UnsupportedEncodingException;
import java.text.DecimalFormat;
import java.util.ArrayList;
import java.util.List;
import java.util.Properties;
import java.util.Set;
import java.util.regex.Matcher;
import java.util.regex.Pattern;
import org.apache.http.HttpEntity;
import org.apache.http.HttpHost;
import org.apache.http.HttpResponse;
import org.apache.http.client.HttpClient;
import org.apache.http.client.entity.UrlEncodedFormEntity;
import org.apache.http.client.methods.HttpGet;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.impl.client.DefaultHttpClient;
import org.apache.http.message.BasicNameValuePair;
import org.apache.http.util.EntityUtils;

public class ITPubDownload {

    public static void main(String[] args) {
        try {
            String fileseparator = System.getProperty("file.separator");
            String basedir = System.getProperty("net.saplobby.basedir");
            if(basedir == null) {
                basedir = "D:/Downloads/itpub-download";
            }
            System.out.println("base dir: " + basedir);
            File baseconfig = new File(basedir + fileseparator + "config"
                    + fileseparator + "config.txt");
            FileInputStream fis = new FileInputStream(baseconfig);
            Properties downloadprop = new Properties();
            downloadprop.load(fis);

            System.out.println(downloadprop);
            String username = downloadprop.getProperty("USERNAME");
            String pwd = downloadprop.getProperty("PASSWORD");
            if ((username == null) || (username.trim().length() == 0)) {
                System.out.println("user name cannot be empty.");
                return;
            }

            String suffix = downloadprop.getProperty("SUFFIX");
            if ((suffix == null) || (suffix.trim().length() == 0)) {
                suffix = "[(pdf)|(rar)|(doc)|(excel)|(chm)|(zip)|(7z)|(swf)|(gif)|(jpg)|(jpeg)|(png)|(torrent)|(txt)|(sql)|(docx)|(xls)|(xlsx)|(ppt)|(pptx)]";
            }
            final String suffix1 = suffix;

            DefaultHttpClient httpclient = new DefaultHttpClient();
            String proxyStr = downloadprop.getProperty("PROXY");
            if ((proxyStr != null) && (proxyStr.trim().length() > 0)
                    && (proxyStr.contains(":"))) {
                System.out.println("using proxy " + proxyStr);
                String[] proxyInfo = proxyStr.split(":");

                HttpHost proxy = new HttpHost(proxyInfo[0],
                        Integer.valueOf(proxyInfo[1]).intValue());
                httpclient.getParams().setParameter(
                        "http.route.default-proxy", proxy);
            }

            HttpPost httpost = new HttpPost(
                    "http://www.itpub.net/member.php?mod=logging&action=login&loginsubmit=yes&infloat=yes");

            List nvps = new ArrayList();
            nvps.add(new BasicNameValuePair("username", username));
            nvps.add(new BasicNameValuePair("password", pwd));

            httpost.setEntity(new UrlEncodedFormEntity(nvps, "UTF-8"));

            HttpResponse response = httpclient.execute(httpost);

            HttpEntity entity = response.getEntity();
            if (entity != null) {
                EntityUtils.consume(entity);
            }

            String threadsfilepath = basedir + fileseparator + "config"
                    + fileseparator + "threads.txt";
            BufferedReader br = new BufferedReader(new FileReader(
                    threadsfilepath));
            String strLine;
            while ((strLine = br.readLine()) != null) {
                System.out.println("scanning thread: " + strLine);
                try {
                    Set<ItpubAttachmentLink> links =
                            LinkerExtractor.extracLinks(strLine, new LinkFilter() {
                        @Override
                        public boolean accept(String url, String name) {
                            if ((url == null) || (name == null)) {
                                return false;
                            }

                            if ((url.contains("attachment.php?aid="))
                                    && (url.contains("fid="))) {
                                String regEx = suffix1;
                                Pattern p = Pattern.compile(regEx, 2);
                                Matcher m = p.matcher(name);

                                return m.find();
                            }

                            return false;
                        }
                    });
                    if ((links == null) || (links.isEmpty())) {
                        System.out
                                .println("no link found. make sure you set the suffix filter correctly.");
                    } else {
                        for (ItpubAttachmentLink link : links) {
                            System.out.println(link);
                            String returncode = download(httpclient, link, "",
                                    basedir + System.getProperty("file.separator")
                                    + "downloaded", false);

                            if ("NR".equalsIgnoreCase(returncode)) {
                                System.out.println("");
                            }
                        }
                    }
                } catch (Exception e) {
                    e.printStackTrace();
                }
            }

            System.out.println("\r\nall downloading are finished");
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    public static String download(HttpClient httpclient, ItpubAttachmentLink link, String captcha, String destination, boolean overwrite) {
        String linkStr = link.getLink();
        linkStr = linkStr.replace("attachment.php?",
                "forum.php?mod=attachment&").replace("&amp;", "&");
        System.out.println("final link " + linkStr);
        try {
            HttpGet finalattachmentGet = new HttpGet(linkStr);

            HttpResponse finalresponse = httpclient.execute(finalattachmentGet);

            File downloadDirectory = new File(destination);
            if (!downloadDirectory.exists()) {
                downloadDirectory.mkdirs();
            }
            File attFile = new File(destination
                    + System.getProperty("file.separator") + link.getName());
            HttpEntity finalentity = finalresponse.getEntity();
            InputStream attInput = finalentity.getContent();
            long fileLength = finalentity.getContentLength();
            System.out.println("file size " + fileLength);
            if (attFile.exists()) {
                System.out.println("existing file size is " + attFile.length());

                if (fileLength > attFile.length()) {
                    System.out
                            .println("size of new file is bigger than the existing one, which will be overwritten.");
                } else {
                    System.out.println("file existed, no need to download");
                    finalattachmentGet.releaseConnection();
                    return "";
                }

                System.out.println("downloading will continue");
            }

            System.out.println("downloading \"" + link.getName()
                    + "\" is started.");
            FileOutputStream attOutput = new FileOutputStream(attFile);
            byte[] b1 = new byte[102400];
            int len1 = 0;
            int finished = 0;

            while ((len1 = attInput.read(b1)) != -1) {
                finished += len1;
                attOutput.write(b1, 0, len1);

                DecimalFormat df = new DecimalFormat("#");

                System.out.print("\r"
                        + df.format(finished / (float) fileLength * 100.0F)
                        + "% downloaded");
            }
            System.out.println("\r\n" + link.getName() + " is downloaded to "
                    + destination);
            attInput.close();
            attOutput.close();
            finalattachmentGet.releaseConnection();
        } catch (UnsupportedEncodingException e) {
            e.printStackTrace();
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        }

        return "";
    }
}
