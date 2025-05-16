using System.Text.Json.Serialization;

namespace LoginToTheVoid.JsonObjects;

internal class GithubRelease
{
    [JsonPropertyName("tag_name")]
    public string TagName { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("body")]
    public string Body { get; set; }

    [JsonPropertyName("html_url")]
    public string HtmlUrl { get; set; }

    [JsonPropertyName("assets")]
    public GithubAsset[] Assets { get; set; }
}
