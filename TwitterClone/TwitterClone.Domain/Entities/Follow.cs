using System;

namespace TwitterClone.Domain.Entities
{
    public class Follow : BaseEntity
    {
        public Guid FollowerId { get; private set; }
        public Guid FollowingId { get; private set; }

        protected Follow() { }

        public Follow(Guid followerId, Guid followingId, Guid createdBy)
            : base(createdBy)
        {
            if (followerId == Guid.Empty)
                throw new ArgumentException("Follower ID cannot be empty.", nameof(followerId));
            if (followingId == Guid.Empty)
                throw new ArgumentException("Following ID cannot be empty.", nameof(followingId));
            if (followerId == followingId)
                throw new InvalidOperationException("Users cannot follow themselves.");

            FollowerId = followerId;
            FollowingId = followingId;
        }
    }
}