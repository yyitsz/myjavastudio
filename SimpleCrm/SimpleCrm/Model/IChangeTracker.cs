using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCrm.Model
{
    public interface IChangeTracker
    {
        bool IsNew();
        bool IsUpdated(); 
        bool IsDeleted();
        bool IsChanged();
        void MarkAsPersisted();
        //void MarkAsAdded();
        void MarkAsUpdated();
        void MarkAsDeleted();
    }
}
