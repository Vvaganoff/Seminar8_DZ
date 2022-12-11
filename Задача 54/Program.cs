//Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
//Например, задан массив:
//1 4 7 2
//5 9 2 3
//8 4 2 4
//В итоге получается вот такой массив:
//7 4 2 1
//9 5 3 2
//8 4 4 2




Console.Write("Введите размер двухмерного массива: ");
string strArraySize = Console.ReadLine(); //Пользователь вводит два размера: количество строк и столбцов
char[] charSeparators = new char[] { ' ', 'x', '+', '*', 'X', '-', ',', ';' };//Определяем, чем пользователь может отделить размеры
string[] strArrayOfArraySize = strArraySize.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);

if (strArrayOfArraySize.Length != 2) //Если пользователь ввёл не два числа, то выдаём ошибку и выходим
{
    Console.WriteLine("У двухмерного массива два размера: количество строк и количество толбцов");
    return;
}
int[] intArraySize = new int[strArrayOfArraySize.Length];             //Преобразуем строковый массив в массив целых
for (int i = 0; i < strArrayOfArraySize.Length; i++)                  //
{
    intArraySize[i] = Convert.ToInt32(strArrayOfArraySize[i]);        //
}

int[,] intArray = new int[intArraySize[0], intArraySize[1]];
intArray = FillArray(intArraySize);
PrintArray(intArray);
Console.WriteLine("");
intArray = SortRaw(intArray);
PrintArray(intArray);


int[,] FillArray(int[] intArraySize) //Функция заполняет массив случайными числами. На вход получает массив размеров, возвращает двухмерный массив
{
    var random = new Random();
    var randomInt = new Random();
    int[,] resultArray = new int[intArraySize[0], intArraySize[1]];
    for (int i = 0; i < intArraySize[0]; i++)
    {
        for (int j = 0; j < intArraySize[1]; j++)
        {
            resultArray[i, j] = random.Next(-10, 10);
        }
    }
    return resultArray;
}

void PrintArray(int[,] arr)//Метод выводит массив на экран в формате [.., .., .., ..]
{

    for (int i = 0; i < arr.GetUpperBound(0) + 1; i++)
    {
        for (int j = 0; j < arr.GetUpperBound(1) + 1; j++)
        {
            if (i == arr.GetUpperBound(0) && j == arr.GetUpperBound(1))
            {
                Console.Write($"{arr[i, j]}");
            }
            else
            {
                Console.Write($"{arr[i, j]}, ");
            }

        }
        Console.WriteLine("");
    }
}

int[,] SortRaw(int[,] arr)
{
    int temp = 0;
    
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int count = 1; count < arr.GetLength(1); count++)
        {
            for (int j = 0; j < arr.GetLength(1) - count; j++)
            {
                if (arr[i, j+1] > arr[i, j])
                {
                    temp = arr[i, j];
                    arr[i, j] = arr[i, j+1];
                    arr[i, j+1] = temp;
                }
            }
        }
    }
    return arr;
}