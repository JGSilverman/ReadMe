using Microsoft.EntityFrameworkCore;
using ReadMe.Models;
using System.Linq.Expressions;

namespace ReadMe.Data
{
    public class StoryRepo : IStoryRepo
    {
        private readonly IDbContextFactory<ApplicationDbContext> _factory;

        public StoryRepo(IDbContextFactory<ApplicationDbContext> factory)
        {
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        public async Task<Story> CreateStory(Story story)
        {
            if (story == null) throw new ArgumentNullException(nameof(story));

            try
            {
                using var ctx = _factory.CreateDbContext();
                await ctx.AddAsync<Story>(story);
                await ctx.SaveChangesAsync();
                return story;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteStory(Story story)
        {
            if (story == null) throw new ArgumentNullException(nameof(story));

            try
            {
                using var ctx = _factory.CreateDbContext();
                ctx.Remove(story);
                return (await ctx.SaveChangesAsync() > 1);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Story>> GetStories(Expression<Func<Story, bool>> filter = null)
        {
            try
            {
                using var ctx = _factory.CreateDbContext();

                IQueryable<Story> query = ctx.Stories.AsNoTracking();

                if (filter != null)
                {
                    query = query.Where(filter);
                }

                return await query.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Story> GetStory(Expression<Func<Story, bool>> filter)
        {
            try
            {
                using var ctx = _factory.CreateDbContext();

                IQueryable<Story> query = ctx.Stories.AsNoTracking();

                if (filter != null)
                {
                    query = query.Where(filter);
                }

                return await query.FirstOrDefaultAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Story> UpdateStory(Story story)
        {
            try
            {
                using var ctx = _factory.CreateDbContext();
                ctx.Update<Story>(story);
                await ctx.SaveChangesAsync();
                return story;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
