using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authors_Dapper.Model
{
     class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int YearPress { get; set; }

        public int id_Author { get; set; }

        public override string ToString()
        {
            return  Name ;
        }
    }
}
