using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace SimpleCrm.Utils
{
    /// <summary>
    /// Help class of MessageBox.It simplifies the MessageBox usage.
    /// </summary>
    public class MessageBoxHelper
    {
        /// <summary>
        /// Show propmt message box.
        /// </summary>
        /// <param name="textResourceID">The Resource ID of The text which be shown in messagebox</param>
        /// <param name="param">The param.</param>
        /// <returns></returns>
        public static DialogResult ShowPrompt(string textResourceID, params object[] param)
        {
            return Show(textResourceID, "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1,
                param);
        }

        /// <summary>
        /// Show propmt message box.
        /// </summary>
        /// <param name="textResourceID">The Resource ID of The text which be shown in messagebox</param>
        /// <param name="param">The param.</param>
        /// <returns></returns>
        public static DialogResult ShowError(string textResourceID, params object[] param)
        {
            return Show(textResourceID, "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                param);
        }

        /// <summary>
        /// Shows the prompt.
        /// </summary>
        /// <param name="captionResourceID">The caption resource ID.</param>
        /// <param name="textResourceID">The text resource ID.</param>
        /// <param name="param">The param.</param>
        /// <returns></returns>
        public static DialogResult ShowPrompt(string captionResourceID, string textResourceID, params object[] param)
        {
            return Show(textResourceID, captionResourceID, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, param);
        }

        /// <summary>
        /// Shows message box included the OK and Cancel button.
        /// </summary>
        /// <param name="textResourceID">The text resource ID.</param>
        /// <param name="param">The param.</param>
        /// <returns></returns>
        public static DialogResult ShowOKCancel(string textResourceID, params object[] param)
        {
            return ShowOKCancel("温馨提示", textResourceID, param);
        }

        /// <summary>
        /// Shows message box included the OK and Cancel button.
        /// </summary>
        /// <param name="captionResourceID">The caption resource ID.</param>
        /// <param name="textResourceID">The text resource ID.</param>
        /// <param name="param">The param.</param>
        /// <returns></returns>
        public static DialogResult ShowOKCancel(string captionResourceID, string textResourceID, params object[] param)
        {
            return Show(textResourceID, captionResourceID, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3, param);
        }

        /// <summary>
        ///  Shows message box included the Yes and No button.
        /// </summary>
        /// <param name="textResourceID">The text resource ID.</param>
        /// <param name="param">The param.</param>
        /// <returns></returns>
        public static DialogResult ShowYesNo(string textResourceID, params object[] param)
        {
            return Show(textResourceID, "温馨提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, param);

        }

        /// <summary>
        ///  Shows message box included the Yes and No button.
        /// </summary>
        /// <param name="captionResourceID">The caption resource ID.</param>
        /// <param name="textResourceID">The text resource ID.</param>
        /// <param name="param">The param.</param>
        /// <returns></returns>
        public static DialogResult ShowYesNo(string captionResourceID, string textResourceID, params object[] param)
        {
            return Show(textResourceID, captionResourceID, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, param);

        }

        /// <summary>
        ///  Shows message box included the Yes and No and Cancel button.
        /// </summary>
        /// <param name="textResourceID">The text resource ID.</param>
        /// <param name="param">The param.</param>
        /// <returns></returns>
        public static DialogResult ShowYesNoCancel(string textResourceID, params object[] param)
        {
            return Show(textResourceID, "温馨提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3, param);

        }

        /// <summary>
        /// Shows message box included the Yes and No and Cancel button.
        /// </summary>
        /// <param name="captionResourceID">The caption resource ID.</param>
        /// <param name="textResourceID">The text resource ID.</param>
        /// <param name="param">The param.</param>
        /// <returns></returns>
        public static DialogResult ShowYesNoCancel(string captionResourceID, string textResourceID, params object[] param)
        {
            return Show(textResourceID, captionResourceID, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3, param);

        }

        /// <summary>
        /// Shows message box included the retry and cancel and Cancel button. 
        /// </summary>
        /// <param name="textResourceID">The text resource ID.</param>
        /// <param name="param">The param.</param>
        /// <returns></returns>
        public static DialogResult ShowRetryCancel(string textResourceID, params object[] param)
        {
            return Show(textResourceID, "温馨提示", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, param);
        }

        /// <summary>
        /// Shows message box included the retry and cancel and Cancel button. 
        /// </summary>
        /// <param name="captionResourceID">The caption resource ID.</param>
        /// <param name="textResourceID">The text resource ID.</param>
        /// <param name="param">The param.</param>
        /// <returns></returns>
        public static DialogResult ShowRetryCancel(string captionResourceID, string textResourceID, params object[] param)
        {
            return Show(textResourceID, captionResourceID, MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, param);
        }


        /// <summary>
        /// Shows message box.
        /// </summary>
        /// <param name="textResourceID">The text resource ID.</param>
        /// <param name="captionResourceID">The caption resource ID.</param>
        /// <param name="buttons">The buttons.</param>
        /// <param name="icon">The icon.</param>
        /// <param name="defaultButton">The default button.</param>
        /// <param name="param">The param.</param>
        /// <returns></returns>
        public static DialogResult Show(string textResourceID, string captionResourceID, MessageBoxButtons buttons,
            MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, params object[] param)
        {
            string caption = captionResourceID;
            string text = textResourceID;

            if (param.Length > 0)
            {
                text = string.Format(text, param);
            }

            return MessageBoxEx.Show(text, caption, buttons, icon, defaultButton);
        }

        public static DialogResult ShowDetail(MessageType messageType, string captionResourceID, string textResourceID, Exception ex, params object[] textParam)
        {

            string caption = captionResourceID;

            string text = textResourceID;

            if (textParam.Length > 0)
            {
                text = string.Format(text, textParam);
            }

            DetailMessageBox box = new DetailMessageBox(messageType);
            return box.Show(caption, text, ex);

        }
    }
}
