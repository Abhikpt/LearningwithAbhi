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

    // Accept catch-all fileName so paths like "docs/guide.md" are supported
    [HttpGet("{*fileName}")]
    public async Task<IActionResult> GetMarkdownFile(string fileName)
    {
        var repoOwner = _config["GitHub:Owner"];
        var repoName = _config["GitHub:Repo"];
        var githubToken = _config["GitHub:Token2"];
        // Use provided fileName, default to README.md if empty
        if (string.IsNullOrWhiteSpace(fileName))
            fileName = "README";
        var filePath = fileName.EndsWith(".md", StringComparison.OrdinalIgnoreCase) ? fileName : $"{fileName}.md";

        // Use the GitHub contents API endpoint
        var url = $"https://api.github.com/repos/{repoOwner}/{repoName}/contents/{filePath}";

        var client = _clientFactory.CreateClient();
        client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("BlazorApp", "1.0"));
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", githubToken);

        var response = await client.GetAsync(url);
        if (!response.IsSuccessStatusCode)
            return NotFound("Markdown file not found.");

        var json = await response.Content.ReadFromJsonAsync<JsonElement>();
        var base64Content = json.GetProperty("content").GetString();
        // Remove any line breaks/newlines in the Base64 content before decoding
        base64Content = base64Content?.Replace("\n", "").Replace("\r", "");
        if (string.IsNullOrWhiteSpace(base64Content))
            return NotFound("Markdown content was empty.");
        var markdown = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(base64Content));

        return Ok(markdown);
    }
}
