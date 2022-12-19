using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caixeiro_Viajante 
{
    class Program
    {
        static void Main()
        {
            //Inicialização do programa:
            Console.Write("Digite o número de cidades: ");
            int.TryParse(Console.ReadLine(), out int n);

            //Matriz de distâncias:
            int[,] distancias = new int[n, n];

            //Preenchimento da matriz:
            for(int i = 0; i < n; i++) 
            {
                distancias[i, i] = 0;
                for(int j = i + 1; j < n; j++)
                {
                    Console.Write($"Digite a distância entre a cidade {i + 1} e {j + 1}: ");
                    int.TryParse(Console.ReadLine(), out int d);
                    distancias[i, j] = d;
                    distancias[j, i] = distancias[i, j];
                }                
            }

            //Definição do percurso:
            Console.WriteLine("Qual percurso deseja percorrer?");
            string? percurso = Console.ReadLine();
            string[] cidades;
            cidades = percurso.Split(',');

            //Cálculo da distância percorrida:
            int distanciaPercorrida = 0;
            for (int k = 0; k < cidades.Length-1;k++)
            {
                int.TryParse(cidades[k], out int cidadeInicial);
                int.TryParse(cidades[k+1], out int cidadeFinal);
                distanciaPercorrida = distanciaPercorrida + distancias[cidadeInicial-1, cidadeFinal-1];
            }
            Console.WriteLine($"Distância total: {distanciaPercorrida} km");
        }
    }
}