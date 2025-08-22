namespace Task4
{
    class Book
    {
        string Title;
        string Author;
        string ISBN;
        bool Availability;
        public Book(string title, string author, string ISBN)
        {
            this.Title = title;
            this.Author = author;
            this.ISBN = ISBN;
            this.Availability = true;
        }
        public string GetTitle()
        {
            return Title;
        }
        public void SetTitle(string title)
        {
            this.Title = title;
        }
        public string GetAuthor()
        {
            return Author;
        }
        public void SetAuthor(string author)
        {
            this.Author = author;
        }
        public string GetISBN()
        {
            return ISBN;
        }
        public void SetISBN(string isbn)
        {
            this.ISBN = isbn;
        }
        public bool GetAvailability()
        {
            return Availability;
        }
        public void SetAvailability(bool availability)
        {
            this.Availability = availability;
        }
    }

    class Library
    {
        List<Book> books = new List<Book>();
        public void AddBook(Book book)
        {
            books.Add(book);
            Console.WriteLine("Book  is added  " + book.GetTitle());
        }
        public bool SearchBook(string keyword)
        {

            for (int i = 0; i < books.Count; i++)
            {
                Book book = books[i];
                if (book.GetTitle().ToLower().Contains(keyword.ToLower()) || book.GetAuthor().ToLower().Contains(keyword.ToLower()))
                    return true;

            }

            return false;
        }
        public bool BorrowBook(string title)
        {
            for (int i = 0; i < books.Count; i++)
            {
                Book book = books[i];
                if (book.GetTitle().ToLower() == title.ToLower() && book.GetAvailability())
                {
                    book.SetAvailability(false);

                    return true;
                }
            }
            return false;
        }
        public bool ReturnBook(string title)
        {
            for (int i = 0; i < books.Count; i++)
            {
                Book book = books[i];
                if (book.GetTitle().ToLower() == title.ToLower() && !book.GetAvailability())
                {
                    book.SetAvailability(true);
                    return true;
                }
            }
            return false;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            Library library = new Library();

            // Adding books to the library
            library.AddBook(new Book("The Great Gatsby", "F. Scott Fitzgerald", "9780743273565"));
            library.AddBook(new Book("To Kill a Mockingbird", "Harper Lee", "9780061120084"));
            library.AddBook(new Book("1984", "George Orwell", "9780451524935"));

            // Searching and borrowing books
            Console.WriteLine("Searching and borrowing books...\n");
            Console.WriteLine(library.BorrowBook("Gatsby"));
            Console.WriteLine(library.BorrowBook("1984"));
            Console.WriteLine(library.BorrowBook("Harry Potter")); // Not in library

            // Returning books
            Console.WriteLine("\nReturning books...\n");
            Console.WriteLine(library.ReturnBook("Gatsby"));
            Console.WriteLine(library.ReturnBook("1984"));

            Console.ReadLine();
        }
    }
}