using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace BiblioGestSbyS.ViewModels
{
    internal class ViewModelBase : INotifyPropertyChanged
    {


        #region INotifyPropertyChanged Implementation

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void RaisePropertyChanged<M>(Expression<Func<M>> action)
        {
            MemberExpression expression = (MemberExpression)action.Body;
            string propertyName = expression.Member.Name;
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected void RaisePropertyChanged([CallerMemberName] string name = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        #endregion
    }
}
