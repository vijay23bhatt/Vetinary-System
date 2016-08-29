using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSystem.Modal.Pal
{
    [Table(Name = "MST_ScheduleSlot")]
    public class PalScheduleSlot
    {
        [Column(Name = "Id", IsDbGenerated = true, IsPrimaryKey = true)]
        public int Id { get; set; }

        [Column(Name = "Room")]
        public string Room { get; set; }

        [Column(Name = "StartTime")]
        public string StartTime { get; set; }

        [Column(Name = "EndTime")]
        public string EndTime { get; set; }

        [Column(Name = "Date")]
        public DateTime Date { get; set; }

    }
}
