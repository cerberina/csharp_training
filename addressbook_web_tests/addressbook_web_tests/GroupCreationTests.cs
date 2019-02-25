using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            navigationHelper.GoToHomePage();
            loginHelper.Login(new AccountData ("admin", "secret"));
            navigationHelper.GoToGroupsPage();
            groupHelper.InitGroupCreation();
            GroupData group = new GroupData("aaa");
            group.Header = "ddd";
            group.Footer = "fff";
            groupHelper.FillGroupForm(group);
            groupHelper.SubmitGroupCreation();
            groupHelper.ReturnsToGroupPage();
            loginHelper.Logout();
        }
    }
}
