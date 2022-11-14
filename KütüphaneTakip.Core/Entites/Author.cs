using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KütüphaneTakip.Core.Entites
{
    public class Author
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }

        public DateTime CDate { get; set; }
        //public virtual ICollection<Book> Books { get; set; }
    }
}
