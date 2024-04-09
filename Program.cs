using System.Text;
using DesafioProjetoHospedagem.Models;


Console.OutputEncoding = Encoding.UTF8;

// Cria os modelos de hóspedes e cadastra na lista de hóspedes
List<Pessoa> hospedes = new List<Pessoa>();
List<Suite> suites = new List<Suite>();
List<Reserva> reservas = new List<Reserva>();

Hotel:
Console.WriteLine("Bem-vindo ao AbeHotel!");
Console.WriteLine("Digite uma opção: \n1- Realizar Reserva \n2- Cadastrar Suíte \n3- Sair" );

int option = Convert.ToInt32(Console.ReadLine());



switch (option)
{
    //REALIZANDO RESERVA
    case 1:
    if(suites.Count() <= 0)
    {
        Console.WriteLine("Não há suítes criadas ainda!\nPressione qualquer tecla para continuar.");
        Console.ReadLine();
        Console.Clear();
        goto Hotel;
    }
    Console.WriteLine("Quantos hóspedes estarão presentes?");
    int hospedesCount = Convert.ToInt32(Console.ReadLine());
    
    foreach(var item in suites)
    {
        if(item.Capacidade >= hospedesCount && !item.EstaOcupado)
        {
         
         for (int i = 0; i < hospedesCount; i++)
         { 
            Console.WriteLine("Digite o nome do hóspede: " );
            string nome =  Console.ReadLine();
        
            Console.WriteLine("Digite o sobrenome: ");
            string sobrenome =  Console.ReadLine();

            Console.WriteLine("Pessoa cadastrada com sucesso!");
            Pessoa pessoa = new Pessoa(nome: nome, sobrenome: sobrenome);
            hospedes.Add(pessoa);
            item.EstaOcupado = true;
        }
        Console.ReadLine();
        Console.Clear();
        Console.WriteLine("Deseja reservar por quantos dias?");
        int diasReservados = Convert.ToInt32(Console.ReadLine());
        Reserva reserva = new Reserva(diasReservados);
        reservas.Add(reserva);
        }
        
    }

    goto Hotel;
    
    //CADASTRANDO SUÍTE
    case 2:
    Console.WriteLine("Informe o tipo da suíte: ");
    string tipoSuite = Console.ReadLine();

    Console.WriteLine("Informe a capacidade da suíte: ");
    int capacidade = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("Informe o valor da diária: ");
    decimal valorDiaria = Convert.ToDecimal(Console.ReadLine());

    Suite suite = new Suite(tipoSuite: tipoSuite, capacidade: capacidade, 
                            valorDiaria: valorDiaria, estaOcupado: false);
    
    suites.Add(suite);
    Console.WriteLine("Suíte cadastrada com sucesso!\nPressione qualquer tecla para continuar");
    Console.ReadLine();
    Console.Clear();
    goto Hotel;

    case 3:
    Console.WriteLine("Obrigado pela preferência, volte sempre!");
    break;
}