using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        public Produto() { }

        public int Numero{ get; set; }

        public String Nome{ get; set; }

        public double Preco { get; set; }

        public String Validade { get; set; }

        public int Quantidade { get; set; }


        public static bool validarData(string data)
        {
            Regex r = new Regex(@"(\d{2}\/\d{2}\/\d{4})");
            return r.Match(data).Success;
        }

    }
}