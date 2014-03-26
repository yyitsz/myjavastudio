/**
 * To change this template, choose Tools | Templates and open the template in
 * the editor.
 */
package tools.sqltool.utils;

import java.lang.Thread.UncaughtExceptionHandler;
import javax.swing.JOptionPane;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

/**
 *
 * @author yyi
 */
public class AppUncaughtExceptionHandler implements UncaughtExceptionHandler {

    private static Logger logger = LoggerFactory.getLogger(AppUncaughtExceptionHandler.class);

    @Override
    public void uncaughtException(Thread t, Throwable e) {
        logger.error(e.getMessage(), e);
        JOptionPane.showMessageDialog(
                UiUtils.getMainform(), "Error: " + e.toString(),
                "Error", JOptionPane.ERROR_MESSAGE);
    }
}
