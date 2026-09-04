using System;

namespace TwitterClone.Domain.Entities
{
    public class DirectMessage : BaseEntity
    {
        public Guid SenderId { get; private set; }
        public Guid ReceiverId { get; private set; }
        public string Content { get; private set; } = string.Empty;

        protected DirectMessage() { }

        public DirectMessage(Guid senderId, Guid receiverId, string content, Guid createdBy)
            : base(createdBy)
        {
            if (senderId == Guid.Empty)
                throw new ArgumentException("Sender ID cannot be empty.", nameof(senderId));
            if (receiverId == Guid.Empty)
                throw new ArgumentException("Receiver ID cannot be empty.", nameof(receiverId));
            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentException("Message content cannot be empty.", nameof(content));
            if (senderId == receiverId)
                throw new InvalidOperationException("You cannot send a message to yourself.");

            SenderId = senderId;
            ReceiverId = receiverId;
            Content = content;
        }
    }
}