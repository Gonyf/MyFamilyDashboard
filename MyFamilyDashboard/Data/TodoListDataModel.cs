using MyFamilyDashboard.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace MyFamilyDashboard.Data
{
    public class TodoListDataModel
    {
        void TodoItemDataModel()
        {
            this.CreatedDate = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string Title { get; set; }

        public List<TodoItemDataModel> TodoItems { get; set; }

        public DateTime CreatedDate { get; private set; }

        public DateTime? DueDate { get; set; }
    }
}
