using AppointmentSystem.Modal.Bal;
using AppointmentSystem.Modal.Pal;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSystem.Modal.Dal
{
    public class DalStaffRegister
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
        public static bool insertRegistration(PalStaffRegistration insertRegistration)
        {
            try
            {
                GetConnection();
                insertRegistration.Password = EncryptDecrypt.Encrypt(insertRegistration.Password);
                tblRegistration.InsertOnSubmit(insertRegistration);
                dc.SubmitChanges();

                PalUser newUser = new PalUser();
                newUser.Email = insertRegistration.Email;
                newUser.FirstName = insertRegistration.FirstName;
                newUser.LastName = insertRegistration.LastName;
                newUser.Password = insertRegistration.Password;
                newUser.UserType = 2;
                tblUser.InsertOnSubmit(newUser);
                dc.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static PalStaffRegistration[] ViewRegistration()
        {
            try
            {
                GetConnection();
                var data = from n in tblRegistration select n;
                return data.ToArray<PalStaffRegistration>();
            }

            catch (Exception ex)
            {
                return null;
            }
        }

        public static PalStaffRegistration ShowRecord(int id)
        {
            try
            {
                GetConnection();
                var tempRegistration = (from tmpRegistration in tblRegistration where tmpRegistration.Id == id select tmpRegistration).Single();
                return tempRegistration;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static void DeleteRegistration(int id)
        {
            try
            {
                GetConnection();
                var tempRegistration = (from tmpRegistration in tblRegistration where tmpRegistration.Id == id select tmpRegistration).Single();
                tblRegistration.DeleteOnSubmit(tempRegistration);
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {

            }
        }

        public static bool UpdateRegistration(PalStaffRegistration updateRegistration)
        {
            try
            {
                GetConnection();
                var update = (from n in tblRegistration where n.Id == updateRegistration.Id select n).Single();
                var pass = EncryptDecrypt.Encrypt(updateRegistration.Password);
                update.FirstName = updateRegistration.FirstName;
                update.LastName = updateRegistration.LastName;
                update.Phone = updateRegistration.Phone;
                update.SpecialityName = updateRegistration.SpecialityName;
                update.Email = updateRegistration.Email;
                update.Password = pass;
                update.SpeciallityDescription = updateRegistration.SpeciallityDescription;
                dc.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public static PalStaffRegistration[] SearchRegistration(string text)
        {
            try
            {
                GetConnection();
                var tempRegistration = (from tmpRegistration in tblRegistration where tmpRegistration.FirstName.ToLower() == text.ToLower() select tmpRegistration);
                return tempRegistration.ToArray<PalStaffRegistration>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static bool checkLogin(string email, string password)
        {
            try
            {
                GetConnection();
                var data = (from n in tblRegistration where n.Email == email && n.Password == password select n);
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
