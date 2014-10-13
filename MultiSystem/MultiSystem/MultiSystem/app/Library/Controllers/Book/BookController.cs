using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiSystem.app.Library.Models;
using System.Windows;
using System.ComponentModel;

namespace MultiSystem.app.Library.Controllers
{
    public class BookController
    {
        private BookModel modelBook = new BookModel();
        private List<Dictionary<string, string>> resultOfQuerys;

        public BookController() 
        {
            resultOfQuerys = new List<Dictionary<string, string>>();
        }

        public int editBook(Dictionary<string, string> parameters, Dictionary<string, string> whereParameters) 
        {
            return modelBook.editBook(parameters, whereParameters);
        }
		
		public int executeRefundBook(Dictionary<string, string> parameters, Dictionary<string, string> whereParameters)
		{
			return modelBook.executeRefundBook(parameters, whereParameters);
		}

        public Book getBookById(Dictionary<string, string> parameter) 
        {
            
            List<Dictionary<string, string>> dictionaryBook = new List<Dictionary<string, string>>();
            dictionaryBook = modelBook.getBookById(parameter);
            Book book = new Book();
			
			

            foreach (var _book in dictionaryBook)
            {
                foreach(var item in _book)
                {
                    switch(item.Key)
                    {
                        case "idBook":
                            book.idBook = int.Parse( item.Value );
                        break;

                        case "nameBook":
                            book.nameBook = item.Value;
                        break;

                        case "author":
                            book.author = item.Value;
                        break;

                        case "editorial":
                            book.editorial = item.Value;
                        break;

                        case "edition":
                            book.edition = item.Value;
                        break;

                        case "pages":
                            book.pages = item.Value;
                        break;

                        case "ISBN":
                        book.ISBN = item.Value;
                        break;

                        case "idGenere":
                            book.idGenere = int.Parse( item.Value );
                        break;
                    }
                }
            }

            return book;
        }
        public int addBook(Dictionary<string, string> parameters)
        {
            int idInserted = modelBook.addBook(parameters);
            if ( idInserted != 0)
            {
                return idInserted;
            }
            else 
            {
                return 0;
            }
        }

        public List<LoanBook> getLoanedsBook(string date)
        {
            List<Dictionary<string, string>> dictionaryBook = new List<Dictionary<string, string>>();
            dictionaryBook = modelBook.getLoanedsBook(date);
            LoanBook book;

            List<LoanBook> listOfBooks = new List<LoanBook>();

            if (dictionaryBook == null) 
            {
                return null;
            }

            foreach(var token in dictionaryBook)
            {
                book = new LoanBook();
                foreach (var item in token) 
                {
                    switch(item.Key)
                    {
                        case "hashLoan":
                        book.hashLoan = item.Value;
                        break;

                        case "nameReader":
                        book.nameReader = item.Value;
                        break;

                        case "hourLoan":
                        book.hourLoan = item.Value;
                        break;

                        case "hourDeliveryLoan":
                        book.hourDeliveryLoan = item.Value;
                        break;

                        case "dateLoan":
                        book.dateLoan = item.Value;
                        break;

                        case "dateDeliveryLoan":
                        book.dateDeliveryLoan = item.Value;
                        break;

                        case "nameBook":
                        book.nameBook = item.Value;
                        break;
                            
                    }
                }
                listOfBooks.Add(book);
            }

            return listOfBooks;
			
        }

        public int addLoanBook(Dictionary<string,string> parameters) 
        {
           return modelBook.addLoanBook(parameters);
        }

