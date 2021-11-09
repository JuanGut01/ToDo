using System;
using System.Collections.Generic;
using System.Text;

namespace JustDoItConsoleApp
{
    class UI
    {
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
            time.getInfo();
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
                    Console.WriteLine("\nAdd task clicked");
                    //Add.Task()
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
            Console.WriteLine(Menu);
        }
        public void AddTask()
        {
            Console.WriteLine("\nTitle:");
            string TaskTitle = Console.ReadLine();
            Console.WriteLine("\nPriority:");
            Console.WriteLine("\nTitle:");
        }
        public void DeleteTask() //WIP
        {
            Console.WriteLine("\nEnter the ID of the task you want to delete:");
            int TaskId = Convert.ToInt32(Console.ReadLine());
        }
    }
}
