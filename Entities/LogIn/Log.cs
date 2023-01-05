using ByteBank.Entities;
using ByteBank.Entities.NewRegister;

namespace ByteBank.Entities.LogIn {
    public class Log {
        public List<string> cpfs = new List<string>();
        public List<string> titulares = new List<string>();
        public List<string> senhas = new List<string>();
        public List<double> saldos = new List<double>();

        ClassFinalizer finalizer = new();

        //Método que realiza a verificação de login na conta de usuário
        public void LogIn( List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos ) {
            Console.Write("CPF: ");
            string CpfDotitular = Console.ReadLine();
            Console.Write("Senha: ");
            string senhaDeLogin = Console.ReadLine();

            int indexCpfParaLogar = cpfs.FindIndex(cpf => cpf == CpfDotitular);
            int indexSenhaParaLogar = senhas.FindIndex(senha => senha == senhaDeLogin);

            if (indexCpfParaLogar == -1 || indexSenhaParaLogar == -1) {
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("Não é possível exibir esta conta");
                Console.WriteLine("MOTIVO: Conta não encontrada");
            }
            else {
                OptionAlteracao(indexCpfParaLogar, cpfs, titulares, senhas, saldos);
            }
        }

        //Menu de opções de alterações possíveis para usuários cadastrados
        static void Options() {
            Console.WriteLine("Digite a opção desejada: ");
            Console.WriteLine("1 - Exibir meus Dados");
            Console.WriteLine("2 - Alterar dados");
            Console.WriteLine("3 - Alterar Senha");
            Console.WriteLine("4 - Depositar");
            Console.WriteLine("5 - Sacar");
            Console.WriteLine("6 - Tranferir");
            Console.WriteLine("7 - Excluir conta");
            Console.WriteLine("0 - Para voltar ao menu inicial");
        }

