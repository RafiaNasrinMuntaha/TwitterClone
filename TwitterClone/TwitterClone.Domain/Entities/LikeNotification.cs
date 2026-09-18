using System;

namespace TwitterClone.Domain.Entities
{
    public sealed class LikeNotification : Notification
    {
        public Guid TweetId { get; private set; }

        private LikeNotification() { }

        public LikeNotification(Guid recipientId, Guid triggeredById, Guid tweetId, string content, Guid createdBy)
            : base(recipientId, triggeredById, NotificationType.Like, content, createdBy)
        {
            if (tweetId == Guid.Empty)
                throw new ArgumentException("Tweet ID cannot be empty.", nameof(tweetId));

            TweetId = tweetId;
        }
    }
}