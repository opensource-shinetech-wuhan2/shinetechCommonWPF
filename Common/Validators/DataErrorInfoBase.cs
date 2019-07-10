using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace Common.Validators
{
    public class DataErrorInfoBase :ObservableObject,INotifyDataErrorInfo
    {
        public Dictionary<string,List<string>> _listOfErrors = new Dictionary<string,List<string>>();

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public bool HasErrors => _listOfErrors.Any();
        protected void AddError (string propertyName,string errorMessage)
        {
            if(!_listOfErrors.ContainsKey(propertyName))
            {
                _listOfErrors[propertyName] = new List<string>();
            }

            _listOfErrors[propertyName].Add(errorMessage);
        }

        protected void SetValue (string propertyName)
        {
            RaisePropertyChanged(propertyName);
            ValidateProperty(propertyName);
        }

        protected string ValidateProperty (string columnName)
        {
            ClearErrors(columnName);

            var context = new ValidationContext(this);
            context.MemberName = columnName;
            var res = new List<ValidationResult>();
            var succeed = Validator.TryValidateProperty(this.GetType().GetProperty(columnName).GetValue(this),context,res);
            if(!succeed)
            {
                foreach(var item in res)
                {
                    AddError(columnName,item.ErrorMessage);
                }
                return string.Join(Environment.NewLine,res.Select(r => r.ErrorMessage).ToArray());
            }
            return string.Empty;
        }

        protected bool ValidateAllProperties ()
        {
            var result = string.Empty;
            var lstOfProperties = this.GetType().GetProperties()
                .Select(u => new KeyValuePair<string,Type>(u.Name,u.PropertyType)).ToList();
            foreach(var property in lstOfProperties)
            {
                //if(property.Value == typeof(string) || property.Value == typeof(int))
                ValidateProperty(property.Key);
            }

            if(HasErrors)
            {
                foreach(var property in lstOfProperties)
                {
                    RaisePropertyChanged(property.Key);
                }                
            }

            return !HasErrors;
        }

        public bool IsValid ()
        {
            return ValidateAllProperties();
        }

        protected void ClearErrors (string propertyName)
        {
            if(_listOfErrors.ContainsKey(propertyName))
                _listOfErrors.Remove(propertyName);
        }

        public IEnumerable GetErrors (string propertyName)
        {
            return _listOfErrors.ContainsKey(propertyName) ? _listOfErrors[propertyName] : null;
        }
    }
}
