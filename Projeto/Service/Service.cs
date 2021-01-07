//using Projeto.Entities;
//using Projeto.Entities.Enums;
//using System.Threading;
//using System;
//using System.IO;
//using System.Text.RegularExpressions;

//namespace Projeto.Service
//{
//    public class Services
//    {
//        #region Directories
//        string diretorioCliente = @"C:\Users\mateus.wagnitz\Desktop\TecherPark\Cliente.txt";
//        string diretorioCarro = @"C:\Users\mateus.wagnitz\Desktop\TecherPark\Carro.txt";
//        string diretorioTicket = @"C:\Users\mateus.wagnitz\Desktop\TecherPark\Ticket.txt";
//        string diretorioPatio = @"C:\Users\mateus.wagnitz\Desktop\TecherPark\Patio.txt";
//        #endregion

//        #region Validators
//        public bool ValidacaoCPF(string cpf)
//        {
//            if (cpf.Length == 11 && long.TryParse(cpf, out long numero))
//                return true;
//            return false;
//        }

//        public bool ValidacaoTipoCliente(string tipoCliente)
//        {
//            if (tipoCliente == "P" || tipoCliente == "F")
//                return true;
//            return false;
//        }

//        public bool ValidacaoPlaca(string placa)
//        {
//            Regex regex = new Regex(@"^[A-Z]{3}\d{4}$");

//            if (regex.IsMatch(placa))
//                return true;
//            return false;
//        }

//        public bool ValidacaoDateTime(string date)
//        {
//            if (DateTime.TryParse(date, out DateTime result))
//                return true;
//            return false;
//        }

//        public bool ValidacaoDateTimeFinal(string date, DateTime dataInicial)
//        {
//            if (DateTime.TryParse(date, out DateTime result))
//                if (DateTime.Parse(date) > dataInicial)
//                    return true;
//                else
//                    Console.WriteLine("\nA Data Final deve ser maior que a Data Inicial!");
//            return false;
//        }

//        #endregion

//        //Client Register
//        public void CadastrarCliente(string nome, string cpf)
//        {
//            //Looking if the client exists
//            var clienteExiste = BuscarCliente(cpf);

//            if (clienteExiste == "")
//            {
//                var cli = new Cliente(cpf, nome, StatusCliente.Fixo);

//                SalvarCliente(cli);

//                Console.WriteLine("\nCadastrado com Sucesso!");
//                Thread.Sleep(1000);
//            }
//            else
//            {
//                //if the client is not null, means that it already has a registration
//                throw new Exception("Cliente já existente!");
//            }
//        }

//        //Saving a client
//        private void SalvarCliente(Cliente cli)
//        {
//            using (StreamWriter sw = File.AppendText(diretorioCliente))
//            {
//                sw.WriteLine($"{cli.Id_Cpf},{cli.Nome},{cli.StatusCliente}");
//            }
//        }

//        //Listing all clients
//        public string ListagemClientes()
//        {
//            var listaCli = "";

//            using (FileStream fs = new FileStream(diretorioCliente, FileMode.Open))
//            {
//                using (StreamReader sr = new StreamReader(fs))
//                {
//                    while (!sr.EndOfStream)
//                    {
//                        var linha = sr.ReadLine().Split(",");
//                        listaCli += $"{linha[0]} - {linha[1]} - {linha[2]}\n";
//                    }
//                }
//            }
//            return listaCli;
//        }

//        //Checking if the car exists
//        public void VerificarCarroExiste(string placa)
//        {
//            var car = BuscarCarro(placa);

//            if (car != "")
//                throw new Exception("\nVeiculo ja Existente!");

//        }

//        //Car register
//        //Checks if the owner ID has a value
//        //If yes, means that he is a monthly client
//        //If not, means that the client is just passing by

//        //If the client is monthly it's requeried a registration, at client register
//        //Also check if the client exists
//        public void CadastrarCarro(string placa, string marca, string modelo, string dono_Id, string nome, string tipoCliente)
//        {
//            var idCliente = "";

