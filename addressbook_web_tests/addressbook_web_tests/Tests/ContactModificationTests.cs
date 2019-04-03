using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests: AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newData = new ContactData("aaa", "bbb", "ccc");
            newData.HomePhone = "222";
            newData.Homepage = "333";
            newData.MobilePhone = "777";
            newData.NickName = "888";
            newData.Notes = "999";
            newData.Phone2 = "";
            newData.Title = "qqq";
            newData.WorkPhone = "www";
            newData.Fax = "eee";
            newData.Email3 = "rrr";
            newData.Email2 = "ttt";
            newData.Email = "uuu";
            newData.Company = "iii";
            //newData.Byear = "1990";
            //newData.Bmonth = "September";
            //newData.Bday = "21";
            //newData.Ayear = "2000";
            //newData.Amonth = "November";
            //newData.Aday = "30";
            newData.Address2 = "lll";
            newData.Address = "kkk";

            app.Contacts.EnsureContactExists();
            List<ContactData> oldContacts = ContactData.GetAll();
            //ContactData oldData = oldContacts[0];

            app.Contacts.Modify(0,newData);

            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts[0].FirstName = newData.FirstName;
            oldContacts[0].LastName = newData.LastName;
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);
            //app.Auth.Logout();
        }
    }
}
