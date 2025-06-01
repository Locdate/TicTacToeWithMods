using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class MainMenu : Form
    {
        public Settings settings;
        public ComboBox.ObjectCollection itemList;
        public List<string> themeFiles;
        public Image selectedCustomTheme;
        public Color selectedTheme = Color.Silver;
        public string defaultTheme = "GRAY";
        public int temp;
        public MainMenu()
        {
            InitializeComponent();
        }

        private void startGameButton_Click(object sender, EventArgs e)
        {
            Game formGame = new Game();
            formGame.BackColor = selectedTheme;
            formGame.BackgroundImage = selectedCustomTheme;
            formGame.Show();
            formGame.menu = this;
            this.Hide();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.menu = this;
            if (selectedTheme == Color.Empty || selectedCustomTheme == null)
            {
                settings.selectedTheme = defaultTheme;
            }
            settings.BackColor = selectedTheme;
            settings.BackgroundImage = selectedCustomTheme;
            settings.Show();
            this.Hide();
        }
    }
}
