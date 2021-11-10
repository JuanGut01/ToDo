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

            Console.WriteLine("\n   Choose a menu option:");
            while (isDone == false)
            {
                try
                {
                    Input = Convert.ToInt32(Console.ReadLine());

                    if (Input == 1 || Input == 2 || Input == 3)
                    {
                        isDone = true;
                    }
                    else
                    {
                        Console.WriteLine("\n   Please choose one of the options shown in the menu above:");
                    }
                }
                catch (System.FormatException er)
                {
                    Console.WriteLine("\n   Letters and special characters are not permitted. Please choose one of the options shown above.");
                    //Input = Convert.ToInt32(Console.ReadLine());
                    //throw er;
                }
            }

            switch (Input)
            {
                case 1:
                    AddTask();
                    ReadInput();
                    break;
                case 2:
                    DeleteTask();
                    ReadInput();
                    break;
                case 3:
                    break;
                default:
                    Console.WriteLine("\n   That option is incorrect, please try again");
                    ReadInput();
                    break;
            }
        }
        public void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine(Menu);
            ShowTasks(service);
            
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
                    }
                    else
                    {
                        Console.WriteLine("\n   Please choose one of the options shown above:");
                    }
                }
                catch (System.FormatException er)
                {
                    Console.WriteLine("\n   Please choose one of the options shown above:");
                    //CheckForPriority();
                    //Input = Convert.ToInt32(Console.ReadLine());
                    //throw er;
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
            Console.WriteLine("\n   Title:");
            string TaskTitle = Console.ReadLine();

            // priority
            Console.WriteLine("\n   Choose one of the following priorities:");
            Console.WriteLine(@"
    1.  Low
    2.  Normal
    3.  High
    4.  Urgent
");

            string TaskPriority = CheckForPriority();


            // title
            Console.WriteLine("\n   Deadline: (dd.mm.yyyy)");
            string TaskDeadline = Console.ReadLine();



            service.add(TaskTitle, TaskPriority, TaskDeadline);

            ShowMenu();
            //ShowTasks(service);


        }
        public void DeleteTask() //WIP
        {
            Console.WriteLine("\n   Enter the ID of the task you want to delete:");
            //int TaskId = Convert.ToInt32(Console.ReadLine());

            int Input = 0;
            bool isDone = false;

            while (isDone == false)
            {
                try
                {
                    Input = Convert.ToInt32(Console.ReadLine());

                    foreach (var item in Taskservice.taskArray)
                    {
                        if (item.taskId == Input)
                        {
                            isDone = true;
                        }
                    }

                    if (isDone == false)
                    {
                        Console.WriteLine($"\n   A task with this ID does not exist. Please enter one of the IDs shown above.");
                    }
                }
                catch (System.FormatException er)
                {
                    Console.WriteLine($"\n   A task with this ID does not exist. Please enter one of the IDs shown above.");
                    //Input = Convert.ToInt32(Console.ReadLine());
                    //throw er;
                }
            }

                bool returned = service.delete(Input);
                ShowMenu();
                //Console.WriteLine($"   The task with the id {Input} will now be deleted");
                if (returned)
                {
                    Console.WriteLine("\n    Task was deleted.");
                }
                else
                {
                    Console.WriteLine("\n    Task was not deleted.");
                }
        }

        public void ShowTasks(Taskservice service)
        {
            Console.WriteLine(@"    TODO LIST
    #########################################################################
    #
    #      Id                 Title            Priority                Deadline
    #-----------------------------------------------------------------------");

            foreach (var item in Taskservice.taskArray)
            {
                Console.WriteLine(@$"    #
    #       {item.taskId}               {item.title}            {item.priority}             {item.deadline}
    #-   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   ");
            }

            Console.WriteLine(@$"    #########################################################################
    ");
        }
    }
}
