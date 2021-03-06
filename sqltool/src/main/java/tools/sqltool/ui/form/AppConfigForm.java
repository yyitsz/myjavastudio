/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package tools.sqltool.ui.form;

import java.awt.event.ItemEvent;
import java.util.HashMap;
import java.util.Map;
import java.util.Map.Entry;
import javax.swing.JComboBox;
import javax.swing.JOptionPane;
import tools.sqltool.cfg.AppConfig;
import tools.sqltool.cfg.DataSourceConfig;
import tools.sqltool.utils.UiUtils;

/**
 *
 * @author yy
 */
public class AppConfigForm extends javax.swing.JDialog {

    /**
     * Creates new form AppConfigForm
     */
    public AppConfigForm(java.awt.Frame parent, boolean modal) {
        super(parent, modal);
        initComponents();
        initData();
    }

    /**
     * This method is called from within the constructor to initialize the form.
     * WARNING: Do NOT modify this code. The content of this method is always
     * regenerated by the Form Editor.
     */
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        jLabel1 = new javax.swing.JLabel();
        jLabel2 = new javax.swing.JLabel();
        txtWorkspace = new javax.swing.JTextField();
        cmbDs = new javax.swing.JComboBox();
        jLabel3 = new javax.swing.JLabel();
        txtUrl = new javax.swing.JTextField();
        jLabel4 = new javax.swing.JLabel();
        txtUserName = new javax.swing.JTextField();
        jLabel5 = new javax.swing.JLabel();
        txtPassword = new javax.swing.JTextField();
        jLabel6 = new javax.swing.JLabel();
        btnConfirm = new javax.swing.JButton();
        btnCancel = new javax.swing.JButton();

        jLabel1.setText("jLabel1");

        setDefaultCloseOperation(javax.swing.WindowConstants.DISPOSE_ON_CLOSE);

        jLabel2.setText("Workspace:");

        cmbDs.setModel(new javax.swing.DefaultComboBoxModel(new String[] { "Source Data Source", "Destination Data Source" }));
        cmbDs.addItemListener(new java.awt.event.ItemListener() {
            public void itemStateChanged(java.awt.event.ItemEvent evt) {
                cmbDsItemStateChanged(evt);
            }
        });

        jLabel3.setText("DataSource");

        jLabel4.setText("URL");

        jLabel5.setText("User Name");

        jLabel6.setText("Passowrd:");

