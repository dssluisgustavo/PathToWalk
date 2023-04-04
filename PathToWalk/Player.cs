using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathToWalk
{
    public class Player
    {
        //celula da entrance;
        public Cell Cell { get; set; }
        public void Move(ConsoleKey key)
        {
            //rodar um for com map para pegar celulas do array Cells e a partir dele criar condições para as arrowskaye
            // console key é o método certo e possivelmente aquele q se passará como parâmetro
            // pega a celula da entrance e faz a validação com ela.
            // a célula já foi setada lá no Main e por isso você pode altera-lá aqui dentro

            if (key == ConsoleKey.LeftArrow)
            {
                if (Cell.left.blockType == Cell.ObjectType.Block || Cell.left.blockType == Cell.ObjectType.Wall)
                {
                    Console.WriteLine("Não é possivel se mover para a esquerda");
                }
                else
                {
                    Cell = Cell.left;
                    Cell.isVisible = true;
                }
            }
            
            
            if(key == ConsoleKey.RightArrow)
            {
                if (Cell.right.blockType == Cell.ObjectType.Block || Cell.right.blockType == Cell.ObjectType.Wall)
                {
                    Console.WriteLine("Não é possivel se mover para a direita");
                }
                else
                {
                    Cell = Cell.right;
                    Cell.right.isVisible = true;
                }

            }

            if(key == ConsoleKey.DownArrow)
            {
                if (Cell.down.blockType == Cell.ObjectType.Block || Cell.down.blockType == Cell.ObjectType.Wall)
                {
                    Console.WriteLine("Não é possivel se mover para baixo");
                }

                if (Cell.down.blockType == Cell.ObjectType.Floor || Cell.down.blockType == Cell.ObjectType.Exit)
                {
                    Cell = Cell.down;
                    Cell.down.isVisible = true;

                    if (Cell.down.blockType == Cell.ObjectType.Exit)
                    {
                        Cell = Cell.down;
                        Cell.down.isVisible = true;
                        Console.WriteLine("Parabéns!! Você encontrou a Saida");
                    }
                }
            }
            
            if(key == ConsoleKey.UpArrow)
            {
                if (Cell.up.blockType == Cell.ObjectType.Entrance
                || Cell.up.blockType == Cell.ObjectType.Block
                || Cell.up.blockType == Cell.ObjectType.Wall)
                {
                    Console.WriteLine("Não é possivel se mover para cima");
                }
                else
                {
                    Cell = Cell.up;
                    Cell.up.isVisible = true;
                }
            } 
        }
    }
}
