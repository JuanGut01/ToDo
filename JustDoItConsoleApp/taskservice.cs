using System;
using System.Collections.Generic;
using System.Text;

namespace JustDoItConsoleApp
{
    class Taskservice
    {
        public static List<Task> taskArray = new List<Task>();
        int idIndex;
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
            taskArray.Add(task);

        }
        public void edit(string title, string priority, string deadline, int taskId)
        {
            foreach (Task t in taskArray)
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
            foreach (Task t in taskArray)
            {
                if (t.taskId == taskId)
                {
                    t.finished = true;
                }
            }
        }
        public bool delete(int taskId)
        {
            foreach (Task t in taskArray)
            {
                if (t.taskId == taskId)
                {
                    bool result = taskArray.Remove(t);
                    return result;
                }
                //zweite Möglichkeit ausserhalb der if schlaufe removen
            }
            return false;
        }

        enum Priority { 
            Low,
            Normal,
            High,
            Urgent
        }
    }
}
