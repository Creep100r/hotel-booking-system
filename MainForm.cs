using MaterialSkin;
using MaterialSkin.Controls;
using System.Globalization;

namespace hotel_booking_system
{
    public partial class MainForm : MaterialForm
    {
        public MainForm()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue400, Primary.Blue700,
                Primary.Blue100, Accent.LightBlue200,
                TextShade.WHITE);

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                var phonenumber = phoneTextBox.Text;
                var apartmentnumber = apartmentTextBox.Text;
                TimeSpan? staytime = null;
                if (TimeSpan.TryParse(staysforTextBox.Text, out var staytimeResult))
                {
                    staytime = staytimeResult;
                }
                var untildate = DateTime.Now;
                if (DateTime.TryParseExact(untilTextBox.Text, "dd/MM/yyyy hh:mm tt",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out var untildateResult))
                {
                    untildate = untildateResult;
                }
                var id = Guid.NewGuid();
                var customer = new Customer
                {
                    Id = id,
                    PhoneNumber = phonenumber,
                    ApartmentNumber = apartmentnumber,
                    StayTime = staytime,
                    UntilDate = untildate
                };
                FileManager.Add(customer);
                var item = new ListViewItem(listView1.Items.Count + 1 + "");
                item.SubItems.Add(phonenumber);
                item.SubItems.Add(apartmentnumber);
                item.SubItems.Add(staysforTextBox.Text);
                item.SubItems.Add(untilTextBox.Text);
                listView1.Items.Add(item);
            }
            catch (Exception ex)
            {
                MaterialMessageBox.Show(ex.Message);
            }
        }
    }
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
    public class Person : Entity
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
    }
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
            return $"[{base.Format()}[{PhoneNumber}][{ApartmentNumber}][{StayTime}][{UntilDate.Value.ToUniversalTime()}]";
        }
        public override void Parse(string record)
        {
            if (string.IsNullOrWhiteSpace(record))
            {
                throw new ArgumentException("Record cannot be null or empty.", nameof(record));
            }
            var parts = record.Trim('[', ']').Split(new[] { "][" }, StringSplitOptions.None);
            if (parts.Length != 5)
            {
                throw new ArgumentException("Invalid record format.");
            }
            if (!Guid.TryParse(parts[0], out Guid id))
            {
                throw new FormatException("Invalid ID format.");
            }
            Id = id;
            PhoneNumber = parts[1];
            ApartmentNumber = parts[2];

            if (!TimeSpan.TryParse(parts[3], out TimeSpan staytime))
            {
                throw new FormatException("Invalid StayTime format.");
            }
            StayTime = staytime;

            if (!DateTime.TryParse(parts[4], out DateTime untildate))
            {
                throw new FormatException("Invalid UntilDate format.");
            }
            UntilDate = untildate;
        }

    }
    public static class FileManager
    {
        public static void Add(Entity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            if (!entity.IsValid())
            {
                throw new Exception("Entity is invalid");
            }
            var record = entity.Format();
            using (var writer = new StreamWriter(entity.FileName, append: true))
            {
                writer.WriteLine(record);
            }
        }
    }
}