namespace hotel_booking_system
{
    public interface IEntity
    {
        public Guid Id { get; set; }
        public bool Search(string searchString);
        public void Parse(string record);
        public bool IsValid();
    }
}
