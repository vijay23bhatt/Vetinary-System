using AppointmentSystem.Appointment;
using AppointmentSystem.ScheduleSlot;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppointmentSystem
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        public static string ConnectionString = "";
        public static int UserType = 0;
        [STAThread]
        static void Main()
        {
      
            ConnectionString = ConfigurationManager.ConnectionStrings["DefaultString"].ToString();
            
            string[] Instance = new string[GetLocalSqlServerInstanceNames().Count];
            GetLocalSqlServerInstanceNames().CopyTo(Instance, 0);
            string path1 = "CN.dll", CN = "";
            try
            {

                // Delete the file if it exists. 
                if (File.Exists(path1))
                {
                    FileStream fs2 = new FileStream("CN.dll", FileMode.OpenOrCreate, FileAccess.Read);
                    StreamReader reader = new StreamReader(fs2);
                    CN = reader.ReadToEnd().ToString();// @"Data Source=ALIGHT4-PC\SQLEXPRESS;Initial Catalog=F:\STOCKMANAGMENT\STOCK MANAGEMENT\STOCKMANAGMENTSYSTEM\STOCKMANAGEMENT.MDF;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
                    //reader.ReadToEnd().ToString();
                    reader.Close();
                    fs2.Close();
                }
                else
                {
                    File.Create("CN.dll").Close();

                }
            }
            catch
            {
            }


            try
            {
                using (SqlConnection conn = new SqlConnection(CN))
                {
                    conn.Open();
                    conn.Close();
                    ConnectionString = CN;
                }
            }
            catch
            {
                try
                {

                    ConnectionString = @"Data Source=.\" + Instance[0] + @";AttachDbFilename=|DataDirectory|\AppointmentSystem.mdf;Integrated Security=True;User Instance=True";
                    using (SqlConnection conn = new SqlConnection(ConnectionString))
                    {
                        conn.Open();
                        conn.Close();
                    }
                }
                catch
                {
                    try
                    {
                        ConnectionString = @"Data Source=.\" + Instance[1] + @";AttachDbFilename=|DataDirectory|\AppointmentSystem.mdf;Integrated Security=True;User Instance=True";
                        using (SqlConnection conn = new SqlConnection(ConnectionString))
                        {
                            conn.Open();
                            conn.Close();
                        }
                    }
                    catch
                    {
                        try
                        {
                            ConnectionString = @"Data Source=.\" + Instance[2] + @";AttachDbFilename=|DataDirectory|\AppointmentSystem.mdf;Integrated Security=True;User Instance=True";
                            using (SqlConnection conn = new SqlConnection(ConnectionString))
                            {
                                conn.Open();
                                conn.Close();
                            }
                        }
                        catch
                        {
                            ConnectionString = @"Data Source=(local);AttachDbFilename=|DataDirectory|\AppointmentSystem.mdf;Integrated Security=True;User Instance=True";
                            using (SqlConnection conn = new SqlConnection(ConnectionString))
                            {
                                conn.Open();
                                conn.Close();
                            }
                        }
                    }
                }
                try
                {
                    if (File.Exists(path1))
                    {
                        //File.Delete(path);
                        System.IO.File.WriteAllText("CN.dll", string.Empty);
                        FileStream fs1 = new FileStream("CN.dll", FileMode.OpenOrCreate, FileAccess.Write);
                        StreamWriter writer = new StreamWriter(fs1);
                        writer.Write(ConnectionString.Trim().ToString());
                        writer.Close();
                        fs1.Close();
                    }
                    else
                    {
                        File.Create("CN.dll").Close();
                        System.IO.File.WriteAllText("CN.dll", string.Empty);
                        FileStream fs1 = new FileStream("CN.dll", FileMode.OpenOrCreate, FileAccess.Write);
                        StreamWriter writer = new StreamWriter(fs1);
                        writer.Write(ConnectionString.Trim().ToString());
                        writer.Close();
                        fs1.Close();
                    }
                }
                catch
                {
                }
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login.Login());//.AddEditScheduleSlot());
        }
        public static IList<string> GetLocalSqlServerInstanceNames()
        {
            RegistryValueDataReader registryValueDataReader = new RegistryValueDataReader();

            string[] instances64Bit = registryValueDataReader.ReadRegistryValueData(RegistryHive.Wow64,
                                                                                    Registry.LocalMachine,
                                                                                    @"SOFTWARE\Microsoft\Microsoft SQL Server",
                                                                                    "InstalledInstances");

            string[] instances32Bit = registryValueDataReader.ReadRegistryValueData(RegistryHive.Wow6432,
                                                                                    Registry.LocalMachine,
                                                                                    @"SOFTWARE\Microsoft\Microsoft SQL Server",
                                                                                    "InstalledInstances");

            // FormatLocalSqlInstanceNames(ref instances64Bit);
            //FormatLocalSqlInstanceNames(ref instances32Bit);

            IList<string> localInstanceNames = new List<string>(instances64Bit);

            localInstanceNames = localInstanceNames.Union(instances32Bit).ToList();

            return localInstanceNames;
        }
        public enum RegistryHive
        {
            Wow64,
            Wow6432
        }
        public class RegistryValueDataReader
        {
            private static readonly int KEY_WOW64_32KEY = 0x200;
            private static readonly int KEY_WOW64_64KEY = 0x100;

            private static readonly UIntPtr HKEY_LOCAL_MACHINE = (UIntPtr)0x80000002;

            private static readonly int KEY_QUERY_VALUE = 0x1;

            [DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegOpenKeyEx")]
            static extern int RegOpenKeyEx(
                        UIntPtr hKey,
                        string subKey,
                        uint options,
                        int sam,
                        out IntPtr phkResult);


            [DllImport("advapi32.dll", SetLastError = true)]
            static extern int RegQueryValueEx(
                        IntPtr hKey,
                        string lpValueName,
                        int lpReserved,
                        out uint lpType,
                        IntPtr lpData,
                        ref uint lpcbData);

            private static int GetRegistryHiveKey(RegistryHive registryHive)
            {
                return registryHive == RegistryHive.Wow64 ? KEY_WOW64_64KEY : KEY_WOW64_32KEY;
            }

            private static UIntPtr GetRegistryKeyUIntPtr(RegistryKey registry)
            {
                if (registry == Registry.LocalMachine)
                {
                    return HKEY_LOCAL_MACHINE;
                }
                return UIntPtr.Zero;
            }

            public string[] ReadRegistryValueData(RegistryHive registryHive, RegistryKey registryKey, string subKey, string valueName)
            {
                string[] instanceNames = new string[0];

                int key = GetRegistryHiveKey(registryHive);
                UIntPtr registryKeyUIntPtr = GetRegistryKeyUIntPtr(registryKey);

                IntPtr hResult;

                int res = RegOpenKeyEx(registryKeyUIntPtr, subKey, 0, KEY_QUERY_VALUE | key, out hResult);

                if (res == 0)
                {
                    uint type;
                    uint dataLen = 0;

                    RegQueryValueEx(hResult, valueName, 0, out type, IntPtr.Zero, ref dataLen);

                    byte[] databuff = new byte[dataLen];
                    byte[] temp = new byte[dataLen];

                    List<String> values = new List<string>();

                    GCHandle handle = GCHandle.Alloc(databuff, GCHandleType.Pinned);
                    try
                    {
                        RegQueryValueEx(hResult, valueName, 0, out type, handle.AddrOfPinnedObject(), ref dataLen);
                    }
                    finally
                    {
                        handle.Free();
                    }

                    int i = 0;
                    int j = 0;

                    while (i < databuff.Length)
                    {
                        if (databuff[i] == '\0')
                        {
                            j = 0;
                            string str = Encoding.Default.GetString(temp).Trim('\0');

                            if (!string.IsNullOrEmpty(str))
                            {
                                values.Add(str);
                            }

                            temp = new byte[dataLen];
                        }
                        else
                        {
                            temp[j++] = databuff[i];
                        }

                        ++i;
                    }

                    instanceNames = new string[values.Count];
                    values.CopyTo(instanceNames);
                }

                return instanceNames;
            }
        }
    }
}
