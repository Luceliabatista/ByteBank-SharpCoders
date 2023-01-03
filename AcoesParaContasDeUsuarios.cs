using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
            Console.WriteLine("5 - Efetuar Tranferência de saldo");
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
                Console.WriteLine("Tecle Enter para voltar ao menu anterior");
                Console.ReadLine();
                Console.Clear();
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
                    case 5:
                        TransferirValoresEntreContas(indexParaAlterar, saldos);
                        break;
                }
            }
        }
        public void TransferirValoresEntreContas(int index, List<double> saldos)
        {
            Console.Write("Favor confirmar o cpf da conta que irá transferir o valor: ");
            string cpfParaAlterar = Console.ReadLine();
            int indexParaAlterar = cpfs.FindIndex(cpf => cpf == cpfParaAlterar);

            Console.Write("Digite o cpf da conta que receberá o valor: ");
            string cpfParaTransferir = Console.ReadLine();
            int indexParaTransferir = cpfs.FindIndex(cpf => cpf == cpfParaTransferir);

            if (indexParaTransferir == -1)
            {
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("MOTIVO: Conta não encontrada");
            }
            else
            {
                Console.WriteLine($"Qual o valor que deseja tranferir para {titulares[indexParaTransferir]}: ");
                double valorTranferencia = double.Parse(Console.ReadLine());
                if (saldos[indexParaAlterar] >= valorTranferencia)
                {
                    saldos[indexParaAlterar] -= valorTranferencia;
                    saldos[indexParaTransferir] += valorTranferencia;
                    Console.WriteLine("Tranferência realizada com sucesso!");
                }
                else
                {
                    Console.WriteLine("Saldo insuficiente para transferência");

                }
            }
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Tecle Enter para voltar ao menu anterior");
            Console.ReadLine();
            Console.Clear();
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
            Console.WriteLine("Tecle Enter para voltar ao menu anterior");
            Console.ReadLine();
            Console.Clear();
        }
        public void AlterarSenha(int index, List<string> senhas)
        {
            Console.WriteLine("Digite a nova Senha: ");
            senhas[index] = Console.ReadLine();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Senha alterado com sucesso!");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Tecle Enter para voltar ao menu anterior");
            Console.ReadLine();
            Console.Clear();
        }
        public void AlterarSaldo(int index, List<double> saldos)
        {
            Console.WriteLine("Digite o novo Saldo: ");
            saldos[index] = double.Parse(Console.ReadLine());
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Saldo alterado com sucesso!");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Tecle Enter para voltar ao menu anterior");
            Console.ReadLine();
            Console.Clear();
        }

        public void ListarTodasAsContas(List<string> cpfs, List<string> titulares, List<double> saldos)
        {
            if (cpfs.Count <= 0)
            {
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("Não há contas cadastradas até o momento.");
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("Tecle Enter para voltar ao menu anterior");
                Console.ReadLine();
                Console.Clear();
            }
            else
            {
                for (int i = 0; i < cpfs.Count; ++i)
                {
                    Console.WriteLine("-----------------------------------");
                    ApresentaConta(i, cpfs, titulares, saldos);
                }
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
            }
            else
            {
                Console.WriteLine("-----------------------------------");
                ApresentaConta(indexParaApresentar, cpfs, titulares, saldos);
            }
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Tecle Enter para voltar ao menu anterior");
            Console.ReadLine();
            Console.Clear();
        }

        public void ApresentaConta(int index, List<string> cpfs, List<string> titulares, List<double> saldos)
        {
            if (index == -1)
            {
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("Não foi possível deletar este CPF");
                Console.WriteLine("MOTIVO: Conta não encontrada.");
            }
            else
            {
                Console.WriteLine($"CPF = {cpfs[index]} | Titular = {titulares[index]} | Saldo = R$ {saldos[index].ToString("C")}");
            }
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Tecle Enter para voltar ao menu anterior");
            Console.ReadLine();
            Console.Clear();
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
            Console.WriteLine("Tecle Enter para voltar ao menu anterior");
            Console.ReadLine();
            Console.Clear();
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
                Console.WriteLine("Tecle Enter para voltar ao menu anterior");
                Console.ReadLine();
                Console.Clear();
            }

            cpfs.Remove(cpfParaDeletar);
            titulares.RemoveAt(indexParaDeletar);
            senhas.RemoveAt(indexParaDeletar);
            saldos.RemoveAt(indexParaDeletar);

            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Conta deletada com sucesso!");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Tecle Enter para voltar ao menu anterior");
            Console.ReadLine();
            Console.Clear();

        }

        public void ApresentarValorAcumulado(List<double> saldos)
        {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine($"Total acumulado no banco: {saldos.Sum().ToString("C")}");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Tecle Enter para voltar ao menu anterior");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
