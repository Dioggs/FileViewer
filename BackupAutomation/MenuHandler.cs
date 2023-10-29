using System.Collections;
using System.Formats.Tar;
using System.Security.Cryptography;

namespace BackupAutomation;

public class MenuHandler
{
    public static void DisplayOptions(List<string> options, string path)
    {
        Console.CursorVisible = false; 
        if (options.Count == 0)
        {
            Console.WriteLine("There are no backup files");
            return;
        }
        int paintPosition = 0;
        string content = "";

        while (true)    
        {
            PrintIntro();
            for (int i = 0; i < options.Count; i++)
            {
                if (i == paintPosition)
                {
                    PaintOption(options[i]);
                    continue;
                }
                
                Console.WriteLine(options[i]);
            }

            Console.WriteLine();
            
            if (content.Length > 0) PrintContent(content);

            int result = GetUserInput(paintPosition, options, path, out content);

            if (result == -1)
            {
                Console.Clear();
                break;
            }

            paintPosition = result;
            
            Console.Clear();    
        }
    }

    private static void PaintOption(string option)
    {
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine(option);
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;
    }

    private static int GetUserInput(int paintPosition, List<string> options, string path, out string content)
    {
        ConsoleKeyInfo keyInfo = Console.ReadKey();

        if (keyInfo.Key == ConsoleKey.UpArrow && paintPosition - 1 >= 0)
        {
            content = "";
            return paintPosition - 1;
        }

        if (keyInfo.Key == ConsoleKey.DownArrow && paintPosition + 1 <= options.Count - 1)
        {
            content = "";
            return paintPosition + 1;
        }

        if (keyInfo.Key == ConsoleKey.Enter)
        {
            content = GetFileContent(paintPosition, options, path);
            return paintPosition;
        }

        if (keyInfo.Key == ConsoleKey.X)
        {
            content = "";
            return -1;
        }

        content = "";
        return paintPosition;
    }

    private static string GetFileContent(int paintPosition, List<string> options, string path)
    {
        string fileName = options[paintPosition];
        return File.ReadAllText($"{path}/{fileName}");
    }

    private static void PrintContent(string content)
    {
        Console.WriteLine();
        Console.WriteLine(content);
    }

    private static void PrintIntro()
    {
        Console.WriteLine("----------------");
        Console.WriteLine("     FILES");        
        Console.WriteLine("---------------\n");
        
    }
}