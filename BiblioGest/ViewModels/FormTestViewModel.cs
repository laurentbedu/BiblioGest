using BiblioGest.Models;
using System.ComponentModel;
using System.Linq.Expressions;

namespace BiblioGest.ViewModels
{
    internal class FormTestViewModel : INotifyPropertyChanged
    {
        public FormTestViewModel()
        {

            usures = new BindingList<Usure>(Usure.jsonDataAcces.GetAll());
            exemplaire = Exemplaire.jsonDataAcces.GetById(1);

        }

        private Exemplaire exemplaire;
        public Exemplaire Exemplaire
        {
            get { return exemplaire; }
            set
            {
                if (this.exemplaire != value)
                {
                    this.exemplaire = value;
                    RaisePropertyChanged(() => this.exemplaire);
                    //Debug.WriteLine("VM exemplaire changed");
                }
            }
        }


        private BindingList<Usure> usures;
        public BindingList<Usure> Usures
        {
            get { return usures; }

        }

        public void AddUsure(string etat)
        {
            usures.Add(new Usure() { Etat = etat });

        }



        #region  INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler? PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
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
