using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFtests
{
    public class StaticClass : INotifyPropertyChanged
    {
        #region Singleton Implementation
        static StaticClass _instance;
        public static StaticClass Instance
        {
            get
            {
                if (_instance == null) { _instance = new StaticClass(); }
                return _instance;
            }
        }
        #endregion

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

        int _clickCount;
        public int ClickCount
        {
            get => _clickCount;
            set
            {
                _clickCount = value;
                OnPropertyChanged(nameof(ClickCount));
            }
        }


        private StaticClass() { }
    }
}
