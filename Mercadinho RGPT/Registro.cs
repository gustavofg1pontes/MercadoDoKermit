using MercadinhoDaSacanagem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mercadinho_RGPT
{
    public partial class Registro : Form
    {
        ComandosBanco cmd = new ComandosBanco();

        public Registro()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Registro_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Produto produto = new Produto(int.Parse(TxbCode.Text), txbNome.Text, float.Parse(txbPreco.Text), txbValidade.Text, int.Parse(txbQuant.Text));
                if (produto.Nome == "") throw new Exception();
                cmd.Adicionar(produto);
                MessageBox.Show("Produto registrado.");
            }
            catch(Exception err)
            {
                MessageBox.Show("Falha ao registrar. Verifique os campos novamente.");
            }
        }
    }
}
