using System;

namespace TwitterClone.Domain.Entities
{
    public sealed class SystemNotification : Notification
    {
        private SystemNotification() { }

        public SystemNotification(Guid recipientId, string content, Guid createdBy)
            : base(recipientId, Guid.Empty, NotificationType.System, content, createdBy)
        {
            // System notifications usually have no real "TriggeredBy" user
        }
    }
}