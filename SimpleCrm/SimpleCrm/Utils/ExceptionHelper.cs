using System;
using System.Collections.Generic;
using System.Text;
using SimpleCrm.Common;
using System.Data.SQLite;
using System.Windows.Forms;

namespace SimpleCrm.Utils
{
    public static class ExceptionHelper
    {
        public static void HandleException(Exception ex)
        {
            if (ex is AppException)
            {
                MessageBoxHelper.ShowError(ex.Message);
            }
            else if (ex is StaleRecordException)
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
    }
}
