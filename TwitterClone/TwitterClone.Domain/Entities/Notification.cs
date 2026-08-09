using System;

namespace TwitterClone.Domain.Entities
{
    public enum NotificationType
    {
        Like,
        Retweet,
        Follow,
        Message
    }

    public class Notification
    {
        public Guid Id { get; private set; }
        public Guid RecipientId { get; private set; } // The user receiving the notification
        public Guid TriggeredById { get; private set; } // The user who performed the action
        public NotificationType Type { get; private set; }
        public string Content { get; private set; } = string.Empty;
        public bool IsRead { get; private set; }
        public DateTime CreatedAt { get; private set; }

        protected Notification() { }

        public Notification(Guid recipientId, Guid triggeredById, NotificationType type, string content)
        {
            if (recipientId == Guid.Empty)
                throw new ArgumentException("Recipient ID cannot be empty.", nameof(recipientId));

            if (triggeredById == Guid.Empty)
                throw new ArgumentException("TriggeredBy ID cannot be empty.", nameof(triggeredById));

            Id = Guid.NewGuid();
            RecipientId = recipientId;
            TriggeredById = triggeredById;
            Type = type;
            Content = content;
            IsRead = false;
            CreatedAt = DateTime.UtcNow;
        }

        // Domain method to mark notification as read
        public void MarkAsRead()
        {
            IsRead = true;
        }
    }
}