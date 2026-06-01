namespace hotel_booking_system
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listView1 = new ListView();
            Id = new ColumnHeader();
            Phone_Number = new ColumnHeader();
            Apartment = new ColumnHeader();
            Stays_for = new ColumnHeader();
            Stays_Until = new ColumnHeader();
            idColumn = new ColumnHeader();
            label1 = new Label();
            phoneTextBox = new MaterialSkin.Controls.MaterialTextBox2();
            apartmentTextBox = new MaterialSkin.Controls.MaterialTextBox2();
            label2 = new Label();
            staysforTextBox = new MaterialSkin.Controls.MaterialTextBox2();
            label3 = new Label();
            label4 = new Label();
            untilTextBox = new DateTimePicker();
            addButton = new MaterialSkin.Controls.MaterialButton();
            SearchBar = new MaterialSkin.Controls.MaterialTextBox2();
            label5 = new Label();
            SearchButton = new MaterialSkin.Controls.MaterialButton();
            frombox = new MaterialSkin.Controls.MaterialTextBox2();
            tobox = new MaterialSkin.Controls.MaterialTextBox2();
            label6 = new Label();
            filterbutton = new MaterialSkin.Controls.MaterialButton();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            selectedItemTextBox = new TextBox();
            sortBtn = new MaterialSkin.Controls.MaterialButton();
            prevBtn = new MaterialSkin.Controls.MaterialButton();
            nextBtn = new MaterialSkin.Controls.MaterialButton();
            pageNumTextBox = new TextBox();
            countTextBox = new TextBox();
            maxStayTimeTextBox = new TextBox();
            label10 = new Label();
            label11 = new Label();
            loadAnotherSourseButton = new MaterialSkin.Controls.MaterialButton();
            fileDialog = new OpenFileDialog();
            dataBox = new TextBox();
            updateBtn = new MaterialSkin.Controls.MaterialButton();
            selectColBox = new ComboBox();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            showDataBtn = new MaterialSkin.Controls.MaterialButton();
            idBox = new TextBox();
            dataReserveBox = new TextBox();
            columnReserveBox = new TextBox();
            queryPerformer = new MaterialSkin.Controls.MaterialButton();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { Id, Phone_Number, Apartment, Stays_for, Stays_Until, idColumn });
            listView1.FullRowSelect = true;
            listView1.Location = new Point(6, 139);
            listView1.Name = "listView1";
            listView1.Size = new Size(657, 290);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // Id
            // 
            Id.Text = "#";
            Id.Width = 20;
            // 
            // Phone_Number
            // 
            Phone_Number.Text = "Phone Number";
            Phone_Number.TextAlign = HorizontalAlignment.Center;
            Phone_Number.Width = 110;
            // 
            // Apartment
            // 
            Apartment.Text = "Apartment";
            Apartment.TextAlign = HorizontalAlignment.Center;
            Apartment.Width = 80;
            // 
            // Stays_for
            // 
            Stays_for.Text = "Stays for";
            Stays_for.TextAlign = HorizontalAlignment.Center;
            Stays_for.Width = 90;
            // 
            // Stays_Until
            // 
            Stays_Until.Text = "Stays_Until";
            Stays_Until.TextAlign = HorizontalAlignment.Center;
            Stays_Until.Width = 100;
            // 
            // idColumn
            // 
            idColumn.Text = "Id";
            idColumn.Width = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(670, 78);
            label1.Name = "label1";
            label1.Size = new Size(125, 15);
            label1.TabIndex = 1;
            label1.Text = "Clients phone number";
            // 
            // phoneTextBox
            // 
            phoneTextBox.AnimateReadOnly = false;
            phoneTextBox.BackgroundImageLayout = ImageLayout.None;
            phoneTextBox.CharacterCasing = CharacterCasing.Normal;
            phoneTextBox.Depth = 0;
            phoneTextBox.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            phoneTextBox.HideSelection = true;
            phoneTextBox.LeadingIcon = null;
            phoneTextBox.Location = new Point(670, 96);
            phoneTextBox.MaxLength = 32767;
            phoneTextBox.MouseState = MaterialSkin.MouseState.OUT;
            phoneTextBox.Name = "phoneTextBox";
            phoneTextBox.PasswordChar = '\0';
            phoneTextBox.PrefixSuffixText = null;
            phoneTextBox.ReadOnly = false;
            phoneTextBox.RightToLeft = RightToLeft.No;
            phoneTextBox.SelectedText = "";
            phoneTextBox.SelectionLength = 0;
            phoneTextBox.SelectionStart = 0;
            phoneTextBox.ShortcutsEnabled = true;
            phoneTextBox.Size = new Size(219, 48);
            phoneTextBox.TabIndex = 2;
            phoneTextBox.TabStop = false;
            phoneTextBox.TextAlign = HorizontalAlignment.Left;
            phoneTextBox.TrailingIcon = null;
            phoneTextBox.UseSystemPasswordChar = false;
            // 
            // apartmentTextBox
            // 
            apartmentTextBox.AnimateReadOnly = false;
            apartmentTextBox.BackgroundImageLayout = ImageLayout.None;
            apartmentTextBox.CharacterCasing = CharacterCasing.Normal;
            apartmentTextBox.Depth = 0;
            apartmentTextBox.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            apartmentTextBox.HideSelection = true;
            apartmentTextBox.LeadingIcon = null;
            apartmentTextBox.Location = new Point(670, 165);
            apartmentTextBox.MaxLength = 32767;
            apartmentTextBox.MouseState = MaterialSkin.MouseState.OUT;
            apartmentTextBox.Name = "apartmentTextBox";
            apartmentTextBox.PasswordChar = '\0';
            apartmentTextBox.PrefixSuffixText = null;
            apartmentTextBox.ReadOnly = false;
            apartmentTextBox.RightToLeft = RightToLeft.No;
            apartmentTextBox.SelectedText = "";
            apartmentTextBox.SelectionLength = 0;
            apartmentTextBox.SelectionStart = 0;
            apartmentTextBox.ShortcutsEnabled = true;
            apartmentTextBox.Size = new Size(219, 48);
            apartmentTextBox.TabIndex = 4;
            apartmentTextBox.TabStop = false;
            apartmentTextBox.TextAlign = HorizontalAlignment.Left;
            apartmentTextBox.TrailingIcon = null;
            apartmentTextBox.UseSystemPasswordChar = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(670, 147);
            label2.Name = "label2";
            label2.Size = new Size(105, 15);
            label2.TabIndex = 3;
            label2.Text = "Booked apartment";
            // 
            // staysforTextBox
            // 
            staysforTextBox.AnimateReadOnly = false;
            staysforTextBox.BackgroundImageLayout = ImageLayout.None;
            staysforTextBox.CharacterCasing = CharacterCasing.Normal;
            staysforTextBox.Depth = 0;
            staysforTextBox.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            staysforTextBox.HideSelection = true;
            staysforTextBox.LeadingIcon = null;
            staysforTextBox.Location = new Point(670, 234);
            staysforTextBox.MaxLength = 32767;
            staysforTextBox.MouseState = MaterialSkin.MouseState.OUT;
            staysforTextBox.Name = "staysforTextBox";
            staysforTextBox.PasswordChar = '\0';
            staysforTextBox.PrefixSuffixText = null;
            staysforTextBox.ReadOnly = false;
            staysforTextBox.RightToLeft = RightToLeft.No;
            staysforTextBox.SelectedText = "";
            staysforTextBox.SelectionLength = 0;
            staysforTextBox.SelectionStart = 0;
            staysforTextBox.ShortcutsEnabled = true;
            staysforTextBox.Size = new Size(219, 48);
            staysforTextBox.TabIndex = 6;
            staysforTextBox.TabStop = false;
            staysforTextBox.TextAlign = HorizontalAlignment.Left;
            staysforTextBox.TrailingIcon = null;
            staysforTextBox.UseSystemPasswordChar = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(670, 216);
            label3.Name = "label3";
            label3.Size = new Size(87, 15);
            label3.TabIndex = 5;
            label3.Text = "Stays for (days)";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(670, 285);
            label4.Name = "label4";
            label4.Size = new Size(61, 15);
            label4.TabIndex = 7;
            label4.Text = "Stays until";
            // 
            // untilTextBox
            // 
            untilTextBox.CustomFormat = "dd/MM/yyyy";
            untilTextBox.Format = DateTimePickerFormat.Custom;
            untilTextBox.Location = new Point(670, 303);
            untilTextBox.Name = "untilTextBox";
            untilTextBox.Size = new Size(219, 23);
            untilTextBox.TabIndex = 8;
            untilTextBox.Value = new DateTime(2026, 5, 15, 0, 0, 0, 0);
            // 
            // addButton
            // 
            addButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            addButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            addButton.Depth = 0;
            addButton.HighEmphasis = true;
            addButton.Icon = null;
            addButton.Location = new Point(670, 393);
            addButton.Margin = new Padding(4, 6, 4, 6);
            addButton.MouseState = MaterialSkin.MouseState.HOVER;
            addButton.Name = "addButton";
            addButton.NoAccentTextColor = Color.Empty;
            addButton.Size = new Size(64, 36);
            addButton.TabIndex = 9;
            addButton.Text = "ADD";
            addButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            addButton.UseAccentColor = false;
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // SearchBar
            // 
            SearchBar.AnimateReadOnly = false;
            SearchBar.BackgroundImageLayout = ImageLayout.None;
            SearchBar.CharacterCasing = CharacterCasing.Normal;
            SearchBar.Depth = 0;
            SearchBar.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            SearchBar.HideSelection = true;
            SearchBar.LeadingIcon = null;
            SearchBar.Location = new Point(6, 90);
            SearchBar.Margin = new Padding(3, 2, 3, 2);
            SearchBar.MaxLength = 32767;
            SearchBar.MouseState = MaterialSkin.MouseState.OUT;
            SearchBar.Name = "SearchBar";
            SearchBar.PasswordChar = '\0';
            SearchBar.PrefixSuffixText = null;
            SearchBar.ReadOnly = false;
            SearchBar.RightToLeft = RightToLeft.No;
            SearchBar.SelectedText = "";
            SearchBar.SelectionLength = 0;
            SearchBar.SelectionStart = 0;
            SearchBar.ShortcutsEnabled = true;
            SearchBar.Size = new Size(169, 48);
            SearchBar.TabIndex = 10;
            SearchBar.TabStop = false;
            SearchBar.TextAlign = HorizontalAlignment.Left;
            SearchBar.TrailingIcon = null;
            SearchBar.UseSystemPasswordChar = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(5, 72);
            label5.Name = "label5";
            label5.Size = new Size(101, 15);
            label5.TabIndex = 11;
            label5.Text = "Search for a room";
            // 
            // SearchButton
            // 
            SearchButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            SearchButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            SearchButton.Depth = 0;
            SearchButton.HighEmphasis = true;
            SearchButton.Icon = Properties.Resources.search_icon_png_11;
            SearchButton.Location = new Point(182, 96);
            SearchButton.Margin = new Padding(4);
            SearchButton.MouseState = MaterialSkin.MouseState.HOVER;
            SearchButton.Name = "SearchButton";
            SearchButton.NoAccentTextColor = Color.Empty;
            SearchButton.Size = new Size(64, 36);
            SearchButton.TabIndex = 12;
            SearchButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            SearchButton.UseAccentColor = false;
            SearchButton.UseVisualStyleBackColor = true;
            SearchButton.Click += SearchButton_Click;
            // 
            // frombox
            // 
            frombox.AnimateReadOnly = false;
            frombox.BackgroundImageLayout = ImageLayout.None;
            frombox.CharacterCasing = CharacterCasing.Normal;
            frombox.Depth = 0;
            frombox.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            frombox.HideSelection = true;
            frombox.LeadingIcon = null;
            frombox.Location = new Point(304, 90);
            frombox.MaxLength = 32767;
            frombox.MouseState = MaterialSkin.MouseState.OUT;
            frombox.Name = "frombox";
            frombox.PasswordChar = '\0';
            frombox.PrefixSuffixText = null;
            frombox.ReadOnly = false;
            frombox.RightToLeft = RightToLeft.No;
            frombox.SelectedText = "";
            frombox.SelectionLength = 0;
            frombox.SelectionStart = 0;
            frombox.ShortcutsEnabled = true;
            frombox.Size = new Size(70, 48);
            frombox.TabIndex = 13;
            frombox.TabStop = false;
            frombox.TextAlign = HorizontalAlignment.Left;
            frombox.TrailingIcon = null;
            frombox.UseSystemPasswordChar = false;
            // 
            // tobox
            // 
            tobox.AnimateReadOnly = false;
            tobox.BackgroundImageLayout = ImageLayout.None;
            tobox.CharacterCasing = CharacterCasing.Normal;
            tobox.Depth = 0;
            tobox.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            tobox.HideSelection = true;
            tobox.LeadingIcon = null;
            tobox.Location = new Point(398, 90);
            tobox.MaxLength = 32767;
            tobox.MouseState = MaterialSkin.MouseState.OUT;
            tobox.Name = "tobox";
            tobox.PasswordChar = '\0';
            tobox.PrefixSuffixText = null;
            tobox.ReadOnly = false;
            tobox.RightToLeft = RightToLeft.No;
            tobox.SelectedText = "";
            tobox.SelectionLength = 0;
            tobox.SelectionStart = 0;
            tobox.ShortcutsEnabled = true;
            tobox.Size = new Size(70, 48);
            tobox.TabIndex = 14;
            tobox.TabStop = false;
            tobox.TextAlign = HorizontalAlignment.Left;
            tobox.TrailingIcon = null;
            tobox.UseSystemPasswordChar = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(380, 107);
            label6.Name = "label6";
            label6.Size = new Size(12, 15);
            label6.TabIndex = 15;
            label6.Text = "-";
            // 
            // filterbutton
            // 
            filterbutton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            filterbutton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            filterbutton.Depth = 0;
            filterbutton.HighEmphasis = true;
            filterbutton.Icon = Properties.Resources.filter_icon2;
            filterbutton.Location = new Point(475, 96);
            filterbutton.Margin = new Padding(4, 6, 4, 6);
            filterbutton.MouseState = MaterialSkin.MouseState.HOVER;
            filterbutton.Name = "filterbutton";
            filterbutton.NoAccentTextColor = Color.Empty;
            filterbutton.Size = new Size(64, 36);
            filterbutton.TabIndex = 16;
            filterbutton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            filterbutton.UseAccentColor = false;
            filterbutton.UseVisualStyleBackColor = true;
            filterbutton.Click += filterbutton_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(304, 72);
            label7.Name = "label7";
            label7.Size = new Size(35, 15);
            label7.TabIndex = 17;
            label7.Text = "From";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(398, 72);
            label8.Name = "label8";
            label8.Size = new Size(20, 15);
            label8.TabIndex = 18;
            label8.Text = "To";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(5, 591);
            label9.Name = "label9";
            label9.Size = new Size(54, 15);
            label9.TabIndex = 19;
            label9.Text = "Selected:";
            // 
            // selectedItemTextBox
            // 
            selectedItemTextBox.Location = new Point(66, 588);
            selectedItemTextBox.Name = "selectedItemTextBox";
            selectedItemTextBox.Size = new Size(597, 23);
            selectedItemTextBox.TabIndex = 20;
            // 
            // sortBtn
            // 
            sortBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            sortBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            sortBtn.Depth = 0;
            sortBtn.HighEmphasis = true;
            sortBtn.Icon = null;
            sortBtn.Location = new Point(599, 96);
            sortBtn.Margin = new Padding(4, 6, 4, 6);
            sortBtn.MouseState = MaterialSkin.MouseState.HOVER;
            sortBtn.Name = "sortBtn";
            sortBtn.NoAccentTextColor = Color.Empty;
            sortBtn.Size = new Size(64, 36);
            sortBtn.TabIndex = 21;
            sortBtn.Text = "SORT";
            sortBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            sortBtn.UseAccentColor = false;
            sortBtn.UseVisualStyleBackColor = true;
            sortBtn.Click += sortBtn1_Click;
            // 
            // prevBtn
            // 
            prevBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            prevBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            prevBtn.Depth = 0;
            prevBtn.HighEmphasis = true;
            prevBtn.Icon = null;
            prevBtn.Location = new Point(483, 435);
            prevBtn.Margin = new Padding(4, 6, 4, 6);
            prevBtn.MouseState = MaterialSkin.MouseState.HOVER;
            prevBtn.Name = "prevBtn";
            prevBtn.NoAccentTextColor = Color.Empty;
            prevBtn.Size = new Size(64, 36);
            prevBtn.TabIndex = 22;
            prevBtn.Text = "Prev";
            prevBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            prevBtn.UseAccentColor = false;
            prevBtn.UseVisualStyleBackColor = true;
            prevBtn.Click += prevBtn_Click;
            // 
            // nextBtn
            // 
            nextBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            nextBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            nextBtn.Depth = 0;
            nextBtn.HighEmphasis = true;
            nextBtn.Icon = null;
            nextBtn.Location = new Point(599, 436);
            nextBtn.Margin = new Padding(4, 6, 4, 6);
            nextBtn.MouseState = MaterialSkin.MouseState.HOVER;
            nextBtn.Name = "nextBtn";
            nextBtn.NoAccentTextColor = Color.Empty;
            nextBtn.Size = new Size(64, 36);
            nextBtn.TabIndex = 23;
            nextBtn.Text = "Next";
            nextBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            nextBtn.UseAccentColor = false;
            nextBtn.UseVisualStyleBackColor = true;
            nextBtn.Click += nextBtn_Click;
            // 
            // pageNumTextBox
            // 
            pageNumTextBox.Enabled = false;
            pageNumTextBox.Location = new Point(554, 435);
            pageNumTextBox.Name = "pageNumTextBox";
            pageNumTextBox.Size = new Size(38, 23);
            pageNumTextBox.TabIndex = 24;
            // 
            // countTextBox
            // 
            countTextBox.Enabled = false;
            countTextBox.Location = new Point(670, 588);
            countTextBox.Name = "countTextBox";
            countTextBox.Size = new Size(50, 23);
            countTextBox.TabIndex = 25;
            // 
            // maxStayTimeTextBox
            // 
            maxStayTimeTextBox.Enabled = false;
            maxStayTimeTextBox.Location = new Point(726, 588);
            maxStayTimeTextBox.Name = "maxStayTimeTextBox";
            maxStayTimeTextBox.Size = new Size(92, 23);
            maxStayTimeTextBox.TabIndex = 26;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(670, 570);
            label10.Name = "label10";
            label10.Size = new Size(43, 15);
            label10.TabIndex = 27;
            label10.Text = "Count:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(726, 570);
            label11.Name = "label11";
            label11.Size = new Size(83, 15);
            label11.TabIndex = 28;
            label11.Text = "Max stay time:";
            // 
            // loadAnotherSourseButton
            // 
            loadAnotherSourseButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            loadAnotherSourseButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            loadAnotherSourseButton.Depth = 0;
            loadAnotherSourseButton.DialogResult = DialogResult.OK;
            loadAnotherSourseButton.HighEmphasis = true;
            loadAnotherSourseButton.Icon = null;
            loadAnotherSourseButton.Location = new Point(7, 435);
            loadAnotherSourseButton.Margin = new Padding(4, 6, 4, 6);
            loadAnotherSourseButton.MouseState = MaterialSkin.MouseState.HOVER;
            loadAnotherSourseButton.Name = "loadAnotherSourseButton";
            loadAnotherSourseButton.NoAccentTextColor = Color.Empty;
            loadAnotherSourseButton.Size = new Size(91, 36);
            loadAnotherSourseButton.TabIndex = 29;
            loadAnotherSourseButton.Text = "Load file";
            loadAnotherSourseButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            loadAnotherSourseButton.UseAccentColor = false;
            loadAnotherSourseButton.UseVisualStyleBackColor = true;
            loadAnotherSourseButton.Click += loadAnotherSourseButton_Click;
            // 
            // dataBox
            // 
            dataBox.Location = new Point(398, 556);
            dataBox.Name = "dataBox";
            dataBox.Size = new Size(180, 23);
            dataBox.TabIndex = 30;
            // 
            // updateBtn
            // 
            updateBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            updateBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            updateBtn.Depth = 0;
            updateBtn.HighEmphasis = true;
            updateBtn.Icon = null;
            updateBtn.Location = new Point(586, 543);
            updateBtn.Margin = new Padding(4, 6, 4, 6);
            updateBtn.MouseState = MaterialSkin.MouseState.HOVER;
            updateBtn.Name = "updateBtn";
            updateBtn.NoAccentTextColor = Color.Empty;
            updateBtn.Size = new Size(77, 36);
            updateBtn.TabIndex = 31;
            updateBtn.Text = "Update";
            updateBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            updateBtn.UseAccentColor = false;
            updateBtn.UseVisualStyleBackColor = true;
            updateBtn.Click += updateBtn_Click;
            // 
            // selectColBox
            // 
            selectColBox.FormattingEnabled = true;
            selectColBox.Items.AddRange(new object[] { "Phone Number", "Apartment", "Stays For", "Stays Until" });
            selectColBox.Location = new Point(66, 511);
            selectColBox.Name = "selectColBox";
            selectColBox.Size = new Size(137, 23);
            selectColBox.TabIndex = 32;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(398, 537);
            label12.Name = "label12";
            label12.Size = new Size(34, 15);
            label12.TabIndex = 34;
            label12.Text = "Data:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(66, 493);
            label13.Name = "label13";
            label13.Size = new Size(53, 15);
            label13.TabIndex = 35;
            label13.Text = "Column:";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(66, 537);
            label14.Name = "label14";
            label14.Size = new Size(20, 15);
            label14.TabIndex = 36;
            label14.Text = "Id:";
            // 
            // showDataBtn
            // 
            showDataBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            showDataBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            showDataBtn.Depth = 0;
            showDataBtn.HighEmphasis = true;
            showDataBtn.Icon = null;
            showDataBtn.Location = new Point(286, 511);
            showDataBtn.Margin = new Padding(4, 6, 4, 6);
            showDataBtn.MouseState = MaterialSkin.MouseState.HOVER;
            showDataBtn.Name = "showDataBtn";
            showDataBtn.NoAccentTextColor = Color.Empty;
            showDataBtn.Size = new Size(105, 36);
            showDataBtn.TabIndex = 37;
            showDataBtn.Text = "Show data";
            showDataBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            showDataBtn.UseAccentColor = false;
            showDataBtn.UseVisualStyleBackColor = true;
            showDataBtn.Click += showDataBtn_Click;
            // 
            // idBox
            // 
            idBox.Location = new Point(67, 556);
            idBox.Name = "idBox";
            idBox.Size = new Size(325, 23);
            idBox.TabIndex = 38;
            // 
            // dataReserveBox
            // 
            dataReserveBox.Enabled = false;
            dataReserveBox.Location = new Point(209, 511);
            dataReserveBox.Name = "dataReserveBox";
            dataReserveBox.Size = new Size(32, 23);
            dataReserveBox.TabIndex = 39;
            // 
            // columnReserveBox
            // 
            columnReserveBox.Enabled = false;
            columnReserveBox.Location = new Point(247, 511);
            columnReserveBox.Name = "columnReserveBox";
            columnReserveBox.Size = new Size(32, 23);
            columnReserveBox.TabIndex = 40;
            // 
            // queryPerformer
            // 
            queryPerformer.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            queryPerformer.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            queryPerformer.Depth = 0;
            queryPerformer.HighEmphasis = true;
            queryPerformer.Icon = null;
            queryPerformer.Location = new Point(286, 435);
            queryPerformer.Margin = new Padding(4, 6, 4, 6);
            queryPerformer.MouseState = MaterialSkin.MouseState.HOVER;
            queryPerformer.Name = "queryPerformer";
            queryPerformer.NoAccentTextColor = Color.Empty;
            queryPerformer.Size = new Size(152, 36);
            queryPerformer.TabIndex = 41;
            queryPerformer.Text = "Perform a query";
            queryPerformer.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            queryPerformer.UseAccentColor = false;
            queryPerformer.UseVisualStyleBackColor = true;
            queryPerformer.Click += queryPerformer_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(895, 617);
            Controls.Add(queryPerformer);
            Controls.Add(columnReserveBox);
            Controls.Add(dataReserveBox);
            Controls.Add(idBox);
            Controls.Add(showDataBtn);
            Controls.Add(label14);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(selectColBox);
            Controls.Add(updateBtn);
            Controls.Add(dataBox);
            Controls.Add(loadAnotherSourseButton);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(maxStayTimeTextBox);
            Controls.Add(countTextBox);
            Controls.Add(pageNumTextBox);
            Controls.Add(nextBtn);
            Controls.Add(prevBtn);
            Controls.Add(sortBtn);
            Controls.Add(selectedItemTextBox);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(filterbutton);
            Controls.Add(label6);
            Controls.Add(tobox);
            Controls.Add(frombox);
            Controls.Add(SearchButton);
            Controls.Add(label5);
            Controls.Add(SearchBar);
            Controls.Add(addButton);
            Controls.Add(untilTextBox);
            Controls.Add(label4);
            Controls.Add(staysforTextBox);
            Controls.Add(label3);
            Controls.Add(apartmentTextBox);
            Controls.Add(label2);
            Controls.Add(phoneTextBox);
            Controls.Add(label1);
            Controls.Add(listView1);
            Name = "MainForm";
            Text = "Apartment Booking";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView listView1;
        private Label label1;
        private MaterialSkin.Controls.MaterialTextBox2 phoneTextBox;
        private MaterialSkin.Controls.MaterialTextBox2 apartmentTextBox;
        private Label label2;
        private MaterialSkin.Controls.MaterialTextBox2 staysforTextBox;
        private Label label3;
        private Label label4;
        private DateTimePicker untilTextBox;
        private ColumnHeader Id;
        private ColumnHeader Phone_Number;
        private ColumnHeader Apartment;
        private ColumnHeader Stays_for;
        private ColumnHeader Stays_Until;
        private MaterialSkin.Controls.MaterialButton addButton;
        private MaterialSkin.Controls.MaterialTextBox2 SearchBar;
        private Label label5;
        private MaterialSkin.Controls.MaterialButton SearchButton;
        private MaterialSkin.Controls.MaterialTextBox2 frombox;
        private MaterialSkin.Controls.MaterialTextBox2 tobox;
        private Label label6;
        private MaterialSkin.Controls.MaterialButton filterbutton;
        private Label label7;
        private Label label8;
        private Label label9;
        private TextBox selectedItemTextBox;
        private ColumnHeader idColumn;
        private MaterialSkin.Controls.MaterialButton sortBtn;
        private MaterialSkin.Controls.MaterialButton prevBtn;
        private MaterialSkin.Controls.MaterialButton nextBtn;
        private TextBox pageNumTextBox;
        private TextBox countTextBox;
        private TextBox maxStayTimeTextBox;
        private Label label10;
        private Label label11;
        private MaterialSkin.Controls.MaterialButton loadAnotherSourseButton;
        private OpenFileDialog fileDialog;
        private TextBox dataBox;
        private MaterialSkin.Controls.MaterialButton updateBtn;
        private ComboBox selectColBox;
        private Label label12;
        private Label label13;
        private Label label14;
        private MaterialSkin.Controls.MaterialButton showDataBtn;
        private TextBox idBox;
        private TextBox dataReserveBox;
        private TextBox columnReserveBox;
        private MaterialSkin.Controls.MaterialButton queryPerformer;
    }
}
