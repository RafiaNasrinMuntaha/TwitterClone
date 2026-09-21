using System;

namespace TwitterClone.Domain.Entities
{
    public class Tweet : BaseEntity, ILikeable
    {
        public Guid AuthorId { get; private set; }
        public string Content { get; private set; } = string.Empty;
        public bool IsDeleted { get; private set; }

        protected Tweet() { }

        public Tweet(Guid authorId, string content, Guid createdBy)
            : base(createdBy)
        {
            if (authorId == Guid.Empty)
                throw new ArgumentException("Author ID cannot be empty.", nameof(authorId));
            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentException("Tweet content cannot be empty.", nameof(content));

            AuthorId = authorId;
            Content = content;
            IsDeleted = false;
        }

        // Implementation of ILikeable
        public bool CanBeLiked()
        {
            // A tweet can be liked only if it is not deleted and has content
            return !IsDeleted && !string.IsNullOrWhiteSpace(Content);
        }

        public void SoftDelete()
        {
            IsDeleted = true;
        }

        public void UpdateContent(string newContent, Guid modifiedBy)
        {
            if (string.IsNullOrWhiteSpace(newContent))
                throw new ArgumentException("Content cannot be empty.", nameof(newContent));

            Content = newContent;
            MarkAsModified(modifiedBy);
        }
    }
}