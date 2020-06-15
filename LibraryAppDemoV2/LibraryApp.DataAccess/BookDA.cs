using LibraryApp.BusinessObjects.Entities;
using System.Collections.Generic;


namespace LibraryApp.DataAccess
{
    public class BookDA
    {
        public BookDA()
        {

        }
        public List<BookBO> GetBooks()
        {
            try
            {
                return new List<BookBO>();
            }
            catch
            {
                throw;
            }
        }
        public List<BookBO> Add(BookBO book, List<BookBO> books) // Data Access Layer 
        {
            try
            {
                books.Add(book);
                return books;
            }
            catch
            {
                throw;
            }
        }

        public List<BookBO> Update(BookBO book, List<BookBO> books)
        {
            try
            {
                int index = books.FindIndex(x => x.Id == book.Id);
                if (index > 0)
                    books[index] = book;
                return books;
            }
            catch
            {
                throw;
            }
        }

        public List<BookBO> DeleteById(int Id, List<BookBO> books)         {
            try
            {
                int index = books.FindIndex(x => x.Id == Id);
                books.RemoveAt(index);
                return books;
            }
            catch
            {
                throw;
            }
        }
    }
}
