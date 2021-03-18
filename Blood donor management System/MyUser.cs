using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blood_donor_management_System
{
    public class MyUser
    {
        public string ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        private static string error="There was some error. Please restart the program!";
        
        public static void ShowError()
        {
            System.Windows.Forms.MessageBox.Show(error);
        }
        public static bool IsEqual(MyUser user1,MyUser user2)
        {
            if(user1==null || user2==null)
            {
                return false;
            }

            if (user1.Username != user2.Username)
            {
                error = "Username doesn't exist!";
                return false;
            }
            else if(user1.Password!=user2.Password)
            {
                error = "Username and Password doesn't match!";
                return false;
            }
            return true;
        }
    }
}
