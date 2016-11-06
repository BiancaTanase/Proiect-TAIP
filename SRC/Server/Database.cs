using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    class Database
    {
        private static volatile Database instanceDatabase;
        private static ModelDBContainer context;
        private static object syncRoot = new Object();

        private Database()
        {
            context = new ModelDBContainer();
        }

        public static Database Instance
        {
            get
            {
                if (instanceDatabase == null)
                {
                    lock (syncRoot)
                    {
                        if (instanceDatabase == null)
                            instanceDatabase = new Database();
                    }
                }

                return instanceDatabase;
            }
        }

        public bool AddUser(string name, string password)
        {
            bool result = true;
            try
            {
                User user = new User();
                user.name = name;
                user.password = password;
                Folder fold = new Folder();
                fold.name = name + "Folder";
                fold.User = user;
                fold.createDate = DateTime.Now;

                context.Users.Add(user);
                context.Folders.Add(fold);
                context.SaveChanges();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                result = false;
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
}
