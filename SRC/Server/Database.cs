using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            string result = "true";
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
                else if(password.Length < passwordMinLength)
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
                    fold.createDate = DateTime.Now;

                    // verify if user already in db
                    int UserExist = 0;
                    using (SqlConnection conn = new SqlConnection(Server.Properties.Settings.Default.ConnectionString))
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
                            
                            if(null != mockstore)
                            {
                                mockstore.SaveChanges();
                            }
                        }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                //result = ex.ToString();
                throw ex;
            }
            
            return result;
        }

        public bool VerifyUser(string name, string password)
        {
            bool result = false;
            try
            {
                SqlCommand check = new SqlCommand("SELECT COUNT(*) FROM [Table] WHERE ([user] = @user && [password] = @password)");
                check.Parameters.AddWithValue("@user", name);
                check.Parameters.AddWithValue("@password", password);
                result = (bool)check.ExecuteScalar();                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
