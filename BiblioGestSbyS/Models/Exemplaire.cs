using Newtonsoft.Json;

namespace BiblioGestSbyS.Models
{
    internal class Exemplaire : ModelBase<Exemplaire>
    {
        [JsonProperty(PropertyName = "date_achat")]
        private string dateAchat;
        [JsonIgnore]
        public DateTime DateAchat
        {
            get => DateTime.Parse(dateAchat);
            set
            {
                if (this.dateAchat != value.ToString("yyyy-MM-dd"))
                {
                    this.dateAchat = value.ToString("yyyy-MM-dd");
                    RaisePropertyChanged();
                }
            }
        }

        [JsonProperty(PropertyName = "emplacement")]
        private string emplacement;
        [JsonIgnore]
        public string Emplacement
        {
            get { return emplacement; }
            set
            {
                if (this.emplacement != value)
                {
                    this.emplacement = value;
                    RaisePropertyChanged();
                }
            }
        }

        [JsonProperty(PropertyName = "id_livre")]
        private int? idLivre;
        [JsonIgnore]
        public int? IdLivre
        {
            get { return idLivre; }
            set
            {
                if (this.idLivre != value)
                {
                    this.idLivre = value;
                    //TODO persist ?
                }
            }
        }

        [JsonIgnore]
        private Livre livre;
        [JsonIgnore]
        public Livre Livre
        {
            get
            {
                if (this.livre == null)
                {
                    livre = Livre.jDA.GetById(this.idLivre);
                }
                return livre;
            }
            set
            {
                if (this.idLivre != value?.Id)
                {
                    Livre?.RemoveExemplaire(this);
                    this.idLivre = value?.Id;
                    this.livre = null; //needed to reset Livre get
                    Livre?.AddExemplaire(this);
                }
            }
        }

        [JsonProperty(PropertyName = "id_usure")]
        private int idUsure;
        [JsonIgnore]
        public int IdUsure
        {
            get { return idUsure; }
            set
            {
                if (this.idUsure != value)
                {
                    this.idUsure = value;
                }
            }
        }

        [JsonProperty(PropertyName = "id_editeur")]
        private int? idEditeur;
        [JsonIgnore]
        public int? IdEditeur
        {
            get { return idEditeur; }
            set
            {
                if (this.idEditeur != value)
                {
                    this.idEditeur = value;
                }
            }
        }

        [JsonIgnore]
        private Editeur editeur;
        [JsonIgnore]
        public Editeur Editeur
        {
            get
            {
                if (this.editeur == null)
                {
                    editeur = Editeur.jDA.GetById(this.idEditeur);
                }
                return editeur;
            }
            set
            {
                if (this.idEditeur != value?.Id)
                {
                    Editeur?.RemoveExemplaire(this);
                    this.idEditeur = value?.Id;
                    this.editeur = null; //needed to reset Editeur get
                    Editeur?.AddExemplaire(this);
                }
            }
        }

    }

}