        btnConfirm.setText("Confirm");
        btnConfirm.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btnConfirmActionPerformed(evt);
            }
        });

        btnCancel.setText("Cancel");
        btnCancel.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btnCancelActionPerformed(evt);
            }
        });

        org.jdesktop.layout.GroupLayout layout = new org.jdesktop.layout.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
            .add(layout.createSequentialGroup()
                .add(layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
                    .add(layout.createSequentialGroup()
                        .add(28, 28, 28)
                        .add(layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
                            .add(jLabel5)
                            .add(jLabel6)
                            .add(jLabel4))
                        .add(18, 18, 18)
                        .add(layout.createParallelGroup(org.jdesktop.layout.GroupLayout.TRAILING, false)
                            .add(org.jdesktop.layout.GroupLayout.LEADING, txtUserName, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, 301, Short.MAX_VALUE)
                            .add(org.jdesktop.layout.GroupLayout.LEADING, txtPassword)
                            .add(txtUrl)))
                    .add(layout.createSequentialGroup()
                        .add(layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
                            .add(layout.createSequentialGroup()
                                .add(21, 21, 21)
                                .add(jLabel2))
                            .add(layout.createSequentialGroup()
                                .add(29, 29, 29)
                                .add(jLabel3)))
                        .add(18, 18, 18)
                        .add(layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
                            .add(cmbDs, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                            .add(txtWorkspace, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 415, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE))))
                .addContainerGap(org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
            .add(org.jdesktop.layout.GroupLayout.TRAILING, layout.createSequentialGroup()
                .add(0, 0, Short.MAX_VALUE)
                .add(btnConfirm)
                .addPreferredGap(org.jdesktop.layout.LayoutStyle.UNRELATED)
                .add(btnCancel)
                .add(63, 63, 63))
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
            .add(layout.createSequentialGroup()
                .add(26, 26, 26)
                .add(layout.createParallelGroup(org.jdesktop.layout.GroupLayout.BASELINE)
                    .add(jLabel2)
                    .add(txtWorkspace, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE))
                .add(18, 18, 18)
                .add(layout.createParallelGroup(org.jdesktop.layout.GroupLayout.BASELINE)
                    .add(cmbDs, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                    .add(jLabel3))
                .add(18, 18, 18)
                .add(layout.createParallelGroup(org.jdesktop.layout.GroupLayout.BASELINE)
                    .add(jLabel4)
                    .add(txtUrl))
                .add(18, 18, 18)
                .add(layout.createParallelGroup(org.jdesktop.layout.GroupLayout.BASELINE)
                    .add(jLabel5)
                    .add(txtUserName))
                .add(18, 18, 18)
                .add(layout.createParallelGroup(org.jdesktop.layout.GroupLayout.BASELINE)
                    .add(jLabel6)
                    .add(txtPassword))
                .add(46, 46, 46)
                .add(layout.createParallelGroup(org.jdesktop.layout.GroupLayout.BASELINE)
                    .add(btnConfirm)
                    .add(btnCancel))
                .add(17, 17, 17))
        );

        pack();
    }// </editor-fold>//GEN-END:initComponents

    private void btnConfirmActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btnConfirmActionPerformed
        try {
            saveData();
            this.dispose();
        } catch (Exception ex) {
            JOptionPane.showMessageDialog(
                    this, "Error: " + ex.toString(),
                    "Error", JOptionPane.ERROR_MESSAGE);
        }

    }//GEN-LAST:event_btnConfirmActionPerformed

    private void cmbDsItemStateChanged(java.awt.event.ItemEvent evt) {//GEN-FIRST:event_cmbDsItemStateChanged
        if (evt.getStateChange() == ItemEvent.DESELECTED) {
            String key = nameMap.get(evt.getItem().toString());
            bindUiToBs(key);
        } else {
            String key = nameMap.get(evt.getItem().toString());
            bindDsToUi(key);
        }
    }//GEN-LAST:event_cmbDsItemStateChanged

    private void btnCancelActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btnCancelActionPerformed
        this.dispose();
    }//GEN-LAST:event_btnCancelActionPerformed
    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton btnCancel;
    private javax.swing.JButton btnConfirm;
    private javax.swing.JComboBox cmbDs;
    private javax.swing.JLabel jLabel1;
    private javax.swing.JLabel jLabel2;
    private javax.swing.JLabel jLabel3;
    private javax.swing.JLabel jLabel4;
    private javax.swing.JLabel jLabel5;
    private javax.swing.JLabel jLabel6;
    private javax.swing.JTextField txtPassword;
    private javax.swing.JTextField txtUrl;
    private javax.swing.JTextField txtUserName;
    private javax.swing.JTextField txtWorkspace;
    // End of variables declaration//GEN-END:variables
    private Map<String, DataSourceConfig> dsConfigs = new HashMap<String, DataSourceConfig>();
    private Map<String, String> nameMap = new HashMap<String, String>();
    private String workspace;

    private void initData() {


        nameMap.put("Source Data Source", AppConfig.SRC_DS);
        nameMap.put("Destination Data Source", AppConfig.DEST_DS);

        DataSourceConfig cfg = AppConfig.getDSConfig(AppConfig.SRC_DS);
        if (cfg != null) {
            dsConfigs.put(AppConfig.SRC_DS, cfg);
        }

        cfg = AppConfig.getDSConfig(AppConfig.DEST_DS);
        if (cfg != null) {
            dsConfigs.put(AppConfig.DEST_DS, cfg);
        }

        workspace = AppConfig.getWorkspace();

        this.txtWorkspace.setText(workspace);
        bindDsToUi(this.nameMap.get(this.cmbDs.getSelectedItem().toString()));
    }

    private void bindDsToUi(String key) {
        DataSourceConfig cfg = this.dsConfigs.get(key);
        if (cfg != null) {
            this.txtUrl.setText(cfg.getUrl());
            this.txtUserName.setText(cfg.getUser());
            this.txtPassword.setText(cfg.getPassword());
        } else {
            this.txtPassword.setText("");
            this.txtUrl.setText("");
            this.txtUserName.setText("");
        }

    }

    private void bindUiToBs(String key) {
        DataSourceConfig cfg = new DataSourceConfig();
        cfg.setUrl(txtUrl.getText());
        cfg.setUser(txtUserName.getText());
        cfg.setPassword(txtPassword.getText());

        dsConfigs.put(key, cfg);

    }

    private void bindUiToBs() {
        String key = nameMap.get(cmbDs.getSelectedItem().toString());
        bindUiToBs(key);

    }

    private void saveData() {
        bindUiToBs();
        AppConfig.setWorkspace(this.txtWorkspace.getText());
        for (Entry<String, DataSourceConfig> kv : this.dsConfigs.entrySet()) {
            AppConfig.setDSConfig(kv.getKey(), kv.getValue());
        }
    }
}
