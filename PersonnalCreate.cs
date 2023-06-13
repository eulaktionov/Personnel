using System.Drawing.Printing;
using System.Windows.Forms;

using static System.Windows.Forms.Design.AxImporter;

namespace Personnel
{
    partial class PersonnelForm
    {
        public const int _Margin = 10;
        public const int _Width = 100;
        public const int _Height = 30;

        void CreateControls()
        {
            List = new()
            {
                Width = _Width * 2,
                Dock = DockStyle.Left
            };
            List.SelectedIndexChanged += (s, e) => Show();
            Controls.Add(List);

            GroupBox group = new()
            {
                Top = _Margin,
                Left = List.Right + _Margin,
                Text = "Employee:"
            };
            Controls.Add(group);

            Name = new()
            {
                Top = _Margin * 4,
                Left = _Width,
                Width = _Width * 2
            };
            group.Controls.Add(Name);
            Label _ = new()
            {
                Top = Name.Top,
                Left = _Margin,
                Text = "&Name:"
            };
            group.Controls.Add(_);

            Age = new()
            {
                Top = Name.Bottom + _Margin * 2,
                Left = Name.Left,
                Width = _Width * 2,
                Minimum = 18,
                Maximum = 80,
                Increment = 1,
                TextAlign = HorizontalAlignment.Center
            };
            group.Controls.Add(Age);
            _ = new()
            {
                Top = Age.Top,
                Left = _Margin,
                Text = "A&ge:"
            };
            group.Controls.Add(_);

            Male = new()
            {
                Top = Age.Bottom + _Margin * 2,
                Left = _Width,
                Text = "&Mail",
                Checked = true
            };
            group.Controls.Add(Male);

            Female = new()
            {
                Top = Male.Bottom + _Margin,
                Left = _Width,
                Text = "&Femail"
            };
            group.Controls.Add(Female);

            PositionList = new()
            {
                Top = Female.Bottom + _Margin,
                Left = _Width,
                Width = _Width * 2
            };
            group.Controls.Add(PositionList);
            _ = new()
            {
                Top = PositionList.Top,
                Left = _Margin,
                Text = "&Position:"
            };
            group.Controls.Add(_);

            group.Width = Name.Right + _Margin * 2;
            group.Height = PositionList.Bottom + _Margin * 2;

            _Button add = new()
            {
                Top = group.Bottom + _Margin * 2,
                Left = group.Left,
                Text = "&Add"
            };
            add.Click += (s, e) => Add();
            Controls.Add(add);

            _Button remove = new()
            {
                Top = add.Top,
                Left = add.Right + _Margin,
                Text = "&Remove"
            };
            remove.Click += (s, e) => Remove();
            Controls.Add(remove);

            _Button update = new()
            {
                Top = add.Top,
                Left = remove.Right + _Margin,
                Text = "&Update"
            };
            update.Click += (s, e) => Update();
            Controls.Add(update);

            _Button save = new()
            {
                Top = add.Bottom + _Margin * 2,
                Left = add.Left,
                Text = "&Save"
            };
            save.Click += (s, e) => Save();
            Controls.Add(save);

            _Button open = new()
            {
                Top = save.Top,
                Left = remove.Left,
                Text = "&Open"
            };
            open.Click += (s, e) => Open();
            Controls.Add(open);

            _Button positions = new()
            {
                Top = save.Top,
                Left = update.Left,
                Text = "Posi&tions"

            };
            positions.Click += (s, e) => EditPostions();
            Controls.Add(positions);

            _Button calculate = new()
            {
                Top = save.Bottom + _Margin * 2,
                Left = save.Left,
                Text = "&Calculate"

            };
            calculate.Click += (s, e) => Calculate();
            Controls.Add(calculate);

            TotalSalary = new()
            {
                Top = calculate.Top,
                Left = calculate.Right + _Margin,
                Width = _Width,
                TextAlign = HorizontalAlignment.Center,
                ReadOnly = true
            };
            Controls.Add(TotalSalary);

            SortByName = new()
            {
                Top = TotalSalary.Bottom + _Margin * 2,
                Left = calculate.Left,
                Text = "Sort by &Name",
                AutoSize = true
            };
            SortByName.CheckedChanged += (s, e) => Sort();
            Controls.Add(SortByName);

            SortBySalary = new()
            {
                Top = SortByName.Top,
                Left = TotalSalary.Left + _Width/2,
                Text = "Sort by &Salary",
                AutoSize = true
            };
            SortBySalary.CheckedChanged += (s, e) => Sort();
            Controls.Add(SortBySalary);

            ClientSize = new(group.Right + _Margin * 2,
                SortBySalary.Bottom + _Margin * 2);
        }
    }

    class _Button : Button
    {
        public _Button()
        {
            Width = PersonnelForm._Width;
            Height = PersonnelForm._Height;
        }
    }
}
