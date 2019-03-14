﻿using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            app.Contacts.EnsureContactExists();
            app.Contacts.Remove();
            //app.Auth.Logout();
        }
    }
}
