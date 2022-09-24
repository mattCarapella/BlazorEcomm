using System.ComponentModel.DataAnnotations;

namespace BlazorEcomm_DATA;

public class OrderHeader
{
    [Key]
    public int Id { get; set; }

    [Required]
    // #TODO: Add navigation property
    public string UserId { get; set; } = string.Empty;

    [Required]
    public double OrderTotal { get; set; }

    [Required]
    public DateTime OrderDate { get; set; }

    [Required]
    public DateTime ShippingDate { get; set; }

    [Required]
    public string Status { get; set; } = string.Empty;

    public string? SessionId { get; set; }

    public string? PaymentIntentId { get; set; }

    
    // User Details

    [Required]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    public string LastName { get; set; } = string.Empty;

    [Required]
    public string PhoneNumber { get; set; } = string.Empty;

    [Required]
    public string Address_1 { get; set; } = string.Empty;

    public string? Address_2 { get; set; } = string.Empty;

    [Required]
    public string City { get; set; } = string.Empty;

    [Required]
    public string State { get; set; } = string.Empty;

    [Required]
    public string Country { get; set; } = string.Empty;

    [Required]
    public string PostalCode { get; set; } = string.Empty;

    [Required]
    public string Email { get; set; } = string.Empty;


}
