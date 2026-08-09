using System;

namespace TwitterClone.Domain.Entities
{
    public class Retweet
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public Guid OriginalTweetId { get; private set; }
        public DateTime RetweetedAt { get; private set; }

        // Parameterless constructor for ORM tools
        protected Retweet() { }

        // Main constructor
        public Retweet(Guid userId, Guid originalTweetId)
        {
            if (userId == Guid.Empty)
                throw new ArgumentException("User ID cannot be empty.", nameof(userId));

            if (originalTweetId == Guid.Empty)
                throw new ArgumentException("Original Tweet ID cannot be empty.", nameof(originalTweetId));

            Id = Guid.NewGuid();
            UserId = userId;
            OriginalTweetId = originalTweetId;
            RetweetedAt = DateTime.UtcNow;
        }
    }
}