using System;

namespace TwitterClone.Domain.Entities
{
    public sealed class MentionNotification : Notification
    {
        public Guid TweetId { get; private set; }

        private MentionNotification() { }

        public MentionNotification(Guid recipientId, Guid triggeredById, Guid tweetId, Guid createdBy)
            : base(recipientId, triggeredById, createdBy)
        {
            if (tweetId == Guid.Empty)
                throw new ArgumentException("Tweet ID cannot be empty.", nameof(tweetId));

            TweetId = tweetId;
        }

        public override string GetMessage()
        {
            return $"User {TriggeredById} mentioned you in a tweet.";
        }
    }
}