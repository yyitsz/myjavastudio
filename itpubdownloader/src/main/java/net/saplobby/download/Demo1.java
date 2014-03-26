 package net.saplobby.download;
 
 import java.io.PrintStream;
 import java.util.regex.Matcher;
 import java.util.regex.Pattern;
 import org.apache.http.client.HttpClient;
 
 public class Demo1
 {
   public static void printProgBar(int percent)
   {
     StringBuilder bar = new StringBuilder("[");
 
     for (int i = 0; i < 50; i++) {
       if (i < percent / 2)
         bar.append("=");
       else if (i == percent / 2)
         bar.append(">");
       else {
         bar.append(" ");
       }
     }
 
     bar.append("]   " + percent + "%     ");
     System.out.print("\r" + bar.toString() + "\r");
   }
 
   public static final void main(String[] args) throws Exception
   {
     String name = "sadfsafsa.ra";
     String regEx = "[(rar)]$";
     Pattern p = Pattern.compile(regEx, 2);
     Matcher m = p.matcher(name);
     System.out.println(m.find());
 
     System.out.print("test1111");
     System.out.print("\ro");
   }
 
   public static void download(HttpClient httpclient, ItpubAttachmentLink link, String captcha, String cookie)
   {
   }
 }

/* Location:           D:\Downloads\itpub-download\bin\
 * Qualified Name:     net.saplobby.download.Demo1
 * JD-Core Version:    0.6.2
 */