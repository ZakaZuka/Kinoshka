using System;

namespace Kinoshka.Models.Entities
{
    public class EditRoleRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}