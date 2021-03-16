using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;


namespace BDMSUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "RexrG6OuogoAu6dghwvsZtLkCi3z5ig2NfaRtnsK",
            BasePath = "https://blood-donor-9af63-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;
        public void TestMethod1()
        {
            try
            {
                client = new FireSharp.FirebaseClient(config);

                if (client != null)
                {

                }
                else
                {
                    Console.Write("Check your connection again!");
                }
            }
            catch (Exception)
            {
                Console.Write("Check your connection again!", "Error");
            }
        }
    }
}
