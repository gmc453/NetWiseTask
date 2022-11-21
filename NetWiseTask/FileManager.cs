using Microsoft.Extensions.Logging;
using System.Net.Http.Json;
using System.Text.Json;

public class FileManager : IFileManager
{
	private readonly ILogger<FactModel> _log;

	public FileManager(ILogger<FactModel> log)
	{
		_log = log;
	}

	public void SaveResponseToFile(FactModel response)
	{
		var filePath = @"Facts.txt";

        File.AppendAllText(filePath, $"Fact: {response.fact} Lenght: {response.length}\n");
    }
}
