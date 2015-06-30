using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
    public partial class GerirCartas : Form
    {
        string filtrarmana;
        string filtrarcor;
        Image img;
        byte[] bArr;
        string id;
        int quantidade = 0;
        string getpreco;
     

        public GerirCartas()
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
        //AdicionarCarta Icon Glow
        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox4.Image = ((System.Drawing.Image)(Properties.Resources.adicionar_cartas_2));
        }
        //AdicionarCarta Icon Glow
        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            this.pictureBox4.Image = ((System.Drawing.Image)(Properties.Resources.adicionar_cartas_2));
        }
        //AdicionarCarta Icon Normal
        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox4.Image = ((System.Drawing.Image)(Properties.Resources.adicionar_carta_1));
        }
        //AtualizarCartas Icon Glow
        private void pictureBox5_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox5.Image = ((System.Drawing.Image)(Properties.Resources.actualizar_cartas_2));
        }
        //AtualizarCartas Icon Glow
        private void pictureBox5_MouseHover(object sender, EventArgs e)
        {
            this.pictureBox5.Image = ((System.Drawing.Image)(Properties.Resources.actualizar_cartas_2));
        }
        //AtualizarCartas Icon Normal
        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox5.Image = ((System.Drawing.Image)(Properties.Resources.actualizar_carta_1));
        }
        private void GerirCartas_Load(object sender, EventArgs e)
        {
            //Fazer load da tabela cartas com a coluna das imagens escondida
            dataGridView1.DataSource = BLL.produtos.LoadCartas();
            this.dataGridView1.Columns[9].Visible = false;

            textBox3.Text = "0";

            //Load das colunas para as suas respetivas combo boxes
            DataTable expansoes = BLL.produtos.LoadExpansoes();
            for (int i = 0; i != expansoes.Rows.Count; i++)
            {
                string n1 = Convert.ToString(expansoes.Rows[i]["NomeExpansao"]);
                NomeExpansao.Items.Add(n1);
            }

            DataTable tipo = BLL.produtos.LoadTipos();
            for (int i = 0; i != tipo.Rows.Count; i++)
            {
                string n2 = Convert.ToString(tipo.Rows[i]["Tipo"]);
                Tipo.Items.Add(n2);
            }

            DataTable cor = BLL.produtos.LoadCores();
            for (int i = 0; i != cor.Rows.Count; i++)
            {
               string n3 = Convert.ToString(cor.Rows[i]["Cor"]);
                Cor.Items.Add(n3);
            }

            //Converter o dinheiro para o seu formato ideal
            //this.dataGridView1.Columns[7].DefaultCellStyle.Format = "C2";


            
            
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Admin.getopengerircartas = "0";
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            //Inserir nova carta
            if (MessageBox.Show("Deseja realmente inserir a carta na base de dados?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MemoryStream ms = new MemoryStream();
                pictureBox3.Image.Save(ms, pictureBox3.Image.RawFormat);
                byte[] img = ms.ToArray();
                int InsertCarta = BLL.produtos.InsertCarta(textBox1.Text, NomeExpansao.Text, Tipo.Text, Cor.Text, comboBox4.Text, comboBox5.Text, Convert.ToDouble(textBox4.Text), Convert.ToInt32(textBox3.Text), img);
                dataGridView1.DataSource = BLL.produtos.LoadCartas();
                textBox1.Text = "";
                NomeExpansao.Text = "";
                Tipo.Text = "";
                Cor.Text = "";
                comboBox4.Text = "";
                comboBox5.Text = "";
                textBox4.Text = "";
                textBox3.Text = "0";
                quantidade = 0;
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            pictureBox4.Enabled = true;
            //Atualizar Carta
            if (MessageBox.Show("Deseja realmente atualizar a carta na base de dados?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
            MemoryStream ma = new MemoryStream();
            pictureBox3.Image.Save(ma, pictureBox3.Image.RawFormat);
            byte[] image = ma.ToArray();
       
            int UpdateCarta = BLL.produtos.UpdateCarta(Convert.ToInt32(id), textBox1.Text, NomeExpansao.SelectedItem.ToString(), Tipo.SelectedItem.ToString(), Cor.SelectedItem.ToString(), comboBox4.SelectedItem.ToString(), comboBox5.SelectedItem.ToString(), Convert.ToDouble(textBox4.Text), Convert.ToInt32(textBox3.Text), image);
            dataGridView1.DataSource = BLL.produtos.LoadCartas();
            textBox1.Text = "";
            NomeExpansao.Text = "";
            Tipo.Text = "";
            Cor.Text = "";
            comboBox4.Text = "";
            comboBox5.Text = "";
            textBox4.Text = "";
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

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            //Inserir nova expansão
            if (MessageBox.Show("Deseja realmente inserir uma nova expansão?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
            int InsertExpansao = BLL.produtos.InsertExpansao(NomeExpansao.Text);
            DataTable expansoes = BLL.produtos.LoadExpansoes();
            for (int i = 0; i != expansoes.Rows.Count; i++)
            {
                string n1 = Convert.ToString(expansoes.Rows[i]["NomeExpansao"]);
                NomeExpansao.Items.Add(n1);
            }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //Filtrar cartas
            dataGridView1.DataSource = BLL.produtos.FiltrarCartas(textBox2.Text);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            //Inserir nova cor
            if (MessageBox.Show("Deseja realmente inserir uma nova cor?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int InsertCor = BLL.produtos.InsertCor(Cor.Text);
                DataTable cor = BLL.produtos.LoadCores();
                for (int i = 0; i != cor.Rows.Count; i++)
                {
                    string n3 = Convert.ToString(cor.Rows[i]["Cor"]);
                    Cor.Items.Add(n3);
                }
            }
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

       

        private void dataGridView1_CellMouseDoubleClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            pictureBox5.Enabled = true;
            pictureBox4.Enabled = false;
            //Preencher informações consoante a tabela
            id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
       
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                NomeExpansao.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                Tipo.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                Cor.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                comboBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                comboBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                byte[] img = (byte[])dataGridView1.Rows[e.RowIndex].Cells[9].Value;
                MemoryStream ms = new MemoryStream(img);
                pictureBox3.Image = Image.FromStream(ms);

                //Converter dinheiro para o formato certo
                //getpreco = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                //getpreco = string.Format("{0:c}", Decimal.Parse(textBox4.Text));
                //textBox4.Text = getpreco;

                //Marcas a quantidade inicial de cartas
                quantidade = Convert.ToInt32(textBox3.Text);

               
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            //Filtrar a cor branca
            filtrarcor = "branca";
            dataGridView1.DataSource = BLL.produtos.FiltrarCor(filtrarcor);
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            //Filtrar a cor azul
            filtrarcor = "azul";
            dataGridView1.DataSource = BLL.produtos.FiltrarCor(filtrarcor);
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            //Filtrar a cor preta
            filtrarcor = "preta";
            dataGridView1.DataSource = BLL.produtos.FiltrarCor(filtrarcor);
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            //Filtrar a cor vermelha
            filtrarcor = "vermelha";
            dataGridView1.DataSource = BLL.produtos.FiltrarCor(filtrarcor);
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            //Filtrar a cor verde
            filtrarcor = "verde";
            dataGridView1.DataSource = BLL.produtos.FiltrarCor(filtrarcor);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            //Inserir novo tipo
            if (MessageBox.Show("Deseja realmente inserir um novo tipo?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int InsertTipo = BLL.produtos.InsertTipo(Tipo.Text);
                DataTable tipo = BLL.produtos.LoadTipos();
                for (int i = 0; i != tipo.Rows.Count; i++)
                {
                    string n2 = Convert.ToString(tipo.Rows[i]["Tipo"]);
                    Tipo.Items.Add(n2);
                }
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            //Filtrar o custo da carta 0
            filtrarmana = "0";
            dataGridView1.DataSource = BLL.produtos.FiltrarMana(filtrarmana);
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            //Filtrar o custo da carta 1
            filtrarmana = "1";
            dataGridView1.DataSource = BLL.produtos.FiltrarMana(filtrarmana);
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            //Filtrar o custo da carta 2
            filtrarmana = "2";
            dataGridView1.DataSource = BLL.produtos.FiltrarMana(filtrarmana);
        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            //Filtrar o custo da carta 3
            filtrarmana = "3";
            dataGridView1.DataSource = BLL.produtos.FiltrarMana(filtrarmana);
        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {
            //Filtrar o custo da carta 4
            filtrarmana = "4";
            dataGridView1.DataSource = BLL.produtos.FiltrarMana(filtrarmana);
        }

        private void pictureBox22_Click(object sender, EventArgs e)
        {
            //Filtrar o custo da carta 5
            filtrarmana = "5";
            dataGridView1.DataSource = BLL.produtos.FiltrarMana(filtrarmana);
        }

        private void pictureBox23_Click(object sender, EventArgs e)
        {
            //Filtrar o custo da carta 6
            filtrarmana = "6";
            dataGridView1.DataSource = BLL.produtos.FiltrarMana(filtrarmana);
        }

        private void pictureBox24_Click(object sender, EventArgs e)
        {
            //Filtrar o custo da carta 7
            filtrarmana = "7";
            dataGridView1.DataSource = BLL.produtos.FiltrarMana(filtrarmana);
        }

        private void pictureBox25_Click(object sender, EventArgs e)
        {
            //Filtrar o custo da carta 8
            filtrarmana = "8";
            dataGridView1.DataSource = BLL.produtos.FiltrarMana(filtrarmana);
        }

        private void pictureBox26_Click(object sender, EventArgs e)
        {
            //Filtrar o custo da carta 9
            filtrarmana = "9";
            dataGridView1.DataSource = BLL.produtos.FiltrarMana(filtrarmana);
        }

        private void pictureBox27_Click(object sender, EventArgs e)
        {
            //Filtrar o custo da carta 10+
            filtrarmana = "10+";
            dataGridView1.DataSource = BLL.produtos.FiltrarMana(filtrarmana);
        }

        private void Cor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        
        
        
        
    }
}
