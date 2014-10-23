using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SQLite;
using SQLiteTools.PaymentForm;
using SQLiteTools.Common;
using SQLiteTools.Utils;

namespace SQLiteTools
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);

            Application.Run(new SQLiteToolsMainForm());
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            try
            {
                Exception ex = (Exception)e.Exception;
                if (ex is AppException)
                {
                    MessageBoxHelper.ShowError(ex.Message);
                }
                else if (ex is SQLiteException)
                {
                    if (ex.Message.StartsWith("constraint failed"))
                    {
                        MessageBoxHelper.ShowDetail(MessageType.Information, "Error", "Save duplicate data to DB.", ex);
                    }
                    else
                    {
                        MessageBoxHelper.ShowDetail(MessageType.Information, "Error", "Error when do action on DB. " + ex.Message, ex);
                    }
                }
                else
                {
                    if (MessageBoxHelper.ShowDetail(MessageType.Critical, "Error", ex.Message, ex) == DialogResult.Abort)
                    {
                        Application.Exit();
                    }
                }

            }
            catch
            {
                try
                {
                    MessageBox.Show("Fatal Error", "Fatal Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop);
                }
                finally
                {
                    Application.Exit();
                }
            }

            //// Exits the program when the user clicks Abort.
            //if (result == DialogResult.Abort)
            //    Application.Exit();
        }

        /// <summary>
        /// Handles the UnhandledException event of the CurrentDomain control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.UnhandledExceptionEventArgs"/> instance containing the event data.</param>
        public static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                Exception ex = (Exception)e.ExceptionObject;
                if (ex is AppException)
                {
                    MessageBoxHelper.ShowError(ex.Message);
                }
                else
                {
                    MessageBoxHelper.ShowDetail(MessageType.Critical, "Error", ex.Message, ex);
                }
            }
            catch
            {
                try
                {
                    MessageBox.Show("Fatal Error", "Fatal Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop);
                }
                catch (Exception)
                {

                }
                finally
                {
                    Application.Exit();
                }
            }
        }
    }
}