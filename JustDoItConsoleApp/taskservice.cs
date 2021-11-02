using System;
using System.Collections.Generic;
using System.Text;

namespace JustDoItConsoleApp
{
    class Taskservice
    {
        public List<Task> tasks = new List<Task>();
        int idIndex = 0;
        int genId()
        {
            idIndex++;
            return idIndex;
        }
        public void add(string title, string priority, DateTime deadline)
        {
            var task = new Task();
            task.title = title;
            task.priority = priority;
            task.deadline = deadline;
            task.taskId = genId();
            tasks.Add(task);

        }
        public void edit(string title, string priority, DateTime deadline, int taskId)
        {
            foreach (Task t in tasks)
            {
                if (t.taskId == taskId)
                {
                    t.title = title;
                    t.priority = priority;
                    t.deadline = deadline;
                }
            }
        }
        public void complete()
        {

        }
        public void delete()
        {

        }
    }
}
