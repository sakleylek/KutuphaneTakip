using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KütüphaneTakip.Core.Entites
{
    public class Reservation
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public User User { get; set; }
        public ReservationStatu? ReservationStatu { get; set; }


    }
    public enum ReservationStatu
    {
        TalepEdildi=0,
        Onaylandı=1,
        Red=2,
        
    }

}