//            //Montlhy
//            if (dono_Id != null)
//            {
//                //Checks if "ClienteFixo" exists.
//                var clienteExiste = BuscarCliente(dono_Id);

//                if (clienteExiste == "")
//                    throw new Exception("Cliente Inexistente!");
//                idCliente = dono_Id;
//            }
//            //Passing by
//            else
//            {

//                //Read the registry file where the clients are saved, and check how many lines it has.
//                //Doing that, it generates a ID accordly with the amout of lines in the file.
//                idCliente = (QuantidadeLinhasTXT(diretorioCliente) + 1).ToString();

//                //Creates a passing by client and saves
//                var cli = new Cliente(idCliente, nome, StatusCliente.Passante);
//                SalvarCliente(cli);
//            }

//            var car = new Carro(placa, idCliente, marca, modelo);
//            SalvarCarro(car);

//            Console.WriteLine("\nCadastrado com Sucesso!");
//            Thread.Sleep(1000);
//        }

//        //Return the amount of lines that the file has
//        private int QuantidadeLinhasTXT(string diretorio)
//        {
//            var count = 0;
//            using (FileStream fs = new FileStream(diretorio, FileMode.Open))
//            {
//                using (StreamReader sr = new StreamReader(fs))
//                {
//                    while (!sr.EndOfStream)
//                    {
//                        sr.ReadLine();
//                        count++;
//                    }
//                }
//            }
//            return count;
//        }

//        //Saving the car at it's file
//        private void SalvarCarro(Carro car)
//        {
//            using (StreamWriter sw = File.AppendText(diretorioCarro))
//            {
//                sw.WriteLine($"{car.Id_Placa},{car.Id_Dono},{car.Marca},{car.Modelo}");
//            }
//        }

//        //Returns the list that contents all the cars
//        public string ListagemCarros()
//        {
//            var listaCar = "";

//            using (FileStream fs = new FileStream(diretorioCarro, FileMode.Open))
//            {
//                using (StreamReader sr = new StreamReader(fs))
//                {
//                    while (!sr.EndOfStream)
//                    {
//                        var linha = sr.ReadLine().Split(",");

//                        var cli = BuscarCliente(linha[1]);
//                        var linhaDono = cli.Split(",");

//                        listaCar += $"Placa: {linha[0]} \n" +
//                            $"Marca: {linha[2]} \n" +
//                            $"Modelo: {linha[3]} \n" +
//                            $"Dono:  {linhaDono[0]}  -  {linhaDono[1]}" +
//                            $"\n\n";
//                    }
//                }
//            }
//            return listaCar;
//        }

//        //Ticket register.
//        public void CadastrarTicket(string placa)
//        {
//            //Checks if the car exists.
//            var vei = BuscarCarro(placa);

//            if (vei != "")
//            {

//                //Checks if the car is at lot, that way a Ticket can't be emmited twice for the same car.                
//                if (VerificarCarroEstacionado(placa) == false)
//                {
//                    var pat = BuscarPatio();
//                    var itemPatio = pat.Split(",");
//                    //Checking if there are any spots left
//                    if (int.Parse(itemPatio[2]) < int.Parse(itemPatio[1]))
//                    {
//                        //IF the car exists, and there is enough spots left in the park, a Ticket is generated.
//                        var tic = new Ticket((QuantidadeLinhasTXT(diretorioTicket) + 1).ToString(), placa, DateTime.Now);

//                        itemPatio[2] = (int.Parse(itemPatio[2]) + 1).ToString();

//                        //Realiza a Leitura do Arquivo onde estão os dados. //Reading the park lot file.
//                        string text = File.ReadAllText(diretorioPatio);

//                        //Replacing the file line and update it.
//                        text = text.Replace(pat, $"{itemPatio[0]},{itemPatio[1]},{itemPatio[2]}");

