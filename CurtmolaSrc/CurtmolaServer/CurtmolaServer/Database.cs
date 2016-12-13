using CurtmolaServer;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class TAIPDatabase
    {
        private static volatile TAIPDatabase instanceDatabase;
        private static ModelDBContainer context;
        private static object syncRoot = new Object();
        public IStore mockstore;

        private TAIPDatabase()
        {
            context = new ModelDBContainer();
        }

        public static TAIPDatabase Instance
        {
            get
            {
                if (instanceDatabase == null)
                {
                    lock (syncRoot)
                    {
                        if (instanceDatabase == null)
                            instanceDatabase = new TAIPDatabase();
                    }
                }

                return instanceDatabase;
            }
        }

        public string AddUser(string name, string password)
        {
            int passwordMinLength = 5;
            string result = "SUCCESS";
            try
            {
                if (null == name || null == password)
                {
                    throw new ArgumentException();
                }
                if (String.Empty == name || String.Empty == password)
                {
                    result = "empty name or password";
                }
                else if (password.Length < passwordMinLength)
                {
                    result = "password to short";
                }
                else
                {
                    User user = new User();
                    user.name = name;
                    user.password = password;
                    Folder fold = new Folder();
                    fold.name = name + "Folder";
                    fold.User = user;
                    fold.createdDate = DateTime.Now.ToString();
                    fold.asignedUser = name;

                    // verify if user already in db
                    int UserExist = 0;
                    using (SqlConnection conn = new SqlConnection("data source=DESKTOP-BHSNUIB;initial catalog=TAIP;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;"))
                    {
                        conn.Open();
                        SqlCommand check_User_Name = new SqlCommand("SELECT COUNT(*) FROM Users WHERE (name = @user)", conn);
                        check_User_Name.Parameters.AddWithValue("@user", name);
                        UserExist = (int)check_User_Name.ExecuteScalar();
                    }
                    if (0 < UserExist)
                    {
                        result = "name already there";
                    }
                    else
                    {
                        context.Users.Add(user);
                        context.Folders.Add(fold);
                        context.SaveChanges();

                        if (null != mockstore)
                        {
                            mockstore.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
                //result = ex.ToString();
                Console.WriteLine(ex.ToString());
                result = "error db register";
            }

            return result;
        }

        public bool VerifyUser(string name, string password)
        {
            bool result = false;
            try
            {
                using (SqlConnection conn = new SqlConnection("data source=DESKTOP-BHSNUIB;initial catalog=TAIP;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;"))
                {
                    conn.Open();
                    SqlCommand check = new SqlCommand("SELECT COUNT(*) FROM Users WHERE (name = @user AND password = @password)", conn);
                    check.Parameters.AddWithValue("@user", name);
                    check.Parameters.AddWithValue("@password", password);
                    result = (int)check.ExecuteScalar() == 1;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
                result = false;
            }
            return result;
        }
    }

    public interface IStore
    {
        void SaveChanges();
    }
}
