using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ILT.Core.Data.Entities.Models
{
    public class Group : IEntity
    {
        [Key, Column("GroupId")]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<User>? Users { get; set;}
        [JsonIgnore]
        public ICollection<Fellows>? Fellows { get; set; }
    }
}