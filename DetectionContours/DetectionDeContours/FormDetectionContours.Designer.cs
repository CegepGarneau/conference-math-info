namespace TP_3_Test
{
    partial class FormDetectionContours
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

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.pboImageSource = new System.Windows.Forms.PictureBox();
            this.pboImageTransfo = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fichierToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.chargerImageToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.réinitialiserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flouToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.améliorationDeLaNettetéToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.repoussageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detectionContours1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detectionContours2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeriveeHorizontaleEnXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeriveeVerticaleEnYToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gradientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pboImageSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboImageTransfo)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pboImageSource
            // 
            this.pboImageSource.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pboImageSource.Location = new System.Drawing.Point(3, 44);
            this.pboImageSource.Name = "pboImageSource";
            this.pboImageSource.Size = new System.Drawing.Size(512, 512);
            this.pboImageSource.TabIndex = 1;
            this.pboImageSource.TabStop = false;
            // 
            // pboImageTransfo
            // 
            this.pboImageTransfo.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pboImageTransfo.Location = new System.Drawing.Point(521, 44);
            this.pboImageTransfo.Name = "pboImageTransfo";
            this.pboImageTransfo.Size = new System.Drawing.Size(512, 512);
            this.pboImageTransfo.TabIndex = 2;
            this.pboImageTransfo.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fichierToolStripMenuItem1,
            this.fichierToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1036, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fichierToolStripMenuItem1
            // 
            this.fichierToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chargerImageToolStripMenuItem1,
            this.réinitialiserToolStripMenuItem,
            this.quitterToolStripMenuItem});
            this.fichierToolStripMenuItem1.Name = "fichierToolStripMenuItem1";
            this.fichierToolStripMenuItem1.Size = new System.Drawing.Size(54, 20);
            this.fichierToolStripMenuItem1.Text = "Fichier";
            // 
            // chargerImageToolStripMenuItem1
            // 
            this.chargerImageToolStripMenuItem1.Name = "chargerImageToolStripMenuItem1";
            this.chargerImageToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.chargerImageToolStripMenuItem1.Text = "Charger image";
            this.chargerImageToolStripMenuItem1.Click += new System.EventHandler(this.chargerImageToolStripMenuItem1_Click);
            // 
            // réinitialiserToolStripMenuItem
            // 
            this.réinitialiserToolStripMenuItem.Name = "réinitialiserToolStripMenuItem";
            this.réinitialiserToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.réinitialiserToolStripMenuItem.Text = "Réinitialiser";
            this.réinitialiserToolStripMenuItem.Click += new System.EventHandler(this.réinitialiserToolStripMenuItem_Click);
            // 
            // quitterToolStripMenuItem
            // 
            this.quitterToolStripMenuItem.Name = "quitterToolStripMenuItem";
            this.quitterToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.quitterToolStripMenuItem.Text = "Quitter";
            this.quitterToolStripMenuItem.Click += new System.EventHandler(this.quitterToolStripMenuItem_Click);
            // 
            // fichierToolStripMenuItem
            // 
            this.fichierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.flouToolStripMenuItem,
            this.améliorationDeLaNettetéToolStripMenuItem,
            this.repoussageToolStripMenuItem,
            this.detectionContours1ToolStripMenuItem,
            this.detectionContours2ToolStripMenuItem,
            this.DeriveeHorizontaleEnXToolStripMenuItem,
            this.DeriveeVerticaleEnYToolStripMenuItem,
            this.gradientToolStripMenuItem});
            this.fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
            this.fichierToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.fichierToolStripMenuItem.Text = "Opérations";
            // 
            // flouToolStripMenuItem
            // 
            this.flouToolStripMenuItem.Name = "flouToolStripMenuItem";
            this.flouToolStripMenuItem.Size = new System.Drawing.Size(284, 22);
            this.flouToolStripMenuItem.Text = "Flou";
            this.flouToolStripMenuItem.Click += new System.EventHandler(this.flouToolStripMenuItem_Click);
            // 
            // améliorationDeLaNettetéToolStripMenuItem
            // 
            this.améliorationDeLaNettetéToolStripMenuItem.Name = "améliorationDeLaNettetéToolStripMenuItem";
            this.améliorationDeLaNettetéToolStripMenuItem.Size = new System.Drawing.Size(284, 22);
            this.améliorationDeLaNettetéToolStripMenuItem.Text = "Amélioration de la netteté";
            this.améliorationDeLaNettetéToolStripMenuItem.Click += new System.EventHandler(this.améliorationDeLaNettetéToolStripMenuItem_Click);
            // 
            // repoussageToolStripMenuItem
            // 
            this.repoussageToolStripMenuItem.Name = "repoussageToolStripMenuItem";
            this.repoussageToolStripMenuItem.Size = new System.Drawing.Size(284, 22);
            this.repoussageToolStripMenuItem.Text = "Effect d\'embossage (relief)";
            this.repoussageToolStripMenuItem.Click += new System.EventHandler(this.repoussageToolStripMenuItem_Click);
            // 
            // detectionContours1ToolStripMenuItem
            // 
            this.detectionContours1ToolStripMenuItem.Name = "detectionContours1ToolStripMenuItem";
            this.detectionContours1ToolStripMenuItem.Size = new System.Drawing.Size(284, 22);
            this.detectionContours1ToolStripMenuItem.Text = "Detection des contours 1";
            this.detectionContours1ToolStripMenuItem.Click += new System.EventHandler(this.detectionContours1ToolStripMenuItem_Click);
            // 
            // detectionContours2ToolStripMenuItem
            // 
            this.detectionContours2ToolStripMenuItem.Name = "detectionContours2ToolStripMenuItem";
            this.detectionContours2ToolStripMenuItem.Size = new System.Drawing.Size(284, 22);
            this.detectionContours2ToolStripMenuItem.Text = "Detection des contours 2";
            this.detectionContours2ToolStripMenuItem.Click += new System.EventHandler(this.detectionContours2ToolStripMenuItem_Click);
            // 
            // DeriveeHorizontaleEnXToolStripMenuItem
            // 
            this.DeriveeHorizontaleEnXToolStripMenuItem.Name = "DeriveeHorizontaleEnXToolStripMenuItem";
            this.DeriveeHorizontaleEnXToolStripMenuItem.Size = new System.Drawing.Size(284, 22);
            this.DeriveeHorizontaleEnXToolStripMenuItem.Text = "Filtre de Sobel : Dérivée horizontale en X";
            this.DeriveeHorizontaleEnXToolStripMenuItem.Click += new System.EventHandler(this.DeriveeHorizontaleEnXToolStripMenuItem_Click);
            // 
            // DeriveeVerticaleEnYToolStripMenuItem
            // 
            this.DeriveeVerticaleEnYToolStripMenuItem.Name = "DeriveeVerticaleEnYToolStripMenuItem";
            this.DeriveeVerticaleEnYToolStripMenuItem.Size = new System.Drawing.Size(284, 22);
            this.DeriveeVerticaleEnYToolStripMenuItem.Text = "Filtre de Sobel : Dérivée verticale en Y";
            this.DeriveeVerticaleEnYToolStripMenuItem.Click += new System.EventHandler(this.DeriveeVerticaleEnYToolStripMenuItem_Click);
            // 
            // gradientToolStripMenuItem
            // 
            this.gradientToolStripMenuItem.Name = "gradientToolStripMenuItem";
            this.gradientToolStripMenuItem.Size = new System.Drawing.Size(284, 22);
            this.gradientToolStripMenuItem.Text = "Filtre de Sobel : Norme du gradient";
            this.gradientToolStripMenuItem.Click += new System.EventHandler(this.gradientToolStripMenuItem_Click);
            // 
            // FormDetectionContours
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 560);
            this.Controls.Add(this.pboImageTransfo);
            this.Controls.Add(this.pboImageSource);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormDetectionContours";
            this.Text = "Détection des contours des images";
            this.Load += new System.EventHandler(this.FormDetectionContour_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pboImageSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboImageTransfo)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pboImageSource;
        private System.Windows.Forms.PictureBox pboImageTransfo;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fichierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeriveeHorizontaleEnXToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeriveeVerticaleEnYToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gradientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fichierToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem chargerImageToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem réinitialiserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem flouToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detectionContours1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detectionContours2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem améliorationDeLaNettetéToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem repoussageToolStripMenuItem;
    }
}

