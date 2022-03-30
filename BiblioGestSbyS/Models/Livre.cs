using Newtonsoft.Json;

namespace BiblioGestSbyS.Models
{
    internal class Livre : ModelBase<Livre>
    {
        [JsonProperty(PropertyName = "titre")]
        private string titre;
        [JsonIgnore]
        public string Titre
        {
            get { return titre; }
            set
            {
                if (this.titre != value)
                {
                    this.titre = value;
                    RaisePropertyChanged(() => Titre);
                }
            }
        }

        [JsonProperty(PropertyName = "isbn")]
        private string isbn;
        [JsonIgnore]
        public string Isbn
        {
            get { return isbn; }
            set
            {
                if (this.isbn != value)
                {
                    this.isbn = value;
                    RaisePropertyChanged(() => Isbn);
                }
            }
        }

        [JsonIgnore]
        private List<Exemplaire> exemplairesList;

        [JsonIgnore]
        public List<Exemplaire> ExemplairesList
        {
            get
            {
                if (this.exemplairesList == null)
                {
                    this.exemplairesList = Exemplaire.jDA.GetAll(item => item.IdLivre == this.Id);
                }
                return this.exemplairesList;
            }
        }
        public List<Exemplaire> AddExemplaire(Exemplaire exemplaire)
        {
            if (this.ExemplairesList.Find(item => item.Id == exemplaire.Id) == null)
            {
                this.ExemplairesList.Add(exemplaire);
                if (exemplaire.Livre.Id != this.Id)
                {
                    exemplaire.Livre = this;
                }
            }
            return this.ExemplairesList;
        }

        public List<Exemplaire> RemoveExemplaire(Exemplaire exemplaire)
        {
            int index = this.ExemplairesList.FindIndex(item => item.Id == exemplaire.Id);
            if (index >= 0)
            {
                this.ExemplairesList.RemoveAt(index);
                if (exemplaire.Livre.Id == this.Id)
                {
                    exemplaire.Livre = null;
                }
            }
            return this.ExemplairesList;
        }


        [JsonIgnore]
        private List<int> idAuteurList;

        [JsonIgnore]
        public List<int> IdAuteurList
        {
            get
            {
                if (this.idAuteurList == null)
                {

                    List<dynamic> ids = jDA.LoadJsonData("auteur_livre").FindAll(item => item.id_livre == this.Id);
                    idAuteurList = new();
                    ids.ForEach(item =>
                    {
                        idAuteurList.Add((int)item.id_auteur);
                    });
                }
                return this.idAuteurList;
            }
        }

        [JsonIgnore]
        private List<Auteur> auteurList;

        [JsonIgnore]
        public List<Auteur> AuteurList
        {
            get
            {
                if (this.auteurList == null)
                {
                    this.auteurList = Auteur.jDA.GetAll(item => this.IdAuteurList.Contains(item.Id));
                }
                return this.auteurList;
            }
        }

        public List<Auteur> AddAuteur(Auteur auteur)
        {
            if (this.AuteurList.Find(item => item.Id == auteur.Id) == null)
            {
                this.IdAuteurList.Add(auteur.Id);
                this.AuteurList.Add(auteur);
                auteur.AddLivre(this);
                //TODO persist
            }
            return this.AuteurList;
        }

        public List<Auteur> RemoveAuteur(Auteur auteur)
        {
            int index = this.AuteurList.FindIndex(item => item.Id == auteur.Id);
            if (index >= 0)
            {
                this.IdAuteurList.Remove(auteur.Id);
                this.AuteurList.RemoveAt(index);
                auteur.RemoveLivre(this);
                //TODO persist
            }
            return this.AuteurList;
        }


    }
}
