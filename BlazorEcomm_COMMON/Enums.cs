using System.ComponentModel.DataAnnotations;

namespace BlazorEcomm_COMMON;

public class Enums
{
    public enum OrderStatus
    { 
        [Display(Name="Received")]
        RECEIVED = 0,
        [Display(Name = "In Progressed")]
        INPROGRESS = 1,
        [Display(Name = "Shipped")]
        SHIPPED = 2,
        [Display(Name = "Delivered")]
        DELIVERED = 3,
        [Display(Name = "Returned")]
        RETURNED = 4,
    }
}
