using System;

namespace TwitterClone.Domain.Entities
{
    public enum NotificationType
    {
        Like,
        Comment,
        FriendRequest,
        System,
        Retweet,
        Follow,
        Message
    }

    public class Notification : BaseEntity
    {
        public Guid RecipientId { get; protected set; }
        public Guid TriggeredById { get; protected set; }
        public NotificationType Type { get; protected set; }
        public string Content { get; protected set; } = string.Empty;
        public bool IsRead { get; protected set; }

        protected Notification() { }

        protected Notification(Guid recipientId, Guid triggeredById, NotificationType type, string content, Guid createdBy)
            : base(createdBy)
        {
            if (recipientId == Guid.Empty)
                throw new ArgumentException("Recipient ID cannot be empty.", nameof(recipientId));
            if (triggeredById == Guid.Empty)
                throw new ArgumentException("TriggeredBy ID cannot be empty.", nameof(triggeredById));

            RecipientId = recipientId;
            TriggeredById = triggeredById;
            Type = type;
            Content = content;
            IsRead = false;
        }

        public virtual void MarkAsRead()
        {
            IsRead = true;
        }
    }
}