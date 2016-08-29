using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSystem.Modal.Pal
{
     [Table(Name = "User")]
    public class PalUser
    {
         [Column(Name = "Id", IsDbGenerated = true, IsPrimaryKey = true)]
         public int Id { get; set; }

         [Column(Name = "FirstName")]
         public string FirstName { get; set; }

         [Column(Name = "LastName")]
         public string LastName { get; set; }

         [Column(Name = "Password")]
         public string Password { get; set; }

         [Column(Name = "Email")]
         public string Email { get; set; }

         [Column(Name = "UserType")]
         public int UserType { get; set; }
    }
}
