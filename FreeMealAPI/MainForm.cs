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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            CategoriesForm main = new CategoriesForm();
            main.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var provider = new API();
            var repository = new Repository(provider);
            var RandomItem = provider.GetRandomMeal();
            listView1.Items.Clear();
            foreach (var i in RandomItem)
            {
                MealName.Text = i.strMeal;
                MealArea.Text = i.strArea;
                var listViewItem = provider.GetFilteredMealsByArea(i.strArea);
                foreach (var z in listViewItem)
                {
                    var item = new ListViewItem(new[] { z.strMeal});
                    listView1.Items.Add(item);  
                }
                textBox1.Text = repository.CountMealsByArea(i.strArea).ToString() + " meals with same meal area!";
                MealInstructions.Text = i.strInstructions;
                MealImage.SizeMode = PictureBoxSizeMode.StretchImage;
                MealImage.ImageLocation = i.strMealThumb;
            }
          

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            ListByLetterForm main = new ListByLetterForm();
            main.ShowDialog();
            this.Close();
        }
    }
}
