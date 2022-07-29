using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReadMe.Data;

namespace ReadMe.Controllers
{
    [Route("api/stories")]
    [ApiController]
    public class StoriesController : ControllerBase
    {
        private readonly IStoryRepo _storyRepo;

        public StoriesController(IStoryRepo storyRepo)
        {
            _storyRepo = storyRepo;
        }

        [HttpGet("GetStory/{storyId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetStory(long storyId)
        {
            try
            {
                var story = await _storyRepo.GetStory(x => x.StoryId == storyId);
                if (story == null) return NotFound($"StoryId: {storyId} was not found");
                return Ok(story);   
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetStories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetStories()
        {
            try
            {
                return Ok(await _storyRepo.GetStories());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
