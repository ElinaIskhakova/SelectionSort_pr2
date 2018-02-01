using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace SIAOD
{
    class Population
    {
        public string state;
        public string city;
        public int population;
        public Population(string state, string city, int population)
        {
            this.state = state;
            this.city = city;
            this.population = population;
        }
    }
    class SortSelectandPrint
    {
        public SortSelectandPrint()
        {
        }
        public int getPopulation(Population population)
        {
            return population.population;
        }
        public void SortSelection(Population []population)
        {
            for (int i = 0; i < population.Length - 1; i++)
            {
                //поиск минимального числа
                int min = i;
                for (int j = i + 1; j < population.Length; j++)
                {
                    if (getPopulation(population[j]) < getPopulation(population[min]))
                    {
                        min = j;
                    }
                }
                //обмен элементов
                Population temp = population[min];
                population[min] = population[i];
                population[i] = temp;
            }
            Console.WriteLine("State, City, Population");
            for (int i = 0; i < population.Length; i++)
            {
                Console.WriteLine("{0}, {1}, {2}", population[i].state, population[i].city, population[i].population);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string filepath = @"C:\Users\USER\Documents\Visual Studio 2015\Projects\SIAOD\SIAOD\population1.csv";
            if ((!File.Exists(filepath)))
                Console.WriteLine("File is error");
            int count = (System.IO.File.ReadAllLines(filepath).Length)-10000;
    
            Population[] population = new Population[count];
            char separator = ';';
            using (StreamReader reader = File.OpenText(filepath))
            {
                while (!reader.EndOfStream)
                {
                    for (int i = 0; i < count; i++)
                    {
                        string text = reader.ReadLine();
                        string[] sharedtext = text.Split(separator);
                        population[i] = new Population((sharedtext[0]), (sharedtext[1]), Convert.ToInt32(sharedtext[2]));
                    }
                }
            }
            SortSelectandPrint sort = new SortSelectandPrint();
            var watch = System.Diagnostics.Stopwatch.StartNew();
            sort.SortSelection(population);
            watch.Stop();
            Console.WriteLine("Выполнение сортировки заняло: {0}",watch.Elapsed.TotalSeconds);
            Console.ReadKey();
        }
       
    }
    
}


    


