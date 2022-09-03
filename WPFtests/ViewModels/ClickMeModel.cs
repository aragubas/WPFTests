using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFtests.ViewModels
{
    public class ClickMeModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler? PropertyChanged;
        void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        // Working, instance based code
        //int _clickCount = 0;
        //public int ClickCount
        //{
        //    get => _clickCount;
        //    set
        //    {
        //        _clickCount = value;
        //        OnPropertyChanged("ClickCount");
        //    }
        //}

        // StaticClass implementation
        int _clickCountCache; 
        public int ClickCount
        {
            get => StaticClass.Instance.ClickCount;
            set
            {
                StaticClass.Instance.ClickCount = value;
                OnPropertyChanged("ClickCount");
            }
        }

        public ClickMeModel()
        {
            StaticClass.Instance.PropertyChanged += Instance_PropertyChanged;
        }

        private void Instance_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "ClickCount")
            {
                if (_clickCountCache != StaticClass.Instance.ClickCount)
                {
                    _clickCountCache = StaticClass.Instance.ClickCount;
                    ClickCount = StaticClass.Instance.ClickCount;
                }
            }
        }
    }
}