//                        //Saving the information again.
//                        File.WriteAllText(diretorioPatio, text);

//                        SalvarTicket(tic);

//                        Console.WriteLine("\nTicket Gerado com Sucesso!");
//                        Thread.Sleep(1000);
//                    }
//                    else
//                    {
//                        throw new Exception("\nPatio Lotado!");
//                    }
//                }
//                else
//                {
//                    throw new Exception("\nO Veiculo já se encontra no Estacionamento!");
//                }
//            }
//            else
//            {
//                throw new Exception("\nVeiculo não Encontrado!");
//            }
//        }

//        //Saving the ticket file.
//        private void SalvarTicket(Ticket tic)
//        {
//            using (StreamWriter sw = File.AppendText(diretorioTicket))
//            {
//                sw.WriteLine($"{tic.Id_Ticket},{tic.Id_Carro},{tic.DataEntrada},{tic.DataSaida},{tic.Valor}");
//            }
//        }

//        //Closing the ticket.
//        public string FecharTicket(string id_Ticket)
//        {
//            //Search if the Ticket exists.
//            var tic = BuscarTicket(id_Ticket);

//            if (tic != "")
//            {
//                //If the ticket exists, keep it's value
//                //the itens within the value[] will be the same as it's registration
//                //for instance itemTicket[0] will be the ticket ID, and so on. 
//                var itemTicket = tic.Split(",");

//                //Item Ticket[3] is the exit time.
//                //Chcks if the ticket is currently activated, and can be finished.
//                if (itemTicket[3] == "")
//                {
//                    Console.Clear();

//                    //Calculate how many time the car was in the lot, and store it on a variable called "duracao".
//                    TimeSpan duracao = DateTime.Now.Subtract(DateTime.Parse(itemTicket[2]));

//                    //Store on the ticket it's exit time
//                    itemTicket[3] = DateTime.Now.ToString();

//                    //Calculates how much the client must pay with the Ticket value.
//                    itemTicket[4] = (1.50 * (Math.Ceiling(duracao.TotalMinutes / 15))).ToString().Replace(".", "").Replace(",", ".");

//                    //Atualiza as Vagas no Patio. //Refresh the spots left on the park.
//                    var pat = BuscarPatio();
//                    var itemPatio = pat.Split(",");

//                    itemPatio[2] = (int.Parse(itemPatio[2]) - 1).ToString();

//                    string text = File.ReadAllText(diretorioPatio);
//                    text = text.Replace(pat, $"{itemPatio[0]},{itemPatio[1]},{itemPatio[2]}");
//                    File.WriteAllText(diretorioPatio, text);

//                    //Reads where the data is on the file
//                    text = File.ReadAllText(diretorioTicket);

//                    //Replace the line in the Ticket file and update it.
//                    text = text.Replace(tic, $"{itemTicket[0]},{itemTicket[1]},{itemTicket[2]},{itemTicket[3]},{itemTicket[4]}");

//                    //Saving the new information
//                    File.WriteAllText(diretorioTicket, text);

//                    //Searchs for the Client and Car in the ticket
//                    var vei = BuscarCarro(itemTicket[1]);
//                    var itemCarro = vei.Split(",");

//                    var cli = BuscarCliente(itemCarro[1]);
//                    var itemCliente = cli.Split(",");

//                    //Return a string with the updated Ticket.
//                    return $"-----Ticket Finalizado com Sucesso!-----\n" +
//                        $"Ticket: {itemTicket[0]} \n" +
//                        $"Veiculo: {itemCarro[0]}  - {itemCarro[2]} - {itemCarro[3]} \n" +
//                        $"Dono: {itemCliente[0]} - {itemCliente[1]} \n" +
//                        $"Entrada: {itemTicket[2]} \n" +
//                        $"Saida: {itemTicket[3]} \n" +
//                        $"Valor: {itemTicket[4]} \n\n";
//                }
//                else
//                {
//                    throw new Exception("\nTicket Inativo!");
//                }
//            }
//            else
//            {
//                throw new Exception("\nTicket não Encontrado!\n");
//            }
//        }

