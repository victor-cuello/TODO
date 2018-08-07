using System;
using Core.Model;
namespace Core.UseCases
{
    public class CreateTask
    {
        
        public static void Save(Task NewTask)
        {
            if (NewTask.Title == "" || NewTask.Title == null)
            {
                throw new ArgumentException("Title cannot be empty");
            }
        }
    }
}