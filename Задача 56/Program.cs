//Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.

//Например, задан массив:

//1 4 7 2

//5 9 2 3

//8 4 2 4

//5 2 6 7

//Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка

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
Console.WriteLine($"Самая минимальная сумма элементов в строке {NumberMinRaw(intArray)} ");




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

int NumberMinRaw(int[,] arr)
{
    int sum = 0;
    int result = 0;
    int min = 1000000;
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1);  j++)
        {
            sum = sum + arr[i, j];
        }
        Console.WriteLine($"в строке {i} сумма элементов равна {sum}");
        if (min > sum)
        {
            min = sum;
            result = i;
        }
        sum = 0;
    }
    return result;
}