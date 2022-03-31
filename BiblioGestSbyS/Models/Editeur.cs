using Newtonsoft.Json;

namespace BiblioGestSbyS.Models
{
    internal class Editeur : ModelBase<Editeur>
    {
        [JsonProperty(PropertyName = "nom")]
        private string nom;
        [JsonIgnore]
        public string Nom
        {
            get { return nom; }
            set
            {
                if (this.nom != value)
                {
                    this.nom = value;
                    RaisePropertyChanged();
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
                    this.exemplairesList = Exemplaire.jDA.GetAll(item => item.IdEditeur == this.Id);
                }
                return this.exemplairesList;
            }
        }
        public List<Exemplaire> AddExemplaire(Exemplaire exemplaire)
        {
            if (this.ExemplairesList.Find(item => item.Id == exemplaire.Id) == null)
            {
                this.ExemplairesList.Add(exemplaire);
                if (exemplaire.Editeur.Id != this.Id)
                {
                    exemplaire.Editeur = this;
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
                if (exemplaire.Editeur.Id == this.Id)
                {
                    exemplaire.Editeur = null;
                }
            }
            return this.ExemplairesList;
        }
    }
}
