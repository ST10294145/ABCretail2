using ABCretail2.Models;
using ABCretail2.Services;
using Azure.Storage.Files.Shares.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ABCretail2.Controllers
{
    public class FileController : Controller
    {
        private readonly AzureFileShareService _fileShareService;

        public FileController(AzureFileShareService fileShareService)
        {
            _fileShareService = fileShareService;
        }

        // GET: File/Upload
        [HttpGet]
        public IActionResult Upload()
        {
            return View();
        }

        // POST: File/Upload
        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file, string directoryName)
        {
            if (file == null || file.Length == 0)
            {
                ModelState.AddModelError("", "No file selected for upload.");
                return View();
            }

            try
            {
                using (var stream = file.OpenReadStream())
                {
                    await _fileShareService.UploadFileAsync(directoryName, file.FileName, stream);
                }

                return RedirectToAction("UploadSuccess");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error uploading file: {ex.Message}");
                return View();
            }
        }

        // GET: File/UploadSuccess
        public IActionResult UploadSuccess()
        {
            return View();
        }

        // GET: File/Download
        [HttpGet]
        public IActionResult Download()
        {
            return View();
        }

        // POST: File/Download
        [HttpPost]
        public async Task<IActionResult> Download(string directoryName, string fileName)
        {
            if (string.IsNullOrEmpty(directoryName) || string.IsNullOrEmpty(fileName))
            {
                ModelState.AddModelError("", "Directory name and file name are required.");
                return View();
            }

            try
            {
                var fileStream = await _fileShareService.DownloadFileAsync(directoryName, fileName);
                if (fileStream == null)
                {
                    ModelState.AddModelError("", "File not found.");
                    return View();
                }

                return File(fileStream, "application/octet-stream", fileName);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error downloading file: {ex.Message}");
                return View();
            }
        }

        // GET: File/List
        [HttpGet]
        public async Task<IActionResult> List(string directoryName)
        {
            if (string.IsNullOrEmpty(directoryName))
            {
                ModelState.AddModelError("", "Directory name is required.");
                return View();
            }

            try
            {
                var files = await _fileShareService.ListFilesAsync(directoryName);
                return View(files);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error listing files: {ex.Message}");
                return View();
            }
        }
    }
}
