using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BDMSUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void LogIn_NullUser_ISFalse()
        {
            var user = new Blood_donor_management_System.MyUser();
            user.Username = "Chanuka";

            var user1 = new Blood_donor_management_System.MyUser();
            user.Username = "Dinuwan";

            var result=true;
            if (user1 == null || user == null)
            {
                result = false;
            }

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void LogInWithPass_SamePass_ISTrue()
        {
            var user = new Blood_donor_management_System.MyUser();
            user.Password = "1234";

            var user1 = new Blood_donor_management_System.MyUser();
            user1.Password = "1234";

            var result = false;
            if(user.Password==user1.Password)
            {
                result = true;
            }

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void LogInWithPass_DifferentPassword_IsFalse()
        {
            var user = new Blood_donor_management_System.MyUser();
            user.Password = "1234";

            var user1 = new Blood_donor_management_System.MyUser();
            user1.Password = "1111";

            var result = true;
            if(user.Password!=user1.Password)
            {
                result = false;
            }

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void LogInwithPass_UnmatchPasswordAndUser_IsFalse()
        {
            var user = new Blood_donor_management_System.MyUser();
            user.Password = "1234";
            user.Username = "Chanuka";

            var user1 = new Blood_donor_management_System.MyUser();
            user.Password = "1111";
            user.Username = "Chanuka";

            var result = true;
            if(user1.Username==user.Username)
            {
                if(user1.Password!=user.Password)
                {
                    result = false;

                    Assert.IsFalse(result);
                }
            }

        }
    }
}
