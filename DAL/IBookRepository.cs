using EF_Example.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EF_Example.DAL
{
    public interface IBookRepository : IDisposable
    {
        IEnumerable<Book> GetBooks();
        Book GetBookById(int bookId);
        void InsertBook(Book book);
        void DeleteBook(int bookId);
        void UpdateBook(Book book);
        void Save();
    }
}