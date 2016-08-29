using AppointmentSystem.Modal.Pal;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSystem.Modal.Dal
{
    public class DalUser
    {
        protected static DataContext dc;
        protected static Table<PalStaffRegistration> tblRegistration;
        protected static Table<PalUser> tblUser;
        protected static void GetConnection()
        {
            string str = Program.ConnectionString;
            dc = new DataContext(str);
            tblRegistration = dc.GetTable<PalStaffRegistration>();
            tblUser = dc.GetTable<PalUser>();

        }
        public static PalUser[] ViewUser()
        {
            try
            {
                GetConnection();
                var data = (from n1 in tblUser select n1);
                return data.ToArray<PalUser>();
            }
            catch { return null; }
        }
        public static bool checkLogin(string email, string password)
        {
            try
            {
                GetConnection();
                var data = (from n in tblUser where n.Email == email && n.Password == password select n);
                if (data.Count() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch { return false; }
        }

        
    }
}
