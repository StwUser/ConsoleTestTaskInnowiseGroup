using ConsoleTestTaskInnowiseGroup.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace ConsoleTestTaskInnowiseGroup
{
    class Program
    {
        static void Main(string[] args)
        {

            try  //Тело проверок на ошибки
            {
                //Загружаем Коллекцию книг
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load("BooksCollection");
                string xmlString = xmlDocument.OuterXml;

                using (StringReader read = new StringReader(xmlString))
                {

                    XmlSerializer serializer = new XmlSerializer(CollectionOfBooks.BookCollection.GetType());
                    using (XmlReader reader = new XmlTextReader(read))
                    {
                        CollectionOfBooks.BookCollection = (List<Book>)serializer.Deserialize(reader);
                        reader.Close();
                    }

                    read.Close();
                }

                //Загружаем Коллекцию авторов
                foreach (var bk in CollectionOfBooks.BookCollection)
                {
                    foreach (string name in bk.Author)
                    {
                        if (!CollectionOfAuthors.AuthorsCollection.Contains(name))
                        {
                            CollectionOfAuthors.AuthorsCollection.Add(name);
                        }
                    }
                }

                // Начало Меню
                Menu MMenu = new Menu();
                ConsoleKeyInfo key;
                do
                {
                    MMenu.SwitchMenu();
                    key = Console.ReadKey();
                    Console.WriteLine(key.Key + " клавиша была нажата");
                }
                while (key.Key != ConsoleKey.Escape); // по нажатию на Escape завершаем цикл
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
