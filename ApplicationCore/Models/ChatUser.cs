using ApplicationCore.Models;

namespace BlazorChat.Components.AplicationCore.Models;

public class ChatUser : User
{
    public string ConnectionId { get; set; }
}