﻿ namespace SEP3ClientLATEST.Data.dto
{
    public class LoginDTO
    {
        public string username { get; set; }
        
        public string password { get; set; }
        
        public LoginDTO() {}

        public LoginDTO(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public override string ToString()
        {
            return $"User: {username} {password}";
        }
    }
}