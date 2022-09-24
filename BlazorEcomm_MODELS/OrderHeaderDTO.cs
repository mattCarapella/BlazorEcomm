using System.ComponentModel.DataAnnotations;
using BlazorEcomm_COMMON;
using static BlazorEcomm_COMMON.Enums;

namespace BlazorEcomm_MODELS;

public class OrderHeaderDTO
{
    public int Id { get; set; }

    [Required]
    public string UserId { get; set; } = string.Empty;


    [Required, Display(Name = "Order Total")]
    public double OrderTotal { get; set; }


    [Required, Display(Name = "Order Date")]
    public DateTime OrderDate { get; set; }


    [Required, Display(Name = "Shipping Date")]
    public DateTime ShippingDate { get; set; }


    public OrderStatus Status { get; set; }


    public string? SessionId { get; set; }


    public string? PaymentIntentId { get; set; }


    // User Details

    [Required, Display(Name = "Name")]
    public string Name { get; set; } = string.Empty;


    [Required, Display(Name = "Phone Number")]
    public string PhoneNumber { get; set; } = string.Empty;


    [Required, Display(Name = "Address - line 1")]
    public string Address_1 { get; set; } = string.Empty;


    [Display(Name = "Address - line 2")]
    public string? Address_2 { get; set; } = string.Empty;


    [Required, Display(Name = "City")]
    public string City { get; set; } = string.Empty;


    [Required, Display(Name = "State")]
    public State State { get; set; } = new(string.Empty, string.Empty);


    [Required, Display(Name = "Country")]
    public string Country { get; set; } = string.Empty;


    [Required, Display(Name = "Postal Code")]
    public string PostalCode { get; set; } = string.Empty;


    [Required, Display(Name = "Email")]
    public string Email { get; set; } = string.Empty;

}
