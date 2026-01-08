using System.ComponentModel.DataAnnotations;

namespace DbIntegation.Entitites;

public abstract class BaseEntity
{
    [Key]
    public virtual int Id { get; set; }
}
