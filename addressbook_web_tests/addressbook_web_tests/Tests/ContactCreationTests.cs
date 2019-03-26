using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contact = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contact.Add(new ContactData(GenerateRandomString(30), GenerateRandomString(100), GenerateRandomString(100))
                {
                    HomePhone = GenerateRandomString(100),
                    Homepage = GenerateRandomString(100),
                    MobilePhone = GenerateRandomString(100),
                    NickName = GenerateRandomString(100),
                    Notes = GenerateRandomString(100),
                    Phone2 = GenerateRandomString(100),
                    Title = GenerateRandomString(100),
                    WorkPhone = GenerateRandomString(100),
                    Fax = GenerateRandomString(100),
                    Email3 = GenerateRandomString(100),
                    Email2 = GenerateRandomString(100),
                    Email = GenerateRandomString(100),
                    Company = GenerateRandomString(100),
                    Address2 = GenerateRandomString(100),
                    Address = GenerateRandomString(100),
                });
            }
            return contact;

        }

        [Test, TestCaseSource("RandomContactDataProvider")]
        public void ClientCreationTest(ContactData contact)
        {
            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Create(contact);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);
            //app.Auth.Logout();
        }
    }
}
