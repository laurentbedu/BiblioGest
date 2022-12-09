namespace BiblioGest.Models
{
    internal class Usure : ModelBase<Usure>
    {
        private string etat;
        public string Etat
        {
            get { return etat; }
            set
            {
                if (this.etat != value)
                {
                    this.etat = value;
                    RaisePropertyChanged(() => this.etat);
                }
            }
        }

        //public override string ToString()
        //{
        //    return etat;
        //}
    }
}
