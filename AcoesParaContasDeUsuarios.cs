using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    internal class AcoesParaContasDeUsuarios
    {

        public List<string> cpfs = new List<string>();
        public List<string> titulares = new List<string>();
        public List<string> senhas = new List<string>();
        public List<double> saldos = new List<double>();

        public void ShowMenu()
        {
            Console.WriteLine("Digite a opção desejada: ");
            Console.WriteLine("1 - Inserir novo usuário");
            Console.WriteLine("2 - Deletar um usuário");
            Console.WriteLine("3 - Listar todas as contas registradas");
            Console.WriteLine("4 - Detalhes de um usuário");
            Console.WriteLine("5 - Total armazenado no banco");
            Console.WriteLine("6 - Manipular a conta");
            Console.WriteLine("0 - Para sair do programa");
        }

        public void optionAlteracao()
        {
            Console.WriteLine("Digite a opção desejada: ");
            Console.WriteLine("1 - Alterar CPF");
            Console.WriteLine("2 - Alterar Titular");
            Console.WriteLine("3 - Alterar Senha");
            Console.WriteLine("4 - Alterar Saldo");
        }

        public void AlterarContaDeUsuario(List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos)
        {
            Console.Write("Digite o cpf da conta que será alterada: ");
            string cpfParaAlterar = Console.ReadLine();
            int indexParaAlterar = cpfs.FindIndex(cpf => cpf == cpfParaAlterar);

            if (indexParaAlterar == -1)
            {
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("Não é possível exibir esta conta");
                Console.WriteLine("MOTIVO: Conta não encontrada");
                Console.WriteLine("-----------------------------------");
            }
            else
            {
                optionAlteracao();
                int option = (int.Parse(Console.ReadLine()));
                switch (option)
                {
                    case 1:
                        AlterarCPF(indexParaAlterar, cpfs);
                        break;
                    case 2:
                        AlterarTitular(indexParaAlterar, titulares);
                        break;
                    case 3:
                        AlterarSenha(indexParaAlterar, senhas);
                        break;
                    case 4:
                        AlterarSaldo(indexParaAlterar, saldos);
                        break;
                }
            }
        }

        public void AlterarCPF(int index, List<string> cpfs)
        {
            Console.WriteLine("Digite o novo CPF: ");
            cpfs[index] = Console.ReadLine();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("CPF alterado com sucesso!");
            Console.WriteLine("-----------------------------------");
        }
        public void AlterarTitular(int index, List<string> titulares)
        {
            Console.WriteLine("Digite o novo Titular: ");
            titulares[index] = Console.ReadLine();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Titular alterado com sucesso!");
            Console.WriteLine("-----------------------------------");
        }
        public void AlterarSenha(int index, List<string> senhas)
        {
            Console.WriteLine("Digite a nova Senha: ");
            senhas[index] = Console.ReadLine();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Senha alterado com sucesso!");
            Console.WriteLine("-----------------------------------");
        }
        public void AlterarSaldo(int index, List<double> saldos)
        {
            Console.WriteLine("Digite o novo Saldo: ");
            saldos[index] = double.Parse(Console.ReadLine());
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Saldo alterado com sucesso!");
            Console.WriteLine("-----------------------------------");
        }

        public void ListarTodasAsContas(List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos)
        {
            for (int i = 0; i < cpfs.Count; ++i)
            {
                Console.WriteLine("-----------------------------------");
                ApresentaConta(i, cpfs, titulares, saldos);
                Console.WriteLine("-----------------------------------");
            }
        }

        public void ApresentarUsuario(List<string> cpfs, List<string> titulares, List<double> saldos)
        {
            Console.Write("Digite o cpf: ");
            string cpfParaApresentar = Console.ReadLine();
            int indexParaApresentar = cpfs.FindIndex(cpf => cpf == cpfParaApresentar);

            if (indexParaApresentar == -1)
            {
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("Não é possível exibir esta conta");
                Console.WriteLine("MOTIVO: Conta não encontrada");
                Console.WriteLine("-----------------------------------");
            }
            else
            {
                Console.WriteLine("-----------------------------------");
                ApresentaConta(indexParaApresentar, cpfs, titulares, saldos);
                Console.WriteLine("-----------------------------------");
            }
        }

        public void ApresentaConta(int index, List<string> cpfs, List<string> titulares, List<double> saldos)
        {
            Console.WriteLine($"CPF = {cpfs[index]} | Titular = {titulares[index]} | Saldo = R$ {saldos[index].ToString("C")}");

        }

        public void RegistrarNovoUsuario(List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos)
        {
            Console.WriteLine("Digite o cpf: ");
            cpfs.Add(Console.ReadLine());
            Console.WriteLine("Digite o nome: ");
            titulares.Add(Console.ReadLine());
            Console.WriteLine("Digite a senha: ");
            senhas.Add(Console.ReadLine());
            Console.WriteLine("Digite seu saldo: ");
            saldos.Add(double.Parse(Console.ReadLine()));
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Novo usuário registrado com sucesso!");
            Console.WriteLine("-----------------------------------");
        }

        public void DeletarUsuario(List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos)
        {
            Console.Write("Digite o cpf: ");
            string cpfParaDeletar = Console.ReadLine();
            int indexParaDeletar = cpfs.FindIndex(d => d == cpfParaDeletar);
            cpfs.Remove(cpfParaDeletar);

            if (indexParaDeletar == -1)
            {
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("Não foi possível deletar este CPF");
                Console.WriteLine("MOTIVO: Conta não encontrada.");
                Console.WriteLine("-----------------------------------");
            }

            cpfs.Remove(cpfParaDeletar);
            titulares.RemoveAt(indexParaDeletar);
            senhas.RemoveAt(indexParaDeletar);
            saldos.RemoveAt(indexParaDeletar);

            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Conta deletada com sucesso!");
            Console.WriteLine("-----------------------------------");

        }

        public void ApresentarValorAcumulado(List<double> saldos)
        {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine($"Total acumulado no banco: {saldos.Sum().ToString("C")}");
            Console.WriteLine("-----------------------------------");
        }
    }
}
