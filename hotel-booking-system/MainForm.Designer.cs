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
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { Id, Phone_Number, Apartment, Stays_for, Stays_Until });
            listView1.Location = new Point(6, 139);
            listView1.Name = "listView1";
            listView1.Size = new Size(519, 290);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
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
            Apartment.Width = 70;
            // 
            // Stays_for
            // 
            Stays_for.Text = "Stays for";
            Stays_for.TextAlign = HorizontalAlignment.Center;
            // 
            // Stays_Until
            // 
            Stays_Until.Text = "Stays_Until";
            Stays_Until.TextAlign = HorizontalAlignment.Center;
            Stays_Until.Width = 100;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(531, 86);
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
            phoneTextBox.Location = new Point(531, 104);
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
            phoneTextBox.Size = new Size(250, 48);
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
            apartmentTextBox.Location = new Point(531, 183);
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
            apartmentTextBox.Size = new Size(250, 48);
            apartmentTextBox.TabIndex = 4;
            apartmentTextBox.TabStop = false;
            apartmentTextBox.TextAlign = HorizontalAlignment.Left;
            apartmentTextBox.TrailingIcon = null;
            apartmentTextBox.UseSystemPasswordChar = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(531, 165);
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
            staysforTextBox.Location = new Point(531, 263);
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
            staysforTextBox.Size = new Size(250, 48);
            staysforTextBox.TabIndex = 6;
            staysforTextBox.TabStop = false;
            staysforTextBox.TextAlign = HorizontalAlignment.Left;
            staysforTextBox.TrailingIcon = null;
            staysforTextBox.UseSystemPasswordChar = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(531, 245);
            label3.Name = "label3";
            label3.Size = new Size(87, 15);
            label3.TabIndex = 5;
            label3.Text = "Stays for (days)";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(531, 325);
            label4.Name = "label4";
            label4.Size = new Size(61, 15);
            label4.TabIndex = 7;
            label4.Text = "Stays until";
            // 
            // untilTextBox
            // 
            untilTextBox.CustomFormat = "dd/MM/yyyy hh:mm tt";
            untilTextBox.Format = DateTimePickerFormat.Custom;
            untilTextBox.Location = new Point(531, 343);
            untilTextBox.Name = "untilTextBox";
            untilTextBox.Size = new Size(200, 23);
            untilTextBox.TabIndex = 8;
            // 
            // addButton
            // 
            addButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            addButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            addButton.Depth = 0;
            addButton.HighEmphasis = true;
            addButton.Icon = null;
            addButton.Location = new Point(667, 393);
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
            SearchBar.Size = new Size(273, 48);
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
            SearchButton.Location = new Point(285, 96);
            SearchButton.Margin = new Padding(4, 4, 4, 4);
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
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
            Load += Form1_Load;
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
    }
}
