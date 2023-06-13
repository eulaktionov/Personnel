using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Personnel
{
    public partial class PersonnelForm : Form
    {
        string employeeFile = "Employees.dat";
        string positionFile = "Positions.dat";

        ListBox List;

        TextBox Name;
        NumericUpDown Age;
        RadioButton Male;
        RadioButton Female;
        ComboBox PositionList;
        TextBox TotalSalary;
        RadioButton SortBySalary;
        RadioButton SortByName;

        List<Employee> employees;
        List<Position> positions;

        public PersonnelForm()
        {
            InitializeComponent();

            employees = new();
            positions = new();
            //{
            //    new Position{Name = "111", Salary = 500},
            //    new Position{Name = "222", Salary = 700}
            //};

            CreateControls();
            SetForm();
            //FormClosed += (s, e) => Save();
        }

        void SetForm()
        {
            Text = "Personell";
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
        }

        void Add()
        {
            employees.Add(new()
            {
                Name = Name.Text,
                Age = (int)Age.Value,
                Male = Male.Checked,
                Position = (Position)PositionList.SelectedItem
            });
            List.Items.Add(Name.Text);
            List.SelectedIndex = List.Items.Count - 1;
        }

        void Remove()
        {
            int current = List.SelectedIndex;
            if(current != -1)
            {
                employees.RemoveAt(current);
                List.Items.RemoveAt(current);
            }
            if(current != 0)
            {
                if(current == List.Items.Count)
                {
                    current--;
                }
                List.SelectedIndex = current;
            }
        }

        void Update()
        {
            int current = List.SelectedIndex;
            if(current != -1)
            {
                employees[current].Name = Name.Text;
                employees[current].Age = (int)Age.Value;
                employees[current].Male = Male.Checked;
                employees[current].Position = (Position)PositionList.SelectedItem;
                List.Items[current] = Name.Text;
            }
        }

        void Show()
        {
            int current = List.SelectedIndex;
            if(current != -1)
            {
                Name.Text = employees[current].Name;
                Age.Value = employees[current].Age;
                Male.Checked = employees[current].Male;
                Female.Checked = !employees[current].Male;
                PositionList.SelectedItem = employees[current].Position;
            }
        }

        void Save()
        {
            StreamWriter writer = new StreamWriter(employeeFile);
            foreach(var item in employees)
            {
                writer.WriteLine(
                    $"{item.Name}|{item.Age}|{item.Male}|" +
                    $"{item.Position.Name}");
            }
            writer.Close();
            writer = new StreamWriter(positionFile);
            foreach(var item in positions)
            {
                writer.WriteLine($"{item.Name}|{item.Salary}");
            }
            writer.Close();
        }

        void Open()
        {
            StreamReader reader = new StreamReader(positionFile);
            string line = reader.ReadLine();
            while(line != null)
            {
                string[] fields = line.Split('|');
                positions.Add(new()
                {
                    Name = fields[0],
                    Salary = decimal.Parse(fields[1])
                });
                line = reader.ReadLine();
            }
            reader.Close();
            ResetPosition();
            if(PositionList.Items.Count > 0)
            {
                PositionList.SelectedIndex = 0;
            }

            reader = new StreamReader(employeeFile);
            line = reader.ReadLine();
            while(line != null)
            {
                string[] fields = line.Split('|');
                employees.Add(new()
                {
                    Name = fields[0],
                    Age = int.Parse(fields[1]),
                    Male = bool.Parse(fields[2]),
                    Position = FindPosition(fields[3])
                });
                List.Items.Add(fields[0]);
                line = reader.ReadLine();
            }
            reader.Close();
            if(List.Items.Count > 0)
            {
                List.SelectedIndex = 0;
                List.Focus();
            }
        }

        Position FindPosition(string name)
        {
            foreach(var item in positions)
            {
                if (item.Name == name)
                {
                    return item;
                }
            }
            return null;
        }

        void EditPostions()
        {
            PositionForm form = new()
            {
                positions = this.positions
            };
            form.ShowDialog();
            ResetPosition();
        }

        void Calculate()
        {
            decimal total = 0;
            foreach (var item in employees)
            {
                total += item.Position.Salary;
            }
            TotalSalary.Text = total.ToString();
        }

        void Sort()
        {
            if (employees.Count > 0)
            {
                if (SortByName.Checked)
                {
                    employees.Sort(NameComparison);
                }
                else
                {
                    employees.Sort(SalaryComparison);
                }
                List.Items.Clear();
                foreach(var item in employees)
                {
                    List.Items.Add(item.Name);
                }
                List.SelectedIndex = 0;
                List.Focus();
            }
        }

        int NameComparison(Employee e1, Employee e2)
        {
            return string.Compare(e1.Name, e2.Name);
        }

        int SalaryComparison(Employee e1, Employee e2)
        {
            return (int)(e1.Position.Salary - e2.Position.Salary);
        }

        void ResetPosition()
        {
            PositionList.DataSource = null;
            PositionList.DataSource = positions;
            PositionList.DisplayMember = "Name";
           // PositionList.ValueMember = "Salary";
        }
    }
}