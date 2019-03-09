using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void ClientCreationTest()
        {
            ContactData contact = new ContactData("aaa", "bbb", "ccc");
            contact.Home = "111";
            contact.Homepage = "qqq";
            contact.Mobile = "123";
            contact.NickName = "www";
            contact.Notes = "eee";
            contact.Phone2 = "456";
            contact.Title = "zzz";
            contact.Work = "rrr";
            contact.Fax = "ttt";
            contact.Email3 = "yyy";
            contact.Email2 = "uuu";
            contact.Email = "iii";
            contact.Company = "ooo";
            contact.Byear = "1980";
            contact.Bmonth = "November";
            contact.Bday = "12";
            contact.Ayear = "1990";
            contact.Amonth = "September";
            contact.Aday = "20";
            contact.Address2 = "ppp";
            contact.Address = "xxx";
            
            app.Contacts.Create(contact);
            app.Auth.Logout();
        }
    }
}
