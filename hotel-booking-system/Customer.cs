namespace hotel_booking_system
{
    public class Customer : Person
    {
        public string? PhoneNumber { get; set; }
        public string? ApartmentNumber { get; set; }
        public TimeSpan? StayTime { get; set; }
        public DateTime? UntilDate { get; set; }
        public Customer()
        {
            PhoneNumber = string.Empty;
            ApartmentNumber = string.Empty;
            StayTime = null;
            UntilDate = new DateTime();
        }
        public Customer(Guid id, string firstname, string lastname, string email,
            string phonenumber, string apartmentnumber, TimeSpan staytime, DateTime untildate)
            : base(id, firstname, lastname, email)
        {
            PhoneNumber = phonenumber;
            ApartmentNumber = apartmentnumber;
            StayTime = staytime;
            UntilDate = untildate;
        }
        public new bool IsValid()
        {
            return base.IsValid() &&
                  !string.IsNullOrEmpty(PhoneNumber) &&
                  !string.IsNullOrEmpty(ApartmentNumber) &&
                   StayTime != null &&
                   UntilDate != null;
        }
        public override sealed string Format()
        {
            return $"{base.Format()}[{PhoneNumber}][{ApartmentNumber}][{StayTime}][{UntilDate.Value.ToUniversalTime()}]";
        }
        public override void Parse(string record)
        {
            if (string.IsNullOrWhiteSpace(record))
            {
                throw new ArgumentException("Record cannot be null or empty.", nameof(record));
            }
            var parts = record.Trim('[', ']').Split(new[] { "][" }, StringSplitOptions.None);
            if (parts.Length != 8)
            {
                throw new ArgumentException("Invalid record format.");
            }
            if (!Guid.TryParse(parts[0], out Guid id))
            {
                throw new FormatException("Invalid ID format.");
            }
            Id = id;
            FirstName = parts[1];
            LastName = parts[2];
            Email = parts[3];
            PhoneNumber = parts[4];
            ApartmentNumber = parts[5];

            if (!TimeSpan.TryParse(parts[6], out TimeSpan staytime))
            {
                throw new FormatException("Invalid StayTime format.");
            }
            StayTime = staytime;

            if (!DateTime.TryParse(parts[7], out DateTime untildate))
            {
                throw new FormatException("Invalid UntilDate format.");
            }
            UntilDate = untildate;
        }
        public override bool Search(string searchString)
        {
            return PhoneNumber!.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                   ApartmentNumber!.Contains(searchString, StringComparison.OrdinalIgnoreCase);
        }
    }
}
