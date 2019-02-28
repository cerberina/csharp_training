using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests: TestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newData = new ContactData("aaa", "bbb", "ccc");
            newData.Home = "222";
            newData.Homepage = "333";
            newData.Mobile = "777";
            newData.NickName = "888";
            newData.Notes = "999";
            newData.Phone2 = "000";
            newData.Title = "qqq";
            newData.Work = "www";
            newData.Fax = "eee";
            newData.Email3 = "rrr";
            newData.Email2 = "ttt";
            newData.Email = "uuu";
            newData.Company = "iii";
            newData.Byear = "1990";
            newData.Bmonth = "September";
            newData.Bday = "21";
            newData.Ayear = "2000";
            newData.Amonth = "November";
            newData.Aday = "30";
            newData.Address2 = "lll";
            newData.Address = "kkk";

            app.Contacts.Modify(newData);
            app.Auth.Logout();
        }
    }
}
