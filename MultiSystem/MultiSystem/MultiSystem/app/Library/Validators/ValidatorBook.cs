using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.ComponentModel;

namespace MultiSystem.app.Library.Validators
{
	public class ValidatorBook : IDataErrorInfo
	{
		#region Getters and Setters
		public int idBook  {get; set;}

        [DisplayName("ISBN del libro")]
        public string ISBN { get; set; }

		[DisplayName("Nombre del libro")]
		public string NameBook {get; set;}
		
		[DisplayName("Autor del libro")]
		public string AuthorBook {get; set;}
		
		[DisplayName("Editorial del libro")]
		public string EditorialBook {get; set;}
		
		
		[DisplayName("Edición del libro")]
		public string EditionBook {get; set;}
		
		[DisplayName("Páginas del libro")]
		public int NumberPagesBook {get; set;}
		
		#endregion
		
		public ValidatorBook()
		{
			// Insert code required on object creation below this point.
		}
		
		public ValidatorBook(string nameBook, string ISBN, string authorBook, string editorialBook, string editionBook, int pagesBook)
		{
			this.NameBook 			= nameBook;
			this.AuthorBook 		= authorBook;
			this.EditorialBook  	= editorialBook;
			this.EditionBook 		= editionBook;
			this.NumberPagesBook 	= pagesBook;
            this.ISBN = ISBN;
		}
		
		#region IDataErrorInfo Members
		
		public string Error {
            get { throw new NotImplementedException(); }
        }
		
		public string this[string columnName] {
            get {
                string result = null;
                if (columnName == "NameBook") {
                    if (string.IsNullOrEmpty(NameBook))
                        result = "Nombre invalido";
                }
				
				if (columnName == "EditionBook") {
                    if (string.IsNullOrEmpty(EditionBook))
                        result = "Nombre invalido";
                }
                if (columnName == "ISBN")
                {
                    if (string.IsNullOrEmpty(ISBN))
                        result = "ISBN invalido";
                }
				
				if (columnName == "AuthorBook") {
                    if (string.IsNullOrEmpty(AuthorBook))
                        result = "Autor invalido";
                }
				if (columnName == "EditorialBook") {
                    if (string.IsNullOrEmpty(EditorialBook))
                        result = "Editorial invalido";
                }
				if (columnName == "PagesBook") {
                    if (NumberPagesBook <= 0)
                        result = "Número de páginas invalido";
                }

                return result;
            }
        }
		#endregion
	}
}