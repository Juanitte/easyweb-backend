﻿using Common.Utilities;

namespace EasyWeb.UserMicroservice.Models.Dtos.CreateDto
{
    public class CreateUserDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FullName { get; set; }
        public Language Language { get; set; }

    }
}
