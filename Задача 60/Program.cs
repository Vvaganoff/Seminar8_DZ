//Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
//Массив размером 2 x 2 x 2
//66(0,0,0) 25(0, 1, 0)
//34(1, 0, 0) 41(1, 1, 0)
//27(0, 0, 1) 90(0, 1, 1)
//26(1, 0, 1) 55(1, 1, 1)

Console.Write("Введите размер трехмерного массива: ");
string strArraySize = Console.ReadLine(); //Пользователь вводит два размера: количество строк и столбцов
char[] charSeparators = new char[] { ' ', 'x', '+', '*', 'X', '-', ',', ';' };//Определяем, чем пользователь может отделить размеры
string[] strArrayOfArraySize = strArraySize.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);

if (strArrayOfArraySize.Length != 3) //Если пользователь ввёл не два числа, то выдаём ошибку и выходим
{
    Console.WriteLine("У трехмерного массива три размера");
    return;
}
int[] intArraySize = new int[strArrayOfArraySize.Length];             //Преобразуем строковый массив в массив целых
for (int i = 0; i < strArrayOfArraySize.Length; i++)                  //
{
    intArraySize[i] = Convert.ToInt32(strArrayOfArraySize[i]);        //
}

int[, ,] intArray = new int[intArraySize[0], intArraySize[1], intArraySize[2]];
intArray = FillArray(intArraySize);
PrintArray(intArray);


int[, ,] FillArray(int[] intArraySize) //Функция заполняет массив случайными числами. На вход получает массив размеров, возвращает трехмерный массив
{
    var random = new Random();
    var randomInt = new Random();
    int[, ,] resultArray = new int[intArraySize[0], intArraySize[1], intArraySize[2]];
    for (int i = 0; i < intArraySize[0]; i++)
    {
        for (int j = 0; j < intArraySize[1]; j++)
        {
            for (var k = 0; k < intArraySize[2]; k++)
            {
                resultArray[i, j, k] = random.Next(-10, 10);
            }
        }
    }
    return resultArray;
}

void PrintArray(int[, ,] arr)//Метод выводит массив на экран в формате [.., .., .., ..]
{

    for (int i = 0; i < arr.GetUpperBound(0) + 1; i++)
    {
        for (int j = 0; j < arr.GetUpperBound(1) + 1; j++)
        {
            for (int k = 0; k < arr.GetLength(2); k++)
            {
                if (i == arr.GetUpperBound(0) && j == arr.GetUpperBound(1) && k == arr.GetUpperBound(2))
                {
                    Console.Write($"{arr[i, j, k]} ({i}, {j}, {k})");
                }
                else
                {
                    Console.Write($"{arr[i, j, k]} ({i}, {j}, {k}); ");
                }

            }

        }
        Console.WriteLine("");
    }
}