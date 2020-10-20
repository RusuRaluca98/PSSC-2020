using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Question.Domain.Newquestion
{
    
    public struct Login
    {
        [Required]
        public string Id { get; private set; }
        [Required]
        public string Email { get; private set; }

        public Login(string id, string email)
        {
            Id = id; // id utilizator
            Email = email; //email-ul utilizatorului
        }
    }
}
