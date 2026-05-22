using MaterialSkin;
using MaterialSkin.Controls;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Security.Principal;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics;
using System.IO;

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
                var untildate = untilTextBox.Value.Date;
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
                //ADD TO DATABASE
                using (ApplicationContext db = new ApplicationContext())
                {
                    Customer dbCustomer = new Customer
                    {
                        Id = id,
                        PhoneNumber = phonenumber,
                        ApartmentNumber = apartmentnumber,
                        StayTime = staytime,
                        UntilDate = untildate,
                    };
                    db.Customers.AddRange(dbCustomer);
                    db.SaveChanges();
                }
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
                    .Select(x => x.PhoneNumber + "/" + x.ApartmentNumber + "/" + x.StayTime.ToString() + "/" + x.UntilDate.ToString() + "/" + x.Id)
                    .FirstOrDefault();
                if (!string.IsNullOrEmpty(data))
                {
                    dataReserveBox.Text = data;
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

        private void showDataBtn_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (!string.IsNullOrWhiteSpace(idBox.Text))
                {
                    if (!string.IsNullOrEmpty(selectColBox.Text))
                    {
                        columnReserveBox.Text = selectColBox.Text;
                    }
                    if (Guid.TryParse(idBox.Text, out var id))
                    {
                        var data = string.Empty;
                        if (selectColBox.Text == "Phone Number")
                        {
                            data = dataManager.Entities
                                .Where(x => x.Id == id)
                                .Select(x => x.PhoneNumber)
                                .FirstOrDefault();
                        }
                        else if (selectColBox.Text == "Apartment")
                        {
                            data = dataManager.Entities
                                .Where(x => x.Id == id)
                                .Select(x => x.ApartmentNumber)
                                .FirstOrDefault();
                        }
                        else if (selectColBox.Text == "Stays For")
                        {
                            data = dataManager.Entities
                                .Where(x => x.Id == id)
                                .Select(x => x.StayTime.ToString())
                                .FirstOrDefault();
                        }
                        else if (selectColBox.Text == "Stays Until")
                        {
                            data = dataManager.Entities
                                .Where(x => x.Id == id)
                                .Select(x => x.UntilDate.ToString())
                                .FirstOrDefault();
                        }
                        if (!string.IsNullOrEmpty(data))
                        {
                            dataBox.Text = data;
                        }
                    }
                    else
                    {
                        MaterialMessageBox.Show("Invalid GUID format.");
                    }
                }
            }
            catch (Exception ex)
            {
                MaterialMessageBox.Show(ex.Message);
            }
        }
        private void updateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var dataReservebox = dataReserveBox.Text;
                string[] parts = dataReservebox.Split('/');
                var phonenumber = parts[0];
                if (columnReserveBox.Text == "Phone Number")
                {
                    phonenumber = dataBox.Text;
                }
                var apartmentnumber = parts[1];
                if (columnReserveBox.Text == "Apartment")
                {
                    apartmentnumber = dataBox.Text;
                }
                var staytimeParse = parts[2];
                if (columnReserveBox.Text == "Stays For")
                {
                    staytimeParse = dataBox.Text;
                }
                TimeSpan? staytime = null;
                if (TimeSpan.TryParse(staytimeParse, out var stResult))
                    staytime = stResult;
                var untildateParse = parts[3];
                if (columnReserveBox.Text == "Stays Until")
                {
                    untildateParse = dataBox.Text;
                }
                DateTime untildate = DateTime.Now;
                if (DateTime.TryParse(untildateParse, out var udResult))
                    untildate = udResult;
                var idParse = parts[4];
                var id = Guid.Parse(idParse);
                
                var firstname = string.Empty;
                var lastname = string.Empty;
                var email = string.Empty;
                var customer = new Customer(id, firstname, lastname, email, phonenumber, apartmentnumber, staytime, untildate);
                FileManager.Add(customer);
                dataManager.Add(customer);
                //UPDATE LIST
                bool updated = false;
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    if (listView1.Items[i].SubItems.Count > 5 &&
                        listView1.Items[i].SubItems[5].Text == customer.Id.ToString())
                    {
                        listView1.Items[i].SubItems[1].Text = phonenumber;
                        listView1.Items[i].SubItems[2].Text = apartmentnumber;
                        listView1.Items[i].SubItems[3].Text = staytimeParse;
                        listView1.Items[i].SubItems[4].Text = untildateParse;
                        updated = true;
                        break;
                    }
                }
                if (!updated)//if false
                {
                    var item = new ListViewItem(listView1.Items.Count + 1 + "");
                    item.SubItems.Add(phonenumber);
                    item.SubItems.Add(apartmentnumber);
                    item.SubItems.Add(staytimeParse);
                    item.SubItems.Add(untildateParse);
                    item.SubItems.Add(customer.Id.ToString());
                    listView1.Items.Add(item);
                }
                //DELETE OLD ROW FROM TEXT FILE
                //try
                //{
                //    
                //}
                //catch (Exception ex)
                //{
                //    MaterialMessageBox.Show(ex.Message);
                //}
                //UPDATE DATABASE
                try
                {
                    using (ApplicationContext db = new ApplicationContext())
                    {
                        var dbCustomer = db.Customers.FirstOrDefault(c => c.Id == id);
                        if (dbCustomer != null)
                        {
                            dbCustomer.PhoneNumber = phonenumber;
                            dbCustomer.ApartmentNumber = apartmentnumber;
                            dbCustomer.StayTime = staytime;
                            dbCustomer.UntilDate = untildate;
                            db.SaveChanges();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.Write(ex.Message);
                }
            }
            catch (Exception ex)
            {
                MaterialMessageBox.Show(ex.Message);
            }
        }
    }
}