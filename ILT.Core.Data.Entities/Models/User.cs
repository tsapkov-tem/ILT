using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ILT.Core.Data.Entities.Models
{
    public class User : IEntity
    {
        [Key, Column("UserId")]
        public string Id { get; set; }
        [Required]
        public string FirstName {  get; set; }
        [Required]
        public string LastName { get; set; }
        public string? FatherName {  get; set; }
        [JsonIgnore]
        public ICollection<Group>? Groups { get; set; }
        [JsonIgnore]
        public ICollection<Fellows> Fellows { get;}

    }
}
