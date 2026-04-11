namespace hotel_booking_system
{
    public class Entity
    {
        public virtual string FileName { get; }
        public Guid Id { get; set; }
        public Entity()
        {
            Id = Guid.NewGuid();
        }
        public Entity(Guid id)
        {
            Id = id;
        }
        public bool IsValid()
        {
            return Id != Guid.Empty;
        }
        public virtual string Format()
        {
            return "[" + Id.ToString() + "]";
        }
    }
}
