using Newtonsoft.Json;

namespace ThingMan.Core.Views;

public class NotificationDefView
{
    [JsonProperty("type")]
    public string Type { get; set; } = null!;

    [JsonProperty("isActive")]
    public bool IsActive { get; set; }

    [JsonProperty("userId")]
    public string? UserId { get; set; }
}