using System;
using Microsoft.AspNetCore.Identity;

namespace Kinoshka.Models.Entities
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        public ApplicationRole(string name)
        {
            Name = name;
        }
    }
}