using BiblioGestSbyS.Models;

namespace BiblioGestSbyS
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //List<Exemplaire> exemplaires = Exemplaire.jsonDataAcces.GetAll();
            //List<Livre> livres = Livre.jsonDataAcces.GetAll();
            //Exemplaire exemplaire1 = Exemplaire.jsonDataAcces.GetById(1);
            //Livre livre = new Livre() { Isbn = "abcd", Titre = "Coucou" };
            //Livre.jsonDataAcces.Persist(livre);
            //Livre livre1 = new Livre() { Isbn = "1235-4589-8925", Titre = "Hello !" };

            Livre livre1 = Livre.jDA.GetById(1);
            Exemplaire exemplaire1 = Exemplaire.jDA.GetById(1);
            Auteur auteur1 = Auteur.jDA.GetById(1);
            var test2 = auteur1.LivreList;

            livre1.AddAuteur(auteur1);
            auteur1.RemoveLivre(livre1);

            exemplaire1.Livre = livre1;
            //Livre.jsonDataAcces.Persist(livre1);
            //Exemplaire.jsonDataAcces.Persist(exemplaire1);
            var test = livre1.ExemplairesList;
        }
    }
}