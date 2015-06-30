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
    public partial class Funcionario : Form
    {
        public static string login2;
        public static string getlogin2
        {
            get { return login2; }
            set { login2 = value; }
        }
        public Funcionario()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

     

        private void Funcionario_Load(object sender, EventArgs e)
        {
            //Cor do MDI
            MdiClient ctlMDI = (MdiClient)this.Controls[this.Controls.Count - 1];
            ctlMDI.BackColor = Color.White;
            //Trocar de nome consoante o utilizador
            string nome = getlogin2;
            string upper1 = nome.ToUpper();
            label3.Text = upper1;
        }
        //Vender Icon Glow
        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            this.pictureBox4.Image = ((System.Drawing.Image)(Properties.Resources.vendas_2));
        }
        //Vender Icon Glow
        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox4.Image = ((System.Drawing.Image)(Properties.Resources.vendas_2));
        }
        //Vender Icon Normal
        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox4.Image = ((System.Drawing.Image)(Properties.Resources.vendas_1));
        }
        //GerirClientes Icon Glow
        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            this.pictureBox1.Image = ((System.Drawing.Image)(Properties.Resources.gerir_clientes_2));
        }
        //GerirClientes Icon Glow
        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox1.Image = ((System.Drawing.Image)(Properties.Resources.gerir_clientes_2));
        }
        //GerirCliente Icon Normal
        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox1.Image = ((System.Drawing.Image)(Properties.Resources.gerir_clientes_1));
        }
        //GerirCartas Icon Glow
        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            this.pictureBox2.Image = ((System.Drawing.Image)(Properties.Resources.gerir_cartas_2));
        }
        //GerirCartas Icon Glow
        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox2.Image = ((System.Drawing.Image)(Properties.Resources.gerir_cartas_2));
        }
        //GerirCartas Icon Normal
        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox2.Image = ((System.Drawing.Image)(Properties.Resources.gerir_cartas_1));
        }
        //OutrosProdutos Icon Glow
        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            this.pictureBox3.Image = ((System.Drawing.Image)(Properties.Resources.outros_produtos_2));
        }
        //OutrosPodutos Icon Glow
        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox3.Image = ((System.Drawing.Image)(Properties.Resources.outros_produtos_2));
        }
        //OutrosPodutos Icon Normal
        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox3.Image = ((System.Drawing.Image)(Properties.Resources.outros_produtos_1));
        }
        //Encomendar Icon Glow
        private void pictureBox5_MouseHover(object sender, EventArgs e)
        {
            this.pictureBox5.Image = ((System.Drawing.Image)(Properties.Resources.encomendar_2));
        }
        //Encomendar Icon Glow
        private void pictureBox5_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox5.Image = ((System.Drawing.Image)(Properties.Resources.encomendar_2));
        }
        //Encomendar Icon Normal
        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox5.Image = ((System.Drawing.Image)(Properties.Resources.encomendar_1));
        }
        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            GerirClientes gerirclientes = new GerirClientes();
            pictureBox1.Enabled = false;
            gerirclientes.MdiParent = this;
            gerirclientes.Show();
            gerirclientes.Location = new Point(0, 0);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Vendas vendas = new Vendas();
            vendas.MdiParent = this;
            vendas.Show();
            vendas.Location = new Point(0, 0);
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(pictureBox6, 0, pictureBox6.Height);
        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente terminar a sessão?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Login loginform = new Login();
                this.Close();
                loginform.Show();
            }

        }

        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente sair do programa?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Login loginform = new Login();
                this.Close();
                loginform.Close();
                Application.Exit();
            }

        }

        

        
        
        
        

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            GerirCartas gerircartas = new GerirCartas();
            pictureBox2.Enabled = false;
            gerircartas.MdiParent = this;
            gerircartas.Show();
            gerircartas.Location = new Point(0, 0);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            OutrosProdutos outrosprodutos = new OutrosProdutos();
            pictureBox3.Enabled = false;
            outrosprodutos.MdiParent = this;
            outrosprodutos.Show();
            outrosprodutos.Location = new Point(0, 0);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente terminar a sessão?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Login loginform = new Login();
                this.Close();
                loginform.Show();
            }
        }

        private void toolStripMenuItem2_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente sair do programa?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Login loginform = new Login();
                this.Close();
                loginform.Close();
                Application.Exit();
            }
        }
        
        
        
        
        
        
    }
}
