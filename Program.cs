using ByteBank.Entities;
using ByteBank.Entities.LogIn;
using ByteBank.Entities.NewRegister;


namespace ByteBank {
    public class Program {
        public static void Main( string[] args ) {
            static void ShowMenu() {
                Console.WriteLine("Por favor, digite a opção desejada: ");
                Console.WriteLine("1 - Criar conta de usuário");
                Console.WriteLine("2 - Efetuar Login");
                Console.WriteLine("0 - Para sair do programa");
            }

            Log log = new(); //Instanciando objeto para área de usuários JÁ cadastrados.
            Register register = new(); //Instanciando objeto para cadastro de novo usuário.
            ClassFinalizer finalizer = new(); //Instanciando objeto que executa a ação padrão que finaliza as classes.

            Console.WriteLine("Olá! Seja Bem Vinda(o) ao ByteBank!");
            int option;

            //Menu de opções iniciais de acesso que todos os usuários, cadastrados ou ainda não, podem ter ao ByteBank.
            do {
                ShowMenu();
                option = int.Parse(Console.ReadLine());

                switch (option) {
                    case 1:
                        Register.RegistrarNovoUsuario(register.cpfs, register.titulares, register.senhas, register.saldos);
                        break;
                    case 2:
                        log.LogIn(register.cpfs, register.titulares, register.senhas, register.saldos);
                        break;
                }
                if (option != 0) { finalizer.Finalizer(); }
            } while (option != 0);

        }

    }

}