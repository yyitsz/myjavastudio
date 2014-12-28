using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using SimpleCrm.Model;
using DevComponents.DotNetBar;

namespace SimpleCrm.Config
{
    [Serializable]
    public class AppConfig : INotifyPropertyChanged
    {
        private int pageSize = 10;

        [PropertyIntegerEditor(MinValue = 0, MaxValue = 200)
        , Description("分页每页记录数。")
        , DisplayName("每页记录数")
        , DefaultValue(10)
        , Category("分页")]
        public int PageSize
        {
            get { return pageSize; }
            set
            {
                if (value != pageSize)
                {
                    pageSize = value;
                    this.OnPropertyChanged("pageSize");
                }
            }
        }

        #region INotifyPropertyChanged Members
        /// <summary>
        /// Occurs when property value has changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Raises the PropertyChanged event.
        /// </summary>
        /// <param name="e">Event arguments</param>
        protected virtual void OnPropertyChanged(String propertyName)
        {
            PropertyChangedEventArgs e = new PropertyChangedEventArgs(propertyName);
            PropertyChangedEventHandler eh = PropertyChanged;
            if (eh != null) { eh(this, e); }
        }
        #endregion
    }
}
