
public class Course
{
    public int Id { get; set; }  
    public string? Title { get; set; }
    public string? SubTitle { get; set; }
    public string? Descripton { get; set; }
    
    public string? Author { get; set; }
    public int Rating { get; set; }
    public Level Level { get; set; }  
      public List<Account>? Registers { get; set; }

}

public enum Level
{
    Beginner,
    Intermediate,
    Advanced
}