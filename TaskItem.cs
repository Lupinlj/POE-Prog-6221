using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POE_PROG_YEAR_2.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
        public string Reminder { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
        public DateTime DateAdded { get; set; }

    }
}
