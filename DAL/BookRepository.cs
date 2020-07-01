using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EF_Example.Models;

namespace EF_Example.DAL
{
    public class BookRepository : IBookRepository
    {
        private BookContext _context;

        public BookRepository(BookContext bookContext)
        {
            _context = bookContext;
        }
        public void DeleteBook(int bookId)
        {
            Book book=_context.Books.Find(bookId);
            _context.Books.Remove(book);
        }

        public Book GetBookById(int bookId)
        {
            return _context.Books.Find(bookId);
        }

        public IEnumerable<Book> GetBooks()
        {
            return _context.Books.ToList();
        }

        public void InsertBook(Book book)
        {
            _context.Books.Add(book);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateBook(Book book)
        {
            _context.Entry(book).State = System.Data.Entity.EntityState.Modified;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}