using TwitterClone.Domain.Entities;

public static class LikeService
{
    public static void ProcessLike(ILikeable item)
    {
        if (item.CanBeLiked())
        {
            Console.WriteLine("Like processed successfully.");
        }
        else
        {
            Console.WriteLine("This item cannot be liked.");
        }
    }
}