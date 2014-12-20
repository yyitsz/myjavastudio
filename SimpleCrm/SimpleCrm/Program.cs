using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SimpleCrm.Utils;
using SimpleCrm.Manager;
using SimpleCrm.Common;
using System.Data.SQLite;
using SimpleCrm.Security;
using SimpleCrm.Facade;
using DevComponents.DotNetBar;

namespace SimpleCrm
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
            Dapper.SimpleCRUD.CrudContext = UserManager.UserProfile;
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            AppFacade.Facade.MainForm = new MainForm();
            Application.Run(AppFacade.Facade.MainForm);

        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            try
            {
                ExceptionHelper.HandleException(e.Exception);
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
                ExceptionHelper.HandleException(ex);
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