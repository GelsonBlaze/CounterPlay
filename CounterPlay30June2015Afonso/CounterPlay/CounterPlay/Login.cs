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
    public partial class Login : Form
    {
        Admin admin = new Admin();
        Funcionario funcionario = new Funcionario();
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                    
        }

        private void username_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            DataTable dt = BLL.users.Login(textBox1.Text, textBox2.Text);
                      
                if (dt.Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dt.Rows[0][9]))
                    { 
                        Admin.getlogin = textBox1.Text;
                        this.Hide();
                        admin.Show();
                       
                    }
                    else
                    {
                        if (Convert.ToBoolean(dt.Rows[0][11]))
                        {
                            VerificarPassword.getuser = (Convert.ToString(dt.Rows[0][0]));
                            VerificarPassword verificarlogin = new VerificarPassword();
                            verificarlogin.Show();
                        }
                        else
                        {
                            Funcionario.getlogin2 = textBox1.Text;
                            this.Hide();
                            funcionario.Show();
                        }
                    }
                }
                else
                {

                    MessageBox.Show("Login inválido");
                }
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            admin.ShowDialog();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente fechar o programa?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
                Application.Exit();
            }
        }
        //Fechar Icon Glow
        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox2.Image = ((System.Drawing.Image)(Properties.Resources.fechar_2));
        }
        //Fechar Icon Glow
        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            this.pictureBox2.Image = ((System.Drawing.Image)(Properties.Resources.fechar_2));
        }
        //Fechar Icon Normal
        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox2.Image = ((System.Drawing.Image)(Properties.Resources.fechar_1));
        }

        private void textBox1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DataTable dt = BLL.users.Login(textBox1.Text, textBox2.Text);

                if (dt.Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dt.Rows[0][9]))
                    {
                        Admin.getlogin = textBox1.Text;
                        this.Hide();
                        admin.Show();

                    }
                    else
                    {
                        if (Convert.ToBoolean(dt.Rows[0][11]))
                        {
                            VerificarPassword.getuser = (Convert.ToString(dt.Rows[0][0]));
                            VerificarPassword verificarlogin = new VerificarPassword();
                            verificarlogin.Show();
                        }
                        else
                        {
                            this.Hide();
                            funcionario.Show();
                        }
                    }
                }
                else
                {

                    MessageBox.Show("Login inválido");
                }
            }
        }

        private void textBox2_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DataTable dt = BLL.users.Login(textBox1.Text, textBox2.Text);

                if (dt.Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dt.Rows[0][9]))
                    {
                        Admin.getlogin = textBox1.Text;
                        this.Hide();
                        admin.Show();

                    }
                    else
                    {
                        if (Convert.ToBoolean(dt.Rows[0][11]))
                        {
                            VerificarPassword.getuser = (Convert.ToString(dt.Rows[0][0]));
                            VerificarPassword verificarlogin = new VerificarPassword();
                            verificarlogin.Show();
                        }
                        else
                        {
                            this.Hide();
                            funcionario.Show();
                        }
                    }
                }
                else
                {

                    MessageBox.Show("Login inválido");
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
