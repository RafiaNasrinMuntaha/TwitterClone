using System;

namespace TwitterClone.Domain.Entities
{
    public sealed class SystemNotification : Notification
    {
        public string SystemMessage { get; private set; } = string.Empty;

        private SystemNotification() { }

        public SystemNotification(Guid recipientId, string systemMessage, Guid createdBy)
            : base(recipientId, Guid.Empty, createdBy) // No real user triggered this
        {
            if (string.IsNullOrWhiteSpace(systemMessage))
                throw new ArgumentException("System message cannot be empty.", nameof(systemMessage));

            SystemMessage = systemMessage;
        }

        public override string GetMessage()
        {
            return $"[System] {SystemMessage}";
        }
    }
}