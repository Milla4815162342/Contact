using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contacts.Models
{
    public class Contact
    {
        public int? ID { set; get; }

        public string Name { set; get; }

        public string Surname { set; get; }

        public DateTime Birthday { set; get; }

        public int Age { set; get; }

        public string Sex { set; get; }
    }
}