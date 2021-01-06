using System;
using System.Threading;
using Projeto.Service;
using Projeto.Entities;


namespace Projeto
{
    class Program
    {


        static Services service = new Services();

        static void Main(string[] args)
        {
            MenuPrincipal();
        }

        static void MenuPrincipal()
        {
            try
            {
                //Main Menu

                Console.WriteLine("*******************Estacionamento Techer*******************");
                Console.WriteLine("Selecione a opção desejada");
                Console.WriteLine("1 - Clientes");                             //MenuClientes()
                Console.WriteLine("2 - Carros");                               //MenuCarros()
                Console.WriteLine("3 - Tickets");                              //MenuTickets()
                Console.WriteLine("4 - Controle de Vagas");                    //MenuPatio()
                Console.WriteLine("5 - Controle Financeiro");                  //MenuFInanceiro()
                Console.WriteLine("6 - Finalizar e Fechar o Sistema");
                Console.WriteLine("************************************************************");
                Console.WriteLine();


                var caseSwitch = int.Parse(Console.ReadLine());

                //First Menu

                switch (caseSwitch)
                {
                    case 1:
                        MenuClientes();
                        break;
                    case 2:
                        MenuCarros();
                        break;
                    case 3:
                        MenuTickets();
                        break;
                    case 4:
                        MenuPatio();
                        break;
                    case 5:
                        MenuFinanceiro();
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        Thread.Sleep(1000);
                        Console.Clear();
                        MenuPrincipal();
                        break;
                }
            }
            catch (Exception e)
            {

                //Handling errors
                Console.WriteLine("Error: " + e.Message);
                Console.WriteLine("Pressione qualquer tecla para voltar...");
                Console.ReadLine();

                Console.Clear();
                MenuPrincipal();
            }

            //Costumer Menu

            static void MenuClientes()
            {
                Console.Clear();
                Console.WriteLine("*****Controle de Clientes******");
                Console.WriteLine("1 - Cadastrar Clientes");
                Console.WriteLine("2 - Listar Clientes");
                Console.WriteLine("3 - Voltar");
                Console.WriteLine("4 - Sair");
                Console.WriteLine("*******************************");
                Console.WriteLine();

                var caseSwitch = int.Parse(Console.ReadLine());

                switch (caseSwitch)
                {
                    case 1:
                        CadastroDeCliente();
                        break;
                    case 2:
                        ListarClientes();
                        break;
                    case 3:
                        MenuPrincipal();
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("\nInsira um Valor Valido!...");
                        Thread.Sleep(1000);
                        MenuClientes();
                        break;
                }
            }

            //Car Menu

            static void MenuCarros()
            {
                Console.Clear();
                Console.WriteLine("*******Controle de Carros******");
                Console.WriteLine("1 - Cadastrar Carro");
                Console.WriteLine("2 - Listar Carros");
                Console.WriteLine("3 - Voltar");
                Console.WriteLine("4 - Sair");
                Console.WriteLine("*******************************");
                Console.WriteLine();

                var caseSwitch = int.Parse(Console.ReadLine());

                switch (caseSwitch)
                {
                    case 1:
                        CadastroDeCarro();
                        break;
                    case 2:
                        ListarCarros();
                        break;
                    case 3:
                        MenuPrincipal();
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("\nInsira um Valor Valido!...");
                        Thread.Sleep(1000);
                        MenuCarros();
                        break;
                }
            }

            //Ticket Menu

            static void MenuTickets()
            {
                Console.Clear();
                Console.WriteLine("********Controle de Ticket's*******");
                Console.WriteLine("1 - Cadastrar Ticket");
                Console.WriteLine("2 - Finalizar Ticket");
                Console.WriteLine("3 - Listar Ticket's Ativos");
                Console.WriteLine("4 - Listar Ticket's Finalizados");
                Console.WriteLine("5 - Voltar");
                Console.WriteLine("6 - Sair");
                Console.WriteLine("***********************************");
                Console.WriteLine();

                var caseSwitch = int.Parse(Console.ReadLine());

                switch (caseSwitch)
                {
                    case 1:
                        CadastroDeTicket();
                        break;
                    case 2:
                        FechamentoDeTicket();
                        break;
                    case 3:
                        ListarTicketsAtivos();
                        break;
                    case 4:
                        ListarTicketsFinalizados();
                        break;
                    case 5:
                        MenuPrincipal();
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("\nInsira um Valor Valido!...");
                        Thread.Sleep(1000);
                        MenuTickets();
                        break;
                }
            }

            //Lot menu, with the remaining spots left
            static void MenuPatio()
            {
                Console.Clear();
                var patio = service.BuscarPatio();
                var itemPatio = patio.Split(",");

                Console.WriteLine("*******************************Controle de Patio********************************");
                Console.WriteLine();
                Console.WriteLine($"Capacidade Total: {itemPatio[1]} - " +
                                  $"Vagas Ocupadas: {itemPatio[2]} - " +
                                  $"Vagas Disponiveis: {int.Parse(itemPatio[1]) - int.Parse(itemPatio[2])}");
                Console.WriteLine();
                Console.WriteLine("********************************************************************************");

                string listaEstacionamento = service.ListaEstacionamento();

                Console.WriteLine(listaEstacionamento);

                Console.Write("Pressione qualquer tecla para voltar...");
                Console.ReadLine();

                MenuPrincipal();
            }

            //Balance Menu, can inform the profits by any date requested, with validators
            static void MenuFinanceiro()
            {
                Console.Clear();
                Console.WriteLine("******Controle Financeiro*****");
                Console.WriteLine("1 - Selecionar Período");
                Console.WriteLine("2 - Voltar");
                Console.WriteLine("3 - Sair");
                Console.WriteLine($"Valor arrecadado hoje: { service.ValorPorPeriodo(DateTime.Today, DateTime.Now).ToString("F2") }");
                Console.WriteLine("*******************************");
                Console.WriteLine();

                var caseSwitch = int.Parse(Console.ReadLine());

                switch (caseSwitch)
                {
                    case 1:
                        ValorPorPeriodo();
                        break;
                    case 2:
                        MenuPrincipal();
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("\nInsira um Valor Valido!...");
                        Thread.Sleep(1000);
                        MenuFinanceiro();
                        break;
                }
            }


            //Building a client register
            static void CadastroDeCliente()
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Insira o nome do Cliente: ");
                    var nome = Console.ReadLine();

                    Console.WriteLine("Insira o CPF do Cliente");
                    var cpf = Console.ReadLine();

                    //Verifica se o CPF tem 11 digitos e a variavel é numerica.
                    while (service.ValidacaoCPF(cpf) == false)
                    {
                        Console.WriteLine("\nInsira um CPF valido!");
                        cpf = Console.ReadLine();
                    }

                    service.CadastrarCliente(nome, cpf);

                    MenuClientes();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"\nErro: {e.Message}");
                    Console.WriteLine("Pressione qualquer tecla para voltar...");
                    Console.ReadLine();
                    Thread.Sleep(1000);
                    Console.Clear();

