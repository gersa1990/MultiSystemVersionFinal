using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiSystem.core.DB;

namespace MultiSystem.app.Library.Models
{
    class BookModel : IDatabase
    {
        public int addBook(Dictionary<string, string> parameters) 
        {
            return this.db.Insert("bookStore", "books", parameters);
        }

        public List<Dictionary<string, string>> getAllBooks() 
        {
            return this.db.Select("bookStore", "books").resultArray();
        }

        public int addLoanBook(Dictionary<string, string> parameters) 
        {
            return this.db.Insert("bookStore", "loansbook", parameters);
        }

        public List<Dictionary<string, string>> getBookById(Dictionary<string, string> parameter) 
        {
            return this.db.Select_where("bookStore", "books", parameter).rowArray();
        }

        internal int editBook(Dictionary<string, string> parameters, Dictionary<string, string> whereParameters)
        {
            return this.db.Update("bookStore", "books", parameters, whereParameters);
        }

        public int deleteBook(Dictionary<string, string> idBook)
        {
            return this.db.Delete("bookStore","books",idBook);
        }

        public List<Dictionary<string, string>> getBooksOther()
        {
            return this.db.Query("bookStore", "SELECT * FROM loansbook INNER JOIN books ON loansbook.idBook = books.idBook  WHERE loansbook.hourDeliveryLoan = '00:00' OR (loansbook.dateDeliveryLoan = '0000-00-00' AND loansbook.dateLoan != '0000-00-00'  )  ").resultArray();
        }
		
		public int executeRefundBook(Dictionary<string, string> parameters, Dictionary<string, string> whereParameters)
		{
			return this.db.Update("bookStore", "loansbook", parameters, whereParameters);
		}

        public List<Dictionary<string, string>> getLoanedsBook(string dateFromQuery)
        {
            return this.db.Query("bookStore", "SELECT * FROM loansbook INNER JOIN books ON loansbook.idBook = books.idBook  WHERE loansbook.petitionDay = '"+dateFromQuery+"' ").resultArray();
        }
    }
}
