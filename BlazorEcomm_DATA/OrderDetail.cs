using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorEcomm_DATA;

public class OrderDetail
{
    [Key] 
    public int Id { get; set; }

    [Required] 
    public int OrderHeaderId { get; set; }
    
    [Required] 
    public int ProductId { get; set; }
    
    [ForeignKey("ProductId"), NotMapped] 
    public virtual Product Product { get; set; } = new Product();
    
    [Required] 
    public int Count { get; set; }
    
    [Required] 
    public double Price { get; set; }
    
    [Required] 
    public string Size { get; set; } = string.Empty;
    
    [Required] 
    public string ProductName { get; set; } = string.Empty;
}
