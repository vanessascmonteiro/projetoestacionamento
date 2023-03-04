
using semana3;


List<Carro> carros = new List<Carro>();

string opcao; 
do{
    Console.WriteLine("Bem vindos ao Estacionamento, escolha uma opção");
    Console.WriteLine("1 - Cadastrar carro");
    Console.WriteLine("2- Marcar Entrada");
    Console.WriteLine("3- Marcar Saída");
    Console.WriteLine("4- Consultar Histórico");
    Console.WriteLine("5- Sair");
    
    opcao = Console.ReadLine();

    if(opcao == "1"){
        CadastrarCarro();
    }
    if(opcao == "2"){
        GerarTicket();
    }
    if(opcao == "3"){
        FecharTicket();
    }

    if(opcao =="4"){
        Historico();
    }

}while (opcao != "5");
 
void CadastrarCarro(){
    Carro carro = new Carro();
    Console.WriteLine("Digite a placa");
    carro.Placa = Console.ReadLine();
    Console.WriteLine("Digite o modelo");
    carro.Modelo = Console.ReadLine();
    Console.WriteLine("Digite a cor");
    carro.Cor = Console.ReadLine();
    Console.WriteLine("Digite a marca");
    carro.Marca = Console.ReadLine();
    
    carros.Add(carro);

}

Carro ObterCarro(string placa){
    foreach(var carro in carros){
     if (placa == carro.Placa){
        return carro;
     }
    }
    return null;
}



void GerarTicket(){
    Console.WriteLine("Qual a placa do veículo?");
    string placa = Console.ReadLine();

    var carro = ObterCarro(placa);
    if(carro == null){
        Console.WriteLine("Carro não cadastrado");
        return;
    }
    foreach(var ticket in carro.Tickets){
        if(ticket.Ativo == true){
            Console.WriteLine("Veículo já está no estacionamento");
            return;
        }
    }
    Ticket ticketNovo = new Ticket();
    carro.Tickets.Add(ticketNovo);
    Console.WriteLine("Ticket Gerado com sucesso");
}
    void FecharTicket(){
        Console.WriteLine("Qual a placa do veículo?");
        string placa = Console.ReadLine();
    

    var carro = ObterCarro(placa);
    if(carro == null){
        Console.WriteLine("Carro não cadastrado");
        return;
    }

    Ticket ticketAberto = null;
    foreach(var ticket in carro.Tickets){
   if(ticket.Ativo == true){
    ticketAberto = ticket;

   }
} 
if(ticketAberto == null){
    Console.WriteLine("Não há tickets em aberto para o veículo");
    return;
  }
ticketAberto.FecharTicket();
}


    void Historico(){
    Console.WriteLine("Qual a placa do veículo?");
    string placa = Console.ReadLine();    
    
    
    var carro = ObterCarro(placa);
    if(carro == null){
        Console.WriteLine("Carro não cadastrado");
        return;
    }

    Console.WriteLine("Entrada               |Saída                |Ativo        |Valor");
    
    foreach(var ticket in carro.Tickets){
        if (ticket.Ativo == true){
            Console.WriteLine($"{ticket.horaEntrada} | ----------------| {ticket.Ativo.ToString()} | R$ ---, ---");

        }
        else{
        Console.WriteLine($"{ticket.horaEntrada} | {ticket.horaSaida} | R${ticket.CalcularValor()}");

        }
    }
}




