namespace BettingSite.Models;

public class Product
{
    public int id { get; set; }
    public String name { get; set; }
    
    public String description { get; set; }
    
    public float basePrice { get; set; }
    
    public virtual ICollection<Bid> Bids { get; set; }
}