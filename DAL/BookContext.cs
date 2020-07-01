using EF_Example.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EF_Example.DAL
{
    public class BookContext:DbContext
    {
        public BookContext() : base("con")
        {

        }
        public DbSet<Book> Books { get; set; }
    }
}