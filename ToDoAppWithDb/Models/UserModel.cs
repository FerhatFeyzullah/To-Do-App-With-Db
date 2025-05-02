using System.ComponentModel.DataAnnotations;

namespace ToDoAppWithDb.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Kullanıcı adı gerekli.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "E-posta gerekli.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta girin.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre gerekli.")]
        [MinLength(6, ErrorMessage = "Şifre en az 6 karakter olmalı.")]
        public string Password { get; set; }

        public List<ToDo> Todolar { get; set; }

        public UserModel()
        {
            Todolar = new List<ToDo>();
        }



    }
}