        //Método que disponibiliza e recebe a opção do menu desejada pelo usuário.
        void OptionAlteracao( int indexCpfParaLogar, List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos ) {
            int option;
            do {
                Options();
                option = (int.Parse(Console.ReadLine()));
                switch (option) {
                    case 1:
                        ApresentarUsuario(indexCpfParaLogar, cpfs, titulares, saldos);
                        break;
                    case 2:
                        AlterarCPF(indexCpfParaLogar, cpfs);
                        AlterarTitular(indexCpfParaLogar, titulares);
                        break;
                    case 3:
                        AlterarSenha(indexCpfParaLogar, senhas);
                        break;
                    case 4:
                        DepositarSaldo(indexCpfParaLogar, titulares, saldos);
                        break;
                    case 5:
                        SacarSaldo(indexCpfParaLogar, titulares, saldos);
                        break;
                    case 6:
                        TransferirValoresEntreContas(indexCpfParaLogar, cpfs, titulares, saldos);
                        break;
                    case 7:
                        DeletarUsuario(indexCpfParaLogar, cpfs, titulares, senhas, saldos);
                        option = 0;
                        break;
                }
                if (option != 0) { finalizer.Finalizer(); }
            } while (option != 0);

            //Método que realiza a apresentação de dados do usuário logado
            void ApresentarUsuario( int indexCpfParaLogar, List<string> cpfs, List<string> titulares, List<double> saldos ) {
                if (indexCpfParaLogar == -1) {
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("Não é possível exibir esta conta");
                    Console.WriteLine("MOTIVO: Conta não encontrada");

                }
                else {
                    Console.WriteLine($"CPF = {cpfs[indexCpfParaLogar]} | Titular = {titulares[indexCpfParaLogar]} | Saldo = R$ {saldos[indexCpfParaLogar].ToString("C")}");
                }
            }

            //Método que realiza a alteração do campo CPF
            void AlterarCPF( int indexCpfParaLogar, List<string> cpfs ) {
                Console.WriteLine("Digite o novo CPF: ");
                cpfs[indexCpfParaLogar] = Console.ReadLine();
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("CPF alterado com sucesso!");
                Console.WriteLine("-----------------------------------");
            }

            //Método que realiza a alteração do nome do titular da conta
            void AlterarTitular( int indexCpfParaLogar, List<string> titulares ) {
                Console.WriteLine("Digite o novo Titular: ");
                titulares[indexCpfParaLogar] = Console.ReadLine();
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("Titular alterado com sucesso!");
            }

            //Método que realiza a alteração da senha cadastrada para o usuário que estiver logado
            void AlterarSenha( int indexCpfParaLogar, List<string> senhas ) {
                Console.WriteLine("Favor confirmar senha atual: ");
                string confirmaSenha = Console.ReadLine();
                if (confirmaSenha == senhas[indexCpfParaLogar]) {
                    Console.WriteLine("Digite a nova Senha: ");
                    senhas[indexCpfParaLogar] = Console.ReadLine();
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("Senha alterado com sucesso!");
                }
                else {
                    Console.WriteLine("Senha incorreta! Favor tentar novamente.");
                }
            }

            //Método que realiza o depósito de um determinado valor na conta do usuário que estiver logado
            void DepositarSaldo( int indexCpfParaLogar, List<string> titulares, List<double> saldos ) {
                Console.Clear();
                Console.WriteLine($"Olá {titulares[indexCpfParaLogar]}!");
                Console.WriteLine();
                Console.WriteLine("Digite o valor de depósito: ");
                double valorDeposito = double.Parse(Console.ReadLine());
                saldos[indexCpfParaLogar] += valorDeposito;
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("Depósito realizado com sucesso!");
            }

            //Método que realiza o saque de um determinado valor na conta do usuário que estiver logado
            void SacarSaldo( int indexCpfParaLogar, List<string> titulares, List<double> saldos ) {
                Console.Clear();
                Console.WriteLine($"Olá {titulares[indexCpfParaLogar]}!");

                Console.WriteLine("Digite o valor de Saque: ");
                double valorSaque = double.Parse(Console.ReadLine());
                if (saldos[indexCpfParaLogar] < valorSaque) {
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("Saldo insuficiente");
                }
                else {
                    saldos[indexCpfParaLogar] -= valorSaque;
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("Saque realizado com sucesso!");
                }
            }

            //Método que realiza a transferência de valores entre contas cadastradas, retirando o valor desejado da conta do suário que estiver logado
            void TransferirValoresEntreContas( int indexCpfParaLogar, List<string> cpfs, List<string> titulares, List<double> saldos ) {

                Console.Clear();
                Console.WriteLine($"Olá {titulares[indexCpfParaLogar]}!");

                int confirmacao;

                do {
                    Console.Clear();
                    Console.Write("Digite o cpf da conta que receberá o valor: ");
                    string cpfParaTransferir = Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine($"Favor confirmar se este é o CPF desejado: ");
                    Console.WriteLine();
                    Console.WriteLine($"{cpfParaTransferir}");
                    Console.WriteLine();
                    Console.WriteLine("Se SIM, digite 1, se NÃO digite 2");
                    Console.WriteLine("Para cancelar esta operação, digite 0");
                    confirmacao = int.Parse(Console.ReadLine());
                    switch (confirmacao) {
                        case 0:
                            Console.Clear();
                            Console.WriteLine("-----------------------------------");
                            Console.WriteLine("Operação cancelada!");
                            break;

                        case 1:
                            int indexParaTransferir = cpfs.FindIndex(cpf => cpf == cpfParaTransferir);

                            if (indexParaTransferir == -1) {
                                Console.WriteLine("-----------------------------------");
                                Console.WriteLine("MOTIVO: Conta não encontrada");
                            }
                            else {
                                Console.WriteLine();
                                Console.WriteLine($"Qual o valor que deseja tranferir para {titulares[indexParaTransferir]}: ");
                                double valorTranferencia = double.Parse(Console.ReadLine());
                                if (saldos[indexCpfParaLogar] >= valorTranferencia) {
                                    saldos[indexCpfParaLogar] -= valorTranferencia;
                                    saldos[indexParaTransferir] += valorTranferencia;
                                    Console.WriteLine();
                                    Console.WriteLine("Tranferência realizada com sucesso!");
                                }
                                else {
                                    Console.WriteLine();
                                    Console.WriteLine("Saldo insuficiente para transferência");
                                }
                                confirmacao = 0;
                            }
                            break;
                    }
                } while (confirmacao != 0);

            }

            //Método que realiza a remoção da conta do usuário logado da base de dados de cadastros
            void DeletarUsuario( int indexCpfParaDeletar, List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos ) {

                int indexParaDeletar = indexCpfParaLogar;

                if (indexParaDeletar == -1) {
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("Não foi possível deletar esta conta de usuário");
                    Console.WriteLine("MOTIVO: Conta não encontrada.");
                }
                else if (saldos[indexParaDeletar] > 0) {
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("Não foi possível deletar esta conta de usuário");
                    Console.WriteLine("MOTIVO: Conta possui saldo POSITIVO. É necessário antes zerar esta conta");
                }
                else {
                    cpfs.RemoveAt(indexParaDeletar);
                    titulares.RemoveAt(indexParaDeletar);
                    senhas.RemoveAt(indexParaDeletar);
                    saldos.RemoveAt(indexParaDeletar);

                    Console.Clear();
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("Conta deletada com sucesso!");
                    Console.WriteLine("-----------------------------------");
                }

            }
        }
    }
}
