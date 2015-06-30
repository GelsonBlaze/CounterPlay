using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Security.Cryptography;
using System.IO;
using DataAccessLayer;

namespace CounterPlay
{
    public partial class Vendas : Form
    {
        int quantidade = 0;
        string quantidademax;
        int quantidadefinal;
        string getpreco;
        decimal precodecimal;
        int precoint;
        int id;
        decimal precototal = 0;
        Image img;
        byte[] bArr;
 

        public Vendas()
        {
            InitializeComponent();
            
        }

        private void Vendas_Load(object sender, EventArgs e)
        {
            //Load da datagridview Cartas com IdExpansao e Imagem escondidos. Formatação do Preço para dinheiro.
            dataGridView1.DataSource = BLL.produtos.LoadCartas();
            this.dataGridView1.Columns[7].DefaultCellStyle.Format = "C2";
            this.dataGridView1.Columns[0].Visible = false;
            this.dataGridView1.Columns[2].Visible = false;
            this.dataGridView1.Columns[3].Visible = false;
            this.dataGridView1.Columns[4].Visible = false;
            this.dataGridView1.Columns[5].Visible = false;
            this.dataGridView1.Columns[6].Visible = false;
            this.dataGridView1.Columns[9].Visible = false;

            //Load da datagridview OutrosProdutos com IdProduto e Imagem escondidos. Formatação do Preço para dinheiro.
            dataGridView3.DataSource = BLL.produtos.LoadProdutos();
            this.dataGridView3.Columns[0].Visible = false;
            this.dataGridView3.Columns[4].Visible = false;
            this.dataGridView3.Columns[2].DefaultCellStyle.Format = "C2";

            //Não permitir interação com botões no Load
            textBox4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button3.Enabled = false;


            
        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public byte[] imgToByteArray(Image img)
        {
            //Converter imagem para bytes
            using (MemoryStream mStream = new MemoryStream())
            {
                img.Save(mStream, img.RawFormat);
                return mStream.ToArray();
            }
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            //Converter bytes para imagem
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Preencher os dados escolhidos pelo funcionário para escolher a quantidade
            quantidade = 0;
            quantidademax = "0";
            quantidadefinal = 0;

            textBox4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button3.Enabled = true;
            id =Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());

            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            textBox4.Text = Convert.ToString(quantidade);
            byte[] img = (byte[])dataGridView1.Rows[e.RowIndex].Cells[9].Value;
            MemoryStream ms = new MemoryStream(img);
            pictureBox3.Image = Image.FromStream(ms);
        
            //Determinar a quantidade existente de cartas na base de dados para interagir com elas
            quantidademax = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();

            //Mudar o Preço para o formato adequado (x,xx €)
            //getpreco = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            //getpreco = string.Format("{0:c}", Decimal.Parse(textBox6.Text));
            //textBox6.Text = getpreco;
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            label6.Visible = false;
            label7.Visible = false;
            dataGridView1.Visible = false;
            dataGridView3.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GerirClientes gerirclientes = new GerirClientes();
            //pictureBox2.Enabled = false;
            //gerirclientes.MdiParent = this;
            gerirclientes.Show();
            gerirclientes.Location = new Point(0, 0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Adicionar Carta ao carrinho
            if ((textBox2.Text == "") && (textBox6.Text == "") && (textBox4.Text == ""))
            {
                MessageBox.Show("Escolha uma carta para adicionar ao carrinho");
            }
            else if (quantidade == 0)
            {
                MessageBox.Show("Tem de adicionar pelo menos 1 unidade ao carrinho");
            }
            else
            {
                listBox1.Items.Add(textBox2.Text);
                listBox1.Items.Add(getpreco);
                listBox1.Items.Add(quantidade);
                precototal += Convert.ToInt32(textBox6.Text);



                // Está a dar erro ao fazer o preço total
                //bool converter = decimal.TryParse(getpreco, NumberStyles.Currency, CultureInfo.CurrentCulture.NumberFormat, out precodecimal);
                //precototal += quantidade * precodecimal;
                //label5.Text = precototal.ToString();

            }



            //if (quantidade == 0)
            //{
            //    MessageBox.Show("Tem de adicionar pelo menos 1 unidade ao carrinho");
            //}
            //else
            //{

            //    listBox1.Items.Add(textBox2.Text);
            //    listBox1.Items.Add(getpreco);
            //    listBox1.Items.Add(quantidade);
            //}
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Adicionar mais 1 de quantidade
            if (Convert.ToInt32(quantidademax) == quantidade)
            {
                MessageBox.Show("Não estão disponíveis mais cartas");
            }
            else
            {
                quantidade += 1;
                textBox4.Text = Convert.ToString(quantidade);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Diminuir 1 na quantidade
            if (quantidade > 0)
            {
                quantidade -= 1;
                textBox4.Text = Convert.ToString(quantidade);
            }
            else
            {
                MessageBox.Show("Quantidade de cartas inválida");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Finalizar a venda
            quantidadefinal = (Convert.ToInt32(quantidademax) - quantidade);
            int retorno = BLL.produtos.UpdateQuantidadeCartas(id, quantidadefinal);

            dataGridView1.DataSource = BLL.produtos.LoadCartas();
            this.dataGridView1.Columns[3].DefaultCellStyle.Format = "C2";
            this.dataGridView1.Columns[5].Visible = false;
            



        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }


    }
}
