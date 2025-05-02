using System.ComponentModel.DataAnnotations;

namespace ToDoAppWithDb.ViewModel
{
    public class TodoTaskModel
    {

        [Required(ErrorMessage = "Allah Rızası İçin Boş Geçmeyelim.")]
        public string Task { get; set; }
    }
}
