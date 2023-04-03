using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace PathToWalk
{
    public class Map
    {
        public Cell[,] cells;

        public void BuildMap(int line, int column)
        {
            cells = new Cell[line, column];

            Cell.ObjectType block = Cell.ObjectType.Block;
            Cell.ObjectType wall = Cell.ObjectType.Wall;

            for (int i = 0; i < cells.GetLength(0); i++)
            {
                for (int j = 0; j < cells.GetLength(1); j++)
                {
                    Cell newCell = new Cell();

                    cells[i, j] = newCell;

                    newCell.blockType = block;
                }
            }

            for (int i = 0; i < line; i++)
            {
                cells[i, cells.GetLength(1) - 1].blockType = wall;
                cells[i, 0].blockType = wall;
            }
            for (int j = 0; j < column; j++)
            {
                cells[cells.GetLength(0) - 1, j].blockType = wall;
                cells[0, j].blockType = wall;
            }

            for (int i = 1; i < cells.GetLength(0) - 1; i++)
            {
                for (int j = 1; j < cells.GetLength(0) - 1; j++)
                {
                    var cell = cells[i, j];

                    cell.down = cells[i + 1, j];
                    cell.left = cells[i, j - 1];
                    cell.right = cells[i, j + 1];
                }
            }
        }

        public void BuildPath()
        {
            Random randNum = new Random();

            //int randomLine = randNum.Next(0, cells.GetLength(0) - 1);
            int randomColumn = randNum.Next(1, cells.GetLength(1) - 1);

            cells[0, randomColumn].blockType = Cell.ObjectType.Entrance;
            cells[cells.GetLength(0) - 1, randomColumn].blockType = Cell.ObjectType.Exit;

            Cell start = cells[1, randomColumn];
            start.blockType = Cell.ObjectType.Floor;

            Cell finish = cells[cells.GetLength(0) - 2, randomColumn];
            finish.blockType = Cell.ObjectType.Floor;

            //pega celula down e seta como floor para o player se movimentar e apartir dela, tira um random

            /*var randomWay = randNum.Next(1, 3);

            switch (randomWay)
            {
                case 1:
                    cell.left = cells[1, randomColumn - 1];
                    cell.left.isVisible = true;
                    cell.left.blockType = floor;

                    break;

                case 2:
                    cell.right = cells[1, randomColumn - 2];
                    cell.right.isVisible = true;
                    cell.right.blockType = floor;

                    break;

                case 3:
                    cell.down = cells[2, randomColumn];
                    cell.down.isVisible = true;
                    cell.down.blockType = floor;

                    break;

            }*/

            //While tem q ter a célula em baixo do Entrance como condição aaaaaaaaa
            while (start != finish)
            {
                int door = randNum.Next(1, 4);

                // 1 - para baixo
                // 2 - para left 
                // 3 - para right

                switch (door)
                {
                    case 1:
                        //seta celula de baixo como floor e segura ela

                        if (start.down.blockType == Cell.ObjectType.Wall)
                        {
                            continue;
                        }

                        start = start.down;
                        start.blockType = Cell.ObjectType.Floor;

                        break;

                    case 2:
                        //seta celula da esquerda como floor e segura el

                        if (start.left.blockType == Cell.ObjectType.Wall)
                        {
                            continue;
                        }

                        start = start.left;
                        start.blockType = Cell.ObjectType.Floor;

                        break;

                    case 3:
                        //seta celula da direita como floor e segura el

                        if (start.right.blockType == Cell.ObjectType.Wall)
                        {
                            continue;
                        }

                        start = start.right;
                        start.blockType = Cell.ObjectType.Floor;

                        break;
                }

            }
        }
    }
}

