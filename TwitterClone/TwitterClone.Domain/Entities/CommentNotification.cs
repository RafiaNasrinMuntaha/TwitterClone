using System;

namespace TwitterClone.Domain.Entities
{
    public sealed class CommentNotification : Notification
    {
        public Guid TweetId { get; private set; }
        public Guid CommentId { get; private set; }

        private CommentNotification() { }

        public CommentNotification(Guid recipientId, Guid triggeredById, Guid tweetId, Guid commentId, string content, Guid createdBy)
            : base(recipientId, triggeredById, NotificationType.Comment, content, createdBy)
        {
            if (tweetId == Guid.Empty)
                throw new ArgumentException("Tweet ID cannot be empty.", nameof(tweetId));
            if (commentId == Guid.Empty)
                throw new ArgumentException("Comment ID cannot be empty.", nameof(commentId));

            TweetId = tweetId;
            CommentId = commentId;
        }
    }
}