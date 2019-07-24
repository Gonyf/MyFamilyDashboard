using System;

namespace MyFamilyDashboard.Data
{
    public class TodoItemDataModel
    {
        public Guid ID { get; set; }

        public string Text { get; set; }

        public bool Completed { get; set; }
    }
}
