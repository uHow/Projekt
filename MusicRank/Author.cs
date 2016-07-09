using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicRank
{
    public class Author : Person
    {
        public String whatPlays { get; set; }

        public override String Myname()
        {
            return (base.Myname() + " and he likes to play " + whatPlays);

        }
    }

}
