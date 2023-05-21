using Newtonsoft.Json;

namespace ThingMan.Domain.Dtos;

public record StatusDefDto
{
    [JsonProperty("name")]
    public string Name { get; set; } = null!;
}

public class NotificationDefDto
{
    [JsonProperty("type")]
    public NotificationType Type { get; set; }

    [JsonProperty("isActive")]
    public bool IsActive { get; set; }

    [JsonProperty("userId")]
    public string? UserId { get; set; }
}