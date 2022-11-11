namespace School.Models
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime CreationDate { get; set; }

        protected BaseEntity()
        {
            CreationDate = DateTime.UtcNow;
        }

    }

}