//        //Returns a list with every active Ticket, when the car is still at the parking lot.
//        public string ListagemTicketsAtivos()
//        {
//            var listaTic = "";

//            using (FileStream fs = new FileStream(diretorioTicket, FileMode.Open))
//            {
//                using (StreamReader sr = new StreamReader(fs))
//                {
//                    while (!sr.EndOfStream)
//                    {
//                        var linhaTic = sr.ReadLine().Split(",");

//                        if (linhaTic[3] == "")
//                        {
//                            var car = BuscarCarro(linhaTic[1]);
//                            var linhaCar = car.Split(",");

//                            var cli = BuscarCliente(linhaCar[1]);
//                            var linhaCli = cli.Split(",");

//                            listaTic += $"Ticket: {linhaTic[0]} \n" +
//                                  $"Veiculo: {linhaCar[0]}  - {linhaCar[2]} - {linhaCar[3]} \n" +
//                                  $"Dono: {linhaCli[0]} - {linhaCli[1]} \n" +
//                                  $"Entrada: {linhaTic[2]} \n" +
//                                  $"\n\n";
//                        }
//                    }
//                }
//            }
//            return listaTic;
//        }

//        //Returns a list with every ticket that has already been finished.
//        public string ListagemTicketsFinalizados()
//        {
//            var listaTic = "";

//            using (FileStream fs = new FileStream(diretorioTicket, FileMode.Open))
//            {
//                using (StreamReader sr = new StreamReader(fs))
//                {
//                    while (!sr.EndOfStream)
//                    {
//                        var linhaTic = sr.ReadLine().Split(",");

//                        if (linhaTic[3] != "")
//                        {
//                            var car = BuscarCarro(linhaTic[1]);
//                            var linhaCar = car.Split(",");

//                            var cli = BuscarCliente(linhaCar[1]);
//                            var linhaCli = cli.Split(",");

//                            listaTic += $"Ticket: {linhaTic[0]} \n" +
//                                  $"Veiculo: {linhaCar[0]}  - {linhaCar[2]} - {linhaCar[3]} \n" +
//                                  $"Dono: {linhaCli[0]} - {linhaCli[1]} \n" +
//                                  $"Entrada: {linhaTic[2]} \n" +
//                                  $"Saída: {linhaTic[3]} \n" +
//                                  $"Valor: {linhaTic[4]} \n" +
//                                  $"\n\n";
//                        }
//                    }
//                }
//            }
//            return listaTic;
//        }

//        //Searchs the Client at its file.
//        private string BuscarCliente(string id_Cliente)
//        {
//            var cli = "";

//            using (FileStream fs = new FileStream(diretorioCliente, FileMode.Open))
//            {
//                using (StreamReader sr = new StreamReader(fs))
//                {
//                    bool encontrado = false;

//                    while (!sr.EndOfStream && encontrado == false)
//                    {
//                        var linha = sr.ReadLine().Split(",");

//                        if (linha[0] == id_Cliente)
//                        {
//                            cli = $"{linha[0]},{linha[1]},{linha[2]}";
//                            encontrado = true;
//                        }
//                    }
//                }
//            }
//            return cli;
//        }

//        //Searchs for the car ID and returns a string with the car line data in the file.
//        private string BuscarCarro(string id_Carro)
//        {
//            var vei = "";

//            using (FileStream fs = new FileStream(diretorioCarro, FileMode.Open))
//            {
//                using (StreamReader sr = new StreamReader(fs))
//                {
//                    bool encontrado = false;

//                    while (!sr.EndOfStream && encontrado == false)
//                    {
//                        var linha = sr.ReadLine().Split(",");

