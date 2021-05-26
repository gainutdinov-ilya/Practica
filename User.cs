using System;
using System.Collections.Generic;
using System.Collections;

#nullable disable

namespace Practica
{
    public partial class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public BitArray Surname { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime LastLogin { get; set; }
        public DateTime BanAuth { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsAdmin { get; set; }
    }
}
