using System;
using System.Globalization;
using System.Reflection;

namespace ByteBank
{
    public class Program
    {
        public static void Main(string[] args)
        {

            AcoesParaContasDeUsuarios acao = new AcoesParaContasDeUsuarios();

            List<string> cpfs = new List<string>();
            List<string> titulares = new List<string>();
            List<string> senhas = new List<string>();
            List<double> saldos = new List<double>();

            Console.WriteLine("Seja Bem Vindo ao ByteBank!");

            int option;

            do
            {
                acao.ShowMenu();
                option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 0:
                        Console.WriteLine("Estou encerrando o programa...");
                        break;
                    case 1:
                        acao.RegistrarNovoUsuario(cpfs, titulares, senhas, saldos);
                        break;
                    case 2:
                        acao.DeletarUsuario(cpfs, titulares, senhas, saldos);
                        break;
                    case 3:
                        acao.ListarTodasAsContas(cpfs, titulares, senhas, saldos);
                        break;
                    case 4:
                        acao.ApresentarUsuario(cpfs, titulares, saldos);
                        break;
                    case 5:
                        acao.ApresentarValorAcumulado(saldos);
                        break;
                    case 6:
                        acao.AlterarContaDeUsuario(cpfs, titulares, senhas, saldos);
                        break;
                }

            } while (option != 0);


        }

    }

}