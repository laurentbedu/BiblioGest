using BiblioGestSbyS.Models;
using BiblioGestSbyS.ViewModels;

namespace BiblioGestSbyS.Views
{
    public partial class LivreControl : UserControl
    {

        private LivreControlViewModel viewModel;
        public LivreControl()
        {
            InitializeComponent();
            this.viewModel = new LivreControlViewModel();
        }

        public LivreControl(Control parent) : this()
        {
            SizeComponents(parent);
        }

        private void SizeComponents(Control parent)
        {
            Width = parent.Width;
            Height = parent.Height;
            dataGridViewLivres.Width = Width / 2 - 20;
            dataGridViewExemplaires.Width = Width / 2 - 20;
            labelTitre.Left = dataGridViewLivres.Width + 20;
        }

        private void LivreControl_Load(object sender, EventArgs e)
        {
            Task.Run(() => LoadData());
        }

        private void LoadData()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl.InvokeRequired)
                {
                    ctrl.Invoke(new MethodInvoker(delegate { LoadData(); }));
                    return;
                }
            }

            dataGridViewLivres.DataBindings.Add("DataSource", viewModel, "LivreList");
            dataGridViewLivres.Columns["Id"].Visible = false;
            dataGridViewLivres.Columns["Auteurs"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            labelTitre.DataBindings.Add("Text", viewModel, "SelectedLivre.Titre");
            dataGridViewExemplaires.DataBindings.Add("DataSource", viewModel, "SelectedLivreExemplairesList");
            dataGridViewExemplaires.Columns["Id"].Visible = false;

        }

        private void dataGridViewLivres_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewLivres.SelectedRows.Count > 0)
            {
                int id = (int)dataGridViewLivres.SelectedRows[0].Cells[0].Value;
                viewModel.SelectedLivre = Livre.jDA.GetById(id);
            }
        }
    }
}
