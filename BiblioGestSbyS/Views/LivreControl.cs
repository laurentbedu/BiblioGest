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
            textBoxSearch.Width = dataGridViewLivres.Width - 30;
            buttonSearch.Left = textBoxSearch.Width + 5;
        }

        private void LivreControl_Load(object sender, EventArgs e)
        {
            Task.Run(() => DisplayData());
        }

        private void DisplayData()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl.InvokeRequired)
                {
                    ctrl.Invoke(new MethodInvoker(delegate { DisplayData(); }));
                    return;
                }
            }

            dataGridViewLivres.DataSourceChanged += DataGridViewLivres_DataSourceChanged;
            dataGridViewLivres.DataBindings.Add("DataSource", viewModel, "LivreList");

            labelTitre.DataBindings.Add("Text", viewModel, "SelectedLivre.Titre");

            dataGridViewExemplaires.DataSourceChanged += DataGridViewExemplaires_DataSourceChanged;
            dataGridViewExemplaires.DataBindings.Add("DataSource", viewModel, "SelectedLivreExemplairesList");

        }

        private void DataGridViewLivres_DataSourceChanged(object? sender, EventArgs e)
        {
            if (dataGridViewLivres.Columns.Contains("Id"))
            {
                dataGridViewLivres.Columns["Id"].Visible = false;
            }
            if (dataGridViewLivres.Columns.Contains("Auteurs"))
            {
                dataGridViewLivres.Columns["Auteurs"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void DataGridViewExemplaires_DataSourceChanged(object? sender, EventArgs e)
        {
            //Correction "bug" colonne Id visible
            //aprés changement de SelectedLivre n'ayant pas d'exemplaire
            if (dataGridViewExemplaires.Columns.Contains("Id"))
            {
                dataGridViewExemplaires.Columns["Id"].Visible = false;
            }
        }

        private void dataGridViewLivres_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewLivres.SelectedRows.Count > 0)
            {
                int id = (int)dataGridViewLivres.SelectedRows[0].Cells[0].Value;
                viewModel.SelectedLivre = Livre.jDA.GetById(id);
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            FilterDataGridViewLivres();
        }

        private void textBoxSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                FilterDataGridViewLivres();
            }
        }

        private void FilterDataGridViewLivres()
        {
            List<string> seartchWords = textBoxSearch.Text.Split(' ').ToList();
            foreach (DataGridViewRow row in dataGridViewLivres.Rows)
            {
                row.Visible =
                    seartchWords.Any(word => row.Cells["Auteurs"].Value.ToString().ToUpperInvariant().Contains(word.ToUpperInvariant()) ||
                                          row.Cells["Titre"].Value.ToString().ToUpperInvariant().Contains(word.ToUpperInvariant()));
            }
            int firstVisibleRowIndex = dataGridViewLivres.Rows.GetFirstRow(DataGridViewElementStates.Visible);
            if (firstVisibleRowIndex > -1)
            {
                dataGridViewLivres.Rows[firstVisibleRowIndex].Selected = true;
            }
        }
    }
}