        public List<LoanBook> getBorrowedBooks() 
        {
            List<LoanBook> listOfBooks = new List<LoanBook>();
            List<Dictionary<string, string>> data = new List<Dictionary<string, string>>();
			

            try
            {
                data = modelBook.getBooksOther();
            }
            catch 
            {
                MessageBox.Show("Error al tratar de obtener los resultados.");
            }

            LoanBook loans;
			
			if(data.Count<=0)
			{
				loans = new LoanBook();
				listOfBooks.Add(loans);
				return listOfBooks;
			}

            foreach (var items in data)
            {
                loans = new LoanBook();
                foreach (var row in items)
                {
                    switch (row.Key)
                    {
                        case "idLoan":
                            loans.idLoan = int.Parse(row.Value);
                        break;

                        case "idBook":
                        loans.idBook = int.Parse(row.Value);
                            break;

                        case "hashLoan":
                            loans.hashLoan = row.Value;
                            break;
							
						case "petitionDay":
							loans.petitionDay = row.Value;
						break;

                        case "nameReader":
                            loans.nameReader = row.Value;
                            break;

                        case "hourLoan":
                            loans.hourLoan = row.Value;
                            break;

                        case "hourDeliveryLoan":
                            loans.hourDeliveryLoan = row.Value;
                            break;

                        case "dateLoan":
                            loans.dateLoan = row.Value;
                            break;

                        case "dateDeliveryLoan":
                            loans.dateDeliveryLoan = row.Value;
                            break;

                        case "nameBook":
                            loans.nameBook = row.Value;
                        break;

                        case "ISBN":
                            loans.ISBN = row.Value;
                        break;
                    }
                }
                listOfBooks.Add(loans);
            }

           return listOfBooks;
        }

        public List<Book> getAllBooks() 
        {
            resultOfQuerys = null;
            List<Book> listOfBooks = new List<Book>();
            resultOfQuerys = modelBook.getAllBooks();
            Book book;

            foreach (var items in resultOfQuerys)
            {
                book = new Book();
                foreach (var row in items) 
                {
                    switch (row.Key) 
                    {
                        case "idBook":
                        book.idBook = int.Parse(row.Value);
                        break;

                        case "nameBook":
                        book.nameBook = row.Value;
                        break;

                        case "author":
                        book.author = row.Value;
                        break;

                        case "editorial":
                        book.editorial = row.Value;
                        break;

                        case "edition":
                        book.edition = row.Value;
                        break;

                        case "pages":
                        book.pages = row.Value;
                        break;

                        case "ISBN":
                        book.ISBN = row.Value;
                        break;
                    }
                }
                listOfBooks.Add(book);
            }

            return listOfBooks;
        }

        public string uniqid()
        {
            DateTime dateForButton = DateTime.Now;
            return dateForButton.Year.ToString() + ""+dateForButton.Month.ToString()+""+dateForButton.Minute.ToString()+""+dateForButton.Second.ToString();
        }

        public int deleteBook(int idBook)
        {
            Dictionary<string, string> whereParameters = new Dictionary<string, string>();
            whereParameters.Add("idBook", idBook+"");
            return modelBook.deleteBook(whereParameters);
        }
    }

    public class LoanBook 
    {
        public int          idLoan              { get; set; }
        public int          idBook              { get; set; }

        [DisplayName("Clave")]
        public string       hashLoan            { get; set; }
		
		[DisplayName("Día de préstamo")]
		public string 		petitionDay 		{ get; set; }

        [DisplayName("Lector")]
        public string       nameReader          { get; set; }

        [DisplayName("Hora préstamo")]
        public string       hourLoan            { get; set; }

        [DisplayName("Hora devolución ")]
        public string       hourDeliveryLoan    { get; set; }

        [DisplayName("Fecha préstamo")]
        public string       dateLoan            { get; set; }

        [DisplayName("Fecha devolución")]
        public string       dateDeliveryLoan    { get; set; }

        [DisplayName("Libro")]
        public string nameBook { get; set; }

        [DisplayName("ISBN")]
        public string ISBN { get; set; }
    }

    public class Book 
    {
        
        public int      idBook      { get; set; }

        [DisplayName("Nombre")]
        public string   nameBook    {get; set;  }
       
        [DisplayName("Autor")]
        public string   author      { get; set; }

        [DisplayName("Editorial")]
        public string   editorial   { get; set; }

        [DisplayName("Edición")]
        public string   edition     { get; set; }

        [DisplayName("Páginas")]
        public string   pages       { get; set; }

        [DisplayName("ISBN")]
        public string   ISBN        { get; set; }

        [DisplayName("Genero")]
        public int      idGenere    { get; set; }
		
    }

   
}
