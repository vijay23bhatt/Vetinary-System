using AppointmentSystem.Modal.Pal;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSystem.Modal.Dal
{
    public class DalAppointment
    {
        protected static DataContext dc;
        protected static Table<PalClientRegistration> tblClientRegistration;
        protected static Table<PalStaffRegistration> tblStaffRegistration;
        protected static Table<PalAppointment> tblAppointment;
        protected static void GetConnection()
        {
            string str = Program.ConnectionString;
            dc = new DataContext(str);
            tblClientRegistration = dc.GetTable<PalClientRegistration>();
            tblStaffRegistration = dc.GetTable<PalStaffRegistration>();
            tblAppointment = dc.GetTable<PalAppointment>();
        }
        public static bool insertAppointment(PalAppointment insertAppointment)
        {
            try
            {
                GetConnection();
                tblAppointment.InsertOnSubmit(insertAppointment);
                dc.SubmitChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static PalAppointment[] ViewAppointment()
        {
            try
            {
                GetConnection();
                var data = from n in tblAppointment select n;
                return data.ToArray<PalAppointment>();
            }

            catch (Exception ex)
            {
                return null;
            }
        }
        public static PalAppointmentView[] ViewAppointmentView()
        {
            try
            {
                GetConnection();
                var data = from n in tblAppointment
                           select new PalAppointmentView()
                           {
                               Id = n.Id,
                               ClientId = (from n1 in tblClientRegistration where n.ClientId == n1.Id select n1).Single().FirstName,
                               StaffId = (from n1 in tblStaffRegistration where n.StaffId == n1.Id select n1).Single().FirstName,
                               Date = n.Date,
                               StartTime = n.StartTime,
                               EndTime = n.EndTime
                           };
                return data.ToArray<PalAppointmentView>();
            }

            catch (Exception ex)
            {
                return null;
            }
        }
        public static PalAppointmentView[] ViewAppointmentStaffId(int id)
        {
            try
            {
                GetConnection();
                var data = from n in tblAppointment
                           where n.StaffId == id
                           select new PalAppointmentView()
                           {
                               Id = n.Id,
                               ClientId = (from n1 in tblClientRegistration where n.ClientId == n1.Id select n1).Single().FirstName,
                               StaffId = (from n1 in tblStaffRegistration where n.StaffId == n1.Id select n1).Single().FirstName,
                               Date = n.Date,
                               StartTime = n.StartTime,
                               EndTime = n.EndTime
                           };
                return data.ToArray<PalAppointmentView>();
            }

            catch (Exception ex)
            {
                return null;
            }
        }
        public static PalAppointment ShowRecord(int id)
        {
            try
            {
                GetConnection();
                var data = (from n in tblAppointment where n.Id == id select n).Single();
                return data;
            }

            catch (Exception ex)
            {
                return null;
            }
        }
        public static bool UpdateAppointment(PalAppointment newAppointment)
        {
            try
            {
                GetConnection();
                var data = (from n in tblAppointment where n.Id == newAppointment.Id select n).Single();
                data.ClientId = newAppointment.ClientId;
                data.Date = newAppointment.Date;
                data.StaffId = newAppointment.StaffId;
                data.StartTime = newAppointment.StartTime;
                data.EndTime = newAppointment.EndTime;
                dc.SubmitChanges();
                return true ;
            }

            catch (Exception ex)
            {
                return false;
            }
        }
        public static void DeleteAppointment(int id)
        {
            try
            {
                GetConnection();
                var data =(from n in tblAppointment where n.Id == id select n).Single();
                tblAppointment.DeleteOnSubmit(data);
                dc.SubmitChanges();
            }
            catch { }
        }
        public static PalAppointmentView[] SearchAppointment(string text)
        {
            try
            {
                GetConnection();
                var data = (from n in tblAppointment
                            join n1 in tblClientRegistration on n.ClientId equals n1.Id
                            where n1.FirstName == text
                            select new PalAppointmentView()
                            {
                                ClientId = n1.FirstName,
                                Date = n.Date,
                                Id = n.Id,
                                StaffId = (from n2 in tblStaffRegistration where n.StaffId == n2.Id select n2).Single().FirstName,
                                StartTime = n.StartTime,
                                EndTime = n.EndTime
                            });
                return data.ToArray<PalAppointmentView>();
            }
            catch { return null; }
        }

    }
}
