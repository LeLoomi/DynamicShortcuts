
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
            this.fullRunButton = new System.Windows.Forms.Button();
            this.pathTextbox = new System.Windows.Forms.TextBox();
            this.pathLabel = new System.Windows.Forms.Label();
            this.browseButton = new System.Windows.Forms.Button();
            this.githubButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // fullRunButton
            // 
            this.fullRunButton.Location = new System.Drawing.Point(15, 51);
            this.fullRunButton.Name = "fullRunButton";
            this.fullRunButton.Size = new System.Drawing.Size(126, 23);
            this.fullRunButton.TabIndex = 8;
            this.fullRunButton.Text = "full run (BG)";
            this.fullRunButton.UseVisualStyleBackColor = true;
            this.fullRunButton.Click += new System.EventHandler(this.fullRunButton_Click);
            // 
            // pathTextbox
            // 
            this.pathTextbox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::DynamicShortcuts.Properties.Settings.Default, "savedShotcutPath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.pathTextbox.Location = new System.Drawing.Point(15, 25);
            this.pathTextbox.Name = "pathTextbox";
            this.pathTextbox.ReadOnly = true;
            this.pathTextbox.Size = new System.Drawing.Size(286, 20);
            this.pathTextbox.TabIndex = 9;
            this.pathTextbox.Text = global::DynamicShortcuts.Properties.Settings.Default.savedShotcutPath;
            // 
            // pathLabel
            // 
            this.pathLabel.AutoSize = true;
            this.pathLabel.Location = new System.Drawing.Point(12, 9);
            this.pathLabel.Name = "pathLabel";
            this.pathLabel.Size = new System.Drawing.Size(104, 13);
            this.pathLabel.TabIndex = 10;
            this.pathLabel.Text = "Selected weblink file";
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(307, 25);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(64, 20);
            this.browseButton.TabIndex = 11;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // githubButton
            // 
            this.githubButton.FlatAppearance.BorderSize = 0;
            this.githubButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.githubButton.ForeColor = System.Drawing.Color.DimGray;
            this.githubButton.Location = new System.Drawing.Point(-3, 96);
            this.githubButton.Name = "githubButton";
            this.githubButton.Size = new System.Drawing.Size(389, 32);
            this.githubButton.TabIndex = 12;
            this.githubButton.Text = "Program by Eliah Lohr, click here to see all external code used on Github.";
            this.githubButton.UseVisualStyleBackColor = true;
            this.githubButton.Click += new System.EventHandler(this.githubButton_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 126);
            this.Controls.Add(this.githubButton);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.pathLabel);
            this.Controls.Add(this.pathTextbox);
            this.Controls.Add(this.fullRunButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "mainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "DynamicIcons";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.mainForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button fullRunButton;
        private System.Windows.Forms.TextBox pathTextbox;
        private System.Windows.Forms.Label pathLabel;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.Button githubButton;
    }
}

