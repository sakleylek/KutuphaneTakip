using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KütüphaneTakip.Core.Entites
{
    public class Book
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public int AuthorId { get; set; }
        public DateTime CDate { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public Author Author { get; set; }
        public BookStatu BookStatu { get; set; }

    }
    public enum BookStatu
    {
        TalepEdildi = 0,
        Rezerve= 1,        
        Boşta = 3
    }

}
