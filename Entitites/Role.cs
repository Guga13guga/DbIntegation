using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbIntegation.Entitites;

[Table("Roles")]
public class Role: BaseEntity
{
    [AllowedValues("ADMIN", "USER", "GUEST", ErrorMessage = "Msgavsi roli ar aris xardacherili")]
    public string? Name { get; set; }

    public List<User>? Users  { get; set; }
}
