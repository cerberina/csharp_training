using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using LinqToDB.Mapping;
using System.Collections;
using System.Linq.Expressions;

namespace WebAddressbookTests
{
    [Table(Name = "addressbook")]
    public class ContactData: IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;
        private string allDetailedInformation;

        public ContactData()
        {
        }

        public ContactData (string firstname, string middlename, string lastname)
        {
            FirstName = firstname;
            MiddleName = middlename;
            LastName = lastname;
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            return FirstName == other.FirstName && LastName == other.LastName;
        }

        public override int GetHashCode()
        {
            return (FirstName+LastName).GetHashCode();
        }

        public override String ToString()
        {

            return "Firstname =" + FirstName + "  and LastName=" + LastName;

        }
        public string FirstAndLastNames (string FirstName, string LastName)
        {
            string FirstAndLastNames = FirstName + LastName;
            return FirstAndLastNames;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return FirstAndLastNames(FirstName,LastName).CompareTo(other.FirstAndLastNames(other.FirstName,other.LastName));
        }
        [Column(Name = "firstname")]
        public string FirstName { get; set; }
        [Column(Name = "middlename")]
        public string MiddleName { get; set; }
        [Column(Name = "lastname")]
        public string LastName { get; set; }
        [Column(Name = "nickname")]
        public string NickName { get; set; }
        [Column(Name = "title")]
        public string Title { get; set; }
        [Column(Name = "company")]
        public string Company { get; set; }
        [Column(Name = "address")]
        public string Address { get; set; }
        [Column(Name = "home")]
        public string HomePhone { get; set; }
        [Column(Name = "mobile")]
        public string MobilePhone { get; set; }
        [Column(Name = "work")]
        public string WorkPhone { get; set; }
        [Column(Name = "fax")]
        public string Fax { get; set; }
        [Column(Name = "email")]
        public string Email { get; set; }
        [Column(Name = "email2")]
        public string Email2 { get; set; }
        [Column(Name = "email3")]
        public string Email3 { get; set; }
        [Column(Name = "homepage")]
        public string Homepage { get; set; }
        [Column(Name = "bday")]
        public string Bday { get; set; }
        [Column(Name = "bmonth")]
        public string Bmonth { get; set; }
        [Column(Name = "byear")]
        public string Byear { get; set; }
        [Column(Name = "aday")]
        public string Aday { get; set; }
        [Column(Name = "amonth")]
        public string Amonth { get; set; }
        [Column(Name = "ayear")]
        public string Ayear { get; set; }
        [Column(Name = "address2")]
        public string Address2 { get; set; }
        [Column(Name = "phone2")]
        public string Phone2 { get; set; }
        [Column(Name = "notes")]
        public string Notes { get; set; }
        [Column(Name = "id"), PrimaryKey]
        public string Id { get; set; }
        [Column(Name = "deprecated")]
        public string deprecated { get; set; }

        public static List<ContactData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contacts where c.deprecated == "0000-00-00 00:00:00" select c ).ToList();
            }
        }

        public string AllDetailedInformation
        {
            get
            {
                if (allDetailedInformation != null)
                {
                    return allDetailedInformation;
                }
                else
                {
                    string h_phone = "";
                    string m_phone = "";
                    string w_phone = "";
                    string fax = "";
                    string phone_2 = "";
                    string home_page = "";
                    string fullName = FirstName + " " + MiddleName + " " + LastName;

                    if (HomePhone != "")
                    {
                        h_phone = "H: " + CleanUp(HomePhone);
                    };

                    if (MobilePhone != "")
                    {
                        m_phone = "M: " + CleanUp(MobilePhone);
                    };

                    if (WorkPhone != "")
                    {
                        w_phone = "W: " + CleanUp(WorkPhone);
                    };

                    if (Fax != "")
                    {
                        fax = "F: " + CleanUp(Fax);
                    };
                    
                    if (Homepage != "")
                    {
                        home_page = "Homepage:" + "\r\n" + CleanUp(Homepage);
                    };

                    if (Phone2 != "")
                    {
                        phone_2 = "P: " + CleanUp(Phone2);
                    };

                    return (CleanUp(fullName) + CleanUp(NickName) + CleanUp(Title) + CleanUp(Company) + CleanUp(Address)
                        + "\r\n"
                        + h_phone + m_phone  + w_phone + fax 
                        + "\r\n"
                        + CleanUp(Email) + CleanUp(Email2) + CleanUp(Email3) + home_page 
                        + "\r\n"
                        + "\r\n"
                        + CleanUp(Address2)
                        + "\r\n"
                        + phone_2
                        + CleanUp(Notes)).Trim();
                }
            }
            set
            {
                allDetailedInformation = value;
            }
        }
        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (CleanUp(Email) + CleanUp(Email2) + CleanUp(Email3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }
        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUpForPhones(HomePhone) + CleanUpForPhones(MobilePhone) + CleanUpForPhones(WorkPhone)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        //public Expression Expression => throw new NotImplementedException();

        //public Type ElementType => throw new NotImplementedException();

        //public IQueryProvider Provider => throw new NotImplementedException();

        public string CleanUpForPhones(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[ -()]", "") + "\r\n";
        }
        public string CleanUp(string str)
        {
            if (str == null || str == "")
            {
                return "";
            }
            return str + "\r\n";
        }
    }
}
