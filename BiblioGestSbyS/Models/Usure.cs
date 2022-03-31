using Newtonsoft.Json;

namespace BiblioGestSbyS.Models
{
    internal class Usure : ModelBase<Usure>
    {
        [JsonProperty(PropertyName = "etat")]
        private string etat;
        [JsonIgnore]
        public string Etat
        {
            get { return etat; }
            set
            {
                if (this.etat != value)
                {
                    this.etat = value;
                    RaisePropertyChanged();
                }
            }
        }
    }
}
