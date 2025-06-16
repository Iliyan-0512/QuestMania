using System;
namespace QuestApp.Models;

public class Quest
{
    public int Id { get; set; }
    public string Title { get; set; }               
    public string Riddle { get; set; }              
    public string Answer { get; set; }              
    public string Hint { get; set; } = string.Empty;

    public int Points { get; set; } = 10;           
    public int TimeLimitSeconds { get; set; } = 1800;
    public double Latitude { get; set; }           
    public double Longitude { get; set; }           

    public int LocationId { get; set; }            
    public Location Location { get; set; }

    public List<Progress> Progress { get; set; } = new(); 
}
