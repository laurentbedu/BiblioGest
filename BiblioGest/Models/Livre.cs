namespace BiblioGest.Models
{
    internal class Livre : ModelBase<Livre>
    {
        private string titre;
        public string Titre
        {
            get { return titre; }
            set
            {
                if (this.titre != value)
                {
                    this.titre = value;
                    RaisePropertyChanged(() => this.titre);
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
                    RaisePropertyChanged(() => this.isbn);
                }
            }
        }





    }
}
