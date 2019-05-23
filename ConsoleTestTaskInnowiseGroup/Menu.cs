using ConsoleTestTaskInnowiseGroup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestTaskInnowiseGroup
{
    public class Menu
    {

        String[] MenuItem = new String[]
        {
      "Добавить книгу в коллекцию.",
      "Вывести на экран всех авторов.",
      "Вывести всю коллекцию книг на экран.",
      "По введенному номеру автора из списка, вывести все книги автора.",
      "Удалить книгу по номеру.",
      "Сохранить коллекцию."

        };

        short MenuNumber;
        short NItem;
        ConsoleKeyInfo NN;

        String Header = "Программа для создания коллекции книг:";
        String Footer = "Нажмите 'ESC' для 'Выхода'";

        public Menu()
        {
            MenuNumber = Convert.ToInt16(MenuItem.Length);
            NItem = 0;
        }

        private void PrintMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Header + "\n");

            Console.ForegroundColor = ConsoleColor.Gray;

            for (int i = 0; i < MenuNumber; i++)
            {
                if (i == NItem) Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("{0}. {1}", i + 1, MenuItem[i]);
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n" + Footer + "\n");
            Console.ForegroundColor = ConsoleColor.Gray;   //смена цвета шрифта в моих подменю
        }

        public void SwitchMenu()
        {
            PrintMenu();
            NN = Console.ReadKey();

            switch (NN.Key)
            {
                case ConsoleKey.Escape:
                    return;
                case ConsoleKey.Enter:
                    SwitchTask();
                    break;
                case ConsoleKey.UpArrow:
                    if (NItem > 0) NItem--;
                    else NItem = Convert.ToInt16(MenuNumber - 1);
                    SwitchMenu();
                    break;
                case ConsoleKey.DownArrow:
                    if (NItem < MenuNumber - 1) NItem++;
                    else NItem = 0;
                    SwitchMenu();
                    break;
                default: SwitchMenu(); break;
            }
        }

        private void SwitchTask()
        {

            switch (NItem)
            {
                case 0:
                    Console.Clear();
                    CollectionOfBooks.AddBookToCollection();
                    break;
                case 1:
                    Console.Clear();
                    CollectionOfAuthors.OutAllAuthors();
                    break;
                case 2:
                    Console.Clear();
                    CollectionOfBooks.UotAllCollection();
                    break;
                case 3:
                    Console.Clear();
                    CollectionOfBooks.GetAllBooksOfAuthor();
                    break;
                case 4:
                    Console.Clear();
                    CollectionOfBooks.DeleteBookByNumber();
                    break;
                case 5:
                    Console.Clear();
                    CollectionOfBooks.SaveCollection();
                    break;

            }
        }
    }
}
