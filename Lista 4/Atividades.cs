using Sorting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividades
{
    public class Atividade1 : IAtividade
    {

        int[] C = Sorter.GetRandomIntArray(10, 1, 10);
        int[] D = Sorter.GetRandomIntArray(10, 1, 10);
        public void Executar()
        {
            Console.WriteLine("Insertion sort");

            Sorter.InsertionSort(ref C);
            Console.WriteLine($"Crescente = [{string.Join(" ,", C)}]");

            Sorter.InsertionSort(ref D, false);
            Console.WriteLine($"Decrescente = [{string.Join(" ,", D)}]");
        }

    }

    public class Atividade2 : IAtividade
    {
        string[] random_words = { "alabama", "daniel", "albino", "razão", "ordem", "minecraft", "csharp", "coelho" };
        public void Executar()
        {
            Sorter.InsertionSort(ref random_words);
            Console.WriteLine($"Crescente: [{string.Join(", ", random_words)}]");

            Sorter.InsertionSort(ref random_words, false);
            Console.WriteLine($"Decrescente: [{string.Join(", ", random_words)}]");
        }
    }

    public class Atividade3 : IAtividade
    {
        int[] C = Sorter.GetRandomIntArray(10, 1, 10);
        int[] D = Sorter.GetRandomIntArray(10, 1, 10);
        public void Executar()
        {
            Console.WriteLine("Bubble sort");

            Sorter.BubbleSort(ref C);
            Console.WriteLine($"Crescente = [{string.Join(" ,", C)}]");

            Sorter.BubbleSort(ref D, false);
            Console.WriteLine($"Decrescente = [{string.Join(" ,", D)}]");
        }
    }

    public class Atividade4 : IAtividade
    {
        string resposta = "Verdadeiro se for considerar o que o nomero de comparações do MergeSort é O(n log n) (como mostrado na tabela), e falso se"
            +"\nse for considerar que o MergeSort tem a complexidade de O(n log2 n) que daria, aproximadamente, 15,51.";

        public void Executar()
        {
            Console.WriteLine(resposta);
        }
    }
}
