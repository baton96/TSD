using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeLibrary
{
    public class Book : INotifyPropertyChanged
    {
        public static int counter = 6;
        public int Id { get; private set; }
        //public string Title { get; set; }
        //public string Author { get; set; }
        //public bool IsRead { get; set; }
        //public int Year { get; set; }
        //public BookFormat Format { get; set; }
        public Book(int id) { Id = id; }
        public Book() { Id = counter++; }
        private string title;
        public string Title
        {
            get => title;
            set
            {
                title = value;
                NotifyPropertyChanged("Title");
            }
        }

        private string author;
        public string Author
        {
            get => author;
            set
            {
                author = value;
                NotifyPropertyChanged("Author");
            }
        }

        private bool isRead;
        public bool IsRead
        {
            get => isRead;
            set
            {
                isRead = value;
                NotifyPropertyChanged("IsRead");
            }
        }

        private int year;
        public int Year
        {
            get => year;
            set
            {
                year = value;
                NotifyPropertyChanged("Year");
            }
        }

        //public readonly List<BookFormat> BookFormats = new List<BookFormat>(){ BookFormat.PaperBack, BookFormat.EBook };
        public static List<BookFormat> BookFormats = new List<BookFormat>() { BookFormat.PaperBack, BookFormat.EBook };
        public BookFormat format;
        public BookFormat Format
        {
            get => format;
            set
            {
                format = value;
                NotifyPropertyChanged("Format");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }

    public class Book2
    {
        public int Id { get; private set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public bool IsRead { get; set; }

        public int Year { get; set; }

        public BookFormat Format { get; set; }
        public Book2(int id)
        {
            Id = id;

        }
    }

    public enum BookFormat
    {
        PaperBack, EBook
    }

    public static class MyBookCollection
    {
        public static List<Book> GetMyCollection()
        {
            return new List<Book>()
            {
                new Book(1){ Author = "J.K. Rowling", Format = BookFormat.EBook, IsRead = true, Title = "Harry Potter and the Philosopher's Stone", Year=1997},

                new Book(2)
                {
                    Author = "J.K. Rowling", Format = BookFormat.EBook, IsRead = true, Title = "Harry Potter and the Chamber of Secrets",
                    Year = 1998
                },

                new Book(3){ Author = "J.K. Rowling", Format = BookFormat.PaperBack, IsRead = true, Title = "Harry Potter and the Prisoner of Azkaban", Year = 1999},

                new Book(4){ Author = "Jonathan Swift", Format = BookFormat.PaperBack, IsRead = false, Title = "Very Long Title", Year=1972},

                new Book(5){Author = "Wayne Thomas Batson", Format = BookFormat.EBook, IsRead = true, Title = "Isle of Swords", Year = 2007},

                new Book(5){Author = "Louis A. Meyer", Format = BookFormat.EBook, IsRead = true, Title = "Under the Jolly Roger", Year = 200},                
            };

        }
    }
}
