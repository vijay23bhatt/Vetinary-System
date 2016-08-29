using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSystem.Modal.Pal
{
    [Table(Name = "MST_ClientRegistration")]
    public class PalClientRegistration
    {
        [Column(Name = "Id", IsDbGenerated = true, IsPrimaryKey = true)]
        public int Id { get; set; }

        [Column(Name = "FirstName")]
        public string FirstName { get; set; }

        [Column(Name = "LastName")]
        public string LastName { get; set; }

        [Column(Name = "Address")]
        public string Address { get; set; }

        [Column(Name = "Password")]
        public string Password { get; set; }

        [Column(Name = "Suburb")]
        public string Suburb { get; set; }

        [Column(Name = "Phone")]
        public string Phone { get; set; }

        [Column(Name = "Email")]
        public string Email { get; set; }
    }
}
