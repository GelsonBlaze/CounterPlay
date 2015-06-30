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
    
    public partial class GerirFuncionarios : Form
    {
        bool combo1 = false;
        bool combo2 = true;
        bool validar = true;
        string id;
        Image img;

        public GerirFuncionarios()
        {
            InitializeComponent();
        }
 
        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Admin.getopengerirfuncionario = "0";
            this.Close();   
        }
        
        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox1.Image = ((System.Drawing.Image)(Properties.Resources.minimizar_2));
        }
        
        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox1.Image = ((System.Drawing.Image)(Properties.Resources.minimizar_1));
        }
        
        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            this.pictureBox1.Image = ((System.Drawing.Image)(Properties.Resources.minimizar_2));
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox2.Image = ((System.Drawing.Image)(Properties.Resources.fechar_2));
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox2.Image = ((System.Drawing.Image)(Properties.Resources.fechar_1));
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {

            this.pictureBox2.Image = ((System.Drawing.Image)(Properties.Resources.fechar_2));
        }
        //AdicionarFuncionario Icon Glow
        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox4.Image = ((System.Drawing.Image)(Properties.Resources.adicionar_funcionario_2));
        }
        //AdicionarFuncionario Icon Glow
        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            this.pictureBox4.Image = ((System.Drawing.Image)(Properties.Resources.adicionar_funcionario_2));
        }
        //AdicionarFuncionario Icon Normal
        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox4.Image = ((System.Drawing.Image)(Properties.Resources.adicionar_funcionario_1));
        }
        //AtualizarCliente Icon Glow
        private void pictureBox5_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox5.Image = ((System.Drawing.Image)(Properties.Resources.actualizar_funcionario_2));
        }
        //AtualizarCliente Icon Glow
        private void pictureBox5_MouseHover(object sender, EventArgs e)
        {
            this.pictureBox5.Image = ((System.Drawing.Image)(Properties.Resources.actualizar_funcionario_2));
        }
        //AtualizarCliente Icon Normal
        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox5.Image = ((System.Drawing.Image)(Properties.Resources.actualizar_funcionario_1));
        }
        //Search Icon Glow
        private void pictureBox6_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox6.Image = ((System.Drawing.Image)(Properties.Resources.Searchglow));
        }
        //Search Icon Glow
        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            this.pictureBox6.Image = ((System.Drawing.Image)(Properties.Resources.Searchglow));
        }
        //Search Icon Normal
        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox6.Image = ((System.Drawing.Image)(Properties.Resources.Search));
        }
        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string file = openFileDialog1.FileName.ToString();
            img = Image.FromFile(file, true);
            pictureBox3.Image = img;
        }

        private void GerirFuncionarios_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BLL.users.LoadFuncionarios();
            if (combo1 == true)
            {
                comboBox1.Text = "Admin";
            }
            else
            {
                comboBox1.Text = "Normal";
            }
            if (combo2 == true)
            {
                comboBox2.Text = "Ativo";
            }
            else
            {
                comboBox2.Text = "Inativo";
            }



        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            
            //Load da tabela dos funcionários
            DataTable dt = BLL.users.LoadFuncionarios();
            if (comboBox1.Text=="Admin")
            {
                combo1 = true;
            }
            else
            {
                combo1 = false;
            }
            if (comboBox2.Text == "Ativo")
            {
                combo2 = true;
            }
            else
            {
                combo2 = false;
            }
            //VALIDAÇÕES
            //Username não preenchido
            if (textBox1.Text == "")
            {
                errorProviderUser1.SetError(textBox1, "Este campo é obrigatório");
                validar = false;
            }
            else 
            {
                errorProviderUser1.Dispose();
            }
                //Username já existe
            DataTable verify = BLL.users.verificarUsername(textBox1.Text);
            if (verify.Rows.Count > 0)
            {
                errorProviderUser2.SetError(textBox1, "Este utilizador já existe");
                validar = false;
            }
            else
            {
                errorProviderUser2.Dispose();
            }

                //Password Não Preenchida
                if (textBox2.Text == "")
                {
                        errorProviderPassword1.SetError(textBox2, "Este campo é obrigatório");
                        validar = false;
                }
                else
                {
                    errorProviderPassword1.Dispose();
                }
                //Confirmação de password está errada
            if ( textBox10.Text != textBox2.Text)
                {
                    errorProviderPassword2.SetError(textBox10, "As palavras-passe não coincidem");                 
                        validar = false;
                }
                else
                {
                errorProviderPassword2.Dispose();
                }


            //Nome não preenchido
            if (textBox3.Text == "")
            {
                errorProviderNome.SetError(textBox3, "Este campo é obrigatório");             
                    validar = false;
        
            }
            else
            {
                errorProviderNome.Dispose();
            }
            //Morada não preenchida
            if (textBox4.Text == "")
            {
                errorProviderMorada.SetError(textBox4, "Este campo é obrigatório");              
                    validar = false;    
            }
            else
            {
                errorProviderMorada.Dispose();
            }
            //Contacto não preenchido
            if (textBox6.Text == "" || textBox6.Text == "+351...00254...")
            {
                errorProviderContacto.SetError(textBox6, "Este campo é obrigatório");
                validar = false;
            }
            else
            {
                errorProviderContacto.Dispose();
            }
            //NIB não preenchido
            if (textBox7.Text == "")
            {
                errorProviderNIB1.SetError(textBox7, "Este campo é obrigatório");
                validar = false;
            }
            else
            {
                errorProviderNIB1.Dispose();
            }
            //NIB existente
            DataTable verify3 = BLL.users.verificarNIB(textBox7.Text);
            if (verify3.Rows.Count > 0)
            {
                errorProviderNIB2.SetError(textBox7, "Este NIB já existe");
                validar = false;
            }
            else
            {
                errorProviderNIB2.Dispose();
            }
            //NIF existente
            DataTable verify2 = BLL.users.verificarNIF(textBox8.Text);
            if (verify2.Rows.Count > 0)
            {
                errorProviderNIF1.SetError(textBox8, "Este NIF já existe");
                validar = false;
            }
            else
            {
                errorProviderNIF1.Dispose();
            }
            //NIF não preenchido
            if(textBox8.Text == "")
            {
                errorProviderNIF2.SetError(textBox8, "Este campo é obrigatório");
                validar = false;
            }
            else
            {
                errorProviderNIF2.Dispose();
            }
            if (validar == true)
            {
                if (MessageBox.Show("Deseja realmente adicionar este funcionário?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                //Adicionar funcionario
                int adicionarfuncionario = BLL.users.InsertFuncionario(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, combo1, combo2, true);
                dataGridView1.DataSource = BLL.users.LoadFuncionarios();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                textBox10.Text = "";
                }
                MessageBox.Show("Funcionário adicionado com sucesso!");
                errorProviderUser1.Dispose();
                textBox6.ForeColor = Color.Gray;
                textBox6.Text = "+351...00254...";
            }
            else
            {
                validar = true;
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            pictureBox5.Enabled = true;
            pictureBox4.Enabled = false;
            textBox1.Enabled = false;
            textBox8.Enabled = false;
            textBox1.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            //DataTable dt = BLL.users.LoadFuncionarios();
            id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            string dt1 = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            string dt2 = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            if (dt1 == "True")
            {
                comboBox1.Text = "Admin";
            }
            else
            {
                comboBox1.Text = "Normal";
            }
            if (dt2 == "True")
            {
                comboBox2.Text = "Ativo";
            }
            else
            {
                comboBox2.Text = "Inativo";
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            pictureBox4.Enabled = true;
            pictureBox5.Enabled = false;
            textBox1.Enabled = true;
            textBox8.Enabled = true;

            if (comboBox1.Text == "Admin")
            {
                combo1 = true;
            }
            else
            {
                combo1 = false;
            }
            if (comboBox2.Text == "Ativo")
            {
                combo2 = true;
            }
            else
            {
                combo2 = false;
            }

            //Validações
            //Username não preenchido

            //Nome não preenchido
            if (textBox3.Text == "")
            {
                errorProviderNome.SetError(textBox3, "Este campo é obrigatório");
                validar = false;

            }
            else
            {
                errorProviderNome.Dispose();
            }
            //Morada não preenchida
            if (textBox4.Text == "")
            {
                errorProviderMorada.SetError(textBox4, "Este campo é obrigatório");
                validar = false;
            }
            else
            {
                errorProviderMorada.Dispose();
            }
            //Contacto não preenchido
            if (textBox6.Text == "" || textBox6.Text == "+351...00254...")
            {
                errorProviderContacto.SetError(textBox6, "Este campo é obrigatório");
                validar = false;
            }
            else
            {
                errorProviderContacto.Dispose();
            }
            

            if (validar == true)
            {
                if (textBox2.Text == "")
                {
                    if (MessageBox.Show("Deseja realmente alterar os dados deste funcionário?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int retorno = BLL.users.UpdateFuncionarioSP(id, textBox1.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, combo1, combo2);
                        dataGridView1.DataSource = BLL.users.LoadFuncionarios();
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                        textBox6.Text = "";
                        textBox7.Text = "";
                        textBox8.Text = "";
                        textBox10.Text = "";
                      
                    }
                }
                else
                {
                    if (MessageBox.Show("Deseja realmente alterar os dados deste funcionário?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int retorno = BLL.users.UpdateFuncionarioCP(id, textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, combo1, combo2);
                        dataGridView1.DataSource = BLL.users.LoadFuncionarios();
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                        textBox6.Text = "";
                        textBox7.Text = "";
                        textBox8.Text = "";
                        textBox10.Text = "";
                    }
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        
        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            //Filtrar funcionários
            dataGridView1.DataSource = BLL.users.FiltrarFuncionarios(textBox9.Text, textBox9.Text, textBox9.Text, textBox9.Text, textBox9.Text, textBox9.Text, textBox9.Text, textBox9.Text);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_Click(object sender, EventArgs e)
        {
            textBox6.ForeColor = Color.Black;
            textBox6.Text = "";
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar != 8 && (int)e.KeyChar < 48 && (int)e.KeyChar != 43 || (int)e.KeyChar > 57 && (int)e.KeyChar != 43)
            e.Handled = true;

        }
        
        

        

        

        
    }
}
