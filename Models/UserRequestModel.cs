using System.ComponentModel.DataAnnotations;

namespace RestfullDemo.Models
{
    public class UserRequestModel
    {
        [Key] public int Id { get; set; }
        [Required][MaxLength(15)] public string UserName { get; set; }
        [Required][MaxLength(15)] public string Password { get; set; }
    }
}
