using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubedaLeituraTentativa05.ConsoleApp1.ModuloCaixa
{
    public class RepositorioCaixa  
    {
        
        private ArrayList listaCaixas;

        public RepositorioCaixa(ArrayList lista)
        {
            listaCaixas = lista;
        }

        private int contadorCaixas = 0;

        public void Inserir(Caixa caixa)
        {
            contadorCaixas++;

            caixa.id = contadorCaixas;

            listaCaixas.Add(caixa);
        }

        public ArrayList SelecionarTodos()
        {
            return listaCaixas;
        }

        public void Editar(int id, Caixa caixaAtualizada)
        {
            Caixa caixaSelecionada = SelecionarPorId(id);

            caixaSelecionada.cor = caixaAtualizada.cor;
            caixaSelecionada.etiqueta = caixaAtualizada.etiqueta;
        }

        public void Excluir(int id)
        {
            Caixa caixaSelecionada = SelecionarPorId(id);

            listaCaixas.Remove(caixaSelecionada);
        }

        public Caixa SelecionarPorId(int id)
        {
            Caixa caixaSelecionada = null;

            foreach (Caixa c in listaCaixas)
            {
                if (c.id == id)
                {
                    caixaSelecionada = c;
                    break;
                }
            }

            return caixaSelecionada;
        }
    }
}

