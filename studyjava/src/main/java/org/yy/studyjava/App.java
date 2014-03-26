package org.yy.studyjava;

import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;
import java.util.Locale;

import org.apache.commons.lang.time.DateUtils;

/**
 * Hello world!
 * 
 */
public class App {
    public static void main(String[] args) {
       Locale locale = Locale.UK;
       SimpleDateFormat format = new SimpleDateFormat("yyyy MMM", locale);
       String result = format.format(new Date());
       System.out.println(result);
       
       format = new SimpleDateFormat("yyyy MMM", Locale.CHINA);
       result = format.format(new Date());
       System.out.println(result);
       
       format = new SimpleDateFormat("yyyy MMM", Locale.TAIWAN);
       result = format.format(new Date());
       System.out.println(result);
    }
    public static void test(){
        
        String type = "D11";
        int days = tryParseInt(type.substring(1,type.length() ), 5);
        Calendar nowDate = DateUtils.truncate(Calendar.getInstance(),Calendar.DATE);
        Date startDate = nowDate.getTime();
        nowDate.add(Calendar.DAY_OF_MONTH, -(days-1));
        Date endDate = nowDate.getTime();
        
        System.out.printf("S:%s, E: %s", startDate, endDate);
        System.out.println();
        type = "M0";
        int months = tryParseInt(type.substring(1,type.length()), 0);  
        nowDate = DateUtils.truncate(Calendar.getInstance(),Calendar.MONTH);
        nowDate.add(Calendar.MONTH, -months);
        startDate = nowDate.getTime();
        nowDate.add(Calendar.MONTH, 1);
        nowDate.add(Calendar.DATE, -1);
        endDate = nowDate.getTime();
        
        System.out.printf("M0 -> S:%s, E: %s", startDate, endDate);
        System.out.println();
        
        type = "M1";
        months = tryParseInt(type.substring(1,type.length()), 0);  
        nowDate = DateUtils.truncate(Calendar.getInstance(),Calendar.MONTH);
        nowDate.add(Calendar.MONTH, -months);
        startDate = nowDate.getTime();
        nowDate.add(Calendar.MONTH, 1);
        nowDate.add(Calendar.DATE, -1);
        endDate = nowDate.getTime();
        
        System.out.printf("M1 -> S:%s, E: %s", startDate, endDate);
        System.out.println();
    }
    public static int tryParseInt(String str, int defaultVal) {
        int result = defaultVal;
        try {
            result = Integer.parseInt(str);
        } catch (Exception ex) {
            result = defaultVal;
        }
        return result;
    }
}
