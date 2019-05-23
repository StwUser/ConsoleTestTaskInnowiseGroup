using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ConsoleTestTaskInnowiseGroup.Models
{
    [Serializable]
    public static class CollectionOfBooks
    {
        static public List<Book> BookCollection = new List<Book>();


        //Добавить книгу в коллекцию
        public static void AddBookToCollection()
        {
            //Коллекция Авторов
            List<string> auth = new List<string>();


            //Название книги
            Console.WriteLine("Введите название книги");
            string bookName = null;
            do
            {
                bookName = Console.ReadLine();
                if (bookName.Length > 30)
                {
                    Console.WriteLine("Название книги не должно превышать 30 символов.");
                };
                
            }
            while (bookName.Length  > 30);

            // Год написания книги
            Console.WriteLine("Введите год написания книги");

            bool result = false;
            int correctYear = 0;
            do
            {
                
                result = int.TryParse(Console.ReadLine(), out int year);
                if (!result)
                {
                    Console.WriteLine("Вы ввели не число.");
                }
                correctYear = year;
            }
            while (!result);

            string no = null;
            do
            {
                Console.WriteLine("Введите фамилию автора");
                string authName = null;
                do
                {
                    authName = Console.ReadLine();
                    if (authName.Length > 20)
                    {
                        Console.WriteLine("Фамилия автора не должна превышать 20 символов.");
                    };
                }
                while (authName.Length > 20);
                Console.WriteLine(authName);
                
                auth.Add(authName);

                Console.WriteLine("Вы хотите добавить еще автора?\n \"у\" - Да, \"n\" - Нет");
                no = Console.ReadLine();
            }
            while (no != "n");

            // Создаем книгу через конструктор и передаем ей все наши параметры
            Book book = new Book(bookName, correctYear, auth);
            //Добавляем книгу в коллекцию книг
            CollectionOfBooks.BookCollection.Add(book);
            // Добавляем автора в коллекцию авторов
            foreach (string st in auth)
            {
                if (!CollectionOfAuthors.AuthorsCollection.Contains(st))
                {
                    CollectionOfAuthors.AuthorsCollection.Add(st);
                }
            }
        }

        //Вывести всю коллекцию книг
        public static void UotAllCollection()
        {
            int i = 1;
            Console.WriteLine("Коллекция книг:\n------------------");
            foreach(Book bk in CollectionOfBooks.BookCollection)
            {
                string auth = string.Join (",",bk.Author.ToArray());
                Console.WriteLine($"{i})Название книги: {bk.BookName}, год: {bk.Year}, автор(ы): {auth}.");
                ++i;
            }

        }

        //Вывести книги по номеру автора
        public static void GetAllBooksOfAuthor()
        {
            try
            {
                Console.WriteLine("Введите номер автора книги которого вы хотите найти:");
                bool result = false;
                int numb = -1;
                do
                {

                    result = int.TryParse(Console.ReadLine(), out int number);
                    if (!result)
                    {
                        Console.WriteLine("Вы ввели не число.");
                    }
                    numb = number;
                }
                while (!result);

                string auth = CollectionOfAuthors.AuthorsCollection[numb - 1].ToString();

                int i = 1;
                Console.WriteLine($"{auth}:\n-----------------------");
                foreach (Book bk in CollectionOfBooks.BookCollection)
                {
                    if (bk.Author.Contains(auth))
                    {
                        Console.WriteLine($"{i}){bk.BookName}");
                        ++i;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Удалить книгу по номеру
        public static void DeleteBookByNumber()
        {
            try
            {
                Console.WriteLine("Введите номер книги которую хотите удалить.");
                bool result = false;
                int numb = -1;
                do
                {

                    result = int.TryParse(Console.ReadLine(), out int number);
                    if (!result)
                    {
                        Console.WriteLine("Вы ввели не число.");
                    }
                    numb = number;
                }
                while (!result);

                CollectionOfBooks.BookCollection.RemoveAt(numb-1);
                Console.WriteLine($"Книга номер {numb} удалена.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Сохранить в файл всю коллекцию
        public static void SaveCollection()
        {
            try
            { 
                //Сохраняем книги
                XmlDocument xmlDocument = new XmlDocument();
                XmlSerializer serializer = new XmlSerializer(CollectionOfBooks.BookCollection.GetType());
                using (MemoryStream stream = new MemoryStream())
                {
                    serializer.Serialize(stream, CollectionOfBooks.BookCollection);
                    stream.Position = 0;
                    xmlDocument.Load(stream);
                    xmlDocument.Save("BooksCollection");
                    stream.Close();
                }
                //Сохраняем Авторов
                XmlDocument xmlDocument2 = new XmlDocument();
                XmlSerializer serializer2 = new XmlSerializer(CollectionOfAuthors.AuthorsCollection.GetType());
                using (MemoryStream stream2 = new MemoryStream())
                {
                    serializer2.Serialize(stream2, CollectionOfAuthors.AuthorsCollection);
                    stream2.Position = 0;
                    xmlDocument2.Load(stream2);
                    xmlDocument2.Save("AuthorsCollection");
                    stream2.Close();
                }

                Console.WriteLine("Коллекция сохранена.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
