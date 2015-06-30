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
    public partial class AddCollection : Form
    {
    
        string id;
        

        public AddCollection()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            int adicionarcolecao = BLL.produtos.InsertColecao(textBox1.Text);
            textBox1.Text = "";
            comboBox1.Items.Clear();
            DataTable dt = BLL.produtos.LoadColecoes();

            for (int i = 0; i != dt.Rows.Count; i++)
            {
                string n1 = Convert.ToString(dt.Rows[i][1]);
                comboBox1.Items.Add(n1);
            }
        
          
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            
        
        }

        private void AddCollection_Load(object sender, EventArgs e)
        {

            DataTable dt = BLL.produtos.LoadColecoes();


            for (int i = 0; i != dt.Rows.Count; i++)
            {
                string n1 = Convert.ToString(dt.Rows[i][1]);
                comboBox1.Items.Add(n1);
            }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void comboBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = comboBox1.Text;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
