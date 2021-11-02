using System;
using System.Collections.Generic;
using System.Text;

namespace JustDoItConsoleApp
{
    class UI
    {

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
            int Input;

            try
            {
                Input = Convert.ToInt32(Console.ReadLine());
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Letters and special characters are not permitted. Please choose one of the numbers shown above.");
                Input = Convert.ToInt32(Console.ReadLine());
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
                    //Remove.Task()
                    Taskservice.delete();
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

    }
}
