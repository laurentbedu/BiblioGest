namespace BiblioGestSbyS.Models
{
    internal class Livre : ModelBase<Livre>
    {
        //[JsonProperty(PropertyName = "titre")]
        private string titre;
        public string Titre
        {
            get { return titre; }
            set
            {
                if (this.titre != value)
                {
                    this.titre = value;
                }
            }
        }

        private string isbn;
        public string Isbn
        {
            get { return isbn; }
            set
            {
                if (this.isbn != value)
                {
                    this.isbn = value;
                }
            }
        }





    }
}
