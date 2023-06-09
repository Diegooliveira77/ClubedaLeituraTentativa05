﻿using ClubedaLeituraTentativa05.ConsoleApp1.Compartilhado;
using ClubedaLeituraTentativa05.ConsoleApp1.ModuloAmigo;
using ClubedaLeituraTentativa05.ConsoleApp1.ModuloRevista;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubedaLeituraTentativa05.ConsoleApp1.Emprestimo
{
    public class TelaEmprestimo : Tela
    {
        private RepositorioEmprestimo repositorioEmprestimo;

        private TelaRevista telaRevista;
        private RepositorioRevista repositorioRevista;

        private RepositorioAmigo repositorioAmigo;
        private TelaAmigo telaAmigo;

        public TelaEmprestimo(
            RepositorioEmprestimo repositorioEmprestimo,
            TelaRevista telaRevista,
            RepositorioRevista repositorioRevista,
            TelaAmigo telaAmigo,
            RepositorioAmigo repositorioAmigo)
        {
            this.repositorioEmprestimo = repositorioEmprestimo;
            this.telaRevista = telaRevista;
            this.repositorioRevista = repositorioRevista;
            this.telaAmigo = telaAmigo;
            this.repositorioAmigo = repositorioAmigo;
        }

        public string ApresentarMenu()
        {
            Console.Clear();

            Console.WriteLine("Cadastro de Emprestimos \n");

            Console.WriteLine("Digite 1 para Abrir Novo Emprestimo");
            Console.WriteLine("Digite 2 para Visualizar Emprestimos");
            Console.WriteLine("Digite 3 para Visualizar Emprestimos no Mês");
            Console.WriteLine("Digite 4 para Visualizar Emprestimos em Aberto no Dia");
            Console.WriteLine("Digite 5 para Fechar Emprestimos");
            Console.WriteLine("Digite 6 para Editar Emprestimos");
            Console.WriteLine("Digite 7 para Excluir Emprestimos");

            Console.WriteLine("Digite s para Sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        public void AbrirNovoEmprestimo()
        {
            MostrarCabecalho("Cadastro de Empréstimos", "Abrindo um novo emprestimo...");

            Emprestimo emprestimo = ObterEmprestimo();

            repositorioEmprestimo.Inserir(emprestimo);

            MostrarMensagem("Empréstimo aberto com sucesso!", ConsoleColor.Green);
        }

        public void FecharEmprestimo()
        {
            MostrarCabecalho("Cadastro de Empréstimos", "Fechando um empréstimo...");

            

            ArrayList emprestimosEmAberto = repositorioEmprestimo.SelecionarEmprestimosEmAberto();

            if (emprestimosEmAberto.Count == 0)
            {
                MostrarMensagem("Nenhuma empréstimo cadastrado", ConsoleColor.DarkYellow);
                return;
            }

            MostrarTabela(emprestimosEmAberto);


            Console.Write("Digite o id do Empréstimo: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Emprestimo emprestimo = repositorioEmprestimo.SelecionarPorId(id);

            emprestimo.Fechar();

            MostrarMensagem("Empréstimo fechado com sucesso!", ConsoleColor.Green);
        }

        public void EditarEmprestimos()
        {
            MostrarCabecalho("Cadastro de Empréstimos", "Editando um empréstimo já cadastrado...");

            VisualizarEmprestimos(false);

            Console.WriteLine();

            Console.Write("Digite o id do empréstimo: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Emprestimo emprestimoAtualizado = ObterEmprestimo();

            repositorioEmprestimo.Editar(id, emprestimoAtualizado);

            MostrarMensagem("Empréstimo editado com sucesso!", ConsoleColor.Green);
        }

        public void ExcluirEmprestimos()
        {
            MostrarCabecalho("Cadastro de Empréstimos", "Excluindo um empréstimo já cadastrado...");

            VisualizarEmprestimos(false);

            Console.WriteLine();

            Console.Write("Digite o id do empréstimo: ");
            int id = Convert.ToInt32(Console.ReadLine());

            repositorioEmprestimo.Excluir(id);

            MostrarMensagem("Empréstimo excluído com sucesso!", ConsoleColor.Green);
        }

        public void VisualizarEmprestimos(bool mostrarCabecalho)
        {
            if (mostrarCabecalho)
                MostrarCabecalho("Cadastro de Empréstimos", "Visualizando empréstimos já cadastrados...");

            ArrayList emprestimos = repositorioEmprestimo.SelecionarTodos();

            if (emprestimos.Count == 0)
            {
                MostrarMensagem("Nenhuma empréstimo cadastrado", ConsoleColor.DarkYellow);
                return;
            }

            MostrarTabela(emprestimos);
        }

        public void VisualizarEmprestimosEmAbertoNoDia()
        {
            MostrarCabecalho("Cadastro de Empréstimos", "Visualizando empréstimos em aberto no dia...");

            Console.Write("Digite a data: ");
            DateTime data = Convert.ToDateTime(Console.ReadLine());

            ArrayList emprestimosEmAberto = repositorioEmprestimo.SelecionarEmprestimosEmAbertoNoDia(data);

            if (emprestimosEmAberto.Count == 0)
            {
                MostrarMensagem("Nenhuma empréstimo cadastrado", ConsoleColor.DarkYellow);
                return;
            }

            MostrarTabela(emprestimosEmAberto);
        }

        public void VisualizarEmprestimosNoMes()
        {
            MostrarCabecalho("Cadastro de Empréstimos", "Visualizando empréstimos no mês...");

            Console.Write("Digite o número o Mês e o Ano: ");

            string[] mesEhAno = Console.ReadLine().Split("/");

            int mes = Convert.ToInt32(mesEhAno[0]);
            int ano = Convert.ToInt32(mesEhAno[1]);

            ArrayList emprestimosDoMes = repositorioEmprestimo.SelecionarEmprestimosDoMes(mes, ano);

            if (emprestimosDoMes.Count == 0)
            {
                MostrarMensagem("Nenhuma empréstimo cadastrado", ConsoleColor.DarkYellow);
                return;
            }

            MostrarTabela(emprestimosDoMes);
        }

        private void MostrarTabela(ArrayList emprestimos)
        {
            Console.WriteLine();

            Console.WriteLine("{0, -10} | {1, -40} | {2, -20} | {3, -20} | {4, -10}", "Id", "Revista", "Amigo", "Data do Empréstimo", "Status");

            Console.WriteLine("---------------------------------------------------------------------------------------------");

            foreach (Emprestimo emprestimo in emprestimos)
            {
                string status = emprestimo.estaAberto ? "Aberto" : "Fechado";

                Console.WriteLine("{0, -10} | {1, -40} | {2, -20} | {3, -20} | {4, -10}",
                    emprestimo.id, emprestimo.revista.titulo, emprestimo.amiguinho.nome, emprestimo.dataEmprestimo, status);
            }
        }

        private Emprestimo ObterEmprestimo()
        {
            
            telaRevista.VisualizarRevistas(false);

            
            Console.Write("Digite o id da revista: ");
            int idRevista = Convert.ToInt32(Console.ReadLine());

            Revista revista = repositorioRevista.SelecionarPorId(idRevista);

            

            telaAmigo.VisualizarAmigos(false);

            
            Console.Write("Digite o id do amigo: ");
            int idEmprestimo = Convert.ToInt32(Console.ReadLine());

            Amigo amigo = repositorioAmigo.SelecionarPorId(idEmprestimo);

            
            Console.Write("Digite a data: ");
            DateTime dataEmprestimo = Convert.ToDateTime(Console.ReadLine());

            Emprestimo emprestimo = new Emprestimo(dataEmprestimo, revista, amigo);

            return emprestimo;
        }

    }
}
