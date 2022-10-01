// Задача 56: Задайте прямоугольный двумерный массив.
// Напишите программу, которая будет находить строку с наименьшей суммой элементов.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке
// и выдаёт номер строки с наименьшей суммой элементов: 1 строка

Console.Clear();
int[,] CreateMatrixRndInt(int rows, int columns, int min, int max)
{
    int[,] matrix = new int[rows, columns];

    Random rnd = new Random();
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = rnd.Next(min, max + 1);
        }
    }
    return matrix;
}

void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        Console.Write("|");
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i, j],6} ");
        }
        Console.WriteLine("|");
    }
}

int SumRowElements(int[,] matrix, int i)
{
    int sumRow = matrix[i, 0];
    for (int j = 1; j < matrix.GetLength(1); j++)
    {
        sumRow += matrix[i, j];
    }
    return sumRow;
}

int MinSum(int[,] matrix)
{
    int min = 1;
    int sumLine = SumRowElements(matrix, 0);
    for (int i = 1; i < matrix.GetLength(0); i++)
    {
        int temp = SumRowElements(matrix, i);
        if (sumLine > temp)
        {
            sumLine = temp;
            min = i + 1;
        }
    }
    return min;
}

int[,] array2D = CreateMatrixRndInt(4, 3, 0, 5);
PrintMatrix(array2D);
int result = MinSum(array2D);
Console.WriteLine($"Наименьшая сумма в строке {result}");