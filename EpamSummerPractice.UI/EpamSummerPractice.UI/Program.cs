using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamSummerPractice.BLL.Interface;
using NinjectContainer;
using Ninject;

namespace EpamSummerPractice.UI
{
    class Program
    {
        private static IMedalsLogic medalLogic;
        private static IPeopleLogic personLogic;
        private static IRewardsLogic rewardLogic;

        static void Main(string[] args)
        {
            NinjectCommon.Registration();

            medalLogic = NinjectCommon.Kernel.Get<IMedalsLogic>();
            personLogic = NinjectCommon.Kernel.Get<IPeopleLogic>();
            rewardLogic = NinjectCommon.Kernel.Get<IRewardsLogic>();

            Start();

        }

        private static void Start()
        {
            Console.Clear();
            Console.WriteLine("Main menu: \n");
            Console.WriteLine("1. Add");
            Console.WriteLine("2. Update");
            Console.WriteLine("3. Delete");
            Console.WriteLine("4. Show");
            Console.WriteLine("5. Exit");

            Console.Write("\nChoose menu item ");

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    {

                        Add();
                        break;
                    }
                case ConsoleKey.D2:
                    {
                        Update();
                        break;
                    }
                case ConsoleKey.D3:
                    {
                        Delete();
                        break;
                    }
                case ConsoleKey.D4:
                    {
                        Show();
                        break;
                    }
                case ConsoleKey.D5:
                    {
                        Console.WriteLine("\n\n\nSee you\n");
                        return;
                    }
                default:
                    return;
            }
        }

        private static void Add()
        {
            Console.Clear();
            Console.WriteLine("Add menu: \n");
            Console.WriteLine("1. Add new person");
            Console.WriteLine("2. Add new medal");
            Console.WriteLine("3. Add new reward");
            Console.WriteLine("4. To main menu");

            Console.Write("\nChoose menu item ");

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    {
                        Console.WriteLine("\n");
                        Console.Write("Enter person's name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter person's surname: ");
                        string surname = Console.ReadLine();
                        Console.Write("Enter person's date of birth: ");
                        DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());
                        Console.Write("Enter person's age: ");
                        int age = int.Parse(Console.ReadLine());
                        Console.Write("Enter city of residence: ");
                        string city = Console.ReadLine();
                        Console.Write("Enter street's name: ");
                        string street = Console.ReadLine();
                        Console.Write("Enter house number: ");
                        string houseNumber = Console.ReadLine();

                        try
                        {
                            personLogic.Add(name, surname, dateOfBirth, age, city, street, houseNumber);
                            //personLogic.Add("Ivan", "Ivanov", new DateTime(1996, 12, 27), 30, "Saratov", "Chapaeva", "47a");
                        }
                        catch (ArgumentNullException nullEx)
                        {
                            Console.WriteLine($"\n{nullEx.Message}");
                            Console.WriteLine("Press any key for continue");
                            Console.ReadKey();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"\n{ex.Message}");
                            Console.WriteLine("Press any key for continue");
                            Console.ReadKey();
                        }

