using TimedExercise.Models.User;

namespace TimedExercise.Services.UserS;

public interface IUserService
{
    Task<UserDetail?> GetUserByIdAsync(int userId);
}