namespace App.Web.Models.Entities
{
    public class PersonEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public virtual UserEntity User { get; set;} = null!;
    }
}
