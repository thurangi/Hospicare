﻿namespace HC.API.Model
{
    public class Users
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;// Should be hashed and salted in production
    }
}
