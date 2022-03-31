using BiblioGestSbyS.Views;

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
            this.Controls.Add(new LivreControl(this));
        }






    }
}