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
    
    public partial class EndScreen : Form
    {
        
        public EndScreen()
        {
            InitializeComponent();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PantallaInicio Intro = new PantallaInicio();
            Intro.Show();
            this.Hide();
        }

        
        private void labelscore_Click(object sender, EventArgs e)
        {
           
        }

        private void EndScreen_Load(object sender, EventArgs e)
        {
            labelscore.Text = Game.mensaje;
        }
    }
}
