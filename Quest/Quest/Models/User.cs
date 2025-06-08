using System;

namespace Quest.Models
{
    public class User
    {
        public int Id { get; set; }                     
        public string Username { get; set; }            
        public string Email { get; set; }               
        public string PasswordHash { get; set; }   

        public List<Progress> Progress { get; set; } = new();    
        public List<Payment> Payments { get; set; } = new();       
        public List<GameSession> GameSessions { get; set; } = new(); 
    }

}
