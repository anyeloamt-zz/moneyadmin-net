﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyAdmin.ViewModel
{
    public class UserViewModel : IViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string ProfilePicture { get; set; }
    }
}