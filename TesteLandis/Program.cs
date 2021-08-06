using System;
using TesteLandis.Business;
using TesteLandis.Business.Interface;

namespace TesteLandis
{
    class Program
    {
        static IEndpointBusiness _endPointBusiness = new EndpointBusiness();
        static bool on = true;
        static void Main(string[] args)
        {
            while (on)
            {
                try
                {
                    PrintMenu();
                }
                catch(Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine("An error happened: " + ex.Message + "\n\n\n");
                    PrintMenu();
                }
            }

        }

        private static void PrintMenu()
        {
            Console.WriteLine("System developed by Renan Romanio Alves Santos for Landis+Gyr's selection process - 2021.");
            Console.WriteLine("Insert an option:");
            Console.WriteLine("(1) - Insert a new endpoint");
            Console.WriteLine("(2) - Edit a existing endpoint");
            Console.WriteLine("(3) - Delete an existing endpoint");
            Console.WriteLine("(4) - List all endpoints");
            Console.WriteLine("(5) - Find a endpoint by \"Endpoint Serial Number\"");
            Console.WriteLine("(6) - Exit");
            var option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    _endPointBusiness.Insert();
                    break;
                case 2:
                    _endPointBusiness.Edit();
                    break;
                case 3:
                    _endPointBusiness.Remove();
                    break;
                case 4:
                    _endPointBusiness.List();
                    break;
                case 5:
                    _endPointBusiness.Find();
                    break;
                case 6:
                    ConfirmShutdown();
                    break;
            }
        }

        private static void ConfirmShutdown()
        {
            var response = "";
            Console.WriteLine("Do you really want to quit? - y/n");
            response = Console.ReadLine();
            if (response.Equals("y"))
                on = false;
            else if (!response.Equals("y") && !response.Equals("n"))
            {
                ConfirmShutdown();
            }
        }
    }
}
