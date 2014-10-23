using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;


namespace SimpleCrm.Utils
{
    /// <summary>
    /// Message box type.
    /// </summary>
    public enum MessageType
    {
        /// <summary>
        /// 
        /// </summary>
        Information,
        /// <summary>
        /// 
        /// </summary>
        Warnning,
        /// <summary>
        /// 
        /// </summary>
        Validation,
        /// <summary>
        /// 
        /// </summary>
        Question,
        /// <summary>
        /// 
        /// </summary>
        System,
        /// <summary>
        /// 
        /// </summary>
        Critical
    }

    /// <summary>
    /// Detail message box.
    /// </summary>
    public partial class DetailMessageBox : Office2007Form
    {
        private MessageType _msgType;

        /// <summary>
        /// Initializes a new instance of the <see cref="DetailMessageBox"/> class.
        /// </summary>
        public DetailMessageBox()
        {
            InitializeComponent();
            _msgType = MessageType.Information;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DetailMessageBox"/> class.
        /// </summary>
        /// <param name="messageType">Type of the message.</param>
        public DetailMessageBox(MessageType messageType)
        {
            InitializeComponent();
            _msgType = messageType;
        }

        private int _groupHeight;

        /// <summary>
        /// Handles the Click event of the btnDetail control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnDetail_Click(object sender, EventArgs e)
        {
            ShowDetailMessage(this.grbDetail.Visible != true);
        }

        /// <summary>
        /// Shows the detail message.
        /// </summary>
        /// <param name="visible">if set to <c>true</c> [visible].</param>
        private void ShowDetailMessage(bool visible)
        {
            if (grbDetail.Visible == visible)
            {
                return;
            }

            if (visible == true)
            {
                btnDetail.Text = btnDetail.Text.Replace('<', '>');
                this.Height += _groupHeight;

            }
            else
            {
                btnDetail.Text = btnDetail.Text.Replace('>', '<');
                _groupHeight = this.grbDetail.Height;
                this.Height -= this.grbDetail.Height;

            }

            grbDetail.Visible = visible;
        }

        /// <summary>
        /// Shows the specified caption.
        /// </summary>
        /// <param name="caption">The caption.</param>
        /// <param name="message">The message.</param>
        /// <param name="detailMessage">The detail message.</param>
        /// <returns></returns>
        public DialogResult Show(string caption, string message, string detailMessage)
        {
            this.Text = caption;
            this.lblMessage.Text = message;
            this.txtDetailMessage.Text = detailMessage;
            //if (this.InvokeRequired)
            //{
            //    return (DialogResult)this.Invoke(new MethodInvoker(this.ShowDialog));
            //}
            return this.ShowDialog();
        }

        /// <summary>
        /// Shows the specified caption.
        /// </summary>
        /// <param name="caption">The caption.</param>
        /// <param name="message">The message.</param>
        /// <param name="ex">The ex.</param>
        /// <returns></returns>
        public DialogResult Show(string caption, string message, Exception ex)
        {
            return Show(caption, message, GetDetailMessageFromException(ex));

        }

        /// <summary>
        /// Gets the detail message from exception.
        /// </summary>
        /// <param name="ex">The ex.</param>
        /// <returns></returns>
        private string GetDetailMessageFromException(Exception ex)
        {
            if (ex == null)
            {
                return "";
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("Exception: " + ex.GetType().ToString());
            sb.Append(Environment.NewLine);
            sb.Append("-------------------------------------------");
            sb.Append(Environment.NewLine);
            sb.Append("Message: " + ex.Message);
            sb.Append(Environment.NewLine);
            sb.Append("-------------------------------------------");
            sb.Append(Environment.NewLine);
            sb.Append("Source: " + ex.Source);
            sb.Append(Environment.NewLine);
            sb.Append("-------------------------------------------");
            sb.Append(Environment.NewLine);
            sb.Append("StackTrace: " + ex.StackTrace);
            sb.Append(Environment.NewLine);
            sb.Append("===========================================");
            sb.Append(Environment.NewLine);
           
            if (ex.InnerException != null)
            {


                sb.Append(Environment.NewLine);
                return sb.ToString() + GetDetailMessageFromException(ex.InnerException);
            }
            else
            {
                return sb.ToString();
            }

        }

        /// <summary>
        /// Handles the Load event of the DetaiMessageBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void DetaiMessageBox_Load(object sender, EventArgs e)
        {
            btnOK.Text = "OK";
            btnYes.Text = "Yes";
            btnNo.Text = "No";
            btnCancel.Text = "Cancel";
            btnDetail.Text = "Detail";
            btnExit.Text = "Exit";
            btnCopy.Text = "Copy";

            switch (_msgType)
            {

                case MessageType.Information:
                    lblIcon.Image = (Bitmap)Properties.Resources.InfoIcon.ToBitmap();//.ResourceManager.GetObject("InfoIcon");
                    btnOK.Visible = true;
                    btnOK.Focus();
                    break;
                case MessageType.Warnning:
                    lblIcon.Image = (Bitmap)Properties.Resources.WarningIcon.ToBitmap();//.ResourceManager.GetObject("WarnningIcon");
                    btnCancel.Visible = true;
                    btnNo.Visible = true;
                    btnYes.Visible = true;


                    break;
                case MessageType.Validation:
                    lblIcon.Image = (Bitmap)Properties.Resources.WarningIcon.ToBitmap();//.ResourceManager.GetObject("WarnningIcon");
                    btnOK.Visible = true;
                    break;
                case MessageType.Question:
                    lblIcon.Image = (Bitmap)Properties.Resources.QuestionIcon.ToBitmap();//.ResourceManager.GetObject("QuestionIcon");
                    btnYes.Visible = true;
                    btnNo.Visible = true;
                    break;
                case MessageType.System:
                    lblIcon.Image = (Bitmap)Properties.Resources.ErrorIcon.ToBitmap();//.ResourceManager.GetObject("ErrorIcon");
                    btnOK.Visible = true;
                    break;
                case MessageType.Critical:
                    lblIcon.Image = (Bitmap)Properties.Resources.ErrorIcon.ToBitmap();//.ResourceManager.GetObject("ErrorIcon");

                    btnExit.Visible = true;
                    btnOK.Visible = true;
                    break;
                default:
                    break;
            }

            _groupHeight = this.grbDetail.Height;
            this.ShowDetailMessage(false);

            // this.btnOK.Focus();
        }

        /// <summary>
        /// Handles the Click event of the btnCopy control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.txtDetailMessage.Text);
        }



        //public static DialogResult ShowInformation()
        //{

        //}

    }
}