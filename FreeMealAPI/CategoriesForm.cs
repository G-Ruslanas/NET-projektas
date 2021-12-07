using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FreeMealAPI.Provider;

namespace FreeMealAPI
{
    public partial class CategoriesForm : Form
    {
        public CategoriesForm()
        {
            InitializeComponent();
        }



        private void CategoriesForm_Load(object sender, EventArgs e)
        {
            var provider = new API();
            var listViewItem = provider.GetCategories();
            foreach (var i in listViewItem)
            {
                var item = new ListViewItem(new[] { i.idCategory, i.strCategory });
                CategoriesList.Items.Add(item);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (CategoriesList.SelectedItems.Count > 0)
            {
                var SelectedItem = CategoriesList.SelectedItems[0].SubItems[1].Text;
                var provider = new API();
                var listViewItem = provider.GetCategories();
                foreach (var i in listViewItem)
                {
                    if (i.strCategory == SelectedItem)
                    {
                        textBox1.Text = i.strCategoryDescription;
                    }
                }
            }
            else MessageBox.Show("Please, select category from the list");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (CategoriesList.SelectedItems.Count > 0)
            {
                var SelectedItem = CategoriesList.SelectedItems[0].SubItems[1].Text;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.ImageLocation = "https://www.themealdb.com/images/category/" + SelectedItem + ".png";
            }
            else MessageBox.Show("Please, select category from the list");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = new MainForm();
            main.ShowDialog();
            this.Close();
        }
    }
}
