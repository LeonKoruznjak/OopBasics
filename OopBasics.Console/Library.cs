
namespace OopBasics.Console
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Library
    {
        public List<Book> Books { get; private set; }
        public List<Member> Members { get; private set; }
        public List<Admin> Admins { get; private set; }

        public Library()
        {
            Books = new List<Book>();
            Members = new List<Member>();
            Admins = new List<Admin>();
        }

        
        public void AddBook(Book book)
        {
            Books.Add(book);
            Console.WriteLine($"Knjiga '{book.Title}' dodana u biblioteku.");
        }

        public void AddMember(Member member)
        {
            Members.Add(member);
            Console.WriteLine($"Član {member.Name} {member.Surname} je dodan.");
        }

       
        public void RemoveMember(Member member)
        {
            Members.Remove(member);
            Console.WriteLine($"Član {member.Name} {member.Surname} je izbrisan.");
        }

     
        public void RentBook(string title)
        {
            var book = Books.FirstOrDefault(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (book != null && book.RentBook())
            {
                Console.WriteLine($"Knjiga '{book.Title}' je iznajmljena!");
                Console.WriteLine($"Datum iznajmljivanja: {book.RentDate.Value.ToString("dd/MM/yyyy")}");
                Console.WriteLine($"Datum vraćanja: {book.ReturnDate.Value.ToString("dd/MM/yyyy")}");
            }
            else
            {
                Console.WriteLine("Knjiga nije dostupna.");
            }
        }

       
        public void ReturnBook(string title)
        {
            var book = Books.FirstOrDefault(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (book != null)
            {
                book.ReturnBook();
                Console.WriteLine($"Knjiga '{book.Title}' je vraćena!");
            }
            else
            {
                Console.WriteLine("Knjiga nije pronađena.");
            }
        }
    }
}