using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace Caixeiro_Viajante
{
    class Program
    {
        static void Main()
        {
            //Configurando o recebimento do arquivo de entrada
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
            };
            //Leitura do arquivo de entrada:
            string pathMatriz = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "matriz.txt");
            using var readerMatriz = new StreamReader(pathMatriz);
            using var csvMatriz = new CsvParser(readerMatriz, config);

            //Verificação de existência de conteúdo:
            if (!csv.Read())
                return;

            //Matriz de distâncias:
            int numeroCidades = csvMatriz.Record.Length;
            int[,] distancias = new int[numeroCidades, numeroCidades];

            //Preenchimento da matriz:
            for (int i = 0; i < numeroCidades; i++)
            {
                string[] d = csvMatriz.Record;
                for (int j = 0; j < numeroCidades; j++)
                    int.TryParse(d[j], out distancias[i, j]);
                csvMatriz.Read();
            }
            
            //////Definição do percurso:
            string pathPercurso = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "caminho.txt");
            using var readerPercurso = new StreamReader(pathPercurso);
            using var csvPercurso = new CsvParser(readerPercurso, config);
            int[] cidades = csvPercurso.Record.Select(int.Parse).ToArray(); 

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