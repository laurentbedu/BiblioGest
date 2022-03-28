namespace BiblioGestSbyS.Models
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
                }
            }
        }
    }
}
