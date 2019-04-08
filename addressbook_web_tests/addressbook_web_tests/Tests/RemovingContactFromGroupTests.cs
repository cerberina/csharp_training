using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class RemovingContactFromGroupTests: AuthTestBase
    {
        [Test]
        public void TestRemovingContactFromGroup()
        {
            app.Groups.EnsureGroupsExists();

            GroupData group = GroupData.GetAll()[0];

            app.Contacts.EnsureContactsInGroupExists(group);

            List<ContactData> oldList = group.GetContacts();

            ContactData contact = ContactData.GetAll().Intersect(oldList).First();

            app.Contacts.RemoveContactFromGroup(contact,group);

            List<ContactData> newList = group.GetContacts();
            oldList.Remove(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList,newList);
        }
    }
}
