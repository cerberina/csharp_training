using NUnit.Framework;
using System.IO;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

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

        public static IEnumerable<ContactData> ContactDataFromXmlFile()
        {
            return (List<ContactData>)new XmlSerializer(typeof(List<ContactData>)).Deserialize(new StreamReader(@"contacts.xml"));
        }

        public static IEnumerable<ContactData> ContactDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<ContactData>>(File.ReadAllText(@"contacts.json"));
        }
      
        [Test, TestCaseSource("ContactDataFromJsonFile")]
        public void ClientCreationTest(ContactData contact)
        {
            List<ContactData> oldContacts = ContactData.GetAll();

            app.Contacts.Create(contact);
            oldContacts.Add(contact);

            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);
            //app.Auth.Logout();
        }

    }
}
