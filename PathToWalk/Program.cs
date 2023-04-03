// See https://aka.ms/new-console-template for more information

using PathToWalk;
using System.Linq;
internal class Program
{
    public static void ShowMap(Map map)
    {

        for (int i = 0; i < map.cells.GetLength(0); i++)
        {
            for (int j = 0; j < map.cells.GetLength(1); j++)
            {
                if (map.cells[i, j].blockType == Cell.ObjectType.Entrance
                 || map.cells[i, j].blockType == Cell.ObjectType.Exit
                 || map.cells[i, j].blockType == Cell.ObjectType.Floor)
                {
                    Console.Write("| |");
                }

                if (map.cells[i, j].blockType == Cell.ObjectType.Wall)
                {
                    Console.Write("|O|");
                }

                if (map.cells[i, j].blockType == Cell.ObjectType.Block)
                {
                    Console.Write("|#|");
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

        Map map = new Map();

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

        Player player = new Player();

        player.Cell = (from Cell cell in map.cells
                       where cell.blockType == Cell.ObjectType.Entrance
                       select cell).FirstOrDefault();


        Console.Clear();

        Console.WriteLine();

        ShowMap(map);
    }
}