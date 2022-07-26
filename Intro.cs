using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OGTheGame
{
    public partial class PantallaInicio : Form


        
    {

        Game Game = new Game();

        public PantallaInicio()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Game.Show();
            this.Hide();
        }
    }
}
