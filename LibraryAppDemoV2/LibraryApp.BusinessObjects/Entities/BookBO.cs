using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.BusinessObjects.Entities
{
    public class BookBO : BaseObject
    {
        
        public string Name { get; set; }
        public double Price { get; set; }
        public List<BookBO> Books { get; set; }
    }
}
