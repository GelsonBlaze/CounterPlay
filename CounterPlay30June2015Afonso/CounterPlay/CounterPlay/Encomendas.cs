using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
using DataAccessLayer;

namespace CounterPlay
{
    public partial class Encomendas : Form
    {
        int quantidade = 0;
        string quantidademax;
        int id; 
        Image img;
        byte[] bArr;

        public Encomendas()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

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

        private void Encomendas_Load(object sender, EventArgs e)
        {
            //Load Cartas
            dataGridView1.DataSource = BLL.produtos.LoadCartas();
            this.dataGridView1.Columns[3].DefaultCellStyle.Format = "C2";
            this.dataGridView1.Columns[0].Visible = false;
            this.dataGridView1.Columns[2].Visible = false;
            this.dataGridView1.Columns[3].Visible = false;
            this.dataGridView1.Columns[4].Visible = false;
            this.dataGridView1.Columns[5].Visible = false;
            this.dataGridView1.Columns[6].Visible = false;
            this.dataGridView1.Columns[9].Visible = false;

            //Load Outros Produtos
            dataGridView2.DataSource = BLL.produtos.LoadProdutos();
            this.dataGridView2.Columns[2].DefaultCellStyle.Format = "C2";
            this.dataGridView2.Columns[0].Visible = false;
            this.dataGridView2.Columns[4].Visible = false;

            //Load Encomendas
            dataGridView3.DataSource = BLL.encomendas.LoadEncomenda();
            this.dataGridView3.Columns[5].DefaultCellStyle.Format = "C2";

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            //Diminuir 1 na quantidade
            if (quantidade > 0)
            {
                quantidade -= 1;
                textBox1.Text = Convert.ToString(quantidade);
            }
            else
            {
                MessageBox.Show("Quantidade de produtos inválida");
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            //Adicionar mais 1 de quantidade
            if (Convert.ToInt32(quantidademax) == quantidade)
            {
                MessageBox.Show("Não estão disponíveis mais produtos desse tipo");
            }
            else
            {
                quantidade += 1;
                textBox1.Text = Convert.ToString(quantidade);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Preencher os dados escolhidos pelo funcionário para escolher a quantidade
            quantidade = 0;
            quantidademax = "0";

            id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());

            textBox1.Text = Convert.ToString(quantidade);
            byte[] img = (byte[])dataGridView1.Rows[e.RowIndex].Cells[9].Value;
            MemoryStream ms = new MemoryStream(img);
            pictureBox3.Image = Image.FromStream(ms);

            //Determinar a quantidade existente de cartas ou produtos na base de dados para interagir com eles
            quantidademax = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
        }

        private void dataGridView2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Preencher os dados escolhidos pelo funcionário para escolher a quantidade
            quantidade = 0;
            quantidademax = "0";

            id = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString());

            textBox1.Text = Convert.ToString(quantidade);
            byte[] img = (byte[])dataGridView2.Rows[e.RowIndex].Cells[4].Value;
            MemoryStream ms = new MemoryStream(img);
            pictureBox3.Image = Image.FromStream(ms);

            //Determinar a quantidade existente de cartas ou produtos na base de dados para interagir com eles
            quantidademax = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
