using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SimpleCrm.Facade;

namespace SimpleCrm.Utils
{
    public static class FormHelper
    {
        public static void ShowMdiChildForm<T>()
           where T : Form, new()
        {
            T form = FindOpenedForm<T>();
            if (form == null)
            {
                form = new T();
                form.MdiParent = AppFacade.Facade.MainForm;
                form.StartPosition = FormStartPosition.CenterScreen;
                form.WindowState = FormWindowState.Maximized;
                form.Show();
            }
            else
            {
                form.Activate();
                if (form.WindowState == FormWindowState.Minimized)
                {
                    form.WindowState = FormWindowState.Normal;
                }
            }
        }

        public static void ShowMdiChildForm<T>(Func<T> creator, Predicate<T> predicate = null, Action<T> action = null)
   where T : Form
        {
            T form = FindOpenedForm(predicate);
            if (form == default(T))
            {
                form = creator();
                form.MdiParent = AppFacade.Facade.MainForm;
                form.StartPosition = FormStartPosition.CenterScreen;
                form.WindowState = FormWindowState.Maximized;
                form.Show();
                if (action != null)
                {
                    form.FormClosed += (sender, e) => action((T)sender);
                }
            }
            else
            {
                form.Activate();
                if (form.WindowState == FormWindowState.Minimized)
                {
                    form.WindowState = FormWindowState.Normal;
                }
            }
        }

        public static void ShowNonModalForm<T>(this Form owner, T form, Action<T> action = null)
           where T : Form
        {
            owner.AddOwnedForm(form);
            form.Show();
            if (action != null)
            {
                form.FormClosed += (sender, e) => action((T)sender);
            }
        }

        public static T FindNonModalForm<T>(this Form owner, Predicate<T> predicate) where T : Form
        {
            foreach (var form in owner.OwnedForms)
            {
                T tForm = form as T;
                if (tForm != null && predicate(tForm))
                {
                    return (T)form;
                }
            }
            return default(T);
        }

        public static void ShowNonModalForm<T>(this Form owner, Func<T> creator, Predicate<T> predicate, Action<T> action = null)
   where T : Form
        {
            T form = owner.FindNonModalForm(predicate);
            if (form == default(T))
            {
                form = creator();
                owner.AddOwnedForm(form);
                form.StartPosition = FormStartPosition.CenterScreen;
                form.Show();
                if (action != null)
                {
                    form.FormClosed += (sender, e) => action((T)sender);
                }
            }
            else
            {
                form.Activate();
                if (form.WindowState == FormWindowState.Minimized)
                {
                    form.WindowState = FormWindowState.Normal;
                }
            }
        }

        public static DialogResult ShowDialogForm<T>()
            where T : Form, new()
        {
            T form = new T();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MaximizeBox = false;
            form.MinimizeBox = false;
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            return form.ShowDialog();

        }

        public static T FindOpenedForm<T>(Predicate<T> predicate = null) where T : Form
        {
            foreach (Form form in AppFacade.Facade.MainForm.MdiChildren)
            {
                T tForm = form as T;

                if (tForm != null &&
                    (predicate == null || predicate(tForm)))
                {
                    return tForm;
                }
            }
            return default(T);
        }
    }
}
