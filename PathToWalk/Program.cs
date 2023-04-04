// See https://aka.ms/new-console-template for more information

using PathToWalk;
using System.Linq;
internal class Program
{
    static Player player;
    static Map map;
    public static void ShowMap()
    {
        
        for (int i = 0; i < map.cells.GetLength(0); i++)
        {
            for (int j = 0; j < map.cells.GetLength(1); j++)
            {
                if (map.cells[i, j] == player.Cell)
                {
                    Console.Write("|@|");

                    continue;
                }

                if (map.cells[i, j].blockType == Cell.ObjectType.Entrance)
                {
                    Console.Write("| |");

                    continue;
                }

                if (map.cells[i, j].blockType == Cell.ObjectType.Wall 
                 || map.cells[i, j].blockType == Cell.ObjectType.Block
                 || map.cells[i, j].blockType == Cell.ObjectType.Exit
                 || map.cells[i, j].blockType == Cell.ObjectType.Floor)
                {
                    Console.Write("|O|");

                    continue;
                }
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
    private static void Main(string[] args)
    {
        int line;
        int column;

        map = new Map();

        do
        {
            Console.Clear();

            Console.WriteLine("Digite um número maior que 0 para a Linha");
        }
        while (int.TryParse(Console.ReadLine(), out line) == false || line <= 0);

        do
        {
            Console.Clear();

            Console.WriteLine("Digite um número maior que 0 para a Coluna");
        }
        while (int.TryParse(Console.ReadLine(), out column) == false || column <= 0);


        map.BuildMap(line, column);
        map.BuildPath();

        //intancia o player

        player = new Player();

        player.Cell = (from Cell Cell in map.cells
                       where Cell.blockType == Cell.ObjectType.Entrance
                       select Cell).FirstOrDefault();

        while (true)
        {
            Console.Clear();

            Console.WriteLine();

            ShowMap();

            ConsoleKey movement;

            Console.WriteLine("Digite a direção desejada");
            movement = Console.ReadKey(true).Key;

           player.Move(movement);

            if (player.Cell.blockType == Cell.ObjectType.Exit)
            {
                break;
            }

            if (movement == ConsoleKey.Escape)
            {
                Console.WriteLine("Comando inválido");
            }
        }

    }
}