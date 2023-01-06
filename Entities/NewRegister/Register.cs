using ByteBank.Entities;

namespace ByteBank.Entities.NewRegister
{
    public class Register
    {
        public List<string> cpfs = new List<string>();
        public List<string> titulares = new List<string>();
        public List<string> senhas = new List<string>();
        public List<double> saldos = new List<double>();

        ClassFinalizer finalizer = new();

        //Método que realiza o cadastro de novos usuários no "banco de dados"
        public void RegistrarNovoUsuario(List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos)
        {
            Console.Clear();
            Console.WriteLine("   CADASTRO   ");
            Console.WriteLine("Digite o cpf: ");
            string cpfVerificado = Console.ReadLine();
            int indexCpfVerificado = cpfs.FindIndex(cpf => cpf == cpfVerificado);
            if (indexCpfVerificado == -1)
            {
                cpfs.Add(cpfVerificado);
                Console.WriteLine("Digite o nome: ");
                titulares.Add(Console.ReadLine());
                Console.WriteLine("Digite a senha: ");
                senhas.Add(Console.ReadLine());
                saldos.Add(0);

                Console.WriteLine("-----------------------------------");
                Console.WriteLine("Novo usuário registrado com sucesso!");
            }
            else
            {
                Console.WriteLine("CPF já possui cadastro ativo no ByteBank");
            }
            finalizer.Finalizer();
        }
    }
}