using Cursova123.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace Cursova123.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        
        public event PropertyChangedEventHandler PropertyChanged;
       
        
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        


    }
}