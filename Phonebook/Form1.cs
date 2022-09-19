using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phonebook
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            try
            {
                foreach (var line in File.ReadLines("db.txt"))
                {
                    var use = User.deserialize(line);
                    dataGridView1.Rows.Add(use.FirstName, use.LastName, use.Phone, use.Email);
                }
            }
            catch { }
        }
        private void usuńToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    dataGridView1.Rows.RemoveAt(this.dataGridView1.SelectedRows[0].Index);
                }
                catch
                {
                    MessageBox.Show("Error");
                }
                
            } 
        }
        private void dodajToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUser fuser = new FormUser();
            fuser.ShowDialog();
            if (fuser.DialogResult == DialogResult.OK)
            {
                var row = new DataGridViewRow();
                row.CreateCells(dataGridView1);
                row.SetValues(fuser.user.FirstName, fuser.user.LastName, fuser.user.Phone, fuser.user.Email);
                dataGridView1.Rows.Add(row);
                var s = fuser.user.serialize();
                var file = new StreamWriter("db.txt", append: true);
                file.WriteLine(s);
                file.Close();
            }
                
        }

        private void edytujToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormUser fuser = new FormUser(dataGridView1.SelectedRows[0].Cells[0].Value.ToString(), dataGridView1.SelectedRows[0].Cells[1].Value.ToString(), dataGridView1.SelectedRows[0].Cells[2].Value.ToString(), dataGridView1.SelectedRows[0].Cells[3].Value.ToString());
            fuser.ShowDialog();
            if(fuser.DialogResult == DialogResult.OK)
            {
                dataGridView1.SelectedCells[0].Value = fuser.user.FirstName;
                dataGridView1.SelectedCells[1].Value = fuser.user.LastName;
                dataGridView1.SelectedCells[2].Value = fuser.user.Phone;
                dataGridView1.SelectedCells[3].Value = fuser.user.Email;
            }
        }


        private void zapiszToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var line in File.ReadLines("db.txt"))
            {
                var use = User.deserialize(line);
                dataGridView1.Rows.Add(use.FirstName, use.LastName, use.Phone, use.Email);
            }
        }

        private void otworzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    var fileStream = openFileDialog.OpenFile();

                    dataGridView1.Rows.Clear();
                    foreach (var line in File.ReadLines(openFileDialog.FileName))
                    {
                        var use = User.deserialize(line);
                        dataGridView1.Rows.Add(use.FirstName, use.LastName, use.Phone, use.Email);
                    }
                }
            }
        }
    }
}
