using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathToWalk
{
    public class Cell
    {
        public ObjectType blockType;
        public bool isVisible;

        public Cell left;
        public Cell right;
        public Cell down;

        public enum ObjectType
        {
            Block,
            Floor,
            Wall,
            Entrance,
            Exit
        }
    }
}
