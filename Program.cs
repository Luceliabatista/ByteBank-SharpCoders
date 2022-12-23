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
                        acao.RegistrarNovoUsuario(acao.cpfs, acao.titulares, acao.senhas, acao.saldos);
                        break;
                    case 2:
                        acao.DeletarUsuario(acao.cpfs, acao.titulares, acao.senhas, acao.saldos);
                        break;
                    case 3:
                        acao.ListarTodasAsContas(acao.cpfs, acao.titulares, acao.senhas, acao.saldos);
                        break;
                    case 4:
                        acao.ApresentarUsuario(acao.cpfs, acao.titulares, acao.saldos);
                        break;
                    case 5:
                        acao.ApresentarValorAcumulado(acao.saldos);
                        break;
                    case 6:
                        acao.AlterarContaDeUsuario(acao.cpfs, acao.titulares, acao.senhas, acao.saldos);
                        break;
                }

            } while (option != 0);

        }

    }

}