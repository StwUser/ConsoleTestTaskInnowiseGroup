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
    public class CollectionOfAuthors
    {
        static public List<string> AuthorsCollection = new List<string>();

        public CollectionOfAuthors()
        {

        }

        //Получить всех авторов
        static public void OutAllAuthors()
        {
            Console.WriteLine("Авторы:\n---------------");
            int n = 1;
            foreach (string st in AuthorsCollection)
            {
                Console.WriteLine($"{n}) {st}");
                ++n;
            }
        }

    }
}
