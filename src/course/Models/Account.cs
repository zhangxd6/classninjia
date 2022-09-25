using System.ComponentModel.DataAnnotations.Schema;

public class Account
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string? LastName { get; set; }

    public string? FirstMidName { get; set; }

    public DateTime EnrollmentDate { get; set; }

    public List<Registration>? Registrations { get; set; }
}
