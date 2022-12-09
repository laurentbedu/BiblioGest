using BiblioGest.Models;
using BiblioGest.ViewModels;

namespace BiblioGest
{
    public partial class FormTest : Form
    {
        public FormTest()
        {
            InitializeComponent();
            vm = new FormTestViewModel();
            comboBox1.DataSource = vm.Usures;
            comboBox1.DisplayMember = "Etat";
            label1.DataBindings.Add("Text", vm, "Exemplaire.Emplacement");
            textBox1.DataBindings.Add("Text", vm, "Exemplaire.Emplacement");
            //label1.DataBindings.Add("Text", vm.Exemplaire, "Emplacement");
        }



        FormTestViewModel vm;

        private void button1_Click(object sender, EventArgs e)
        {
            vm.AddUsure("test");
            vm.Usures.RemoveAt(0);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            vm.Exemplaire = Exemplaire.jsonDataAcces.GetById((int)numericUpDown1.Value);
            //label1.DataBindings.Clear();
            //label1.DataBindings.Add("Text", vm, "Exemplaire.Emplacement");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            vm.Exemplaire.Emplacement = textBox1.Text;
        }

        private void FormTest_Load(object sender, EventArgs e)
        {

        }
    }
}