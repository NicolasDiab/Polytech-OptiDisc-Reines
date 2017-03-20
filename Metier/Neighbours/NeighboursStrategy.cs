using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier.Neighbours
{
    interface NeighboursStrategy
    {
        List<Board> compute(Board board, Dictionary<int,int> tabuList = null);
    }
}
