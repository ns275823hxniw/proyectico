using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyectico
{
    public partial class ToDoList : Form
    {
        public ToDoList()
        {
            InitializeComponent();
        }
        DataTable todolist = new DataTable();
        bool isEditing = false;
        private void ToDoList_Load(object sender, EventArgs e)
        {
            todolist.Columns.Add("Title");
            todolist.Columns.Add("Description");

            ToDoListView.DataSource = todolist;
        }

        private void Newbutton_Click(object sender, EventArgs e)
        {
            TitleTextBox.Text = "";
            DescriptionTextBox.Text = "";
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            isEditing = true;
            TitleTextBox.Text = todolist.Rows[ToDoListView.CurrentCell.RowIndex].ItemArray[0].ToString();
            DescriptionTextBox.Text = todolist.Rows[ToDoListView.CurrentCell.RowIndex].ItemArray[1].ToString();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                todolist.Rows[ToDoListView.CurrentCell.RowIndex].Delete();
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (isEditing)
            {

             todolist.Rows[ToDoListView.CurrentCell.RowIndex]["Title"] = TitleTextBox.Text;
                todolist.Rows[ToDoListView.CurrentCell.RowIndex]["Description"] = DescriptionTextBox.Text;
            }
            else
            {
                todolist.Rows.Add(TitleTextBox.Text, DescriptionTextBox.Text);
            }
            TitleTextBox.Text = "";
            DescriptionTextBox.Text = "";
            isEditing = false;
        }
    }
}