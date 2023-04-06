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
        string resposta = "Não, ele não está mentindo, ele consegue obter esse resultado com duas possibilidades, de acordo com o gráfico mostrado: " +
            "\n - Se o array possuir a melhor hipótese do Insertion Sort, será possivel \"ordenar\" o array com apenas 5 comparações." +
            "\n - Se for usado o algoritmo de Merge Sort é possivel ordenar o array de 6 números em 7 comparações" +
            "\n Porém, esse amigo disse 'qualquer array' e não é qualquer array que se encaixa na primeira opção, sendo assim" +
            "\n a opção 2 (Merge Sort) a única restante.";

        public void Executar()
        {
            Console.WriteLine(resposta);
        }
    }
}
