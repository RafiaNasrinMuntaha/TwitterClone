using System;

namespace TwitterClone.Domain.Entities
{
    public class Follow
    {
        public Guid FollowerId { get; private set; }  // The user who clicks "Follow"
        public Guid FollowingId { get; private set; } // The user being followed
        public DateTime FollowedAt { get; private set; }

        // Parameterless constructor for ORM tools
        protected Follow() { }

        // Main constructor
        public Follow(Guid followerId, Guid followingId)
        {
            if (followerId == Guid.Empty)
                throw new ArgumentException("Follower ID cannot be empty.", nameof(followerId));

            if (followingId == Guid.Empty)
                throw new ArgumentException("Following ID cannot be empty.", nameof(followingId));

            if (followerId == followingId)
                throw new InvalidOperationException("Users cannot follow themselves.");

            FollowerId = followerId;
            FollowingId = followingId;
            FollowedAt = DateTime.UtcNow;
        }
    }
}