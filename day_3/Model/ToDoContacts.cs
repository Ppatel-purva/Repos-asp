using Microsoft.EntityFrameworkCore;


namespace day_3.model
{
    public class ToDoContacts:DbContact
    {
        public ToDoContacts(DbContactoptions<ToDoContacts>options) : base(options)
        {

        }
        public DbSet<ToDoItem> ToDoItems { get; set; }  
       
    }
}
