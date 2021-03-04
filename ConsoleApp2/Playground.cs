using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp2
{
    public class Playground
    {

        public Playground() {
            var pedidos = new List<Pedido>();
            var dataAgora = new DateTime(2021,02,11);
            int x = 1;
            for (int i = 0; i < 40; i++) {
                if (x > dataAgora.Day)
                    x = 1;
                pedidos.Add(new Pedido
                {
                    Descricao = "Teste",
                    DataTransacao = new DateTime(dataAgora.Year, dataAgora.Month, x)
                }) ;
                x++;
            }

            var totalPedisoMes = pedidos.Count();
            var diasUteis = DiasUteisMes(dataAgora);
            var diasCorridos = dataAgora.Day - DiasNaoUteisAteAtual(dataAgora);

            Console.WriteLine((totalPedisoMes / (decimal)diasCorridos) * diasUteis);
        }

        public int DiasNaoUteisAteAtual(DateTime dataPesquisa) {
            return Enumerable.Range(1, dataPesquisa.Day)
                    .Select(x => new DateTime(dataPesquisa.Year, dataPesquisa.Month, x))
                    .Where(x => x.DayOfWeek == DayOfWeek.Sunday || x.DayOfWeek == DayOfWeek.Saturday)
                    .Count();
        }
        public int DiasUteisMes(DateTime dataPesquisa) {
            return Enumerable.Range(1, DateTime.DaysInMonth(dataPesquisa.Year, dataPesquisa.Month))
                .Select(x => new DateTime(dataPesquisa.Year, dataPesquisa.Month, x))
                .Where(x => x.DayOfWeek != DayOfWeek.Sunday && x.DayOfWeek != DayOfWeek.Saturday)
                .Count();
        }

        class Pedido {
            public string Descricao { get; set; }
            public DateTime DataTransacao { get; set; }
        }
    }
}
