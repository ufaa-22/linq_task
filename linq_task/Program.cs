using LINQtoObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linq_task
{
    internal class Program
    {
       

        static void Main(string[] args)
        {
            var booksTitleAndISBN = SampleData.Books.Select(b => new { b.Title, b.Isbn });
            foreach(var book in booksTitleAndISBN)
            {
                Console.WriteLine(book.Title, book.Isbn);
            }
            Console.WriteLine("---------------------------------------------------------");
            var firstThreeExpensiveBooks = SampleData.Books
                .Where(b => b.Price > 25)
                .Take(3);
            foreach(var book in firstThreeExpensiveBooks) { Console.WriteLine(book.Title); }
            Console.WriteLine("---------------------------------------------------------");

            var bookWithPublisher1 = SampleData.Books
            .Select(b => new { b.Title, PublisherName = b.Publisher.Name });
            foreach (var item in bookWithPublisher1)
            {
                Console.WriteLine($"{item.Title} - {item.PublisherName}");
            }

            Console.WriteLine("---------------------------------------------------------");
            var numberOfBooksOver20 = SampleData.Books.Count(b => b.Price > 20);
            Console.WriteLine(numberOfBooksOver20);
            Console.WriteLine("---------------------------------------------------------");
            var sortedBooks = SampleData.Books
            .OrderBy(b => b.Subject.Name)
            .ThenByDescending(b => b.Price)
            .Select(b => new { b.Title, b.Price, SubjectName = b.Subject.Name });
            foreach(var item in sortedBooks) { Console.WriteLine($"{item.Title}-{item.Price}-{item.SubjectName}"); }
            Console.WriteLine("---------------------------------------------------------");
            var booksBySubject1 = SampleData.Books
             .GroupBy(b => b.Subject.Name)
             .Select(g => new { SubjectName = g.Key, Books = g.ToList() });
            foreach (var subject in booksBySubject1)
            {
                Console.WriteLine($"Subject: {subject.SubjectName}");
                foreach (var book in subject.Books)
                {
                    Console.WriteLine($"\tBook Title: {book.Title}");
                }
            }
            Console.WriteLine("---------------------------------------------------------");
            var booksBySubject2 = from subject in SampleData.Subjects
                                  select new
                                  {
                                      SubjectName = subject.Name,
                                      Books = SampleData.Books.Where(b => b.Subject == subject).ToList()
                                  };
            foreach (var subject in booksBySubject2)
            {
                Console.WriteLine($"Subject: {subject.SubjectName}");
                foreach (var book in subject.Books)
                {
                    Console.WriteLine($"\tBook Title: {book.Title}");
                }
            }
            Console.WriteLine("---------------------------------------------------------");
            var booksFromFunction = SampleData.GetBooks();
            foreach (var book in booksFromFunction) { Console.WriteLine(book); }
            var groupedBooks = SampleData.Books
             .GroupBy(b => new { PublisherName = b.Publisher.Name, SubjectName = b.Subject.Name })
             .Select(g => new
             {
                 g.Key.PublisherName,
                 g.Key.SubjectName,
                Books = g.ToList()
             });
            foreach (var group in groupedBooks)
            {
                Console.WriteLine($"Publisher: {group.PublisherName}, Subject: {group.SubjectName}");

                foreach (var book in group.Books)
                {
                    Console.WriteLine($"\tBook Title: {book.Title}, Price: {book.Price}");
                }
            }
            Console.WriteLine("---------------------------------------------------------");
            Book book1 = new Book();
            book1.FindBooksSorted("FunBooks", "Price", "ASC");
















            Console.ReadKey();

        }
    }
}
