using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQtoObject
{
  public class Book
  {
    public IEnumerable<Author> Authors {get; set;}
    public String Isbn {get; set;}
    public String Notes {get; set;}
    public Int32 PageCount {get; set;}
    public Decimal Price {get; set;}
    public DateTime PublicationDate {get; set;}
    public Publisher Publisher {get; set;}
		public IEnumerable<Review> Reviews {get; set;}
    public Subject Subject {get; set;}
    public String Summary {get; set;}
    public String Title {get; set;}
       public void FindBooksSorted(string publisherName, string sortingCriteria, string sortingWay)
        {
            var booksByPublisher = SampleData.Books
                .Where(b => b.Publisher.Name.Equals(publisherName, StringComparison.OrdinalIgnoreCase));

            var sortedBooks = booksByPublisher.AsQueryable();

            if (sortingCriteria == "Title")
            {
                sortedBooks = sortingWay == "ASC"
                    ? sortedBooks.OrderBy(b => b.Title)
                    : sortedBooks.OrderByDescending(b => b.Title);
            }
            else if (sortingCriteria == "Price")
            {
                sortedBooks = sortingWay == "ASC"
                    ? sortedBooks.OrderBy(b => b.Price)
                    : sortedBooks.OrderByDescending(b => b.Price);
            }

            foreach (var book in sortedBooks)
            {
                Console.WriteLine($"{book.Title} - {book.Price}");
            }
        }

        public override String ToString()
    {
      return Title;
    }
  }
}