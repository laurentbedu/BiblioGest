using BiblioGestSbyS.Models;

namespace BiblioGestSbyS
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        Livre? livre;

        private void FormMain_Load(object sender, EventArgs e)
        {

            livre = Livre.jDA.GetById(1);
            label1.DataBindings.Add("Text", livre, "Titre");
            textBox1.DataBindings.Add("Text", livre, "Titre");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            livre.Titre = textBox1.Text;
        }


    }
}