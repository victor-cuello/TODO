using System;

namespace Core.Model
{
    public class Task
    {
        private string _title;

        public string Title
        {
            get => _title;
            set => _title = value.Trim();
        }

        public string UserName { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Message { get; set; }
        public long UserId { get; set; }
        public long TaskId { get; set; }

        public override bool Equals(object obj)
        {
            string otherTask = (obj as Task).Title;
            return Title.Equals(otherTask, StringComparison.OrdinalIgnoreCase);
        }

        public bool GetLength(object obj)
        {
            string title = (obj as Task).Title;
            if(title.Length < 50 && title.Length > 0)
            {
                return true;
            }
            else
            {
                throw new ArgumentException("Title Too Long");
            }
        }
    }
}