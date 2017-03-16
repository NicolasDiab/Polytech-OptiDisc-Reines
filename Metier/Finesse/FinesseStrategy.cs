using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier.Finesse
{
    interface FinesseStrategy
    {
        int compute(Board position);
    }
}
