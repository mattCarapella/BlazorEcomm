using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorEcomm_MODELS;

public class ErrorModelDTO
{
    public string Title { get; set; } = string.Empty;
    public int StatusCode { get; set; }
    public string ErrorMessage { get; set; } = string.Empty;
}
