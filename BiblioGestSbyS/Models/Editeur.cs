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
                    RaisePropertyChanged(() => Nom);
                }
            }
        }
    }
}
