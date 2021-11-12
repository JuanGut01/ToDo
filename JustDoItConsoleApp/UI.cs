using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace JustDoItConsoleApp
{
    class UI
    {
        Taskservice service = new Taskservice();
        public TimeAPI time = new TimeAPI();
        private string Menu = @$"
          MENU
    -----------------------
    ¦   1.  Add Task        ¦
    ¦   2.  Delete Task     ¦
    ¦   3.  Complete Task   ¦
    ¦   4.  Edit Task       ¦
    ¦   5.  Exit            ¦
    -----------------------
";

        public void StartUi()
        {
            Console.Clear();
            time.getInfo();
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

                    if (Input == 1 || Input == 2 || Input == 3 || Input == 4 || Input == 5)
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
                    CompleteTask();
                    ReadInput();
                    break;

                case 4:
                    EditTask();
                    ReadInput();
                    break;

                case 5:
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
        public string CheckForDate()
        {
            string Input = null;
            string Pattern = @"^[0-3]\d\/[0-1]\d\/[2][0-9]{3}$";
            bool isDone = false;

            while (isDone == false)
            {
                try
                {
                    Input = Console.ReadLine();

                    if (Regex.IsMatch(Input, Pattern))
                    {
                        isDone = true;
                    }
                    else
                    {
                        Console.WriteLine("\n   Please enter a date using the following format: DD/MM/YYYY");
                    }
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("\n   Please enter a date using the following format: DD/MM/YYYY");
                    //CheckForPriority();
                    //Input = Convert.ToInt32(Console.ReadLine());
                    //throw er;
                }
            }

            return Input;


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
            Console.WriteLine("\n   Deadline: (DD/MM/YYYY)");
            string TaskDeadline = CheckForDate();



            service.add(TaskTitle, TaskPriority, TaskDeadline);

            ShowMenu();


        }
        public void DeleteTask() 
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
        public void CompleteTask()
        {
            Console.WriteLine("\n   Enter the ID of the task you want to mark as complete:");

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

            bool returned = service.complete(Input);
            ShowMenu();
            if (returned)
            {
                Console.WriteLine("\n    Task was marked as completed.");
            }
            else
            {
                Console.WriteLine("\n    Task was not marked as completed.");
            }

        }
        public void EditTask()
        {
            Console.WriteLine("\n   Enter the ID of the task you want to edit:");

            int TaskId = 0;
            bool isDone = false;
            string prevTitle = null;
            string prevPriority = null;
            string prevDeadline = null;


            while (isDone == false)
            {
                try
                {
                    TaskId = Convert.ToInt32(Console.ReadLine());

                    foreach (var item in Taskservice.taskArray)
                    {
                        if (item.taskId == TaskId)
                        {
                            isDone = true;
                            prevTitle = item.title;
                            prevPriority = item.priority;
                            prevDeadline = item.deadline;
                            
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

            string[] newData = GetEditInput(prevTitle, prevPriority, prevDeadline);

            service.edit(newData, TaskId);
            ShowMenu();
        }
        public string[] GetEditInput(string title, string prio, string dln)
        {
            Console.WriteLine($"\n   Enter a new title: (previously {title})");
            string newTitle = Console.ReadLine();

            Console.WriteLine($"\n   Select a new priority: (previously {prio})");
            Console.WriteLine(@"
    1.  Low
    2.  Normal
    3.  High
    4.  Urgent
");
            string newPriority = CheckForPriority();

            Console.WriteLine($"\n   Enter a new deadline (DD/MM/YYYY): (previously {dln})");
            string newDeadline = CheckForDate();


            string[] returnArray =
            {
                newTitle,
                newPriority,
                newDeadline
            };

            return returnArray;

        }
        public void ShowTasks(Taskservice service)
        {
            Console.WriteLine(@"    TODO LIST
    #########################################################################
    #
    #      Id       Title            Priority           Deadline               Status
    #-----------------------------------------------------------------------");

            foreach (var item in Taskservice.taskArray)
            {
                if (item.finished != true)
                {
                    Console.WriteLine(@$"    #
    #       {item.taskId}       {item.title}            {item.priority}             {item.deadline}             {GetStatus(item.finished)}
    #-   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   ");

                }

            }

            Console.WriteLine(@$"    #########################################################################
    ");
        }
        public string GetStatus(bool status)
        {
            if (status != true)
            {
                return "Working";
            }
            else
            {
                return "Complete";
            }
        }
    }
}
