using MaterialSkin;
using MaterialSkin.Controls;
using System.Globalization;
using System.Security.Cryptography.Xml;
using System.Security.Principal;

namespace hotel_booking_system
{
    public partial class MainForm : MaterialForm
    {
        private readonly DataManager<Customer> dataManager;
        public MainForm()
        {
            InitializeComponent();
            dataManager = new DataManager<Customer>();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue400, Primary.Blue700,
                Primary.Blue100, Accent.LightBlue200,
                TextShade.WHITE);
            var customers = FileManager.GetEntities<Customer>("Person.txt");
            foreach (var customer in customers)
            {
                dataManager.Add(customer);
                var item = new ListViewItem(listView1.Items.Count + 1 + "");
                item.SubItems.Add(customer.PhoneNumber);
                item.SubItems.Add(customer.ApartmentNumber);
                item.SubItems.Add(customer.StayTime.ToString());
                item.SubItems.Add(customer.UntilDate.ToString());
                item.SubItems.Add(customer.Id.ToString());
                listView1.Items.Add(item);
            }
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
                dataManager.Add(customer);
                var item = new ListViewItem(listView1.Items.Count + 1 + "");
                item.SubItems.Add(phonenumber);
                item.SubItems.Add(apartmentnumber);
                item.SubItems.Add(staysforTextBox.Text);
                item.SubItems.Add(untilTextBox.Text);
                item.SubItems.Add(customer.Id.ToString());
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
                if (!dataManager.Entities.Any())
                {
                    return;
                }
                listView1.Items.Clear();
                IEnumerable<IEntity> foundEntities = new List<IEntity>();
                if (string.IsNullOrEmpty(SearchBar.Text))
                {
                    foundEntities = dataManager.Entities;
                }
                else
                {
                    foundEntities = dataManager.Search(SearchBar.Text);
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
                        item.SubItems.Add(customerEntity.Id.ToString());
                        listView1.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MaterialMessageBox.Show(ex.Message);
            }
        }

        private void materialTextBox21_Click(object sender, EventArgs e)
        {

        }

        private void materialTextBox21_Click_1(object sender, EventArgs e)
        {

        }

        private void filterbutton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!dataManager.Entities.Any())
                {
                    return;
                }
                listView1.Items.Clear();
                IEnumerable<IEntity> filteredEntities = new List<IEntity>();
                if (string.IsNullOrEmpty(frombox.Text) ||
                    string.IsNullOrEmpty(tobox.Text))
                {
                    filteredEntities = dataManager.Entities;
                }
                else
                {
                    filteredEntities = dataManager.Filter(entity =>
                    {
                        TimeSpan? stayTimeFrom = null;
                        if (TimeSpan.TryParse(frombox.Text, out var stayTimeFromResult))
                            stayTimeFrom = stayTimeFromResult;
                        TimeSpan? stayTimeTo = null;
                        if (TimeSpan.TryParse(tobox.Text, out var stayTimeToResult))
                            stayTimeTo = stayTimeToResult;

                        if (entity is Customer customer && customer.StayTime != null
                        && stayTimeFrom != null && stayTimeTo != null)
                            return customer.StayTime >= stayTimeFrom && customer.StayTime <= stayTimeTo;
                        else
                        {
                            return false;
                        }
                    });
                    foreach (IEntity entity in filteredEntities)
                    {
                        if (entity is Customer customerEntity)
                        {
                            var item = new ListViewItem(listView1.Items.Count + 1 + "");
                            item.SubItems.Add(customerEntity.PhoneNumber);
                            item.SubItems.Add(customerEntity.ApartmentNumber);
                            item.SubItems.Add(customerEntity.StayTime.ToString());
                            item.SubItems.Add(customerEntity.UntilDate != null
                                ? customerEntity.UntilDate.Value.ToString("dd/MM/yyyy hh:mm tt")
                                : string.Empty);
                            item.SubItems.Add(customerEntity.Id.ToString());
                            listView1.Items.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MaterialMessageBox.Show(ex.Message);
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                int selectedIndex = listView1.SelectedIndices[0];
                string selectedItemText = listView1.SelectedItems[0].SubItems[5].Text;
                var id = Guid.Parse(selectedItemText);
                IEntity? entity = dataManager[id];
                if (entity != null)
                {
                    if (entity is Customer customer)
                    {
                        var formattedText = customer.Format();
                        selectedItemTextBox.Text = formattedText;
                    }
                }
            }
        }
    }
}