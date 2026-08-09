using System;

namespace TwitterClone.Domain.Entities
{
    public class Tweet
    {
        public Guid Id { get; private set; }
        public Guid AuthorId { get; private set; }
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; private set; }

        // Parameterless constructor for ORM tools
        protected Tweet() { }

        // Main constructor to enforce required data
        public Tweet(Guid authorId, string content)
        {
            if (authorId == Guid.Empty)
                throw new ArgumentException("Author ID cannot be empty.", nameof(authorId));

            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentException("Tweet content cannot be empty.", nameof(content));

            Id = Guid.NewGuid();
            AuthorId = authorId;
            Content = content;
            CreatedAt = DateTime.UtcNow;
        }

        // Domain method to allow editing tweet content safely
        public void UpdateContent(string newContent)
        {
            if (string.IsNullOrWhiteSpace(newContent))
                throw new ArgumentException("Content cannot be empty.", nameof(newContent));

            Content = newContent;
        }
    }
}