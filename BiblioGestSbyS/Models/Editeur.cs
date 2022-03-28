namespace BiblioGestSbyS.Models
{
    internal class Editeur : ModelBase<Editeur>
    {
        private string nom;
        public string Nom
        {
            get { return nom; }
            set
            {
                if (this.nom != value)
                {
                    this.nom = value;
                }
            }
        }
    }
}
