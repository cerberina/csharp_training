using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData: IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;

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
        public string FullName (string FirstName, string LastName)
        {
            string FullName = FirstName + LastName;
            return FullName;
        }
        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return FullName(FirstName,LastName).CompareTo(other.FullName(other.FirstName,other.LastName));
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
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        public string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
           return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
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
                    return (Email + "\r\n" + Email2 +"\r\n"+ Email3 + "\r\n").Trim();
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
    }
}
