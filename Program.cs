/*Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
Массив размером 2 x 2 x 2
66(0,0,0) 25(0,1,0)
34(1,0,0) 41(1,1,0)
27(0,0,1) 90(0,1,1)
26(1,0,1) 55(1,1,1)*/

int[,,] Matrix3D(int z, int x, int y)
{
    int[,,] arr = new int[z, x, y];
    Random rnd = new Random();
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            for (int k = 0; k < arr.GetLength(2); k++)
            {
                int value = 0;
                bool uniqueValue = false;
                while (!uniqueValue)
                {
                    value = rnd.Next(10, 100);
                    uniqueValue = IsUnique(value, arr);
                }
                arr[i, j, k] = value;
            }
        }
    }
    return arr;
}
int GetNumber(string message)
{
    while (true)
    {
        Console.WriteLine(message);
        string? num = Console.ReadLine();
        if (int.TryParse(num, out int number) == false)
            Console.WriteLine("Введено не число");
        else
        {
            if (number <= 0)
                Console.WriteLine("Задайте число больше 0");
            else
                return number;
        }
    }
}

bool IsUnique(int number, int[,,] arr)
{

    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            for (int k = 0; k < arr.GetLength(2); k++)
            {
                if (number == arr[i, j, k])
                    return false;
            }
        }
    }
    return true;
}

void PrintArray(int[,,] arr, string message)
{
    Console.WriteLine(message);
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            for (int k = 0; k < arr.GetLength(2); k++)
            {
                Console.WriteLine($"[{i},{j},{k}]={arr[i, j, k]}");
            }
        }
    }
}


int firstDemension = GetNumber("Задайте количество слоев трехмерного массива : ");
int secondDemension = GetNumber("Задайте количество строк трехмерного массива : ");
int threeDemension = GetNumber("Задайте количество столбцов трехмерного массива : ");

if (firstDemension * secondDemension * threeDemension > 90)
{
    Console.WriteLine("Количество уникальных двухзначных значений массива не может быть больше 90!");
}
else
{
    int[,,] rnd = Matrix3D(firstDemension, secondDemension, threeDemension);
    PrintArray(rnd, "Элементы трехмерного массива имеют вид:");
}
