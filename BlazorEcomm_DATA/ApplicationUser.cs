using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BlazorEcomm_DATA;

public class ApplicationUser : IdentityUser
{
    [Display(Name = "First Name")]
    public string FirstName { get; set; } = String.Empty;

    [Display(Name = "Last Name")]
    public string LastName { get; set; } = String.Empty;

    [Display(Name = "Name")]
    public string FullName
    {
        get
        {
            return FirstName + " " + LastName;
        }
    }
}
