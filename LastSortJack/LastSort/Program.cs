using System;

class Program
{
    static int[,] labirynth1 = new int[,]
    {
        {1, 1, 1, 1, 1, 1, 1 },
        {1, 0, 0, 0, 0, 0, 1 },
        {1, 0, 1, 1, 1, 0, 1 },
        {0, 0, 0, 0, 1, 0, 0 },
        {1, 1, 0, 0, 1, 1, 1 },
        {1, 1, 1, 0, 1, 1, 1 },
        {1, 1, 1, 0, 1, 1, 1 }
    };

    static void Main()
    {
        int exitCount = CountExits(1, 1, labirynth1);
        Console.WriteLine($"Количество выходов в лабиринте: {exitCount}");
    }

    static int CountExits(int startI, int startJ, int[,] l)
    {
        int rowCount = l.GetLength(0);
        int colCount = l.GetLength(1);
        int exitCount = 0;

        if (startI < 0 || startI >= rowCount || startJ < 0 || startJ >= colCount || l[startI, startJ] == 1)
        {
            return 0;
        }

        if (startI == 0 || startI == rowCount - 1 || startJ == 0 || startJ == colCount - 1)
        {
            // Если текущая позиция находится на грани лабиринта, это считается выходом.
            exitCount++;
        }

        l[startI, startJ] = 1; // Помечаем текущую позицию, чтобы избежать повторных посещений

        // Рекурсивно ищем выходы во всех соседних клетках
        exitCount += CountExits(startI - 1, startJ, l); // Вверх
        exitCount += CountExits(startI + 1, startJ, l); // Вниз
        exitCount += CountExits(startI, startJ - 1, l); // Влево
        exitCount += CountExits(startI, startJ + 1, l); // Вправо

        return exitCount;
    }
}
