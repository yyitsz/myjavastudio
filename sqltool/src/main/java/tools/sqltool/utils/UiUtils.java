/**
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package tools.sqltool.utils;

import java.awt.Component;
import javax.swing.JDesktopPane;
import javax.swing.JInternalFrame;
import tools.sqltool.MainForm;

/**
 *
 * @author yyi
 */
public class UiUtils {
    private static MainForm mainform;

    public static MainForm getMainform() {
        return mainform;
    }

    public static void setMainform(MainForm mainform) {
        UiUtils.mainform = mainform;
    }  
  
}
