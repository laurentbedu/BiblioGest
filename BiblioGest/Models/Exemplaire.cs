using Newtonsoft.Json;

namespace BiblioGest.Models
{
    internal class Exemplaire : ModelBase<Exemplaire>
    {
        [JsonProperty(PropertyName = "date_achat")]
        private string dateAchat;
        public DateTime DateAchat
        {
            get => DateTime.Parse(dateAchat);
            set
            {
                if (this.dateAchat != value.ToString("yyyy-MM-dd"))
                {
                    this.dateAchat = value.ToString("yyyy-MM-dd");
                    RaisePropertyChanged(() => this.dateAchat);
                }
            }
        }

        private string emplacement;
        public string Emplacement
        {
            get { return emplacement; }
            set
            {
                if (this.emplacement != value)
                {
                    this.emplacement = value;
                    RaisePropertyChanged(() => this.emplacement);
                    //Debug.WriteLine("M exemplaire emplacement changed");
                }
            }
        }

        [JsonProperty(PropertyName = "id_livre")]
        private int idLivre;
        public int IdLivre
        {
            get { return idLivre; }
            set
            {
                if (this.idLivre != value)
                {
                    this.idLivre = value;
                    RaisePropertyChanged(() => this.idLivre);
                }
            }
        }


        [JsonProperty(PropertyName = "id_usure")]
        private int idUsure;

        public int IdUsure
        {
            get { return idUsure; }
            set
            {
                if (this.idUsure != value)
                {
                    this.idUsure = value;
                    RaisePropertyChanged(() => this.idUsure);
                }
            }
        }



    }

}
