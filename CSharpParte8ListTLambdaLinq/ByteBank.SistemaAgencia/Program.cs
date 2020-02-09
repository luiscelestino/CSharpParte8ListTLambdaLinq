using ByteBank.Modelos;
using ByteBank.SistemaAgencia.Comparadores;
using ByteBank.SistemaAgencia.Extensoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 2010-02-09 - Terminada a Aula 06.05 - C# parte 8
namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            var contas = new List<ContaCorrente>()
            {
                new ContaCorrente(341, 47480),
                null,
                new ContaCorrente(342, 45678),
                new ContaCorrente(340, 48950),
                null,
                new ContaCorrente(290, 18950)
            };

            // contas.Sort(); // Chama a implementação dada em IComparable
            // contas.Sort(new ComparadorContaCorrentePorAgencia());
            var contasOrdenadas = contas
                .Where(conta => conta != null)
                .OrderBy(conta => conta.Numero);

            foreach (var conta in contasOrdenadas)
            {
                Console.WriteLine($"Conta num. {conta.Numero}, ag. {conta.Agencia}");
            }

            Console.ReadKey();
        }

        static void TestaSort()
        {
            // string
            var nomes = new List<string>()
            {
                "Luis", "Andre", "Souza", "Ricardo"
            };
            nomes.Sort();
            foreach (var nome in nomes)
            {
                Console.WriteLine(nome);
            }

            // int
            var idades = new List<int>();
            idades.AdicionarVarios(1, 5, 14, 99, 25, 38, 61);
            idades.Remove(5);
            idades.Sort();
            for (int i = 0; i < idades.Count; i++)
            {
                Console.WriteLine(idades[i]);
            }
        }
    }
}
