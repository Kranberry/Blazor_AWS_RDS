using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWS_RDS_Blazor.Data
{
    public class User
    {
        public uint ID { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }

        public User(uint id, string firstName, string lastName, string email)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
        public User(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public void SetID(uint id)
        {
            ID = id;
        }
    }
}
