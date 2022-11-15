using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadinhoDaSacanagem
{
    public class Produto
    {
        public Produto(int numero, String nome, double preco, String validade, int quantidade)
        {
            Numero = numero;
            Nome = nome;
            Preco = preco;
            Validade = validade;
            Quantidade = quantidade;
        }

        public int Numero{ get; set; }

        public String Nome{ get; set; }

        public double Preco { get; set; }

        public String Validade { get; set; }

        public int Quantidade { get; set; }

    }
}