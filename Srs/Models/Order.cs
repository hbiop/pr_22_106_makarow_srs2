using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Srs.Models;

public class Order
{
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    [ForeignKey("User")]
    public int UserId { get; set; }
    [Required]
    [ForeignKey("Order")]
    public int GoodId { get; set; }
    [Required]
    public int Count { get; set; }
    public virtual User User { get; set; }
    
    public virtual Good Good { get; set; }
}