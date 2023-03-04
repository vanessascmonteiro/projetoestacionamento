using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace semana3
{
    public class Ticket
    {
        public DateTime horaEntrada { get; set; }
        public DateTime horaSaida { get; set; }
        public bool Ativo { get; set; }

        public Ticket()
        {
            horaEntrada = DateTime.Now;
            Ativo = true;
        }

        public double CalcularTempo(){
            var tempo = horaSaida - horaEntrada;
            return tempo.TotalMinutes;
        }
        public double CalcularValor(){
           return CalcularTempo() * 0.09;
      
        
        }
        public void FecharTicket()
        {
           horaSaida = DateTime.Now;
           Ativo = false;
           Console.WriteLine($"O veúculo ficou {CalcularTempo()} minutos e o valor cobrado será de R$ {CalcularValor()}");

        }
        

        }
    }
