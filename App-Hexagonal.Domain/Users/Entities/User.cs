using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App_Hexagonal.Domain.Users.Entities
{
    public class User
    {
        public Guid Id { get; }
        public string Name { get; }

        public User(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}