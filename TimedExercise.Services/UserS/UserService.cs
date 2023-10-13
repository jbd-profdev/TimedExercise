using TimedExercise.Data;
using TimedExercise.Data.Entities;
using TimedExercise.Models.User;

namespace TimedExercise.Services.UserS;

public class UserService : IUserService
{
    private readonly SocialMediaDbContext _context;


    public UserService (SocialMediaDbContext context)
    {
        _context = context;
    }

    public async Task<UserDetail?> GetUserByIdAsync(int userId)
    {
        User? entity = await _context.Users.FindAsync(userId);
        if(entity is null)
            return null;
        
        UserDetail detail = new()
        {
            Id = entity.Id,
            Email = entity.Email!,
            FirstName = entity.FirstName!,
            LastName = entity.LastName!
        };

        return detail;
    }


}