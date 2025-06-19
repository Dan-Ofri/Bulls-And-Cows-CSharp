using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05
{
    public class Feedback
    {
        public int Hits { get; }
        public int Blows { get; }

        public Feedback(int i_Hits, int i_Blows)
        {
            Hits = i_Hits;
            Blows = i_Blows;
        }
    }
}
