//Задача 62.Напишите программу, которая заполнит спирально массив 4 на 4.
//Например, на выходе получается вот такой массив:
//01 02 03 04
//12 13 14 05
//11 16 15 06
//10 09 08 07

int horizontal = 4; //Задаём размер массива: количество столбцов
int vertical = 4; //количество строк
int[,] spiral = new int[vertical, horizontal];
int s = 1; //Задаём начало отсчета;

//Заполняем периметр
for (int j = 0; j < horizontal; j++)
{
    spiral[0, j] = s;
    s++;
}

for (int i = 1; i < vertical; i++)
{
    spiral[i, horizontal-1] = s;
    s++;
}

for (int j = horizontal - 2; j >= 0; j--)
{
    spiral[vertical - 1, j] = s;
    s++;
}

for (int i = vertical - 2; i >= 1; i--)
{
    spiral[i, 0] = s;
    s++;
}

int c = 1;//Координаты точки начала заполнения внутри
int d = 1;//
//При инициализации массива он заполняется нулями. Периметр заполнен не нулевыми значениями. Теперь мы будем использовать их как границу
while(s < horizontal * vertical)
{
    while (spiral[c, d +1] == 0)
    {
        spiral[c, d] = s;
        s++;
        d++;
    }
    while (spiral[c +1, d] == 0)
    {
        spiral[c, d] = s;
        s++;
        c++;
    }
    while (spiral[c, d - 1] == 0)
    {
        spiral[c, d] = s;
        s++;
        d--;
    }
    while (spiral[c - 1, d] == 0)
    {
        spiral[c, d] = s;
        s++;
        c--;
    }
}

for (int i = 0; i < vertical; i++)
{
    for (int j = 0; j < horizontal; j++)
    {
        if (spiral[i, j] == 0)
        {
            spiral[i, j] = s;
        }
    }
}
PrintArray(spiral);

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