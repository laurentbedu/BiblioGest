namespace BiblioGestSbyS.Models
{
    internal class Auteur : ModelBase<Auteur>
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

        private string prenom;
        public string Prenom
        {
            get { return prenom; }
            set
            {
                if (this.prenom != value)
                {
                    this.prenom = value;
                }
            }
        }
    }
}
