using System;
using System.Collections.Generic;
using System.Text;

namespace JustDoItConsoleApp
{
    class UI
    {
        Taskservice service = new Taskservice();
        private TimeAPI time = new TimeAPI();
        private string Menu = @"
          MENU
 -----------------------
¦   1.  Add Task        ¦
¦   2.  Delete Task     ¦
¦   3.  Exit            ¦
 -----------------------
";

        public void StartUi()
        {
            Console.Clear();
            ShowMenu();
            ReadInput();
        }
        public void ReadInput()
        {
            int Input = 0;
            bool isDone = false;

            while (isDone == false)
            {
                try
                {
                    Input = Convert.ToInt32(Console.ReadLine());

                    if (Input == 1 || Input == 2 || Input == 3)
                    {
                        isDone = true;
                    }
                }
                catch (System.FormatException er)
                {
                    Console.WriteLine("Letters and special characters are not permitted. Please choose one of the numbers shown above.");
                    //Input = Convert.ToInt32(Console.ReadLine());
                    throw er;
                }
            }

            switch (Input)
            {
                case 1:
                    AddTask();
                    ReadInput();
                    break;
                case 2:
                    Console.WriteLine("\nRemove task clicked");
                    //Delete.Task()
                    ReadInput();
                    break;
                case 3:
                    break;
                default:
                    Console.WriteLine("\nThat option is incorrect, please try again");
                    ReadInput();
                    break;
            }
        }
        public void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine(Menu);
        }
        public string CheckForPriority() 
        {
            int Input = 0;
            bool isDone = false;
            string TaskPriority;

            while (isDone == false)
            {
                try
                {
                    Input = Convert.ToInt32(Console.ReadLine());

                    if (Input == 1 || Input == 2 || Input == 3 || Input == 4)
                    {
                        isDone = true;
                    } else
                    {
                        Console.WriteLine("Please choose one of the options shown above:");
                    }
                }
                catch (System.FormatException er)
                {
                    CheckForPriority();
                    //Input = Convert.ToInt32(Console.ReadLine());
                    throw er;
                }
            }

            switch (Input)
            {
                case 1:
                    TaskPriority = "Low";
                    return TaskPriority; 
                case 2:
                    TaskPriority = "Normal";
                    return TaskPriority;
                case 3:
                    TaskPriority = "High";
                    return TaskPriority;
                case 4:
                    TaskPriority = "Urgent";
                    return TaskPriority;
                default:
                    return null;
            }
            
        }
        public void AddTask()
        {
            // title
            Console.WriteLine("\nTitle:");
            string TaskTitle = Console.ReadLine();

            // priority
            Console.WriteLine("\nChoose one of the following priorities:");
            Console.WriteLine(@"\n
1.  Low
2.  Normal
3.  High
4.  Urgent
");

            string TaskPriority = CheckForPriority();


            // title
            Console.WriteLine("\nDeadline: (dd.mm.yyyy)");
            string TaskDeadline = Console.ReadLine();



            service.add(TaskTitle, TaskPriority, TaskDeadline);

            ShowMenu();
            ShowTasks(service);


        }
        public void DeleteTask() //WIP
        {
            Console.WriteLine("\nEnter the ID of the task you want to delete:");
            int TaskId = Convert.ToInt32(Console.ReadLine());
        }

        public void ShowTasks(Taskservice service)
        {
            Console.WriteLine(@"
#########################################################

    Id                 Title            Priority                Deadline
-----------------------------------------------------------------------
");

            foreach (var item in Taskservice.taskArray)
            {
                Console.WriteLine(@$"       {item.taskId}               {item.title}            {item.priority}             {item.deadline}
-   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   
");
            }
        }
    }
}
