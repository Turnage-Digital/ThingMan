using Newtonsoft.Json;

namespace ThingMan.Contracts.Dtos;

public class NotificationDefDto
{
    [JsonProperty("type")]
    public string Type { get; set; } = null!;

    [JsonProperty("isActive")]
    public bool IsActive { get; set; }

    [JsonProperty("userId")]
    public string? UserId { get; set; }
}