using System;

namespace TwitterClone.Domain.Entities
{
    public class Like
    {
        public Guid UserId { get; private set; }
        public Guid TweetId { get; private set; }
        public DateTime LikedAt { get; private set; }

        // Parameterless constructor for ORM tools (like Entity Framework)
        protected Like() { }

        // Main constructor to guarantee valid data on creation
        public Like(Guid userId, Guid tweetId)
        {
            if (userId == Guid.Empty)
                throw new ArgumentException("User ID cannot be empty.", nameof(userId));

            if (tweetId == Guid.Empty)
                throw new ArgumentException("Tweet ID cannot be empty.", nameof(tweetId));

            UserId = userId;
            TweetId = tweetId;
            LikedAt = DateTime.UtcNow;
        }
    }
}