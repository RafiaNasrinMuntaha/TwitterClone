using System;

namespace TwitterClone.Domain.Entities
{
    public class Bookmark
    {
        public Guid UserId { get; private set;}
        public Guid TweetId { get; private set; }
        public DateTime BookmarkedAt { get; private set; }

        protected Bookmark() { }

        public Bookmark(Guid userId, Guid tweetId)
        {
            if (userId == Guid.Empty)
                throw new ArgumentException("User ID cannot be empty.", nameof(userId));

            if (tweetId == Guid.Empty)
                throw new ArgumentException("Tweet ID cannot be empty.", nameof(tweetId));

            UserId = userId;
            TweetId = tweetId;
            BookmarkedAt = DateTime.UtcNow;
        }
    }
}