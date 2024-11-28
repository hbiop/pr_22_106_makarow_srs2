using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Srs.Models;

public class User
{
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    [MaxLength(50)]
    public string Login { get; set; }
    [Required]
    [MaxLength(50)]
    public string Password { get; set; }
    [Required]
    [ForeignKey("Role")]
    public int RoleId { get; set; }
    public virtual ICollection<Order> Orders { get; set; }
    public virtual Role Role { get; set; }
}