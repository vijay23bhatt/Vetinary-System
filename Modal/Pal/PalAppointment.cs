using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSystem.Modal.Pal
{
    [Table(Name = "MST_Appointment")]
    public class PalAppointment
    {
        [Column(Name = "Id", IsDbGenerated = true, IsPrimaryKey = true)]
        public int Id { get; set; }

        [Column(Name = "ClientId")]
        public int ClientId { get; set; }

        [Column(Name = "StaffId")]
        public int StaffId { get; set; }

        [Column(Name = "Date")]
        public DateTime Date { get; set; }

        [Column(Name = "StartTime")]
        public string StartTime { get; set; }
        [Column(Name = "EndTime")]
        public string EndTime { get; set; }
    }
    public class PalAppointmentView
    {
        public int Id { get; set; }
        public string ClientId { get; set; }
        public string StaffId { get; set; }
        public DateTime Date { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
}
