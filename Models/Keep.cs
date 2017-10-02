using System.ComponentModel.DataAnnotations;

namespace keepr.Models
{
    public class Keep
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public int ViewCount { get; set; }
        public int SaveCount { get; set; }
        
        [Required]
        public string UserId { get; set; }

        // public List<string> Tags { get; set; } = new List<string>(); //this is a list of tag ids

    }
}