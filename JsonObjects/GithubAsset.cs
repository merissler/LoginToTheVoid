using System.Text.Json.Serialization;

namespace LoginToTheVoid.JsonObjects;

internal class GithubAsset
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("browser_download_url")]
    public string BrowserDownloadUrl { get; set; }
}
