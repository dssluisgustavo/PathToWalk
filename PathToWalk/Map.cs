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

            for (int i = 0; i < cells.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < cells.GetLength(0) - 1; j++)
                {
                    var cell = cells[i, j];

                    if( i > 0)
                    {
                        cell.up = cells[i - 1, j];
                    }

                    if ( j > 0)
                    {
                        cell.left = cells[i, j - 1];
                    }

                    if (i < cells.GetLength(0) - 1)
                    {
                        cell.down = cells[i + 1, j];
                    }

                    if(j < cells.GetLength(0) - 1)
                    {
                        cell.right = cells[i, j + 1];
                    }

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

            //While tem q ter a célula em baixo do Entrance como condição aaaaaaaaa
            while (start != finish)
            {
                int door = randNum.Next(1, 5);

                // 1 - para baixo
                // 2 - para cima 
                // 3 - para right
                // 4 - para left

                switch (door)
                {
                    case 1:
                        //seta celula de baixo como floor e segura ela

                        if (start.down.blockType == Cell.ObjectType.Wall /*|| start.down.blockType == Cell.ObjectType.Block*/)
                        {
                            continue;
                        }

                        start = start.down;
                        start.blockType = Cell.ObjectType.Floor;

                        break;

                    case 2:
                        if (start.up.blockType == Cell.ObjectType.Entrance
                            /*|| start.up.blockType == Cell.ObjectType.Block*/
                            || start.up.blockType == Cell.ObjectType.Wall)
                        {
                            continue;
                        }

                        start = start.up;
                        start.blockType = Cell.ObjectType.Floor;

                        break;

                    case 3:
                        //seta celula da direita como floor e segura el

                        if (start.right.blockType == Cell.ObjectType.Wall /*|| start.right.blockType == Cell.ObjectType.Block*/)
                        {
                            continue;
                        }

                        start = start.right;
                        start.blockType = Cell.ObjectType.Floor;

                        break;

                    case 4:
                        //seta celula da esquerda como floor e segura el

                        if (start.left.blockType == Cell.ObjectType.Wall /*|| start.left.blockType == Cell.ObjectType.Block*/)
                        {
                            continue;
                        }

                        start = start.left;
                        start.blockType = Cell.ObjectType.Floor;

                        break;
                }

            }
        }
    }
}

