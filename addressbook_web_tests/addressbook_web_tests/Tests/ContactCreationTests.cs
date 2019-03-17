using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void ClientCreationTest()
        {
            ContactData contact = new ContactData("eee", "333", "vvv");
            contact.HomePhone = "111";
            contact.Homepage = "qqq";
            contact.MobilePhone = "123";
            contact.NickName = "www";
            contact.Notes = "eee";
            contact.Phone2 = "";
            contact.Title = "zzz";
            contact.WorkPhone = "rrr";
            contact.Fax = "ttt";
            contact.Email3 = "yyy";
            contact.Email2 = "uuu";
            contact.Email = "iii";
            contact.Company = "ooo";
            //contact.Byear = "1980";
            //contact.Bmonth = "November";
            //contact.Bday = "12";
            //contact.Ayear = "1990";
            //contact.Amonth = "September";
            //contact.Aday = "20";
            contact.Address2 = "ppp";
            contact.Address = "xxx";

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
