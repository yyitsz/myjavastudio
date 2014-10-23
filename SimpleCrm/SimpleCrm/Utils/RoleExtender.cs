using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Resources;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Reflection;
using SimpleCrm.Model;

namespace SimpleCrm.Utils
{
    /// <summary>
    /// The data of object map to the control,or else.
    /// </summary>
    [ProvideProperty("RoleList", typeof(Object))]
    public partial class RoleExtender : Component, IExtenderProvider, ISupportInitialize
    {
        private IDictionary<Object, String[]> m_InnerControlDictionary;

        public static UserProfile UserProfile { get; set; }

        /// <summary>
        /// Gets or sets the inner control dictionary.
        /// </summary>
        /// <value>The inner control dictionary.</value>
        [Browsable(false)]
        public IDictionary<Object, String[]> InnerControlDictionary
        {
            get { return this.m_InnerControlDictionary; }
            private set { this.m_InnerControlDictionary = value; }
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="DataBinding"/> class.
        /// </summary>
        public RoleExtender()
        {
            this.m_InnerControlDictionary = new Dictionary<Object, String[]>();
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="DataBinding"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public RoleExtender(IContainer container)
            : this()
        {
            container.Add(this);
        }


        #region ISupportInitialize Members

        /// <summary>
        /// Signals the object that initialization is starting.
        /// </summary>
        public void BeginInit()
        {
        }

        /// <summary>
        /// Signals the object that initialization is complete.
        /// </summary>
        public void EndInit()
        {
            RefreshAcl();
        }

        #endregion

        public void RefreshAcl()
        {
            if (UserProfile == null)
            {
                return;
            }
            foreach (Object item in InnerControlDictionary.Keys)
            {
                if (item is ToolStripMenuItem)
                {
                    ToolStripMenuItem menu = item as ToolStripMenuItem;
                    String[] roleList = InnerControlDictionary[item];
                    bool hasPermission = UserProfile.IsInRole(roleList);
                    if (hasPermission == false)
                    {
                        menu.Enabled = false;
                        menu.Visible = false;

                        if (menu.OwnerItem != null)
                        {
                            ToolStripMenuItem parent = menu.OwnerItem as ToolStripMenuItem;
                            if (parent != null)
                            {
                                bool hasVisiabled = false;
                                foreach (ToolStripItem childMenu in parent.DropDownItems)
                                {
                                    if (childMenu.Enabled)
                                    {
                                        hasVisiabled = true;
                                    }
                                }
                                if (hasVisiabled == false)
                                {
                                    parent.Enabled = false;
                                    parent.Visible = false;
                                }
                            }
                        }
                    }
                }
            }
        }

        #region IExtenderProvider Members

        /// <summary>
        /// Gets the name of the property.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        [DefaultValue("")]
        [Category("Role")]
        public string GetRoleList(object item)
        {
            if (m_InnerControlDictionary.ContainsKey(item))
            {
                String[] roleList = m_InnerControlDictionary[item];
                return String.Join(",", roleList);
            }

            return string.Empty;
        }

        /// <summary>
        /// Sets the name of the property.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="value">The value.</param>
        public void SetRoleList(object item, string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                if (m_InnerControlDictionary.ContainsKey(item))
                {
                    m_InnerControlDictionary.Remove(item);
                }
                return;
            }

            if (m_InnerControlDictionary.ContainsKey(item) == false)
            {
                String[] roles = value.Split(new String[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                m_InnerControlDictionary[item] = roles;
            }

        }
        /// <summary>
        /// Specifies whether this object can provide its extender properties to the specified object.
        /// </summary>
        /// <param name="extendee">The <see cref="T:System.Object"></see> to receive the extender properties.</param>
        /// <returns>
        /// true if this object can provide extender properties to the specified object; otherwise, false.
        /// </returns>
        public bool CanExtend(object extendee)
        {
            //todo Some control shall be exluded,eg ,button.
            if (extendee is TextBox || extendee is Label || extendee is ComboBox || extendee is CheckBox ||
                extendee is Form || extendee is ToolStripMenuItem)
            {
                return true;
            }
            return false;
        }

        #endregion

    }



}
