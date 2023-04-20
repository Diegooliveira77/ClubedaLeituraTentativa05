using ClubedaLeituraTentativa05.ConsoleApp1.ModuloCaixa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubedaLeituraTentativa05.ConsoleApp1.ModuloRevista
{
    public class Revista
    {
        public int id;
        public string titulo;
        public int edicao;
        public int ano;
        public Caixa caixa;

        public Revista(string titulo, int edicao, int ano, Caixa caixa)
        {
            this.titulo = titulo;
            this.edicao = edicao;
            this.ano = ano;
            this.caixa = caixa;
        }
    }
}