                        Start();
                        break;
                    }
                case ConsoleKey.D2:
                    {
                        Console.WriteLine("\n");
                        Console.Write("Enter medal's title: ");
                        string title = Console.ReadLine();
                        Console.Write("Enter medal's material: ");
                        string material = Console.ReadLine();


                        try
                        {
                            medalLogic.Add(title, material);
                            //medalLogic.Add("For summer practice", null);
                        }
                        catch (ArgumentNullException nullEx)
                        {
                            Console.WriteLine($"\n{nullEx.Message} \n ");
                            Console.WriteLine("Press any key for continue");
                            Console.ReadKey();
                        }

                        Start();
                        break;
                    }
                case ConsoleKey.D3:
                    {
                        Console.WriteLine("\n");

                        Console.Write("Enter person's ID: ");
                        int personID = int.Parse(Console.ReadLine());
                        Console.Write("Enter meadl's ID: ");
                        int medalID = int.Parse(Console.ReadLine());

                        try
                        {
                            rewardLogic.Add(personID, medalID);
                            //rewardLogic.Add(1, 1);
                        }
                        catch (ArgumentNullException nullEx)
                        {
                            Console.WriteLine($"\n{nullEx.Message} \n ");
                            Console.WriteLine("Press any key for continue");
                            Console.ReadKey();
                        }


                        Start();
                        break;
                    }
                case ConsoleKey.D4:
                    {
                        Start();
                        break;
                    }
                default:
                    return;
            }
        }

        private static void Update()
        {
            Console.Clear();
            Console.WriteLine("Update menu: \n");

            Console.WriteLine("1. Update person");
            Console.WriteLine("2. Update medal");
            Console.WriteLine("3. To main menu");

            Console.Write("\nChoose menu item ");

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    {
                        Console.WriteLine("\n");
                        Console.Write("Enter person's ID: ");
                        int personID = int.Parse(Console.ReadLine());
                        Console.Write("Enter person's name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter person's surname: ");
                        string surname = Console.ReadLine();
                        Console.Write("Enter person's date of birth: ");
                        DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());
                        Console.Write("Enter person's age: ");
                        int age = int.Parse(Console.ReadLine());
                        Console.Write("Enter city of residence: ");
                        string city = Console.ReadLine();
                        Console.Write("Enter street's name: ");
                        string street = Console.ReadLine();
                        Console.Write("Enter house number: ");
                        string houseNumber = Console.ReadLine();

                        try
                        {
                            personLogic.Update(personID, name, surname, dateOfBirth, age, city, street, houseNumber);
                            //personLogic.Update(6, "Vasya", "Ivanov", new DateTime(1996, 12, 27), 30, "Saratov", "Chapaeva", "47a");
                        }
                        catch (ArgumentNullException nullEx)
                        {
                            Console.WriteLine($"\n{nullEx.Message}");
                            Console.WriteLine("Press any key for continue");
                            Console.ReadKey();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"\n{ex.Message}");
                            Console.WriteLine("Press any key for continue");
                            Console.ReadKey();
                        }

                        Start();
                        break;
                    }
                case ConsoleKey.D2:
                    {
                        Console.WriteLine("\n");
                        Console.WriteLine("Enter medal's ID: ");
                        int medalID = int.Parse(Console.ReadLine());
                        Console.Write("Enter medal's title: ");
                        string title = Console.ReadLine();
                        Console.Write("Enter medal's material: ");
                        string material = Console.ReadLine();


                        try
                        {
                            medalLogic.Update(medalID, title, material);
                            //medalLogic.Add(1, "For summer practice", null);
                        }
                        catch (ArgumentNullException nullEx)
                        {
                            Console.WriteLine($"\n{nullEx.Message} \n ");
                            Console.WriteLine("Press any key for continue");
                            Console.ReadKey();
                        }

                        Start();
                        break;
                    }
                case ConsoleKey.D3:
                    {
                        Start();
                        break;
                    }
                default:
                    return;
            }
        }

        private static void Delete()

        {
            Console.Clear();

            Console.WriteLine("Delete menu: \n");

            Console.WriteLine("1. Delete person");
            Console.WriteLine("2. Delete medal");
            Console.WriteLine("3. Delete reward");
            Console.WriteLine("4. To main menu");

            Console.Write("\nChoose menu item ");

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    {
                        Console.WriteLine("\n");
                        Console.Write("Enter person's ID: ");
                        int personID = int.Parse(Console.ReadLine());

                        try
                        {
                            personLogic.Delete(personID);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"\n{ex.Message}");
                            Console.WriteLine("Press any key for continue");
                            Console.ReadKey();
                        }

                        Start();
                        break;
                    }
                case ConsoleKey.D2:
                    {

                        Console.WriteLine("\n");
                        Console.Write("Enter medal's ID: ");
                        int medalID = int.Parse(Console.ReadLine());

                        try
                        {
                            medalLogic.Delete(medalID);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"\n{ex.Message}");
                            Console.WriteLine("Press any key for continue");
                            Console.ReadKey();
                        }

                        Start();
                        break;
                    }
                case ConsoleKey.D3:
                    {

                        Console.WriteLine("\n");
                        Console.Write("Enter person's ID: ");
                        int personID = int.Parse(Console.ReadLine());
                        Console.Write("Enter medal's ID: ");
                        int medalID = int.Parse(Console.ReadLine());

                        try
                        {
                            rewardLogic.Delete(personID, medalID);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"\n{ex.Message}");
                            Console.WriteLine("Press any key for continue");
                            Console.ReadKey();
                        }

                        Start();
                        break;
                    }
                case ConsoleKey.D4:
                    {
                        Start();
                        break;
                    }
                default:
                    return;

            }
        }

        private static void Show()
        {
            Console.Clear();

            Console.WriteLine("Show menu: \n");

            Console.WriteLine("1. Show all people");
            Console.WriteLine("2. Show all medals");
            Console.WriteLine("3. Show all rewards");
            Console.WriteLine("4. Show person by ID");
            Console.WriteLine("5. Show medal by ID");
            Console.WriteLine("6. To main menu");

            Console.Write("\nChoose menu item ");

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    {
                        Console.WriteLine("\n");
                        var list = personLogic.GetAll();
                        if (list.Count() > 0)
                        {
                            foreach (var item in list)
                            {
                                Console.WriteLine($"{item.Id}: {item.Name} {item.Surname} {item.Age} {item.DateOfBirth} {item.City} {item.Street} {item.NumberOfHouse}");
                            }
                        }
                        else
                            Console.WriteLine($"This table is empty");

                        Console.WriteLine("\nPress any key for continue");
                        Console.ReadKey();

                        Start();
                        break;
                    }
                case ConsoleKey.D2:
                    {
                        Console.WriteLine("\n");

                        var list = medalLogic.GetAll();


                        if (list.Count() > 0)
                        {
                            foreach (var item in list)
                            {
                                Console.WriteLine($"{item.Id}: {item.Title} {item.Material}");
                            }
                        }
                        else
                            Console.WriteLine($"This table is empty");

                        Console.WriteLine("\nPress any key for continue");
                        Console.ReadKey();

                        Start();
                        break;
                    }
                case ConsoleKey.D3:
                    {
                        Console.WriteLine("\n");

                        var list = rewardLogic.GetAll();


                        if (list.Count() > 0)
                        {
                            foreach (var item in list)
                            {
                                Console.WriteLine(item);
                            }
                        }
                        else
                            Console.WriteLine($"This table is empty");

                        Console.WriteLine("\nPress any key for continue");
                        Console.ReadKey();

                        Start();
                        break;
                    }
                case ConsoleKey.D4:
                    {
                        Console.WriteLine("\n");
                        Console.Write("Enter person's ID: ");

                        var item = personLogic.ShowById(int.Parse(Console.ReadLine()));
                        if (item != null)
                        {

                            Console.WriteLine($"{item.Id}: {item.Name} {item.Surname} {item.Age} {item.DateOfBirth} {item.City} {item.Street} {item.NumberOfHouse}");

                        }
                        else
                            Console.WriteLine($"This person wasn't create or was deleted");

                        Console.WriteLine("\nPress any key for continue");
                        Console.ReadKey();

                        Start();
                        break;
                    }
                case ConsoleKey.D5:
                    {
                        Console.WriteLine("\n");
                        Console.Write("Enter medal's ID: ");

                        var item = medalLogic.ShowById(int.Parse(Console.ReadLine()));


                        if (item != null)
                        {
                            Console.WriteLine($"{item.Id}: {item.Title} {item.Material}");
                        }
                        else
                            Console.WriteLine($"This person wasn't create or was deleted");

                        Console.WriteLine("\nPress any key for continue");
                        Console.ReadKey();

                        Start();
                        break;
                    }
                case ConsoleKey.D6:
                    {
                        Start();
                        break;
                    }
                default:
                    return;

            }
        }
    }
}
