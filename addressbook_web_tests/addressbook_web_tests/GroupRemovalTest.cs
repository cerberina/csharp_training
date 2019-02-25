using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            navigationHelper.GoToHomePage();
            loginHelper.Login(new AccountData ("admin", "secret"));
            navigationHelper.GoToGroupsPage();
            groupHelper.SelectGroup(1);
            groupHelper.RemoveGroup();
            groupHelper.ReturnsToGroupPage();
            loginHelper.Logout();
        }
    }
}
