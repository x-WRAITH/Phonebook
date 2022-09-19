using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook
{
    public class User
    {
        public string FirstName { get;set; }
        public string LastName { get; set; }
        public string Phone { get; set;}
        public string Email { get;set; }
        public string serialize()
        {
            return $"{FirstName}::{LastName}::{Phone}::{Email}";
        }
        public static User deserialize(string s)
        {
            var arr = s.Split(new[] { "::" }, StringSplitOptions.None);
            var cl = new User();
            cl.FirstName = arr[0];
            cl.LastName = arr[1];
            cl.Phone = arr[2];
            cl.Email = arr[3];
            return cl;
        }
    }
}
