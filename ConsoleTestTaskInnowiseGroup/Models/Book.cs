using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestTaskInnowiseGroup.Models
{
    [Serializable]
    public class Book
    {
        public string BookName { get; set; }
        public int Year { get; set; }
        public List<string> Author { get; set; }

        public Book()
        {

        }

        public Book(string bookName, int year, List<string> author)
        {
            BookName = bookName;
            Author = author;
            Year = year; 
        }

        public void AddAuthor(string auth)
        {
            Author.Add(auth);
        }
    }
}
