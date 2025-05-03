using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoAppWithDb.Models
{
    public class ToDo
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage ="Elbet Yazacak Birşey Bulunur.")]
        public string Task { get; set; }
        public bool IsComp { get; set; }
        
        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public UserModel User { get; set; }
    }
}
