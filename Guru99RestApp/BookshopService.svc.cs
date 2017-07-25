using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

using System.Data.Entity;
using System.Data.SqlClient;
using Rest.Data;
using System.IO;
using System.Web.Script.Serialization;


namespace BranchService 
{
  
    [System.Web.Script.Services.ScriptService]
    public class BookshopService : IBookshopService 
    {

        public List<wsFullBookDescription> GetAllBooks()
        {
            var db = new BooksDataContext();
            List<wsFullBookDescription> results = new List<wsFullBookDescription>();

            var res = from bo in db.Books
                      //join ca in db.Categories on bo.Id_Category equals ca.Id
                      //join au in db.Authors on bo.Id_Author equals au.Id
                      select new { bo.Id, bo.Title, bo.Year, bo.Price, bo.Quantity, bo.Author.Name, bo.Author.Surname, bo.Author.Country, Category = bo.Category.Name };

            foreach (var b in res)
            {
                results.Add(new wsFullBookDescription()
                {
                    Id = b.Id,
                    Title = b.Title,
                    Name = b.Name,
                    Surname = b.Surname,
                    Country = b.Country,
                    Price = b.Price,
                    Year = b.Year,
                    Quantity = b.Quantity,
                    Category = b.Category,
                    //Id_Language = b.Id_Language
                });
            }
            return results;

        }


       public List<wsFullBookDescription> GetBooksbyCategory(string CategoryName)
        {
            List<wsFullBookDescription> results = new List<wsFullBookDescription>();
            BooksDataContext db = new BooksDataContext();
            //int pid;
            //Int32.TryParse(CategoryId, out pid);

            var Books = from p in db.Books
                         where p.Category.Name == CategoryName
                        //join c in db.Categories on p.Id_Category equals c.Id
                        select new { p.Id, p.Title, p.Price, p.Quantity, p.Year, Name = p.Author.Name, Surname = p.Author.Surname, Country = p.Author.Country, Category = p.Category.Name };

            foreach (var b in Books)
            {
                results.Add(new wsFullBookDescription()
                {
                    Id = b.Id,
                    Title = b.Title,
                    Name = b.Name,
                    Surname = b.Surname,
                    Country = b.Country,
                    Price = b.Price,
                    Year = b.Year,
                    Quantity = b.Quantity,
                    Category = b.Category,
                    //Id_Language = b.Id_Language
                });
            }

            return results;
        }

        public List<wsFullBookDescription> GetBooksbyAuthor(string AuthorSurname)
        {
            List<wsFullBookDescription> results = new List<wsFullBookDescription>();
            BooksDataContext db = new BooksDataContext();
           
            var Books = from p in db.Books
                        where p.Author.Surname == AuthorSurname
                        select new { p.Id, p.Title, p.Price, p.Quantity, p.Year, Name = p.Author.Name, Surname = p.Author.Surname, Country = p.Author.Country, Category = p.Category.Name };

            foreach (var b in Books)
            {
                results.Add(new wsFullBookDescription()
                {
                    Id = b.Id,
                    Title = b.Title,
                    Name = b.Name,
                    Surname = b.Surname,
                    Country = b.Country,
                    Price = b.Price,
                    Year = b.Year,
                    Quantity = b.Quantity,
                    Category = b.Category,
                    //Id_Language = b.Id_Language
                });
            }

            return results;
        }

        public wsFullBookDescription GetBook(string BookId)
        {
            wsFullBookDescription result = new wsFullBookDescription();
            BooksDataContext db = new BooksDataContext();
            int pid;
            Int32.TryParse(BookId, out pid);

            var book = from p in db.Books
                       where p.Id == pid
                       select new wsFullBookDescription { Id = p.Id, Title = p.Title, Price = p.Price, Quantity = p.Quantity, Year = p.Year, Name = p.Author.Name, Surname = p.Author.Surname, Country = p.Author.Country, Category = p.Category.Name };
            
                foreach (var verObj in book)
                {
                    result.Id = verObj.Id;
                    result.Name = verObj.Name;
                    result.Category = verObj.Category;
                    result.Title = verObj.Title;
                    result.Surname = verObj.Surname;
                    result.Country = verObj.Country;
                    result.Price = verObj.Price;
                    result.Year = verObj.Year;
                    result.Quantity = verObj.Quantity;
                }

            return result;
        }

        public void DeleteBook(string BookId)
        {
            BooksDataContext db = new BooksDataContext();
            int pid;
            Int32.TryParse(BookId, out pid);

            var book = from p in db.Books
                       where p.Id == pid
                       select p;
            db.Books.DeleteAllOnSubmit(book);
            db.SubmitChanges();
        }

        public int AddBook(Stream JSONdataStream)
        {            

            try
            {
                StreamReader reader = new StreamReader(JSONdataStream);
                string JSONdata = reader.ReadToEnd();

                JavaScriptSerializer jss = new JavaScriptSerializer();
                wsBook book = jss.Deserialize<wsBook>(JSONdata); // blad?
                if (book == null)
                {
                    return -2;
                }

                Book newBook = new Book();
                newBook.Id_Author = book.Id_Author;
                newBook.Id_Category = book.Id_Category;
                newBook.Id_Language = book.Id_Language;
                newBook.Price = book.Price;
                newBook.Quantity = book.Quantity;
                newBook.Year = book.Year;
                newBook.Title = book.Title;

                BooksDataContext db = new BooksDataContext();
                db.Books.InsertOnSubmit(newBook);
                db.SubmitChanges();

                return 0;     
            } catch (Exception)
            {
                return -1;
            }
        }




    }
}
