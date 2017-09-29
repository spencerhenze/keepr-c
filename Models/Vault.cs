using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace keepr.Models
{
    public class Vault
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        [Required]
        public string UserId { get; set; }

        public List<Keep> VaultKeeps { get; set; } = new List<Keep>();

    }
}