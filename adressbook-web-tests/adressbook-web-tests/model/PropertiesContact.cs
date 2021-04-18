using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WebAdressbookTests
{
    public class PropertiesContact : IEquatable<PropertiesContact>, IComparable<PropertiesContact>
    {
        private string allPhones;
        private string allEmails;

        public PropertiesContact(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }
        public string Firstname { get; set; }

        public string Lastname { get; set; }
        public string Adress { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }

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

        private string CleanUp(string text)
        {
            if (text == null || text == "") 
            {
                return "";
            }
            return Regex.Replace(text, "[ -()]", "") + "\r\n"; 
        }

        public string Id { get; set; }

        public override string ToString()
        {
            return "first=" + Firstname + ",last=" + Lastname;
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public int CompareTo(PropertiesContact other)
        {
            if (Object.ReferenceEquals(other, null)) 
            {
                return 1;
            }
            if (Firstname == other.Firstname)
            {
                if (Lastname == other.Lastname)
                {
                    return 0;
                }
                else
                {
                    return Lastname.CompareTo(other.Lastname); ;
                }
            } else
            {
                return Firstname.CompareTo(other.Firstname);
            }


            //return this.ToString().CompareTo(other.ToString());
        }

        public bool Equals(PropertiesContact other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return (this.Firstname == other.Firstname) && (this.Lastname == other.Lastname);
        }
    }
}
