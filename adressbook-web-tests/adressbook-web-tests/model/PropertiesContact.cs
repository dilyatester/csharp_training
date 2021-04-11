﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAdressbookTests
{
    public class PropertiesContact : IEquatable<PropertiesContact>, IComparable<PropertiesContact>
    {
        public PropertiesContact(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }
        public string Firstname { get; set; }

        public string Lastname { get; set; }

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
            return this.ToString().CompareTo(other.ToString());
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
            return this.ToString() == other.ToString();
        }
    }
}
