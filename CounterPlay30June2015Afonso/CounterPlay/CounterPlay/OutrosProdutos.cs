using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using DataAccessLayer;
using System.Windows.Forms;

namespace CounterPlay
{
    public partial class OutrosProdutos : Form
    {
        Image img;
        byte[] bArr;
        string id;
        int quantidade = 0;

        public OutrosProdutos()
        {
            InitializeComponent();
        }
        //Minimizar Icon Glow
        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox1.Image = ((System.Drawing.Image)(Properties.Resources.minimizar_2));
        }
        //Minimizar Icon Glow
        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            this.pictureBox1.Image = ((System.Drawing.Image)(Properties.Resources.minimizar_2));
        }
        //Minimizar Icon Normal
        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox1.Image = ((System.Drawing.Image)(Properties.Resources.minimizar_1));
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
        //AdicionarProduto Icon Glow
        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox4.Image = ((System.Drawing.Image)(Properties.Resources.adicionar_produto_2));
        }
        //AdicionarProduto Icon Glow
        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            this.pictureBox4.Image = ((System.Drawing.Image)(Properties.Resources.adicionar_produto_2));
        }
        //AdicionarProduto Icon Normal
        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox4.Image = ((System.Drawing.Image)(Properties.Resources.adicionar_produto));
        }
        //AtualizarProduto Icon Glow
        private void pictureBox5_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox5.Image = ((System.Drawing.Image)(Properties.Resources.actualizar_produto_2));
        }
        //AtualizarProduto Icon Glow
        private void pictureBox5_MouseHover(object sender, EventArgs e)
        {
            this.pictureBox5.Image = ((System.Drawing.Image)(Properties.Resources.actualizar_produto_2));
        }
        //AtualizarProduto Icon Glow
        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox5.Image = ((System.Drawing.Image)(Properties.Resources.actualizar_produto_1));
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Admin.opengerirprodutos = "0";
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

        private void OutrosProdutos_Load(object sender, EventArgs e)
        {
            //Fazer load da tabela cartas com a coluna das imagens escondida
            dataGridView1.DataSource = BLL.produtos.LoadProdutos();
            this.dataGridView1.Columns[4].Visible = false;

            textBox3.Text = "0";
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();          
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            byte[] img = (byte[])dataGridView1.Rows[e.RowIndex].Cells[9].Value;
            MemoryStream ms = new MemoryStream(img);
            pictureBox3.Image = Image.FromStream(ms);

            //Marcas a quantidade inicial de produtos
            quantidade = Convert.ToInt32(textBox3.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Carregar uma imagem para a picturebox
            openFileDialog1.ShowDialog();
            string file = openFileDialog1.FileName.ToString();
            img = Image.FromFile(file, true);
            pictureBox3.Image = img;
            bArr = imgToByteArray(img);
            img = byteArrayToImage(bArr);
            pictureBox3.Image = img;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            //Inserir novo produto
            if (MessageBox.Show("Deseja realmente inserir o produto na base de dados?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MemoryStream ms = new MemoryStream();
                pictureBox3.Image.Save(ms, pictureBox3.Image.RawFormat);
                byte[] img = ms.ToArray();
                int InsertProduto = BLL.produtos.InsertProduto(textBox1.Text, Convert.ToDouble(textBox2.Text), Convert.ToInt32(textBox3.Text), img);
                dataGridView1.DataSource = BLL.produtos.LoadProdutos();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "0";
                quantidade = 0;
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            //Atualizar Produto
            if (MessageBox.Show("Deseja realmente atualizar o produto na base de dados?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MemoryStream ma = new MemoryStream();
                pictureBox3.Image.Save(ma, pictureBox3.Image.RawFormat);
                byte[] image = ma.ToArray();

                int UpdateProduto = BLL.produtos.UpdateProduto(Convert.ToInt32(id), textBox1.Text, Convert.ToDouble(textBox2.Text), Convert.ToInt32(textBox3.Text), image);
                dataGridView1.DataSource = BLL.produtos.LoadProdutos();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "0";
                quantidade = 0;
            }
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            //Diminuir 1 na quantidade
            if (quantidade > 0)
            {
                quantidade -= 1;
                textBox3.Text = Convert.ToString(quantidade);
            }
            else
            {
                MessageBox.Show("Quantidade de cartas inválida");
            }
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            //Adicionar mais 1 de quantidade
            quantidade += 1;
            textBox3.Text = Convert.ToString(quantidade);
        }
        
        
        
    }
}
