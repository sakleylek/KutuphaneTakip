using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KütüphaneTakip.Core.Entites
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime CDate { get; set; }
        public UserRole UserRole { get; set; }

    }
    public enum UserRole
    {
        User=0,
        Admin=1
    }
        

}
