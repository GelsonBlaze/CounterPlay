using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CounterPlay
{
    public partial class Settings : Form
    {
        public static string linguagem;
        public static string getlinguagem
        {
            get { return linguagem; }
            set { linguagem = value; }
        }
        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            getlinguagem = "0";
            if (getlinguagem=="1")
            {
                getlinguagem = "0";
            }
            else
            {
                getlinguagem = "1";
            }
            
        }
    }
}
