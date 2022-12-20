using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Caixeiro_Viajante
{
    class Program
    {
        static void Main()
        {
            //Leitura do arquivo de entrada:
            string pathMatriz = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "matriz.txt");
            string input = File.ReadAllText(pathMatriz);
            string[] matriz = input.Split(Environment.NewLine);

            //Matriz de distâncias:
            int numeroCidades = matriz.Length;
            int[,] distancias = new int[numeroCidades, numeroCidades];

            //Preenchimento da matriz:
            for (int i = 0; i < numeroCidades; i++)
            {
                string[] d = matriz[i].Split(',');
                for (int j = 0; j < numeroCidades; j++)
                    int.TryParse(d[j], out distancias[i, j]);
            }

            //////Definição do percurso:
            string pathPercurso = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "caminho.txt");
            int[] cidades = File.ReadAllText(pathPercurso).Split(',').Select(int.Parse).ToArray();

            //Cálculo da distância percorrida:
            int distanciaPercorrida = 0;
            for (int k = 0; k < cidades.Length - 1; k++)
            {
                int cidadeInicial = cidades[k];
                int cidadeFinal = cidades[k + 1];
                distanciaPercorrida = distanciaPercorrida + distancias[cidadeInicial - 1, cidadeFinal - 1];
            }
            Console.WriteLine($"Distância total: {distanciaPercorrida} km");
        }
    }
}