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
        public void add(string title, string priority, string deadline)
        {
            var task = new Task();
            task.title = title;
            task.priority = priority;
            task.deadline = deadline;
            task.taskId = genId();
            tasks.Add(task);

        }
        public void edit(string title, string priority, string deadline, int taskId)
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
        public void complete(int taskId, bool finished)
        {
            foreach (Task t in tasks)
            {
                if (t.taskId == taskId)
                {
                    t.finished = true;
                }
            }
        }
        public void delete(int taskId)
        {
            foreach (Task t in tasks)
            {
                if (t.taskId == taskId)
                {
                    tasks.Remove(t);
                    break;
                }
                //zweite Möglichkeit ausserhalb der if schlaufe removen
            }
        }

        enum Priority { 
            Low,
            Normal,
            High,
            Urgent
        }
    }
}
