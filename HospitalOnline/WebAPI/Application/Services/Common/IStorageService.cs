﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Common
{
	public interface IStorageService
	{
		string GetFileUrl(string fileName);

		Task SaveFileAsync(Stream mediaBinaryStream, string fileName);

		Task DeleteFileAsync(string fileName);
	}
}
