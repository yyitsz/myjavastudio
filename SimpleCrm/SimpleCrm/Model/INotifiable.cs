using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace SimpleCrm.Model
{
    public interface INotifiable : INotifyPropertyChanged
    {
        void NotifyPropertyChanged(string propertyName);
    }
}