//                        if (linha[0] == id_Carro)
//                        {
//                            vei = $"{linha[0]},{linha[1]},{linha[2]},{linha[3]}";
//                            encontrado = true;
//                        }
//                    }
//                }
//            }
//            return vei;
//        }

//        //Searchs a Ticket ID and returns a string with the Ticket line data in the file.
//        private string BuscarTicket(string id_Ticket)
//        {
//            var tic = "";

//            using (FileStream fs = new FileStream(diretorioTicket, FileMode.Open))
//            {
//                using (StreamReader sr = new StreamReader(fs))
//                {
//                    bool encontrado = false;

//                    while (!sr.EndOfStream && encontrado == false)
//                    {
//                        var linha = sr.ReadLine().Split(",");

//                        if (linha[0] == id_Ticket)
//                        {
//                            tic = $"{linha[0]},{linha[1]},{linha[2]},{linha[3]},{linha[4]}";
//                            encontrado = true;
//                        }
//                    }
//                }
//            }
//            return tic;
//        }

//        //Reads the park file data, so it can be updated.
//        public string BuscarPatio()
//        {
//            var pat = "";

//            using (FileStream fs = new FileStream(diretorioPatio, FileMode.Open))
//            {
//                using (StreamReader sr = new StreamReader(fs))
//                {
//                    while (!sr.EndOfStream)
//                    {
//                        var linha = sr.ReadLine().Split(",");

//                        if (linha[0] == "1")
//                        {
//                            pat = $"{linha[0]},{linha[1]},{linha[2]}";
//                        }
//                    }
//                }
//            }
//            return pat;
//        }

//        //Reads and lists the currently occupied slots, showning it's car and it's owner
//        public string ListaEstacionamento()
//        {
//            var listaEstacionamento = "";

//            using (FileStream fs = new FileStream(diretorioTicket, FileMode.Open))
//            {
//                using (StreamReader sr = new StreamReader(fs))
//                {
//                    while (!sr.EndOfStream)
//                    {
//                        var itemTicket = sr.ReadLine().Split(",");

//                        var car = BuscarCarro(itemTicket[1]);
//                        var itemCarro = car.Split(",");

//                        var cli = BuscarCliente(itemCarro[1]);
//                        var itemCliente = cli.Split(",");

//                        listaEstacionamento += $"Veiculo: {itemCarro[0]} - " +
//                        $"{itemCarro[2]} - {itemCarro[3]} \n" +
//                        $"Dono: {itemCliente[0]} - {itemCliente[1]} \n\n";
//                    }
//                }
//            }
//            return listaEstacionamento;
//        }

//        //Checks if the Car is at the park
//        private bool VerificarCarroEstacionado(string placa)
//        {
//            using (FileStream fs = new FileStream(diretorioTicket, FileMode.Open))
//            {
//                using (StreamReader sr = new StreamReader(fs))
//                {
//                    while (!sr.EndOfStream)
//                    {
//                        var linha = sr.ReadLine().Split(",");

//                        if (linha[1] == placa && linha[3] == "")
//                        {
//                            return true;
//                        }
//                    }
//                }
//            }
//            return false;
//        }

//        //The total amount generated in the tickets within a period.
//        public double ValorPorPeriodo(DateTime dataInicial, DateTime dataFinal)
//        {
//            double total = 0.00;

//            using (FileStream fs = new FileStream(diretorioTicket, FileMode.Open))
//            {
//                using (StreamReader sr = new StreamReader(fs))
//                {
//                    while (!sr.EndOfStream)
//                    {
//                        var itemTicket = sr.ReadLine().Split(",");

//                        if (itemTicket[3] != "")
//                        {
//                            if (DateTime.Parse(itemTicket[3]) >= dataInicial && DateTime.Parse(itemTicket[3]) <= dataFinal)
//                            {
//                                total += Double.Parse(itemTicket[4].Replace(".", ","));
//                            }
//                        }
//                    }
//                }
//            }
//            return total;
//        }
//    }
//}