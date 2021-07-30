
namespace DynamicShortcuts
{
    partial class mainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.generateInBackgroundButton = new System.Windows.Forms.Button();
            this.fullRunButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // generateInBackgroundButton
            // 
            this.generateInBackgroundButton.Location = new System.Drawing.Point(62, 34);
            this.generateInBackgroundButton.Name = "generateInBackgroundButton";
            this.generateInBackgroundButton.Size = new System.Drawing.Size(126, 23);
            this.generateInBackgroundButton.TabIndex = 7;
            this.generateInBackgroundButton.Text = "generate png (BG)";
            this.generateInBackgroundButton.UseVisualStyleBackColor = true;
            this.generateInBackgroundButton.Click += new System.EventHandler(this.generateInBackgroundButton_Click);
            // 
            // fullRunButton
            // 
            this.fullRunButton.Location = new System.Drawing.Point(62, 63);
            this.fullRunButton.Name = "fullRunButton";
            this.fullRunButton.Size = new System.Drawing.Size(126, 23);
            this.fullRunButton.TabIndex = 8;
            this.fullRunButton.Text = "full run (BG)";
            this.fullRunButton.UseVisualStyleBackColor = true;
            this.fullRunButton.Click += new System.EventHandler(this.fullRunButton_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 129);
            this.Controls.Add(this.fullRunButton);
            this.Controls.Add(this.generateInBackgroundButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "mainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "DynamicIcons";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button generateInBackgroundButton;
        private System.Windows.Forms.Button fullRunButton;
    }
}

