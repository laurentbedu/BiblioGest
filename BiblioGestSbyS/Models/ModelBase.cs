using Newtonsoft.Json;
using System.ComponentModel;
using System.Linq.Expressions;

namespace BiblioGestSbyS.Models
{
    internal class ModelBase<T> : INotifyPropertyChanged where T : ModelBase<T>
    {

        [JsonProperty(PropertyName = "id")]
        protected int id;
        [JsonIgnore]
        public int Id
        {
            get => id;
            set
            {
                if (this.id != value)
                {
                    this.id = value;
                }
            }
        }
        [JsonProperty(PropertyName = "deleted")]
        protected bool deleted = false;
        [JsonIgnore]
        public bool Deleted
        {
            get => deleted;
            set
            {
                if (this.deleted != value)
                {
                    this.deleted = value;
                    RaisePropertyChanged(() => Deleted);
                }
            }
        }

        //DAL
        public static readonly DAL.JsonDataAcces<T> jDA = new DAL.JsonDataAcces<T>();

        #region INotifyPropertyChanged Implementation

        public event PropertyChangedEventHandler? PropertyChanged;
        public void RaisePropertyChanged<M>(Expression<Func<M>> action) //where M : ModelBase<M>
        {
            MemberExpression expression = (MemberExpression)action.Body;
            string propertyName = expression.Member.Name;
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
            jDA.Persist((T)this);
        }

        #endregion
    }

}
