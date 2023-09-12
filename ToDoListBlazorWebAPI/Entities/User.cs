﻿using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoListBlazorWebAPI.Entities
{
    public class User : IdentityUser<Guid>
    {
        [MaxLength(250)]
        [Required]
        public string FirstName { get; set; }
        [MaxLength(250)]
        [Required]
        public string LastName { get; set; }

    }
}
