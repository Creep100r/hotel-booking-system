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
                DataManager.Add(customer);
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

        private void SearchButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!DataManager.Entities.Any())
                {
                    return;
                }
                listView1.Items.Clear();
                IEnumerable<IEntity> foundEntities = new List<IEntity>();
                if (string.IsNullOrEmpty(SearchBar.Text))
                {
                    foundEntities = DataManager.Entities;
                }
                else
                {
                    foundEntities = DataManager.Search(SearchBar.Text);
                }
                foreach (IEntity entity in foundEntities)
                {
                    var customerEntity = entity as Customer;
                    if (customerEntity != null)
                    {
                        var item = new ListViewItem(listView1.Items.Count + 1 + "");
                        item.SubItems.Add(customerEntity.PhoneNumber);
                        item.SubItems.Add(customerEntity.ApartmentNumber);
                        item.SubItems.Add(customerEntity.StayTime.ToString());
                        item.SubItems.Add(customerEntity.UntilDate != null
                            ? customerEntity.UntilDate.Value.ToString("dd/MM/yyyy hh:mm tt")
                            : string.Empty);
                        item.SubItems.Add("0");
                        item.SubItems.Add("0");
                        listView1.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MaterialMessageBox.Show(ex.Message);
            }
        }
    }
}