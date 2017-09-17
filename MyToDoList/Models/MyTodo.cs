using System;

namespace MyToDoList.Models
{
    public class MyTodo
    {
        public MyTodo()
        {
            CrtDate = DateTime.Now;
            Id = Guid.NewGuid();
        }
        public Guid? Id { get; set; }
        public string Info { get; set; }        
        public DateTime CrtDate { get; set; }
        public bool IsConclude { get; set; }
    }
}