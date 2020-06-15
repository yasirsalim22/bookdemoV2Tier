using LibraryApp.BusinessObjects.Entities;
using LibraryApp.DataAccess;
using System.Collections.Generic;
using System;

namespace LibraryApp.BusinessLogic
{
    public class BookBL
    {
        public BookBL()
        {

        }

        public List<BookBO> GetBooks()
        {
            try
            {
                BookDA bookDA = new BookDA();
                return bookDA.GetBooks();
            }
            catch
            {
                throw;
            }
        }
        public List<BookBO> Add(BookBO book, List<BookBO> books) // Data Access Layer // passing Bussiness object Here  
        {
            try
            {
                BookDA bookDA = new BookDA();
                // GetNextHighestBookId
                return bookDA.Add(book, books);
            }
            catch
            {
                throw;
            }
        }

        public List<BookBO> Update(BookBO book, List<BookBO> books) // passing Bussiness object Here    
        {
            try
            {
                BookDA bookDA = new BookDA();
                return bookDA.Update(book, books);
            }
            catch
            {
                throw;
            }
        }

        public List<BookBO> DeleteById(object Id, List<BookBO> books) // passing Bussiness object Here  
        {
            try
            {
                BookDA bookDA = new BookDA();
                return bookDA.DeleteById(Convert.ToInt32(Id), books);
            }
            catch
            {
                throw;
            }
        }
    }
}
