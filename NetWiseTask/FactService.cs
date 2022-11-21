using System.Net.Http.Json;

public class FactService
{
	private static HttpClient Client = new HttpClient();
	private readonly IFileManager _fileManager;

	public FactService(IFileManager fileManager)
	{
		_fileManager = fileManager;
	}

	public async Task Run()
	{
		var result = await Client.GetFromJsonAsync<FactModel>("https://catfact.ninja/fact");

		if (result == null)
        {
            Console.WriteLine("Getting response failed.");
			return;
        }
		_fileManager.SaveResponseToFile(result);
	}
}
