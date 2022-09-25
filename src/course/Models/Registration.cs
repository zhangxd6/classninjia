using System.ComponentModel.DataAnnotations.Schema;

public class Registration
{
     [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int AccountId { get; set; }
    public int CourseId { get; set; }

    public  Course? Course {get;set;}
    public Account? Account { get; set; }
}