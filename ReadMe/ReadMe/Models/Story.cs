using static ReadMe.Models.ReadMeEnums;

namespace ReadMe.Models
{
    public class Story : BaseEntity
    {
        public long StoryId { get; set; }
        public string Title { get; set; }
        public string Blurb { get; set; }
        public string Content { get; set; }
        public StoryType StoryType { get; set; }
        public string Tags { get; set; }
        public string ContentWarnings { get; set; }
        public long WordCount { get; set; }
        public Guid AuthorId { get; set; }
        public virtual ApplicationUser Author { get; set; }
    }
}
