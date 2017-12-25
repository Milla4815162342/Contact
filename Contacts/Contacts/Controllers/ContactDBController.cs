using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration; 

namespace Contacts
{
    public class ContactDBController
    {
        SqlConnection _conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Contact"].ConnectionString);

        public Models.Contact Get(int? id)
        {
            _conn.Open();

            SqlCommand command = new SqlCommand(Query.Select(id), _conn);

            Models.Contact contact = new Models.Contact();
            
            contact.ID = id;

            using (var reader = command.ExecuteReader())
            {
                reader.Read();

                contact.Name = reader.GetString(0);

                contact.Surname = reader.GetString(1);

                contact.Birthday = reader.GetDateTime(2);

                contact.Sex = reader.GetString(3);

                contact.Age = reader.GetInt32(4);

            }

            _conn.Close();

            return contact;
        }

        public List<Models.Contact> Get()
        {
            _conn.Open();

            SqlCommand command = new SqlCommand(Query.Select(), _conn);

            List<Models.Contact> contacts = new List<Models.Contact>();

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Models.Contact contact = new Models.Contact();

                    contact.ID = reader.GetInt32(0);

                    contact.Name = reader.GetString(1);

                    contact.Surname = reader.GetString(2);

                    contact.Birthday = reader.GetDateTime(3);

                    contact.Sex = reader.GetString(4);

                    contact.Age = reader.GetInt32(5);

                    contacts.Add(contact);
                }
            }

            _conn.Close();

            return contacts;
        }

        public void Post(Models.Contact contact)
        {
            NonQuery(Query.Insert(contact));
        }

        public void Put(Models.Contact contact, int id)
        {
            NonQuery(Query.Update(contact, id));
             
        }

        public void Delete(int id)
        {
            NonQuery(Query.Delete(id));
        }

        private void NonQuery(string query)
        {
            _conn.Open();

            SqlCommand command = new SqlCommand(query, _conn);

            command.ExecuteNonQuery();

            _conn.Close();
        }
    }
}