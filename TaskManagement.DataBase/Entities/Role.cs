namespace TaskManagement.DataBase.Entities
{
    public class Role
    {
        public int Id { get; init; }
        public required string Name { get; set; }

        

        public virtual ICollection<User> Users { get; set; }
    }
}