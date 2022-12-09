using System.ComponentModel;
using System.Linq.Expressions;

namespace BiblioGest.Models
{
    internal class ModelBase<T> : INotifyPropertyChanged where T : ModelBase<T>
    {

        private int id;
        public int Id
        {
            get => id;
            set
            {
                if (this.id != value)
                {
                    this.id = value;
                    RaisePropertyChanged(() => this.id);
                }
            }
        }
        private bool deleted = false;
        public bool Deleted
        {
            get => deleted;
            set
            {
                if (this.deleted != value)
                {
                    this.deleted = value;
                    RaisePropertyChanged(() => this.deleted);
                }
            }
        }

        //DAL
        public static DAL.JsonDataAcces<T> jsonDataAcces = new DAL.JsonDataAcces<T>();


        #region  INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler? PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                jsonDataAcces.Persist((T)this);
            }
        }
        public void RaisePropertyChanged<T>(Expression<Func<T>> action)
        {
            string propertyName = GetPropertyName(action);
            RaisePropertyChanged(propertyName);
        }
        private static string GetPropertyName<T>(Expression<Func<T>> action)
        {
            MemberExpression expression = (MemberExpression)action.Body;
            return expression.Member.Name;
        }
        #endregion
    }

}
