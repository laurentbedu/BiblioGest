namespace BiblioGestSbyS.Views
{
    partial class LivreControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.dataGridViewLivres = new System.Windows.Forms.DataGridView();
            this.dataGridViewExemplaires = new System.Windows.Forms.DataGridView();
            this.labelTitre = new System.Windows.Forms.Label();
            this.buttonSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLivres)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExemplaires)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(3, 4);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(264, 27);
            this.textBoxSearch.TabIndex = 4;
            this.textBoxSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSearch_KeyPress);
            // 
            // dataGridViewLivres
            // 
            this.dataGridViewLivres.AllowUserToAddRows = false;
            this.dataGridViewLivres.AllowUserToDeleteRows = false;
            this.dataGridViewLivres.AllowUserToResizeRows = false;
            this.dataGridViewLivres.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridViewLivres.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridViewLivres.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLivres.Location = new System.Drawing.Point(3, 37);
            this.dataGridViewLivres.MultiSelect = false;
            this.dataGridViewLivres.Name = "dataGridViewLivres";
            this.dataGridViewLivres.ReadOnly = true;
            this.dataGridViewLivres.RowHeadersVisible = false;
            this.dataGridViewLivres.RowHeadersWidth = 51;
            this.dataGridViewLivres.RowTemplate.Height = 29;
            this.dataGridViewLivres.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewLivres.ShowEditingIcon = false;
            this.dataGridViewLivres.Size = new System.Drawing.Size(300, 443);
            this.dataGridViewLivres.TabIndex = 7;
            this.dataGridViewLivres.SelectionChanged += new System.EventHandler(this.dataGridViewLivres_SelectionChanged);
            // 
            // dataGridViewExemplaires
            // 
            this.dataGridViewExemplaires.AllowUserToAddRows = false;
            this.dataGridViewExemplaires.AllowUserToDeleteRows = false;
            this.dataGridViewExemplaires.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewExemplaires.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridViewExemplaires.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewExemplaires.Location = new System.Drawing.Point(438, 37);
            this.dataGridViewExemplaires.MultiSelect = false;
            this.dataGridViewExemplaires.Name = "dataGridViewExemplaires";
            this.dataGridViewExemplaires.ReadOnly = true;
            this.dataGridViewExemplaires.RowHeadersVisible = false;
            this.dataGridViewExemplaires.RowHeadersWidth = 51;
            this.dataGridViewExemplaires.RowTemplate.Height = 29;
            this.dataGridViewExemplaires.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewExemplaires.Size = new System.Drawing.Size(300, 443);
            this.dataGridViewExemplaires.TabIndex = 8;
            // 
            // labelTitre
            // 
            this.labelTitre.AutoSize = true;
            this.labelTitre.Location = new System.Drawing.Point(438, 7);
            this.labelTitre.Name = "labelTitre";
            this.labelTitre.Size = new System.Drawing.Size(50, 20);
            this.labelTitre.TabIndex = 9;
            this.labelTitre.Text = "label1";
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonSearch.BackgroundImage = global::BiblioGestSbyS.Properties.Resources.loupe;
            this.buttonSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSearch.FlatAppearance.BorderSize = 0;
            this.buttonSearch.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonSearch.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearch.Location = new System.Drawing.Point(273, 3);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(28, 28);
            this.buttonSearch.TabIndex = 10;
            this.buttonSearch.UseVisualStyleBackColor = false;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // LivreControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.labelTitre);
            this.Controls.Add(this.dataGridViewExemplaires);
            this.Controls.Add(this.dataGridViewLivres);
            this.Controls.Add(this.textBoxSearch);
            this.Name = "LivreControl";
            this.Size = new System.Drawing.Size(761, 546);
            this.Load += new System.EventHandler(this.LivreControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLivres)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExemplaires)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TextBox textBoxSearch;
        private DataGridView dataGridViewLivres;
        private DataGridView dataGridViewExemplaires;
        private Label labelTitre;
        private Button buttonSearch;
    }
}
