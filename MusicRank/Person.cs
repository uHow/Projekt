using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicRank
{
    public class Person
    {
        public String name { get; set; }
        public String surname { get; set; }
        public String sex { get; set; }

        public virtual String Myname()
        {
            return ("Song added, author: " + surname);
        }
    }
}
