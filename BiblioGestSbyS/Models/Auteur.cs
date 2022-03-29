using Newtonsoft.Json;

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

        [JsonIgnore]
        private List<int> idLivreList;
        public List<int> IdLivreList
        {
            get
            {
                if (this.idLivreList == null)
                {

                    List<dynamic> ids = jDA.LoadJsonData("auteur_livre").FindAll(item => item.id_auteur == this.Id);
                    idLivreList = new();
                    ids.ForEach(item =>
                    {
                        idLivreList.Add((int)item.id_livre);
                    });
                }
                return this.idLivreList;
            }
        }

        [JsonIgnore]
        private List<Livre> livreList;
        public List<Livre> LivreList
        {
            get
            {
                if (this.livreList == null)
                {
                    this.livreList = Livre.jDA.GetAll(item => this.IdLivreList.Contains(item.Id));
                }
                return this.livreList;
            }
        }

        public List<Livre> AddLivre(Livre livre)
        {
            if (this.LivreList.Find(item => item.Id == livre.Id) == null)
            {
                this.IdLivreList.Add(livre.Id);
                this.LivreList.Add(livre);
                livre.AddAuteur(this);
                //TODO persist 
            }
            return this.LivreList;
        }

        public List<Livre> RemoveLivre(Livre livre)
        {
            int index = this.LivreList.FindIndex(item => item.Id == livre.Id);
            if (index >= 0)
            {
                this.IdLivreList.Remove(livre.Id);
                this.LivreList.RemoveAt(index);
                livre.RemoveAuteur(this);
                //TODO persist
            }
            return this.LivreList;
        }
    }
}
