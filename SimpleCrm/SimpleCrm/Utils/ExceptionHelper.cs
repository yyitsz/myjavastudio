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
                    MessageBoxHelper.ShowDetail(MessageType.Information, "错误", "保存重复的数据，或者保存不符合规范的数据。", ex);
                }
                else
                {
                    MessageBoxHelper.ShowDetail(MessageType.Information, "错误", "保存数据时发生了错误. " + ex.Message, ex);
                }
            }
            else
            {
                if (MessageBoxHelper.ShowDetail(MessageType.Critical, "错误", ex.Message, ex) == DialogResult.Abort)
                {
                    Application.Exit();
                }
            }
        }
    }
}
