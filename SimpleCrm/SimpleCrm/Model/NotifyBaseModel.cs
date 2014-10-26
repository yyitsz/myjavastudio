using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Linq;
using SimpleCrm.Utils;
using System.Linq.Expressions;

namespace SimpleCrm.Model
{
    public abstract class NotifyBaseModel : BaseModel, INotifiable, IChangeTracker
    {
        private bool isUpdated = false;
        private bool isDeleted = false;
        public NotifyBaseModel()
        {
            this.PropertyChanged += new PropertyChangedEventHandler(NotifyBaseModel_PropertyChanged);
        }

        void NotifyBaseModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (IsNew() == false && isDeleted == false)
            {
                isUpdated = true;
            }
        }


        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }



        #endregion

        #region IChangeTracker Members

        public bool IsUpdated()
        {
            return isUpdated;
        }

        public bool IsDeleted()
        {
            return isDeleted;
        }

        public bool IsChanged()
        {
            return IsNew() || isUpdated || isDeleted;
        }

        public virtual void MarkAsPersisted()
        {
            if (base.IsNew())
            {
                return;
            }
            this.isUpdated = false;
            this.isDeleted = false;
        }

        public virtual void MarkAsUpdated()
        {
            if (base.IsNew())
            {
                return;
            }
            this.isUpdated = true;
            this.isDeleted = false;
        }

        public virtual void MarkAsDeleted()
        {
            this.isUpdated = false;
            this.isDeleted = true;
        }
        #endregion
    }
}
