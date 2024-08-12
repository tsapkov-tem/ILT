using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ILT.Core.Data.Entities.Models
{
    public class Fellows
    {
        public string FellowId { get; set; }
        [Required]
        public string UserId { get; set; }
        [JsonIgnore]
        public User? User { get; set; }
        [Required]
        public string GroupId { get; set; }
        [JsonIgnore]
        public Group? Group { get; set; }
        public string? RoleId {  get; set; }
        [JsonIgnore]
        public Role Role { get; set; }

    }
}
