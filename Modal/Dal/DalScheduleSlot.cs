using AppointmentSystem.Modal.Pal;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSystem.Modal.Dal
{
    public class DalScheduleSlot
    {
        protected static DataContext dc;
        protected static Table<PalScheduleSlot> tblScheduleSlot;
        protected static Table<PalUser> tblUser;
        protected static void GetConnection()
        {
            string str = Program.ConnectionString;
            dc = new DataContext(str);
            tblScheduleSlot = dc.GetTable<PalScheduleSlot>();
            tblUser = dc.GetTable<PalUser>();
        }
        public static bool insertScheduleSlot(PalScheduleSlot insertScheduleSlot)
        {
            try
            {
                GetConnection();
                tblScheduleSlot.InsertOnSubmit(insertScheduleSlot);
                dc.SubmitChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static PalScheduleSlot[] ViewScheduleSlot()
        {
            try
            {
                GetConnection();
                var data = from n in tblScheduleSlot select n;
                return data.ToArray<PalScheduleSlot>();
            }

            catch (Exception ex)
            {
                return null;
            }
        }

        public static PalScheduleSlot ShowRecord(int id)
        {
            try
            {
                GetConnection();
                var tempScheduleSlot = (from tmpScheduleSlot in tblScheduleSlot where tmpScheduleSlot.Id == id select tmpScheduleSlot).Single();
                return tempScheduleSlot;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static void DeleteScheduleSlot(int id)
        {
            try
            {
                GetConnection();
                var tempScheduleSlot = (from tmpScheduleSlot in tblScheduleSlot where tmpScheduleSlot.Id == id select tmpScheduleSlot).Single();
                tblScheduleSlot.DeleteOnSubmit(tempScheduleSlot);
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {

            }
        }

        public static bool UpdateScheduleSlot(PalScheduleSlot updateScheduleSlot)
        {
            try
            {
                GetConnection();
                var update = (from n in tblScheduleSlot where n.Id == updateScheduleSlot.Id select n).Single();
                update.Date = updateScheduleSlot.Date;
                update.EndTime = updateScheduleSlot.EndTime;
                update.StartTime = updateScheduleSlot.StartTime;
                update.Room = updateScheduleSlot.Room;

                dc.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public static PalScheduleSlot[] SearchScheduleSlot(string text)
        {
            try
            {
                GetConnection();
                var tempScheduleSlot = (from tmpScheduleSlot in tblScheduleSlot where tmpScheduleSlot.Room.ToLower() == text.ToLower() select tmpScheduleSlot);
                return tempScheduleSlot.ToArray<PalScheduleSlot>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
