using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contacts
{
    public class Query
    {
        static public string Select()
        {
            return "SELECT ID, Name, Surname, Birthday, Sex, DATEDIFF(year, birthday, getDate()) as Age FROM CONTACT";
        }

        static public string Select(int? id)
        {
            return "SELECT Name, Surname, Birthday, Sex, DATEDIFF(year, birthday, getDate()) as Age FROM CONTACT " +
                "WHERE id = " + id;
        }

        static public string Delete(int id)
        {
            return "DELETE FROM Contact WHERE id = " + id;
        }

        static public string Insert(Models.Contact contact)
        {
            return "INSERT INTO Contact VALUES('" + contact.Name + "','" + contact.Surname +
                "', '" + contact.Birthday + "', '" + contact.Sex + "')";
        }

        static public string Update(Models.Contact contact, int id)
        {
            return "Update Contact SET Name = '" + contact.Name + "', Surname = '" + contact.Surname +
                "', Birthday = '" + contact.Birthday + "'" + ", Sex = '" + contact.Sex + "' WHERE id = " + id;
        }
    }
}