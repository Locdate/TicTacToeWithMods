using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Settings : Form
    {
        public MainMenu menu;
        private int temp = 0;
        public string selectedTheme;
        public List<string> themePaths = new List<string>();
        public Settings()
        {
            this.FormClosing += new FormClosingEventHandler(SaveForm);
            InitializeComponent();
            themeDropdown.Items.Add("DEFAULT");
            themeDropdown.Items.Add("WHITE");
            themeDropdown.Items.Add("BLACK");
            themeDropdown.Items.Add("GRAY");
            themeDropdown.Items.Add("PURPLE");
            themeDropdown.Items.Add("RED");
            languageDropdown.Items.Add("ENGLISH");
            languageDropdown.SelectedItem = "ENGLISH";
        }
        
        public void SaveForm(object sender, FormClosingEventArgs e)
        {
            menu.settings = this;
            menu.themeFiles = themePaths;
        }

        private void themeDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (themeDropdown.SelectedIndex)
            {
                case 0:
                    this.BackgroundImage = Image.FromFile("D:\\Programms\\TicTacToe\\TicTacToe\\ClassicTheme.png");
                    menu.BackgroundImage = Image.FromFile("D:\\Programms\\TicTacToe\\TicTacToe\\ClassicTheme.png");
                    menu.selectedCustomTheme = Image.FromFile("D:\\Programms\\TicTacToe\\TicTacToe\\ClassicTheme.png");
                    break;
                case 1:
                    this.BackColor = Color.White;
                    menu.selectedTheme = Color.White;
                    menu.BackColor = Color.White;
                    this.BackgroundImage = null;
                    menu.BackgroundImage = null;
                    menu.selectedCustomTheme = null;
                    break;
                case 2:
                    this.BackColor = Color.Black;
                    menu.selectedTheme = Color.Black;
                    menu.BackColor = Color.Black;
                    this.BackgroundImage = null;
                    menu.BackgroundImage = null;
                    menu.selectedCustomTheme = null;
                    break;
                case 3:
                    this.BackColor = Color.Silver;
                    menu.selectedTheme = Color.Silver;
                    menu.BackColor = Color.Silver;
                    this.BackgroundImage = null;
                    menu.BackgroundImage = null;
                    menu.selectedCustomTheme = null;
                    break;
                case 4:
                    this.BackColor = Color.Purple;
                    menu.selectedTheme = Color.Purple;
                    menu.BackColor = Color.Purple;
                    this.BackgroundImage = null;
                    menu.BackgroundImage = null;
                    menu.selectedCustomTheme = null;
                    break;
                case 5:
                    this.BackColor = Color.Red;
                    menu.selectedTheme = Color.Red;
                    menu.BackColor = Color.Red;
                    this.BackgroundImage = null;
                    menu.BackgroundImage = null;
                    menu.selectedCustomTheme = null;
                    break;
                case 6:
                    this.BackgroundImage = Image.FromFile(themePaths[0]);
                    menu.selectedTheme = Color.Empty;
                    menu.selectedCustomTheme = Image.FromFile(themePaths[0]);
                    menu.BackgroundImage = Image.FromFile(themePaths[0]);
                    break;
                case 7:
                    this.BackgroundImage = Image.FromFile(themePaths[1]);
                    menu.selectedTheme = Color.Empty;
                    menu.selectedCustomTheme = Image.FromFile(themePaths[1]);
                    menu.BackgroundImage = Image.FromFile(themePaths[1]);
                    break;
                case 8:
                    this.BackgroundImage = Image.FromFile(themePaths[2]);
                    menu.selectedTheme = Color.Empty;
                    menu.selectedCustomTheme = Image.FromFile(themePaths[2]);
                    menu.BackgroundImage = Image.FromFile(themePaths[2]);
                    break;
                case 9:
                    this.BackgroundImage = Image.FromFile(themePaths[3]);
                    menu.selectedTheme = Color.Empty;
                    menu.selectedCustomTheme = Image.FromFile(themePaths[3]);
                    menu.BackgroundImage = Image.FromFile(themePaths[3]);
                    break;
                case 10:
                    this.BackgroundImage = Image.FromFile(themePaths[4]);
                    menu.selectedTheme = Color.Empty;
                    menu.selectedCustomTheme = Image.FromFile(themePaths[4]);
                    menu.BackgroundImage = Image.FromFile(themePaths[4]);
                    break;
                case 11:
                    this.BackgroundImage = Image.FromFile(themePaths[5]);
                    menu.selectedTheme = Color.Empty;
                    menu.selectedCustomTheme = Image.FromFile(themePaths[5]);
                    menu.BackgroundImage = Image.FromFile(themePaths[5]);
                    break;
                case 12:
                    this.BackgroundImage = Image.FromFile(themePaths[6]);
                    menu.selectedTheme = Color.Empty;
                    menu.selectedCustomTheme = Image.FromFile(themePaths[6]);
                    menu.BackgroundImage = Image.FromFile(themePaths[6]);
                    break;
            }
        }

        private void addCustomThemeButton_Click(object sender, EventArgs e)
        {
            if (themeDropdown.Items.Count >= 13)
            {
                MessageBox.Show("Custom themes > 7");
                return;
            }
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            string filename = openFileDialog.FileName;
            menu.itemList = themeDropdown.Items;
            themePaths.Add(filename);
            themeDropdown.Items.Add("Custom_Theme_" + temp);
            temp++;
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            if (menu.selectedTheme == Color.Empty && menu.selectedCustomTheme == null)
            {
                themeDropdown.SelectedItem = selectedTheme;
            }
            if (menu.themeFiles != null)
            {
                menu.temp = temp;
                themePaths = menu.themeFiles;
                for (int i = 0; i < themePaths.Count; i++)
                {
                    themeDropdown.Items.Add("Custom_Theme_" + i);
                }
            }
            label1.BringToFront();
            label2.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            menu.Show();
            this.Close();
        }
    }
}
