using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopBasics.Console
{
    public class Book
    {
        public String Title { get; set; }
        public String Author { get; set; }

        public int Quantity { get; set; }

        public DateTime? RentDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        public Book (string title, string author, int quantity, DateTime? rentDate=null, DateTime? returnDate = null)
        {
            Title = title;
            Author = author;
            Quantity = quantity;
            RentDate = rentDate;
            ReturnDate = returnDate;
        }


        public bool RentBook()
        {
            if (Quantity > 0)
            {
                Quantity--;
                RentDate = DateTime.Now;
                ReturnDate = RentDate.Value.AddDays(14);
                return true;
            }
            return false;
        }


        public void ReturnBook()
        {
            Quantity++;
            RentDate = null;
            ReturnDate = null;
        }

    }
}
