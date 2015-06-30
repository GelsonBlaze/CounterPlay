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
    public partial class GerirClientes : Form
    {
        string id;
        bool combo = true;

        public GerirClientes()
        {
            InitializeComponent();
        }

        private void GerirClientes_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BLL.clientes.LoadClientes();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Admin.getopengerirclientes = "0";
            this.Close();
        }
        //Minizar Icon Glow
        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox1.Image = ((System.Drawing.Image)(Properties.Resources.minimizar_2));
        }
        //Minizar Icon Normal
        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox1.Image = ((System.Drawing.Image)(Properties.Resources.minimizar_1));
        }
        //Minizar Icon Glow
        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            this.pictureBox1.Image = ((System.Drawing.Image)(Properties.Resources.minimizar_2));
        }
        //Fechar Icon Glow
        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox2.Image = ((System.Drawing.Image)(Properties.Resources.fechar_2));
        }
        //Fechar Icon Normal
        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox2.Image = ((System.Drawing.Image)(Properties.Resources.fechar_1));
        }
        //Fechar Icon Glow
        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            this.pictureBox2.Image = ((System.Drawing.Image)(Properties.Resources.fechar_2));
        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {

            this.pictureBox6.Image = ((System.Drawing.Image)(Properties.Resources.Searchglow));
        }

        private void pictureBox6_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox6.Image = ((System.Drawing.Image)(Properties.Resources.Searchglow));
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox6.Image = ((System.Drawing.Image)(Properties.Resources.Search));
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Ativo")
            {
                combo = true;
            }
            else
            {
                combo = false;
            }
            if (MessageBox.Show("Deseja realmente adicionar este cliente?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //Adicionar cliente
                int adicionarcliente = BLL.clientes.InsertCliente(textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, combo);
                dataGridView1.DataSource = BLL.clientes.LoadClientes();
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Ativo")
            {
                combo = true;
            }
            else
            {
                combo = false;
            }
            if (MessageBox.Show("Deseja realmente alterar os dados deste cliente?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //Atualizar cliente
                int retorno = BLL.clientes.UpdateCliente(id, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, combo);
                dataGridView1.DataSource = BLL.clientes.LoadClientes();
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                pictureBox4.Enabled = true;
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            //Filtrar cliente
            dataGridView1.DataSource = BLL.clientes.FiltrarClientes(textBox9.Text);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            pictureBox5.Enabled = true;
            pictureBox4.Enabled = false;
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            comboBox2.Text = "";
            id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            string dt = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            if (dt == "True")
            {
                comboBox2.Text = "Ativo";
            }
            else
            {
                comboBox2.Text = "Inativo";
            }
        }
        //Adicionar Cliente Icon Glow
        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox4.Image = ((System.Drawing.Image)(Properties.Resources.adicionar_cliente_2));
        }
        //Adicionar Cliente Icon Glow
        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            this.pictureBox4.Image = ((System.Drawing.Image)(Properties.Resources.adicionar_cliente_2));
        }
        //Adicionar Cliente Icon Normal
        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox4.Image = ((System.Drawing.Image)(Properties.Resources.adicionar_cliente_1));
        }
        //Atualizar Cliente Icon Glow
        private void pictureBox5_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox5.Image = ((System.Drawing.Image)(Properties.Resources.actualizar_cliente_2));
        }
        //Atualizar Cliente Icon Glow
        private void pictureBox5_MouseHover(object sender, EventArgs e)
        {
            this.pictureBox5.Image = ((System.Drawing.Image)(Properties.Resources.actualizar_cliente_2));
        }
        //Atualizar Cliente Icon Normal
        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox5.Image = ((System.Drawing.Image)(Properties.Resources.actualizar_cliente_1));
        }

       
    }
}
