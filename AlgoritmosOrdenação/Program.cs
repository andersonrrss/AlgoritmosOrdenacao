using System.Linq;

namespace AlgoritmosOrdenação
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 1, 4, 2, 5, 76, 345, 123, 134, 254, 23,34345,-1,45,0,-45 };
            int[] sortedArray = Sort.Merge(array);
            Console.WriteLine(String.Join(",", sortedArray));
        }
    }
    class Sort
    {
        public static int[] Bubble(int[] list)
        {
            for (int i = list.Length - 1; i >= 0; i--)
            {
                // Checa se ouve alguma troca
                bool swapped = false;
                for(int j = 0; j < i; j++)
                {
                    // Se o elemento atual for maior que seu sucessor
                    if(list[j] > list[j+1])
                    {
                        // troca os elementos
                        int temp = list[j];
                        list[j] = list[j+1];
                        list[j + 1] = temp;

                        swapped = true;
                    }
                }
                // Se não ouve nenhuma troca então o array já está ordenado
                if (!swapped)
                {
                    break;
                }
            }
            return list;
        }
        public static int[] Selection(int[] list)
        {
            for(int i = 0; i < list.Length; i++)
            {
                int smallestIndex = i; // Índice do menor número
                // Itera sobre a lista a partir do i
                for (int j = i+1; j < list.Length; j++)
                {
                    // Se o número atual for menor que o menor número já armazenado
                    if (list[j] < list[smallestIndex])
                    {
                        smallestIndex = j;
                    }
                }
                // Troca os números
                int temp = list[smallestIndex]; // Armazena o menor número da lista
                list[smallestIndex] = list[i]; // Define o valor do índice do menor número para o valor no I
                list[i] = temp; // Define o I para ser igual ao menor número
            }

            return list;
        }
        public static int[] Merge(int[] list)
        {
            if(list.Length <= 1)
            {
                return list; // Retorna se o tamanho da list for de 1 elemento(o que significa que ela já é ordenada)
            }
            int middleIndex = list.Length/2; // Índice do meio do array

            int[] leftPart = Merge(list.Take(middleIndex).ToArray()); // Resolve a parte esquerda da lista
            int[] rightPart = Merge(list.Skip(middleIndex).ToArray()); // Resolve a parte direita da lista

            int[] mergedList = new int[leftPart.Length+rightPart.Length]; //Lista mesclada do tamanho somado da parte esquerda e da direita
            int i = 0, j = 0, k = 0; // Variáveis de controle
            // Elementos enquanto ambas as listas têm elementos
            while (i < leftPart.Length && j < rightPart.Length) {
                if (leftPart[i] < rightPart[j])
                {
                    mergedList[k++] = leftPart[i++];
                }
                else
                {
                    mergedList[k++] = rightPart[j++];
                }
            }
            // Elementos restante da esquerda
            while(i < leftPart.Length)
            {
                mergedList[k++] = leftPart[i++]; 
            }
            // Elementos restantes da direita
            while (j < rightPart.Length)
            {
                mergedList[k++] = rightPart[j++];
            }

            return mergedList;
        }
    }
}
