using System;

namespace TwitterClone.Domain.Entities
{
    public abstract class Notification : BaseEntity
    {
        public Guid RecipientId { get; protected set; }
        public Guid TriggeredById { get; protected set; }
        public bool IsRead { get; private set; }

        // Parameterless constructor for ORM
        protected Notification() { }

        protected Notification(Guid recipientId, Guid triggeredById, Guid createdBy)
            : base(createdBy)
        {
            if (recipientId == Guid.Empty)
                throw new ArgumentException("Recipient ID cannot be empty.", nameof(recipientId));

            RecipientId = recipientId;
            TriggeredById = triggeredById;
            IsRead = false;
        }

        // Concrete method – shared by all notifications
        public void MarkAsRead()
        {
            IsRead = true;
        }

        // Abstract method – every child MUST implement this
        public abstract string GetMessage();
    }
}