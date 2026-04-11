namespace hotel_booking_system
{
    public sealed class Receptionist : Person
    {
        public string? Password { get; set; }
        public Receptionist()
        {
            Password = string.Empty;
        }
        public Receptionist(Guid id, string firstname, string lastname, string email, string password)
            : base(id, firstname, lastname, email)
        {
            Password = password;
        }
        public new bool IsValid()
        {
            return base.IsValid() &&
                  !string.IsNullOrEmpty(Password);
        }
    }
}
