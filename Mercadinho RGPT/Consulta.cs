using MercadinhoDaSacanagem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mercadinho_RGPT
{
    public partial class Consulta : Form
    {
        ComandosBanco cmd = new ComandosBanco();
        bool alterando = false;

        public Consulta()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            try
            {
                Produto produto = cmd.Consultar(int.Parse(txbCode.Text));
                txbNome.Text = cmd.TemNoBanco(int.Parse(txbCode.Text)) ?  produto.Nome : "Produto não encontrado";
                txbPreco.Text = produto.Preco.ToString();
                txbValidade.Text = produto.Validade;
                txbQuant.Text = produto.Quantidade.ToString();
            }
            catch
            {
                MessageBox.Show("Insira um número de conta válido");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Tem certeza de que deseja excluir esse produto?", "Tem certeza?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)

                {
                    throw new Exception();
                }
                else
                {
                    cmd.Excluir(int.Parse(txbCode.Text));
                    MessageBox.Show("Produto excluído.");
                }
            }
            catch
            {
                MessageBox.Show("Erro ao excluir.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try { 
                if(cmd.TemNoBanco(int.Parse(txbCode.Text)))
                {
                    if (!this.alterando) { 
                        txbCode.Enabled = false;
                        txbNome.Enabled = true;
                        txbPreco.Enabled = true;
                        txbValidade.Enabled = true;
                        txbQuant.Enabled = true;
                        button2.Enabled = false;
                        button4.Enabled = false;
                    }
                    else
                    {
                        Produto produto = new Produto(int.Parse(txbCode.Text), txbNome.Text, double.Parse(txbPreco.Text), txbValidade.Text, int.Parse(txbQuant.Text));
                        cmd.Alterar(produto);
                        MessageBox.Show("Produto alterado");
                        txbCode.Enabled = true;
                        txbNome.Enabled = false;
                        txbPreco.Enabled = false;
                        txbValidade.Enabled = false;
                        txbQuant.Enabled = false;
                        button2.Enabled = true;
                        button4.Enabled = true;
                    }
                    this.alterando = !this.alterando;
                }
                else
                {
                    MessageBox.Show("Primeiro, defina o produto");
                }
            }
             catch{
                //MessageBox.Show("Insira um número de conta válido");
            }
        }
    }
}
