using BiblioDb.Entities;
using System.Diagnostics;

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
            //this.Controls.Add(new LivreControl(this));
        }

        BiblioDbContext context = new BiblioDbContext();
        private void button1_Click(object sender, EventArgs e)
        {
            Auteur auteur = new Auteur() { Nom = "Daudet", Prenom = "Alphonse" };
            context.Auteurs.Add(auteur);

            context.SaveChanges();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Auteur auteur1 = context.Auteurs.Single(a => a.IdAuteur == 1);
            Debug.WriteLine(auteur1.Nom);
            Livre livre = new Livre();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Auteur auteur1 = context.Auteurs.Single(a => a.IdAuteur == 1);
            Auteur auteurClone = new Auteur() { IdAuteur = auteur1.IdAuteur, Deleted = auteur1.Deleted };
            auteur1.Nom = "Signdeuchtrain";
            context.SaveChanges();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            context.Auteurs.Remove(context.Auteurs.Single(a => a.IdAuteur == 1));
            context.SaveChanges();
        }
    }
}