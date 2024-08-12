using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ILT.Core.Data.Entities.Models
{
    public class Role
    {
        [Key, Column("RoleId")]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string FellowId { get; set; }
        [JsonIgnore]
        public Fellows? Fellow {  get; set; }
    }
}
