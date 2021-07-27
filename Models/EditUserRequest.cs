using System;

namespace Kinoshka.Models
{
    public class EditUserRequest
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
    }
}