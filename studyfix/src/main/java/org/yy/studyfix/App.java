package org.yy.studyfix;

import java.util.concurrent.TimeUnit;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.SwingUtilities;

/**
 * Hello world!
 *
 */
public class App 
{
    public static void main( String[] args ) throws InterruptedException
    {
        JFrame frame = new JFrame("Hello Swing");
        final JLabel lable = new JLabel("A Label");
        frame.add(lable);
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        frame.setSize(300,100);
        frame.setLocation(100, 200);
        frame.setVisible(true);
        //Thread.sleep(1000);
        TimeUnit.SECONDS.sleep(1);
        SwingUtilities.invokeLater(new Runnable(){

            @Override
            public void run() {
                lable.setText("changed after 1 sec");
            }
        });
        
    }
}
