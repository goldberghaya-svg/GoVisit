using System.ComponentModel.DataAnnotations;

namespace GoVisit.Domain;

public class User
{
    [Key]
    public long UserId { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Name { get; set; }
}
