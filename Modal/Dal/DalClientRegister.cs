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
    public class DalClientRegister
    {
        protected static DataContext dc;
        protected static Table<PalClientRegistration> tblRegistration;
        protected static Table<PalUser> tblUser;
        protected static void GetConnection()
        {
            string str = Program.ConnectionString;
            dc = new DataContext(str);
            tblRegistration = dc.GetTable<PalClientRegistration>();
            tblUser = dc.GetTable<PalUser>();
        }
        public static bool insertRegistration(PalClientRegistration insertRegistration)
        {
            try
            {
                GetConnection();
                insertRegistration.Password = EncryptDecrypt.Encrypt(insertRegistration.Password);
                insertRegistration.Suburb=EncryptDecrypt.Encrypt(insertRegistration.Suburb);
                tblRegistration.InsertOnSubmit(insertRegistration);
                dc.SubmitChanges();

                PalUser newUser = new PalUser();
                newUser.Email = insertRegistration.Email;
                newUser.FirstName = insertRegistration.FirstName;
                newUser.LastName = insertRegistration.LastName;
                newUser.Password = insertRegistration.Password;
                newUser.UserType = 1;
                tblUser.InsertOnSubmit(newUser);
                dc.SubmitChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static PalClientRegistration[] ViewRegistration()
        {
            try
            {
                GetConnection();
                var data = from n in tblRegistration select n;
                return data.ToArray<PalClientRegistration>();
            }

            catch (Exception ex)
            {
                return null;
            }
        }

        public static PalClientRegistration ShowRecord(int id)
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

        public static bool UpdateRegistration(PalClientRegistration updateRegistration)
        {
            try
            {
                GetConnection();
                var update = (from n in tblRegistration where n.Id == updateRegistration.Id select n).Single();
                var pass = EncryptDecrypt.Encrypt(updateRegistration.Password);
                var suburb = EncryptDecrypt.Encrypt(updateRegistration.Suburb);
                update.FirstName = updateRegistration.FirstName;
                update.LastName = updateRegistration.LastName;
                update.Phone = updateRegistration.Phone;
                update.Address = updateRegistration.Address;
                update.Email = updateRegistration.Email;
                update.Password = pass;
                update.Suburb = suburb;
                dc.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public static PalClientRegistration[] SearchRegistration(string text)
        {
            try
            {
                GetConnection();
                var tempRegistration = (from tmpRegistration in tblRegistration where tmpRegistration.FirstName.ToLower()  == text.ToLower() select tmpRegistration);
                return tempRegistration.ToArray<PalClientRegistration>();
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
