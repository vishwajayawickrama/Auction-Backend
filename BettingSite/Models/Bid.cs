using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BettingSite.Models;

public class Bid
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }
    
    public float bidPrice { get; set; }
    
    [Required]
    public DateTime bidDate { get; set; } = DateTime.Now;
    
    public int productId { get; set; }
    
    [ForeignKey("productId")]
    public Product Product { get; set; }
    
    
}