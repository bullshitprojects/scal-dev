namespace scal_dev_project
{
    partial class MDIStatisticalSoftware
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MDIStatisticalSoftware));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.descriptivaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analizarUnaVariableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.probabilidadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.descriptivaToolStripMenuItem,
            this.probabilidadToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(946, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // descriptivaToolStripMenuItem
            // 
            this.descriptivaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.analizarUnaVariableToolStripMenuItem});
            this.descriptivaToolStripMenuItem.Name = "descriptivaToolStripMenuItem";
            this.descriptivaToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.descriptivaToolStripMenuItem.Text = "Descriptiva";
            // 
            // analizarUnaVariableToolStripMenuItem
            // 
            this.analizarUnaVariableToolStripMenuItem.Name = "analizarUnaVariableToolStripMenuItem";
            this.analizarUnaVariableToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.analizarUnaVariableToolStripMenuItem.Text = "Analizar Una Variable";
            this.analizarUnaVariableToolStripMenuItem.Click += new System.EventHandler(this.analizarUnaVariableToolStripMenuItem_Click);
            // 
            // probabilidadToolStripMenuItem
            // 
            this.probabilidadToolStripMenuItem.Name = "probabilidadToolStripMenuItem";
            this.probabilidadToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.probabilidadToolStripMenuItem.Text = "Probabilidad";
            // 
            // MDIStatisticalSoftware
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(946, 547);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "MDIStatisticalSoftware";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Statistical Software";
            this.TransparencyKey = System.Drawing.Color.White;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MDIStatisticalSoftware_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem descriptivaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem probabilidadToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem analizarUnaVariableToolStripMenuItem;
    }
}

