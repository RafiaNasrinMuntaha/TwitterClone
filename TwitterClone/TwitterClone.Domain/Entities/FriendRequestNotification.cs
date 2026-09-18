using System;

namespace TwitterClone.Domain.Entities
{
    public sealed class FriendRequestNotification : Notification
    {
        public Guid RequestId { get; private set; }

        private FriendRequestNotification() { }

        public FriendRequestNotification(Guid recipientId, Guid triggeredById, Guid requestId, string content, Guid createdBy)
            : base(recipientId, triggeredById, NotificationType.FriendRequest, content, createdBy)
        {
            if (requestId == Guid.Empty)
                throw new ArgumentException("Request ID cannot be empty.", nameof(requestId));

            RequestId = requestId;
        }
    }
}