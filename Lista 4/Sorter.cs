using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class Sorter
    {
        public static void BubbleSort(ref int[] array, bool crescente = true)
        {
            bool sw;
            do
            {
                sw = false;
                for (int i = 1; i < array.Length; i++)
                {
                    if (array[i] == array[i - 1]) continue; // down side of having a bool controlling weather it should order it ascending or descending

                    if (array[i] < array[i - 1] == crescente)
                    {
                        (array[i], array[i - 1]) = (array[i - 1], array[i]);
                        sw = true;
                    }
                }
            } while (sw);
        }

        public static void SelectionSort(ref int[] array, bool crescente = true)
        {
            for (int current_index_to_insert = 0; current_index_to_insert < array.Length; current_index_to_insert++)
            {
                int lowest_number_index = current_index_to_insert;
                for (int i = current_index_to_insert + 1; i < array.Length; i++)
                    if (array[i] < array[lowest_number_index] == crescente)
                        lowest_number_index = i;

                (array[current_index_to_insert], array[lowest_number_index]) = (array[lowest_number_index], array[current_index_to_insert]);
            }
        }

        public static void InsertionSort(ref int[] array, bool crescente = true)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int sorting_number = array[i];
                int lowest_number_index = i;
                for (int o = i - 1; o >= 0; o--)
                {
                    if (sorting_number < array[o] == crescente)
                    {
                        lowest_number_index = o;
                        array[o + 1] = array[o];
                    }
                    else
                        break;
                }
                array[lowest_number_index] = sorting_number;
            }
        }

        public static void InsertionSort(ref string[] array, bool crescente = true)
        {
            for (int i = 1; i < array.Length; i++)
            {
                string sorting_word = array[i];
                int lowest_number_index = i;
                int current_letter = 0;
                for (int o = i - 1; o >= 0; o--)
                {
                    if (sorting_word[current_letter] < array[o][current_letter] == crescente)
                    {
                        lowest_number_index = o;
                        array[o + 1] = array[o];
                    }
                    else if(sorting_word[current_letter] == array[o][current_letter])
                    {
                        current_letter++;
                        o++;
                        continue;
                    }
                    else
                        break;
                }
                array[lowest_number_index] = sorting_word;
            }
        }

        public static int[] GetRandomIntArray(int size, int min, int max)
        {
            Random rnd = new Random();

            int[] array = new int[size];
            for (int i = 0; i < size; i++)
                array[i] = rnd.Next(min, max);

            return array;
        }
    }
}
