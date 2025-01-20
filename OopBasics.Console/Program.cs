using OopBasics.Console;
using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Library library = new Library();

        
        Admin admin = new Admin("Leon", "Koružnjak", "šifra123");
        library.Admins.Add(admin);

        Member member1 = new Member("Marko", "Markic");
        library.Members.Add(member1);

        
        Book book1 = new Book("Gospodar prstenova", "J.R.R. Tolkien", 5);
        Book book2 = new Book("Hobit", "J.R.R. Tolkien", 3);
        library.Books.Add(book1);
        library.Books.Add(book2);

        Person currentUser = null;

      
        Console.WriteLine("Unesite ime:");
        string name = Console.ReadLine();
        Console.WriteLine("Unesite prezime:");
        string surname = Console.ReadLine();

        Console.WriteLine("Jeste li administrator? Da/Ne");
        string isAdmin = Console.ReadLine();

        if (isAdmin.ToLower() == "da")
        {
            Console.WriteLine("Unesite lozinku:");
            string password = Console.ReadLine();

            if (admin.Password == password)
            {
                currentUser = admin;
                Console.WriteLine("Dobrodošli administrator!");
            }
            else
            {
                Console.WriteLine("Neispravna lozinka.");
                return;
            }
        }
        else
        {
            currentUser = library.Members.FirstOrDefault(m => m.Name == name && m.Surname == surname);
            if (currentUser == null)
            {
                Console.WriteLine("Član nije pronađen.");
                return;
            }
            Console.WriteLine("Dobrodošli!");
        }

      
        while (currentUser != null)
        {
            if (currentUser is Admin)
            {
                ShowAdminMenu(library);
            }
            else if (currentUser is Member)
            {
                ShowMemberMenu(library);
            }
        }
    }

    
    static void ShowMemberMenu(Library library)
    {
        Console.Clear();
        Console.WriteLine("1. Pogledaj sve knjige");
        Console.WriteLine("2. Iznajmi knjigu");
        Console.WriteLine("3. Vrati knjigu");
        Console.WriteLine("0. Izlaz");
        Console.WriteLine("Odaberite opciju:");

        string choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                ViewBooks(library);
                break;
            case "2":
                RentBook(library);
                break;
            case "3":
                ReturnBook(library);
                break;
            case "0":
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Nepoznata opcija. Pokušajte ponovo.");
                break;
        }
    }

    static void ShowAdminMenu(Library library)
    {
        Console.Clear();
        Console.WriteLine("1. Pogledaj sve knjige");
        Console.WriteLine("2. Iznajmi knjigu");
        Console.WriteLine("3. Vrati knjigu");
        Console.WriteLine("4. Dodaj novog člana");
        Console.WriteLine("5. Dodaj novu knjigu");
        Console.WriteLine("6. Izbriši člana");
        Console.WriteLine("7. Prikaz svih članova");
        Console.WriteLine("0. Izlaz");
        Console.WriteLine("Odaberite opciju:");

        string choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                ViewBooks(library);
                break;
            case "2":
                RentBook(library);
                break;
            case "3":
                ReturnBook(library);
                break;
            case "4":
                AddMember(library);
                break;
            case "5":
                AddBook(library);
                break;
            case "6":
                RemoveMember(library);
                break;
            case "7":
                ShowAllMembers(library);
                break;
            case "0":
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Nepoznata opcija. Pokušajte ponovo.");
                break;
        }
    }

  
    static void ViewBooks(Library library)
    {
        Console.Clear();
        Console.WriteLine("Knjige u biblioteci:");
        foreach (var book in library.Books)
        {
            Console.WriteLine($"{book.Title} - Autor: {book.Author} - Dostupno: {book.Quantity}");
        }
        Console.WriteLine("Pritisnite bilo koju tipku za povratak u meni...");
        Console.ReadKey();
    }

    static void RentBook(Library library)
    {
        Console.WriteLine("Unesite naziv knjige za iznajmljivanje:");
        string title = Console.ReadLine();
        library.RentBook(title);
        Console.WriteLine("Pritisnite bilo koju tipku za povratak u meni...");
        Console.ReadKey();
    }

    static void ReturnBook(Library library)
    {
        Console.WriteLine("Unesite naziv knjige za vraćanje:");
        string title = Console.ReadLine();
        library.ReturnBook(title);
        Console.WriteLine("Pritisnite bilo koju tipku za povratak u meni...");
        Console.ReadKey();
    }

   
    static void AddMember(Library library)
    {
        Console.WriteLine("Unesite ime člana:");
        string name = Console.ReadLine();
        Console.WriteLine("Unesite prezime člana:");
        string surname = Console.ReadLine();
        Member newMember = new Member(name, surname);
        library.AddMember(newMember);
        Console.WriteLine("Pritisnite bilo koju tipku za povratak u meni...");
        Console.ReadKey();
    }

   
    static void AddBook(Library library)
    {
        Console.WriteLine("Unesite naziv knjige:");
        string title = Console.ReadLine();
        Console.WriteLine("Unesite autora knjige:");
        string author = Console.ReadLine();
        Console.WriteLine("Unesite količinu knjiga:");
        int quantity = int.Parse(Console.ReadLine());
        Book newBook = new Book(title, author, quantity);
        library.AddBook(newBook);
        Console.WriteLine("Pritisnite bilo koju tipku za povratak u meni...");
        Console.ReadKey();
    }


    static void RemoveMember(Library library)
    {
        Console.WriteLine("Unesite ime člana za brisanje:");
        string name = Console.ReadLine();
        Console.WriteLine("Unesite prezime člana za brisanje:");
        string surname = Console.ReadLine();
        var member = library.Members.FirstOrDefault(m => m.Name == name && m.Surname == surname);
        if (member != null)
        {
            library.RemoveMember(member);
        }
        else
        {
            Console.WriteLine("Član nije pronađen.");
        }
        Console.WriteLine("Pritisnite bilo koju tipku za povratak u meni...");
        Console.ReadKey();
    }

   
    static void ShowAllMembers(Library library)
    {
        Console.Clear();
        Console.WriteLine("Članovi biblioteke:");
        foreach (var member in library.Members)
        {
            Console.WriteLine($"{member.Name} {member.Surname}");
        }
        Console.WriteLine("Pritisnite bilo koju tipku za povratak u meni...");
        Console.ReadKey();
    }
}
