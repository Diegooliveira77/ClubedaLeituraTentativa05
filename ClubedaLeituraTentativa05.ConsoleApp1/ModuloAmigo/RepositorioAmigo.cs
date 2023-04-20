using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubedaLeituraTentativa05.ConsoleApp1.ModuloAmigo
{
    public class RepositorioAmigo
    {
        private ArrayList listaAmigos;
        private int contadorAmigos = 0;

        public RepositorioAmigo(ArrayList lista)
        {
            listaAmigos = lista;
        }

        public void Inserir(Amigo amigo)
        {
            contadorAmigos++;

            amigo.id = contadorAmigos;

            listaAmigos.Add(amigo);
        }

        public void Editar(int id, Amigo amigoAtualizado)
        {
            Amigo amigo = SelecionarPorId(id);

            amigo.nome = amigoAtualizado.nome;
            amigo.nomeResponsavel = amigoAtualizado.nomeResponsavel;
            amigo.telefone = amigoAtualizado.telefone;
            amigo.endereco = amigoAtualizado.endereco;
        }

        public void Excluir(int id)
        {
            Amigo amigo = SelecionarPorId(id);

            listaAmigos.Remove(amigo);
        }

        public Amigo SelecionarPorId(int id)
        {
            Amigo amigoSelecionado = null;

            foreach (Amigo c in listaAmigos)
            {
                if (c.id == id)
                {
                    amigoSelecionado = c;
                    break;
                }
            }

            return amigoSelecionado;
        }

        public ArrayList SelecionarTodos()
        {
            return listaAmigos;
        }


    }
}
