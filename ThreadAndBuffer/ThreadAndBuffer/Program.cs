using System;
using System.IO;
using System.Collections.Generic;

class FileSearchUtility
{
    static void Main(string[] args)
    {
        if (args.Length != 2)
        {
            Console.WriteLine("Использование: utility.exe <расширение файла> <текст для поиска>");
            return;
        }

        string targetExtension = args[0];
        string searchText = args[1];

        string currentDirectory = Environment.CurrentDirectory;
        SearchFiles(currentDirectory, targetExtension, searchText);

        Console.WriteLine("Поиск завершен.");
    }

    static void SearchFiles(string directory, string targetExtension, string searchText)
    {
        try
        {
            IEnumerable<string> files = Directory.EnumerateFiles(directory, $"*.{targetExtension}");

            foreach (string file in files)
            {
                if (FileContainsText(file, searchText))
                {
                    Console.WriteLine($"Найден файл: {file}");
                }
            }

            IEnumerable<string> subdirectories = Directory.EnumerateDirectories(directory);

            foreach (string subdirectory in subdirectories)
            {
                SearchFiles(subdirectory, targetExtension, searchText);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при поиске файлов: {ex.Message}");
        }
    }

    static bool FileContainsText(string filePath, string searchText)
    {
        try
        {
            string content = File.ReadAllText(filePath);
            return content.Contains(searchText);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при чтении файла {filePath}: {ex.Message}");
            return false;
        }
    }
}

