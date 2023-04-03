using System;
using System.Collections.Generic;
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


            if ()
            {
                Console.WriteLine("Não é possivel se mover para a esquerda");
            }
            else
            {
                if ()
                {
                    key = ConsoleKey.LeftArrow;
                }

            }

            if ()
            {
                Console.WriteLine("Não é possivel se mover para a esquerda");
            }
            else
            {
                if ()
                {
                    key = ConsoleKey.LeftArrow;
                    
                }
            }

            if ()
            {
                key = ConsoleKey.RightArrow;
            }
            else { Console.WriteLine("Não é possivel se mover para a esquerda"); }

            if ()
            {
                key = ConsoleKey.DownArrow;
            }
            else { Console.WriteLine("Não é possivel se mover para baixo"); }
        }
    }
}
