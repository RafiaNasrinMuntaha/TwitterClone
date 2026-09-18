using System;

namespace TwitterClone.Domain.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime? ModifiedAt { get; protected set; }
        public Guid CreatedBy { get; protected set; }
        public Guid? ModifiedBy { get; protected set; }

        protected BaseEntity() { }

        protected BaseEntity(Guid createdBy)
        {
            if (createdBy == Guid.Empty)
                throw new ArgumentException("CreatedBy cannot be empty.", nameof(createdBy));

            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
            CreatedBy = createdBy;
            ModifiedAt = null;
            ModifiedBy = null;
        }

        public virtual void MarkAsModified(Guid modifiedBy)
        {
            if (modifiedBy == Guid.Empty)
                throw new ArgumentException("ModifiedBy cannot be empty.", nameof(modifiedBy));

            ModifiedAt = DateTime.UtcNow;
            ModifiedBy = modifiedBy;
        }
    }
}