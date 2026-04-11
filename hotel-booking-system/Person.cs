namespace hotel_booking_system
{
    public class Person : Entity, IEntity
    {
        public override string FileName => "Person.txt";
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public Person()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
        }
        public Person(Guid id, string firstname, string lastname, string email) : base(id)
        {
            FirstName = firstname;
            LastName = lastname;
            Email = email;
        }
        public new bool IsValid()
        {
            return base.IsValid() &&
                  !string.IsNullOrEmpty(FirstName) &&
                  !string.IsNullOrEmpty(LastName) &&
                  !string.IsNullOrEmpty(Email);
        }
        public override string Format()
        {
            return $"[{base.Format()}[{FirstName}][{LastName}][{Email}]";
        }
        public virtual void Parse(string record)
        {
            if (string.IsNullOrWhiteSpace(record))
            {
                throw new ArgumentException("Record cannot be null or empty.", nameof(record));
            }
            var parts = record.Trim('[', ']').Split(new[] { "][" }, StringSplitOptions.None);
            if (parts.Length != 4)
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
        }
        public bool Search(string searchString)
        {
            return FirstName!.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                   LastName!.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                   Email!.Contains(searchString, StringComparison.OrdinalIgnoreCase);
        }
    }
}
