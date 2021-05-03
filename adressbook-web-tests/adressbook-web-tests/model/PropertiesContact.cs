using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using LinqToDB.Mapping;

namespace WebAdressbookTests
{
    [Table(Name = "addressbook")]
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

        public PropertiesContact()
        {
        }
        [Column(Name = "firstname")]
        public string Firstname { get; set; }

        [Column(Name = "lastname")]
        public string Lastname { get; set; }
        
        [Column(Name = "middlename")]
        public string Middlename { get; set; }

        [Column(Name = "nickname")]
        public string Nickname{ get; set; }
        
        [Column(Name = "company")]
        public string Company { get; set; }
        
        [Column(Name = "title")]
        public string Title { get; set; }

        [Column(Name = "address")]
        public string Adress { get; set; }

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
        public string Birthday { get; set; }

        [Column(Name = "bmonth")]
        public string Birthmonth { get; set; }

        [Column(Name = "byear")]
        public string Birthyear { get; set; }

        [Column(Name = "aday")]
        public string Anniversaryday { get; set; }

        [Column(Name = "amonth")]
        public string Anniversarymonth { get; set; }

        [Column(Name = "ayear")]
        public string Anniversaryyear { get; set; }

        [Column(Name = "address2")]
        public string Adress2 { get; set; }

        [Column(Name = "phone2")]
        public string Home { get; set; }

        [Column(Name = "notes")]
        public string Notes { get; set; }
        
        [Column(Name = "id"), PrimaryKey, Identity]
        public string Id { get; set; }

        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }

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

        public static List<PropertiesContact> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contacts.Where(x => x.Deprecated == "0000-00-00 00:00:00") select c).ToList();
            }
        }
    }
}
