using MyToDoList.Models;
using System.Data.Entity;

namespace MyToDoList.db
{
    public class PrjContext : DbContext
    {
        public DbSet<MyTodo> MyToDoLists { get; set; }
    }
}