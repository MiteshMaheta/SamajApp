using System;
using System.Threading.Tasks;

namespace SamajApp.Helper
{
    public interface IFileHelper
    {
        string GetFile(string fileName);
        bool DeleteFile(string fileName);
        bool RenameFile(string oldFilename, string newFileName);
        Task<bool> SaveZipToFolder();
        Task<bool> UnzipDb(byte[] zipFile);
    }
}
