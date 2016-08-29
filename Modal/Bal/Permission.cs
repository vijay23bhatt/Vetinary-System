using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSystem.Modal.Bal
{
    public class Permission
    {
        public static bool AddEditStaffRegister(int UserType)
        {
            if (UserType == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool StaffRegisterList(int UserType)
        {
            if (UserType == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool AddEditClientRegister(int UserType)
        {
            if (UserType == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool ClientRegisterList(int UserType)
        {
            if (UserType == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
