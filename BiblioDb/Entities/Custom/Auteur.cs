namespace BiblioDb.Entities
{
    public partial class Auteur
    {
        public Auteur(Auteur auteur)
        {
            IdAuteur = auteur.IdAuteur;
            Nom = auteur.Nom;
        }

        public void AddAuteur(Livre livre)
        {
            this.IdLivres.Add(livre);
        }

    }
}
