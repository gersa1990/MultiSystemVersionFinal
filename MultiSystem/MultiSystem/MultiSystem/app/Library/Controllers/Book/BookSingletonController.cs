using System;

namespace MultiSystem.app.Library.Controllers
{
    
    public class BookSingletonController
    {
        private static BookSingletonController singleton;
        public bool isModifiedLoan { get; set; }
        public bool isModifiedForActions { get; set; }

        public BookSingletonController()
        {

        }

        public static BookSingletonController Singleton 
        {
            get 
            {
                if(singleton == null)
                {
                    singleton = new BookSingletonController();
                }
                return singleton;
            }
        }
    }
}
