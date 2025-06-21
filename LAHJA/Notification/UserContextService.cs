using System.Collections.Concurrent;

namespace LAHJA.Notification
{
    public class UserContextService
    {
        private readonly ConcurrentDictionary<string, string> _userConnections = new();

        public void AddUser(string userId, string connectionId)
        {
            _userConnections[userId] = connectionId;
        }

        public void RemoveUser(string userId)
        {
            _userConnections.TryRemove(userId, out _);
        }

        public string? GetConnectionId(string userId)
        {
            _userConnections.TryGetValue(userId, out var connectionId);
            return connectionId;
        }
    }

}
