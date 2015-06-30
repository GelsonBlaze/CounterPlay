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
    public partial class VerificarPassword : Form
    {
        public static string user;
        public static string getuser
        {
            get { return user; }
            set { user = value;}
        }
        public VerificarPassword()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Preencha todos os campos vazios");
            }
            else
                if (textBox1.Text == textBox2.Text)
                {
                    int retorno = BLL.users.FirstLogin(Convert.ToInt32(getuser), textBox1.Text, false);
                    MessageBox.Show("Troca efetuada com sucesso");
                    Funcionario funcionario = new Funcionario();
                    funcionario.Show();
                    this.Close();
                }
        }

        private void VerificarPassword_Load(object sender, EventArgs e)
        {

        }
    }
}