                    MenuClientes();
                }
            }

            //Listing clients
            static void ListarClientes()
            {
                try
                {
                    Console.Clear();

                    var clientes = service.ListagemClientes();

                    Console.Write(clientes);

                    Console.WriteLine("Pressione qualquer tecla para voltar...");
                    Console.ReadLine();

                    MenuClientes();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"\nErro: {e.Message}");
                    Console.WriteLine("Pressione qualquer tecla para voltar...");
                    Console.ReadLine();
                    Thread.Sleep(1000);
                    Console.Clear();


                    MenuClientes();

                }
            }

            // Building a car register / car and owner data with validators
            static void CadastroDeCarro()
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Insira a Placa do Carro:");
                    var placa = Console.ReadLine();


                    while (service.ValidacaoPlaca(placa) == false)
                    {
                        Console.WriteLine("\nInsira uma Placa Valida!");
                        placa = Console.ReadLine();
                    }

                    service.VerificarCarroExiste(placa);

                    Console.WriteLine("Insira a Marca do Carro:");
                    var marca = Console.ReadLine();

                    Console.WriteLine("Insira o Modelo do Carro:");
                    var modelo = Console.ReadLine();

                    Console.WriteLine("Cliente Passante ou Fixo?: P/F");
                    var tipoCliente = Console.ReadLine();

                    while (service.ValidacaoTipoCliente(tipoCliente) == false)
                    {
                        Console.WriteLine("Insira um valor valido!:");
                        tipoCliente = Console.ReadLine();
                    }

                    string dono_Id = null;
                    string nome = null;

                    if (tipoCliente == "F")
                    {
                        Console.WriteLine("Insira a Identificação do Dono do Carro:");
                        dono_Id = Console.ReadLine();
                    }
                    else if (tipoCliente == "P")
                    {
                        Console.WriteLine("Insira o Nome do Dono do Carro:");
                        nome = Console.ReadLine();
                    }

                    service.CadastrarCarro(placa, marca, modelo, dono_Id, nome, tipoCliente);

                    Console.Clear();
                    MenuCarros();

                }
                catch (Exception e)
                {
                    Console.WriteLine($"\nErro: {e.Message}");
                    Console.WriteLine("Pressione qualquer tecla para voltar...");
                    Console.ReadLine();
                    Thread.Sleep(1000);
                    Console.Clear();

                    MenuCarros();
                }

            }

            //Checking the registered cars
            static void ListarCarros()
            {
                Console.Clear();

                string carros = service.ListagemCarros();

                Console.Write(carros);
                Console.WriteLine("Pressione qualquer tecla para voltar...");
                Console.ReadLine();

                MenuCarros();
            }


            //Recording a ticket, it will only accept the car plate that was registered already
            static void CadastroDeTicket()
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Insira a Placa do Carro: ");
                    var placa = Console.ReadLine();

                    service.CadastrarTicket(placa);

                    Console.Clear();
                    MenuPrincipal();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Pressione qualquer tecla para voltar...");
                    Console.ReadLine();
                    Thread.Sleep(1000);
                    Console.Clear();

                    MenuTickets();
                }
            }


            //Closing a ticket by the index
            static void FechamentoDeTicket()
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Insira o Numero do Ticket: ");
                    var id_Ticket = Console.ReadLine();

                    var retorno = service.FecharTicket(id_Ticket);

                    Console.WriteLine("Pressione qualquer tecla para voltar...");
                    Console.ReadLine();

                    MenuTickets();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Pressione qualquer tecla para voltar...");
                    Console.ReadLine();
                    Thread.Sleep(1000);
                    Console.Clear();

                    MenuTickets();
                }
            }
            //Listing the active tickets, can get the index if needed to close a ticket
            static void ListarTicketsAtivos()
            {
                Console.Clear();

                string tickets = service.ListagemTicketsAtivos();

                Console.Write(tickets);

                Console.WriteLine("Pressione qualquer tecla para voltar...");
                Console.ReadLine();

                MenuTickets();
            }

            //Listing every closed ticket
            static void ListarTicketsFinalizados()
            {
                Console.Clear();

                string tickets = service.ListagemTicketsFinalizados();

                Console.Write(tickets);

                Console.WriteLine("Pressione qualquer tecla para voltar...");
                Console.ReadLine();

                MenuTickets();
            }


            //Balance by date, with validators, the first entry must be lower then a second,
            //Also it must be DD/MM/YYYY
            static void ValorPorPeriodo()
            {
                Console.Clear();
                Console.WriteLine("Informe a Data Inicial: (DD/MM/AAAA)");
                var date = Console.ReadLine();

                //Checking the if the date is correct.
                while (service.ValidacaoDateTime(date) == false)
                {
                    Console.WriteLine("\nInsira uma Data Valida!");
                    date = Console.ReadLine();
                }
                DateTime dataInicial = DateTime.Parse(date);


                Console.WriteLine("Informe a Data Final: (DD/MM/AAAA)");
                date = Console.ReadLine();

                // the first entry must be lower then a second
                while (service.ValidacaoDateTimeFinal(date, dataInicial) == false)
                {
                    Console.WriteLine("\nInsira uma Data Valida!");
                    date = Console.ReadLine();
                }
                DateTime dataFinal = DateTime.Parse(date);

                //Receiving the overall balance by a period
                double valor = service.ValorPorPeriodo(dataInicial, dataFinal);

                Console.Clear();
                Console.WriteLine($"Valor Arrecadado no Período Informado: {valor.ToString("F2")} ");
                Console.WriteLine("Pressione qualquer tecla para voltar...");
                Console.ReadLine();

                MenuFinanceiro();
            }
        }
    }
}

