using System;
using System.Collections.Generic;

namespace TwitterClone.Domain.Entities
{
    public class User : BaseEntity, IFollowable, INotifiable
    {
        public string FirstName { get; private set; } = string.Empty;
        public string LastName { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string PasswordHash { get; private set; } = string.Empty;

        // For IFollowable
        public List<Guid> Followers { get; private set; } = new List<Guid>();

        // For INotifiable
        public List<Guid> Notifications { get; private set; } = new List<Guid>();

        protected User() { }

        public User(string firstName, string lastName, string email, string passwordHash, Guid createdBy)
            : base(createdBy)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("First name is required.", nameof(firstName));
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email is required.", nameof(email));

            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PasswordHash = passwordHash;
        }

        // ========== IFollowable ==========
        public void Follow(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("User ID cannot be empty.", nameof(id));

            if (id == this.Id)
                throw new InvalidOperationException("A user cannot follow themselves.");

            if (!Followers.Contains(id))
            {
                Followers.Add(id);
            }
        }

        public void Unfollow(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("User ID cannot be empty.", nameof(id));

            Followers.Remove(id);
        }

        // ========== INotifiable ==========
        public void Notify(Notification notification)
        {
            if (notification == null)
                throw new ArgumentNullException(nameof(notification));

            Notifications.Add(notification.Id);
        }
    }
}