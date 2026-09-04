using System;

namespace TwitterClone.Domain.Entities
{
    public class Retweet : BaseEntity
    {
        public Guid UserId { get; private set; }
        public Guid OriginalTweetId { get; private set; }

        protected Retweet() { }

        public Retweet(Guid userId, Guid originalTweetId, Guid createdBy)
            : base(createdBy)
        {
            if (userId == Guid.Empty)
                throw new ArgumentException("User ID cannot be empty.", nameof(userId));
            if (originalTweetId == Guid.Empty)
                throw new ArgumentException("Original Tweet ID cannot be empty.", nameof(originalTweetId));

            UserId = userId;
            OriginalTweetId = originalTweetId;
        }
    }
}