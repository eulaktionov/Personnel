using System.Drawing.Printing;
using System.Windows.Forms;

using static System.Windows.Forms.Design.AxImporter;

namespace Personnel
{
    partial class PositionForm
    {
        void CreateControls()
        {
            List = new()
            {
                Width = PersonnelForm._Width * 2,
                Dock = DockStyle.Left
            };
            List.SelectedIndexChanged += (s, e) => Show();
            Controls.Add(List);

            GroupBox group = new()
            {
                Top = PersonnelForm._Margin,
                Left = List.Right + PersonnelForm._Margin,
                Text = "Position:"
            };
            Controls.Add(group);

            Name = new()
            {
                Top = PersonnelForm._Margin * 4,
                Left = PersonnelForm._Width,
                Width = PersonnelForm._Width * 2
            };
            group.Controls.Add(Name);
            Label _ = new()
            {
                Top = Name.Top,
                Left = PersonnelForm._Margin,
                Text = "&Name:"
            };
            group.Controls.Add(_);

            Salary = new()
            {
                Top = Name.Bottom + PersonnelForm._Margin * 2,
                Left = PersonnelForm._Width,
                Width = PersonnelForm._Width * 2,
                Minimum = 500,
                Maximum = 5000,
                Increment = 100,
                TextAlign = HorizontalAlignment.Center
            };
            group.Controls.Add(Salary);
            _ = new()
            {
                Top = Salary.Top,
                Left = PersonnelForm._Margin,
                Text = "&Salary:"
            };
            group.Controls.Add(_);

            group.Width = Name.Right + PersonnelForm._Margin * 2;
            group.Height = Salary.Bottom + PersonnelForm._Margin * 2;

            _Button add = new()
            {
                Top = group.Bottom + PersonnelForm._Margin * 2,
                Left = group.Left,
                Text = "&Add"
            };
            add.Click += (s, e) => Add();
            Controls.Add(add);

            _Button remove = new()
            {
                Top = add.Top,
                Left = add.Right + PersonnelForm._Margin,
                Text = "&Remove"
            };
            remove.Click += (s, e) => Remove();
            Controls.Add(remove);

            _Button update = new()
            {
                Top = add.Top,
                Left = remove.Right + PersonnelForm._Margin,
                Text = "&Update"
            };
            update.Click += (s, e) => Update();
            Controls.Add(update);

            ClientSize = new(group.Right + PersonnelForm._Margin * 2,
                remove.Bottom + PersonnelForm._Margin * 2);
        }
    }

}
