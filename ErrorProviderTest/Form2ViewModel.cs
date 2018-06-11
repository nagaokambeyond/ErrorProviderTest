using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ErrorProviderTest
{
    public class Form2ViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        public Form2ViewModel()
        {
            code = string.Empty;
            name = string.Empty;
            unitPrice = "0";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        string code;
        string name;
        string unitPrice;

        public string Code
        {
            get
            {
                return code;
            }

            set
            {
                code = value;
                NotifyPropertyChanged();
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
                NotifyPropertyChanged();
            }
        }

        public string UnitPrice
        {
            get
            {
                return unitPrice;
            }

            set
            {
                unitPrice = value;
                NotifyPropertyChanged();
            }
        }

        public string Error
        {
            get
            {
                return string.Empty;
            }
        }

        public string this[string columnName]
        {
            get
            {
                if (columnName == "Code")
                {
                    if (string.IsNullOrEmpty(Code))
                    {
                        return "必須入力です。";
                    }
                    if (Code.Length > 5)
                    {
                        return "桁数オーバーです。";
                    }
                }
                else if (columnName == "UnitPrice")
                {
                    int xx;
                    if (int.TryParse(UnitPrice, out xx) == false)
                    {
                        return "数値項目です。";
                    }
                }
                return string.Empty;
            }
        }
    }
}
