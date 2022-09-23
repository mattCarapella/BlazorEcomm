using BlazorEcomm_SERVER.Service.IService;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorEcomm_SERVER.Service;

public class FileUpload : IFileUpload
{
    private readonly IWebHostEnvironment _webHostEnvironment;

    public FileUpload(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }

    public async Task<string> UploadFile(IBrowserFile file)
    {
        FileInfo fileInfo = new(file.Name);
        var fileName = Guid.NewGuid().ToString()+fileInfo.Extension;
        
        // current saved locally... maybe store images in database?
        var folderDirectory = $"{_webHostEnvironment.WebRootPath}\\images\\product";

        // creates a new directory if one doesnt exist
        if (!Directory.Exists(folderDirectory))
        {
            Directory.CreateDirectory(folderDirectory);
        }

        var filePath = Path.Combine(folderDirectory, fileName);

        // FileStream should always be used with Blazor
        await using FileStream fs = new(filePath, FileMode.Create);
        await file.OpenReadStream().CopyToAsync(fs);

        // returns location where file was saved
        var fullPath = $"/images/product/{fileName}";
        return fullPath;
    }

    public bool DeleteFile(string filePath)
    {
        if (File.Exists(_webHostEnvironment.WebRootPath+filePath))
        {
            File.Delete(_webHostEnvironment.WebRootPath+filePath);
            return true;
        }
        return false;
    }

}
