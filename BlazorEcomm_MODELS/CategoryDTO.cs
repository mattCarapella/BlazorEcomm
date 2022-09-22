using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorEcomm_MODELS;

public class CategoryDTO
{
    public int Id { get; set; }

    [Required,
    MinLength(3, ErrorMessage = "Category name must be at least 3 characters."),
    MaxLength(30, ErrorMessage = "Category name must be less than 30 characters.")]
    public string Name { get; set; } = "";


    [Display(Name = "Created On"), DataType(DataType.Date)]
    public DateTime CreatedDate { get; set; }


    [Display(Name = "Last Updated"), DataType(DataType.Date)]
    public DateTime? UpdatedDate { get; set; }
}
