using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Threading.Tasks;

namespace Application.Services.Common
{
	public class FileStorageService : IStorageService
	{
		private readonly string _patientContentFolder;
		private const string PATIENT_CONTENT_FOLDER_NAME = "patient-content";
		public FileStorageService(IWebHostEnvironment webHostEnvironment)
		{
			_patientContentFolder = Path.Combine(webHostEnvironment.WebRootPath, PATIENT_CONTENT_FOLDER_NAME);
		}
		public string GetFileUrl(string fileName)
		{
			return $"/{PATIENT_CONTENT_FOLDER_NAME}/{fileName}";
		}
		public async Task SaveFileAsync(Stream mediaBinaryStream, string fileName)
		{
			var filePath = Path.Combine(_patientContentFolder, fileName);
			using var output = new FileStream(filePath, FileMode.Create);
			await mediaBinaryStream.CopyToAsync(output);
		}

		public async Task DeleteFileAsync(string fileName)
		{
			var filePath = Path.Combine(_patientContentFolder, fileName);
			if (File.Exists(filePath))
			{
				await Task.Run(() => File.Delete(filePath));
			}
		}
	}
}
