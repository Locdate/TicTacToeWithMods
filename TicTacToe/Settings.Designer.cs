namespace TicTacToe
{
    partial class Settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.languageDropdown = new System.Windows.Forms.ComboBox();
            this.themeDropdown = new System.Windows.Forms.ComboBox();
            this.addCustomThemeButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Pixel Game", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(260, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "LANGUAGE:";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Pixel Game", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(260, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "THEMES:";
            // 
            // languageDropdown
            // 
            this.languageDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.languageDropdown.Font = new System.Drawing.Font("Pixel Game", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.languageDropdown.Location = new System.Drawing.Point(385, 62);
            this.languageDropdown.Name = "languageDropdown";
            this.languageDropdown.Size = new System.Drawing.Size(150, 23);
            this.languageDropdown.TabIndex = 3;
            // 
            // themeDropdown
            // 
            this.themeDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.themeDropdown.Font = new System.Drawing.Font("Pixel Game", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.themeDropdown.Location = new System.Drawing.Point(385, 92);
            this.themeDropdown.Name = "themeDropdown";
            this.themeDropdown.Size = new System.Drawing.Size(150, 23);
            this.themeDropdown.TabIndex = 4;
            this.themeDropdown.SelectedIndexChanged += new System.EventHandler(this.themeDropdown_SelectedIndexChanged);
            // 
            // addCustomThemeButton
            // 
            this.addCustomThemeButton.Font = new System.Drawing.Font("Pixel Game", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addCustomThemeButton.Image = global::TicTacToe.Properties.Resources.CrossButton;
            this.addCustomThemeButton.Location = new System.Drawing.Point(541, 88);
            this.addCustomThemeButton.Name = "addCustomThemeButton";
            this.addCustomThemeButton.Size = new System.Drawing.Size(32, 32);
            this.addCustomThemeButton.TabIndex = 5;
            this.addCustomThemeButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.addCustomThemeButton.UseVisualStyleBackColor = true;
            this.addCustomThemeButton.Click += new System.EventHandler(this.addCustomThemeButton_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Pixel Game", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(340, 345);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 30);
            this.button1.TabIndex = 6;
            this.button1.Text = "BACK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(804, 421);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.addCustomThemeButton);
            this.Controls.Add(this.themeDropdown);
            this.Controls.Add(this.languageDropdown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Settings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox languageDropdown;
        private System.Windows.Forms.ComboBox themeDropdown;
        private System.Windows.Forms.Button addCustomThemeButton;
        private System.Windows.Forms.Button button1;
    }
}