using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Personnel
{
    public partial class PositionForm : Form
    {
        ListBox List;

        TextBox Name;
        NumericUpDown Salary;

        public List<Position> positions { get; set; }

        public PositionForm()
        {
            InitializeComponent();
            CreateControls();
            Load += (s, e) => SetForm();
        }

        void SetForm()
        {
            Text = "Positions";
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            
            foreach (var position in positions)
            {
                List.Items.Add(position.Name);
            }
            if (List.Items.Count > 0)
            {
                List.SelectedIndex = 0;
            }
        }

        void Add()
        {
            positions.Add(new()
            {
                Name = Name.Text,
                Salary = Salary.Value
            });
            List.Items.Add(Name.Text);
            List.SelectedIndex = List.Items.Count - 1;
        }

        void Remove()
        {
            int current = List.SelectedIndex;
            if (current != -1)
            {
                positions.RemoveAt(current);
                List.Items.RemoveAt(current);
            }
            if (current != 0)
            {
                if (current == List.Items.Count) 
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
                positions[current].Name = Name.Text;
                positions[current].Salary = Salary.Value;
                List.Items[current] = Name.Text;
            }
        }

        void Show()
        {
            int current = List.SelectedIndex;
            if(current != -1)
            {
                Name.Text = positions[current].Name;
                Salary.Value = positions[current].Salary;
            }
        }
    }
}
