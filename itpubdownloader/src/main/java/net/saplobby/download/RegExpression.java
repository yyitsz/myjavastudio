package net.saplobby.download;

import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class RegExpression {

    public static void main(String[] args) {
        String reg = "\\.(pdf|jpeg|bmp|gif)$";
        String s = "sdfasf.bmp";
        Pattern p = Pattern.compile(reg, 66);
        Matcher m = p.matcher(s);
        while (m.find()) {
            System.out.println(m.group());
        }
    }
}
