using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAddressbookTests;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = Convert.ToInt32 (args[0]);
            StreamWriter writer = new StreamWriter(args[1]);
            string format = args[2];
            string typeOfData = args[3];

            List<ContactData> contacts = new List<ContactData>();
            for (int j = 0; j < count; j++)
            {
                contacts.Add(new ContactData(TestBase.GenerateRandomString(10), TestBase.GenerateRandomString(10), TestBase.GenerateRandomString(10))
                {
                    HomePhone = TestBase.GenerateRandomString(10),
                    Homepage = TestBase.GenerateRandomString(10),
                    MobilePhone = TestBase.GenerateRandomString(10),
                    NickName = TestBase.GenerateRandomString(10),
                    Notes = TestBase.GenerateRandomString(10),
                    Phone2 = TestBase.GenerateRandomString(10),
                    Title = TestBase.GenerateRandomString(10),
                    WorkPhone = TestBase.GenerateRandomString(10),
                    Fax = TestBase.GenerateRandomString(10),
                    Email3 = TestBase.GenerateRandomString(10),
                    Email2 = TestBase.GenerateRandomString(10),
                    Email = TestBase.GenerateRandomString(10),
                    Company = TestBase.GenerateRandomString(10),
                    Address2 = TestBase.GenerateRandomString(10),
                    Address = TestBase.GenerateRandomString(10)
                });
            }

            List <GroupData> groups = new List<GroupData>();
            for (int i=0; i<count; i++)
            {
                groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                {
                    Header = TestBase.GenerateRandomString(10),
                    Footer = TestBase.GenerateRandomString(10)
                });
            }
            
            if (typeOfData == "group")
            {
                if (format == "csv")
                {
                    WriteGroupsToCsvFile(groups, writer);
                }
                else if (format == "xml")
                {
                    WriteGroupsToXmlFile(groups, writer);
                }
                else if (format == "json")
                {
                    WriteGroupsToJsonFile(groups, writer);
                }
                else
                {
                    System.Console.Out.Write("Unrecognized format " + format);
                }
            }
            else if (typeOfData == "contact")
            {
                if (format == "xml")
                {
                    WriteContactsToXmlFile(contacts, writer);
                }
                else if (format == "json")
                {
                    WriteContactsToJsonFile(contacts, writer);
                }
                else
                {
                    System.Console.Out.Write("Unrecognized format " + format);
                }
            }
            else
            {
                System.Console.Out.Write("Unrecognized type " + typeOfData);
            }

                writer.Close();
        }

        static void WriteGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                    group.Name, group.Header, group.Footer));
            }
        }

        static void WriteGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }

        static void WriteContactsToXmlFile(List<ContactData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
        }

        static void WriteGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
        }

        static void WriteContactsToJsonFile(List<ContactData> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
        }

    }
}
