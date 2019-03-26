using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class ContactData: IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;
        private string allDetailedInformation;

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

        public string FirstName { get; set; }
        
        public string MiddleName { get; set; }
        
        public string LastName { get; set; }
        
        public string NickName { get; set; }
       
        public string Title { get; set; }
       
        public string Company { get; set; }
       
        public string Address { get; set; }
        
        public string HomePhone { get; set; }

        public string MobilePhone { get; set; }

        public string WorkPhone { get; set; }

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

        public string CleanUpForPhones(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
           return Regex.Replace(phone,"[ -()]","") + "\r\n";
        }

        public string CleanUp(string str)
        {
            if (str == null || str == "")
            {
                return "";
            }
            return str + "\r\n";
        }

        public string Fax { get; set; }

        public string Email { get; set; }
        
        public string Email2 { get; set; }
        
        public string Email3 { get; set; }

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

        public string Homepage { get; set; }
        
        public string Bday { get; set; }
        
        public string Bmonth { get; set; }
        
        public string Byear { get; set; }

        public string Aday { get; set; }

        public string Amonth { get; set; }

        public string Ayear { get; set; }

        public string Address2 { get; set; }

        public string Phone2 { get; set; }

        public string Notes { get; set; }

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
    }
}
