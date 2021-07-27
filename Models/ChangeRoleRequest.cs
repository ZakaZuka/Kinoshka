using System;
using System.Collections.Generic;
using Kinoshka.Models.Entities;

namespace Kinoshka.Models
{
    public class ChangeRoleRequest
    {
        public ChangeRoleRequest()
        {
            AllRoles = new List<ApplicationRole>();
            UserRoles = new List<string>();
        }

        public Guid UserId { get; set; }
        public string UserEmail { get; set; }
        public List<ApplicationRole> AllRoles { get; set; }
        public IList<string> UserRoles { get; set; }
    }
}