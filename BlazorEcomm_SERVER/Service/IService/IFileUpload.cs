using Microsoft.AspNetCore.Components.Forms;

namespace BlazorEcomm_SERVER.Service.IService;

public interface IFileUpload
{
    Task<string> UploadFile(IBrowserFile file);

    bool DeleteFile(string filePath);

}