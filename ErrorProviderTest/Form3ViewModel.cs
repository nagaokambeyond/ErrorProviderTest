using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace ErrorProviderTest
{
    public class Form3ViewModel: IDataErrorInfo, IDisposable
    {
        //エラー情報を保持
        private Dictionary<string, string> _errors;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Form3ViewModel()
        {
            _errors = new Dictionary<string, string>();
            code = string.Empty;
            name = string.Empty;
            unitPrice = "0";
        }

        #region プロパティー
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
            }
        }
        #endregion

        public void ClearErrorAll()
        {
            _errors.Clear();
        }

        public bool HasError()
        {
            return _errors.Any();
        }

        public void ValidateAll()
        {
            ClearError("Code");
            if (string.IsNullOrEmpty(Code))
                SetError("Code", "Codeは空にはできません。");
        }

        private string GetError(string propertyName)
        {
            string error = null;
            _errors.TryGetValue(propertyName, out error);
            return error;
        }

        private string[] GetErrorPropertyNames()
        {
            return _errors.Keys.ToArray();
        }

        private void SetError(string propertyName, string error)
        {
            _errors[propertyName] = error;
        }

        #region IDataErrorInfo
        public string Error
        {
            get
            {
                var sb = new StringBuilder();
                foreach (var propertyName in GetErrorPropertyNames())
                {
                    sb.AppendLine(this[propertyName]);
                }
                return sb.ToString();
            }
        }

        public string this[string propertyName]
        {
            get { return GetError(propertyName); }
        }
        #endregion

        /// <summary>
        /// 指定したプロパティのエラー情報を消去する
        /// </summary>
        /// <param name="propertyName"></param>
        private void ClearError(string propertyName)
        {
            if (!_errors.ContainsKey(propertyName))
            {
                return;
            }
            _errors.Remove(propertyName);
        }


        public void Dispose()
        {
            _errors.Clear();
            _errors = null;
        }
    }
}
