using ReadMe.Models;
using System.Linq.Expressions;

namespace ReadMe.Data
{
    public interface IStoryRepo
    {
        Task<Story> CreateStory(Story story);
        Task<Story> UpdateStory(Story story);
        Task<Story> GetStory(Expression<Func<Story, bool>> filter);
        Task<List<Story>> GetStories(Expression<Func<Story, bool>> filter = null);
        Task<bool> DeleteStory(Story story);
    };
}
