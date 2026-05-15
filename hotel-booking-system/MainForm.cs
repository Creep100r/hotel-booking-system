using MaterialSkin;
using MaterialSkin.Controls;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Security.Principal;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace hotel_booking_system
{
    public partial class MainForm : MaterialForm
    {
        private readonly DataManager<Customer> dataManager;
        private const int PAGE_LIMIT = 5;
        private int currentPage = 0;
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
            var ordered = customers
                .OrderBy(x => x.PhoneNumber)
                .ThenByDescending(x => x.UntilDate);
            ordered.ToList().ForEach(e => dataManager.Add(e));
            customers = ordered.Paginate(currentPage, PAGE_LIMIT);
            foreach (var customer in customers)
            {
                var item = new ListViewItem(listView1.Items.Count + 1 + "");
                item.SubItems.Add(customer.PhoneNumber);
                item.SubItems.Add(customer.ApartmentNumber);
                item.SubItems.Add(customer.StayTime.ToString());
                item.SubItems.Add(customer.UntilDate.ToString());
                item.SubItems.Add(customer.Id.ToString());
                listView1.Items.Add(item);
            }
        }
        
        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                var firstname = string.Empty;
                var lastname = string.Empty;
                var email = string.Empty;
                var phonenumber = phoneTextBox.Text;
                var apartmentnumber = apartmentTextBox.Text;
                TimeSpan? staytime = null;
                if (TimeSpan.TryParse(staysforTextBox.Text, out var staytimeResult))
                {
                    staytime = staytimeResult;
                }
                //var untildate = DateTime.Now;
                var untildate = untilTextBox.Value.Date; //<=====
                if (DateTime.TryParseExact(untilTextBox.Text, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out var untildateResult))
                {
                    untildate = untildateResult;
                }
                var id = Guid.NewGuid();
                var customer = new Customer(id, firstname, lastname, email, phonenumber, apartmentnumber, staytime, untildate);
                FileManager.Add(customer);
                dataManager.Add(customer);
                var item = new ListViewItem(listView1.Items.Count + 1 + "");
                item.SubItems.Add(phonenumber);
                item.SubItems.Add(apartmentnumber);
                item.SubItems.Add(staysforTextBox.Text);
                item.SubItems.Add(untildate.ToString("dd/MM/yyyy"));
                item.SubItems.Add(customer.Id.ToString());
                listView1.Items.Add(item);
            }
            catch (Exception ex)
            {
                MaterialMessageBox.Show(ex.Message);
            }
            CalculateStatistics();
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
                IEnumerable<Customer> foundEntities = new List<Customer>();
                if (string.IsNullOrEmpty(SearchBar.Text) &&
                    string.IsNullOrEmpty(frombox.Text) &&
                    string.IsNullOrEmpty(tobox.Text))
                {
                    foundEntities = dataManager.Entities
                        .OrderBy(x => x.PhoneNumber)
                        .ThenByDescending(x => x.UntilDate)
                        .Skip(currentPage * PAGE_LIMIT)
                        .Take(PAGE_LIMIT);
                }
                else
                {
                    TimeSpan? stayTimeFrom = null;
                    if (TimeSpan.TryParse(frombox.Text, out var stayTimeFromResult))
                        stayTimeFrom = stayTimeFromResult;
                    TimeSpan? stayTimeTo = null;
                    if (TimeSpan.TryParse(tobox.Text, out var stayTimeToResult))
                        stayTimeTo = stayTimeToResult;
                    foundEntities = dataManager.Entities.
                        Where(e => (string.IsNullOrEmpty(SearchBar.Text) || e.Search(SearchBar.Text)) &&
                                   (stayTimeFrom == null || stayTimeTo == null ||
                                   (e.StayTime >= stayTimeFrom && e.StayTime <= stayTimeTo)))
                        .OrderBy(x => x.PhoneNumber)
                        .ThenByDescending(x => x.UntilDate)
                        .Skip(currentPage * PAGE_LIMIT)
                        .Take(PAGE_LIMIT);
                }
                foundEntities.ToList().ForEach(e =>
                {
                    var item = new ListViewItem(listView1.Items.Count + 1 + "");
                    item.SubItems.Add(e.PhoneNumber);
                    item.SubItems.Add(e.ApartmentNumber);
                    item.SubItems.Add(e.StayTime.ToString());
                    item.SubItems.Add(e.UntilDate != null
                        ? e.UntilDate.Value.ToString("dd/MM/yyyy")
                        : string.Empty);
                    item.SubItems.Add(e.Id.ToString());
                    listView1.Items.Add(item);
                });
            }
            catch (Exception ex)
            {
                MaterialMessageBox.Show(ex.Message);
            }
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
                                ? customerEntity.UntilDate.Value.ToString("dd/MM/yyyy")
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
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                int selectedIndex = listView1.SelectedIndices[0];
                string selectedItemText = listView1.SelectedItems[0].SubItems[5].Text;
                var id = Guid.Parse(selectedItemText);
                var data = dataManager.Entities
                    .Where(x => x.Id == id)
                    .Select(x => x.PhoneNumber + " " + x.ApartmentNumber + " " + x.StayTime.ToString() + " " + x.UntilDate.ToString())
                    .FirstOrDefault();
                if (!string.IsNullOrEmpty(data))
                {
                    selectedItemTextBox.Text = data;
                }
            }
        }
        private void sortBtn1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            var customers = dataManager.Entities
                .OrderBy(x => x.PhoneNumber)
                .ThenByDescending(x => x.UntilDate)
                .Paginate(currentPage, PAGE_LIMIT);
            foreach (var customer in customers)
            {
                var item = new ListViewItem(listView1.Items.Count + 1 + "");
                item.SubItems.Add(customer.PhoneNumber);
                item.SubItems.Add(customer.ApartmentNumber);
                item.SubItems.Add(customer.StayTime.ToString());
                item.SubItems.Add(customer.UntilDate.ToString());
                item.SubItems.Add(customer.Id.ToString());
                listView1.Items.Add(item);
            }
        }
        private void Paginate()
        {
            listView1.Items.Clear();
            var data = dataManager.Entities
                .OrderBy(x => x.PhoneNumber)
                .ThenByDescending(x => x.UntilDate)
                .Paginate(currentPage, PAGE_LIMIT)
                .ToList();
            data.ForEach(e =>
            {
                var item = new ListViewItem(listView1.Items.Count + 1 + "");
                item.SubItems.Add(e.PhoneNumber);
                item.SubItems.Add(e.ApartmentNumber);
                item.SubItems.Add(e.StayTime.ToString());
                item.SubItems.Add(e.UntilDate.ToString());
                item.SubItems.Add(e.Id.ToString());
                listView1.Items.Add(item);
            });
            this.pageNumTextBox.Text = (currentPage + 1).ToString();
        }
        private void CalculateStatistics()
        {
            var futureCustomersNumber = dataManager.Entities
                    .Count(e => e.UntilDate > DateTime.Now);
            countTextBox.Text = futureCustomersNumber.ToString();
            var maxCustomerStayTime = dataManager.Entities.Max(e => e.StayTime);
            maxStayTimeTextBox.Text = maxCustomerStayTime.ToString();
        }
        private void prevBtn_Click(object sender, EventArgs e)
        {
            if (currentPage > 0 && dataManager.Entities.Any())
            {
                currentPage--;
                Paginate();
            }
        }
        private void nextBtn_Click(object sender, EventArgs e)
        {
            if (currentPage < dataManager.Entities.Count() / PAGE_LIMIT && dataManager.Entities.Any())
            {
                currentPage++;
                Paginate();
            }
        }
        private void loadAnotherSourseButton_Click(object sender, EventArgs e)
        {
            var result = fileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                listView1.Items.Clear();
                dataManager.Clear();
                var anotherCustomer = FileManager.GetEntities<Customer>(fileDialog.FileName);
                var currentCustomerIds = dataManager.Entities.Select(e => e.Id);
                var uniqueAnotherCustomers = anotherCustomer.ExceptBy(currentCustomerIds, e => e.Id);
                var allCustomers = dataManager.Entities
                    .Concat(uniqueAnotherCustomers)
                    .OrderBy(x => x.PhoneNumber)
                    .ThenByDescending(x => x.UntilDate)
                    .ToList();
                allCustomers.ForEach(e => dataManager.Add(e));
                allCustomers = allCustomers.Paginate(0, PAGE_LIMIT).ToList();
                allCustomers.ForEach(e =>
                {
                    var item = new ListViewItem(listView1.Items.Count + 1 + "");
                    item.SubItems.Add(e.PhoneNumber);
                    item.SubItems.Add(e.ApartmentNumber);
                    item.SubItems.Add(e.StayTime.ToString());
                    item.SubItems.Add(e.UntilDate.ToString());
                    item.SubItems.Add(e.Id.ToString());
                    listView1.Items.Add(item);
                });
                CalculateStatistics();
            }
        }
    }
}