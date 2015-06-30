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
    public partial class Admin : Form
    {
        //Mudar o nome do user
        public static string login;
        public static string getlogin
        {
            get { return login; }
            set { login = value; }
        }
        //1 Janela GerirFuncionarios
        public static string opengerirfuncionario = "0";
        public static string getopengerirfuncionario
        {
            get { return opengerirfuncionario; }
            set { opengerirfuncionario = value; }
        }
        //1 Janela GerirClientes
        public static string opengerirclientes = "0";
        public static string getopengerirclientes
        {
            get { return opengerirclientes; }
            set { opengerirclientes = value; }
        }
        //1 Janela GerirCartas
        public static string opengerircartas = "0";
        public static string getopengerircartas
        {
            get { return opengerircartas; }
            set { opengerircartas = value; }
        }
        //1 Janela GerirProdutos
        public static string opengerirprodutos = "0";
        public static string getopengerirprodutos
        {
            get { return opengerirprodutos; }
            set { opengerirprodutos = value; }
        }
        public Admin()
        {          
            InitializeComponent();
            pictureBox3.MouseEnter += new EventHandler(pictureBox3_MouseEnter);
            pictureBox3.MouseLeave += new EventHandler(pictureBox3_MouseLeave);
            

        }
        //GerirFuncionarios Icon Glow
        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox1.Image = ((System.Drawing.Image)(Properties.Resources.gerir_funcionarios_2));
        }
        //GerirFuncionarios Icon Normal
        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox1.Image = ((System.Drawing.Image)(Properties.Resources.gerir_funcionarios_1));
        }
        //GerirFuncionarios Icon Glow
        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            this.pictureBox1.Image = ((System.Drawing.Image)(Properties.Resources.gerir_funcionarios_2));
        }

        //GerirClientes Icon Normal
        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox2.Image = ((System.Drawing.Image)(Properties.Resources.gerir_clientes_1));
        }
        //GerirClientes Icon Glow
        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox2.Image = ((System.Drawing.Image)(Properties.Resources.gerir_clientes_2));
        }
        //GerirClientes Icon Glow
        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            this.pictureBox2.Image = ((System.Drawing.Image)(Properties.Resources.gerir_clientes_2));
        }
        //GerirCartas Icon Normal
        void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox3.Image = null;
            this.pictureBox3.Image = ((System.Drawing.Image)(Properties.Resources.gerir_cartas_1));
        }
        //GerirCartas Icon Glow
        void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox3.Image = ((System.Drawing.Image)(Properties.Resources.gerir_cartas_2));
        }
        //GerirCartas Icon Glow
        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            this.pictureBox3.Image = ((System.Drawing.Image)(Properties.Resources.gerir_cartas_2));
        }
        //GerirVendas Icon Glow
        private void pictureBox9_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox9.Image = ((System.Drawing.Image)(Properties.Resources.gerir_vendas_2));
        }
        //GerirVendas Icon Glow
        private void pictureBox9_MouseHover(object sender, EventArgs e)
        {
            this.pictureBox9.Image = ((System.Drawing.Image)(Properties.Resources.gerir_vendas_2));
        }
        //GerirVendas Icon Normal
        private void pictureBox9_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox9.Image = ((System.Drawing.Image)(Properties.Resources.gerir_vendas_1));
        }
        //GerirEncomendas Icon Glow
        private void pictureBox10_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox10.Image = ((System.Drawing.Image)(Properties.Resources.gerir_encomendas_2));
        }
        //GerirEncomendas Icon Glow
        private void pictureBox10_MouseHover(object sender, EventArgs e)
        {
            this.pictureBox10.Image = ((System.Drawing.Image)(Properties.Resources.gerir_encomendas_2));
        }
        //GerirEncomendas Icon Glow
        private void pictureBox10_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox10.Image = ((System.Drawing.Image)(Properties.Resources.gerir_encomendas_1));
        }
        //OutrosProdutos Icon Glow
        private void pictureBox11_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox11.Image = ((System.Drawing.Image)(Properties.Resources.outros_produtos_2));
        }
        //OutrosProdutos Icon Glow
        private void pictureBox11_MouseHover(object sender, EventArgs e)
        {
            this.pictureBox11.Image = ((System.Drawing.Image)(Properties.Resources.outros_produtos_2));
        }
        //OutrosProdutos Icon Normal
        private void pictureBox11_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox11.Image = ((System.Drawing.Image)(Properties.Resources.outros_produtos_1));
        }
        //private void pictureBox1_Click(object sender, EventArgs e)
        //{
            
        //    GerirFuncionarios gerirfuncionarios = new GerirFuncionarios();
        //    gerirfuncionarios.MdiParent = this;
        //    gerirfuncionarios.Show();
        //    gerirfuncionarios.Location = new Point(0, 0);
        //}

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        //GerirFuncionarios
        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            if (opengerirfuncionario == "0")
            { 
            //pictureBox1.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.openbackground));
            GerirFuncionarios gerirfuncionarios = new GerirFuncionarios();
            gerirfuncionarios.MdiParent = this;
            gerirfuncionarios.Show();
            //pictureBox1.Enabled = false;
            gerirfuncionarios.Location = new Point(0, 0);
            opengerirfuncionario = "1";
            }
            else
            {
                MessageBox.Show("Esta janela já está aberta");
            }



        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        

        private void Admin_Load(object sender, EventArgs e)
        {
            //Cor do MDI
            MdiClient ctlMDI = (MdiClient)this.Controls[this.Controls.Count - 1];
            ctlMDI.BackColor = Color.White;
            //Trocar de nome consoante o utilizador
            string nome = getlogin;
            string upper1 = nome.ToUpper();
            label3.Text = upper1;

        }
        //Abrir Form GerirClientes
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (opengerirclientes == "0")
            {
                GerirClientes gerirclientes = new GerirClientes();
                gerirclientes.MdiParent = this;
                gerirclientes.Show();
                gerirclientes.Location = new Point(0, 0);
                opengerirclientes = "1";
            }
            else
            {
                MessageBox.Show("Esta janela já está aberta");
            }
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (opengerircartas == "0")
            {
                GerirCartas gerircartas = new GerirCartas();
                gerircartas.MdiParent = this;
                gerircartas.Show();
                gerircartas.Location = new Point(0, 0);
                opengerircartas = "1";
            }
            else
            {
                MessageBox.Show("Esta janela já está aberta");
            }
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox4.Image = ((System.Drawing.Image)(Properties.Resources.minimizeglow));
        }

        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            this.pictureBox4.Image = ((System.Drawing.Image)(Properties.Resources.minimizeglow));
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox4.Image = ((System.Drawing.Image)(Properties.Resources.minimize));
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Login loginform = new Login();
            this.Close();
            loginform.Show();
            

        }


        private void label2_Click(object sender, EventArgs e)
        {
            Login loginform = new Login();
            this.Close();
            loginform.Close();
            Application.Exit();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(pictureBox6, 0, pictureBox6.Height);
        }

        private void terminarSessãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente terminar a sessão?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Login loginform = new Login();
                this.Close();
                loginform.Show();
            }
            
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente sair do programa?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Login loginform = new Login();
                this.Close();
                loginform.Close();
                Application.Exit();
            }
            
        }

        private void terminarSessãoToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            terminarSessãoToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
        }

        private void terminarSessãoToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            terminarSessãoToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
        }

        private void terminarSessãoToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            terminarSessãoToolStripMenuItem.ForeColor = System.Drawing.Color.White;
        }

        private void sairToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            sairToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
        }

        private void sairToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            sairToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
        }

        private void sairToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            sairToolStripMenuItem.ForeColor = System.Drawing.Color.White;
        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            //contextMenuStrip1.Show(pictureBox6, 0, pictureBox6.Height);
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void pictureBox6_MouseEnter(object sender, EventArgs e)
        {
            //contextMenuStrip1.Show(pictureBox6, 0, pictureBox6.Height);
        }

        private void pictureBox6_MouseClick(object sender, MouseEventArgs e)
        {
            contextMenuStrip1.Show(pictureBox6, 0, pictureBox6.Height);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.Show();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click_1(object sender, EventArgs e)
        {
            Vendas vendas = new Vendas();
            vendas.MdiParent = this;
            vendas.Show();
            vendas.Location = new Point(0, 0);
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            if (opengerirprodutos == "0")
            {
                OutrosProdutos outrosprodutos = new OutrosProdutos();
                outrosprodutos.MdiParent = this;
                outrosprodutos.Show();
                outrosprodutos.Location = new Point(0, 0);
                opengerirprodutos = "1";
            }
            else
            {
                MessageBox.Show("Esta janela já está aberta");
            }
            

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Encomendas encomendas = new Encomendas();
            encomendas.MdiParent = this;
            encomendas.Show();
            encomendas.Location = new Point(0, 0);
        }

        

        

        

        

        

        

        

        

        






      



    }
}
