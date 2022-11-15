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


        private void Registro_Load(object sender, EventArgs e)
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
                if (produto.Nome == "" || !Produto.validarData(produto.Validade)) throw new Exception();
                cmd.Adicionar(produto);
                MessageBox.Show("Produto registrado.");
            }
            catch(Exception err)
            {
                MessageBox.Show("Falha ao registrar. Verifique os campos novamente ou se já existe produto com o código.");
            }
        }
    }
}
