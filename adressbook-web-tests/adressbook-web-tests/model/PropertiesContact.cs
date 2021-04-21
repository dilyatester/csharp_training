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
        private string allDetails;

        public PropertiesContact(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }
        public string Firstname { get; set; }

        public string Lastname { get; set; }
        public string Middlename { get; set; }
        public string Nickname{ get; set; }
        public string Company { get; set; }
        public string Title { get; set; }


        public string Adress { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string Homepage { get; set; }
        public string Birthday { get; set; }
        public string Birthmonth { get; set; }
        public string Birthyear { get; set; }
        public string Anniversaryday { get; set; }
        public string Anniversarymonth { get; set; }
        public string Anniversaryyear { get; set; }
        public string Adress2 { get; set; }
        public string Home { get; set; }
        public string Notes { get; set; }

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
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone) + CleanUp(Home)).Trim();
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
        public string AllDetails
        {
            get
            {
                if (allDetails != null)
                {
                    return allDetails;
                }
                else
                {
                    return (Firstname + " " + (Middlename != ""?Middlename + " ":"")+ Lastname +"\r\n" +
                        (Nickname != "" ? CleanUp(Nickname):"") +
                        (Title != "" ? CleanUp(Title):"") +
                        (Company != "" ? CleanUp(Company):"") +
                        (Adress != "" ? CleanUp(Adress) : "") + "\r\n" +
                        (HomePhone != "" ? "H: " + CleanUp(HomePhone) : "") +
                        (MobilePhone != "" ? "M: " + CleanUp(MobilePhone) : "") +
                        (WorkPhone != "" ? "W: " + CleanUp(WorkPhone) : "") +
                        (Fax != "" ? "F: " + CleanUp(Fax) : "") + "\r\n" +
                        AllEmails + "\r\n" +
                        (Homepage != "" ? "Homepage:\r\n" + CleanUp(Homepage) : "") + "\r\n" +
                        (Birthday != "-" ? "Birthday " + Birthday + ". " + Birthmonth + " "+ Birthyear : "") + "\r\n" +
                        (Anniversaryday != "-" ? "Anniversary " + Anniversaryday + ". " + Anniversarymonth + " " + Anniversaryyear : "") + "\r\n\r\n" +
                        (Adress2 != "" ? CleanUp(Adress2) : "") + "\r\n" +
                        (Home != "" ? "P: " + CleanUp(Home) : "") + "\r\n" +
                        (Notes != "" ? CleanUp(Notes) : "")
                        ).Trim().Replace("\r\n","");

                }
            }
            set
            {
                allDetails = value.Replace("\r\n", ""); ;
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
            return "first=" + Firstname + "\nlast=" + Lastname;
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
