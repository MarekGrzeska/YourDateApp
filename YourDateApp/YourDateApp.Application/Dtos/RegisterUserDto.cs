﻿namespace YourDateApp.Application.Dtos
{

    public class RegisterUserDto
    {
        public string? Email { get; set; }
        public string? Username { get; set; }
        public string? Gender { get; set; }
        public string? Password { get; set; }
        public string? Password2 { get; set; }
    }
}