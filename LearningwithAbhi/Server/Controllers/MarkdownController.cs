using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;

[ApiController]
[Route("api/[controller]")]
public class MarkdownController : ControllerBase
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly IConfiguration _config;

    public MarkdownController(IHttpClientFactory clientFactory, IConfiguration config)
    {
        _clientFactory = clientFactory;
        _config = config;
    }

    [HttpGet("{fileName}")]
    public async Task<IActionResult> GetMarkdownFile(string fileName)
    {
<<<<<<< HEAD
      
=======
        var githubToken = "a";
>>>>>>> Devlope_May
        var repoOwner = "Abhikpt";
        var repoName = "Documentation";
        fileName = "Readme";
        var filePath = $"{fileName}.md"; // adjust if needed

        var url = $"https://api.github.com/repos/{repoOwner}/{repoName}/{filePath}";

        var client = _clientFactory.CreateClient();
        client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("BlazorApp", "1.0"));
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", githubToken);

        var response = await client.GetAsync(url);
        if (!response.IsSuccessStatusCode)
            return NotFound("Markdown file not found.");

        var json = await response.Content.ReadFromJsonAsync<JsonElement>();
        var base64Content = json.GetProperty("content").GetString();
        var markdown = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(base64Content));

        return Ok(markdown);
    }
}
