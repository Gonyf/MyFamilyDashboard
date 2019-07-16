using MyFamilyDashboard.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace MyFamilyDashboard.Data
{
    public class TodoListDataModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string Title { get; set; }

        public List<TodoItemDataModel> TodoItems { get; set; }
    }
}
