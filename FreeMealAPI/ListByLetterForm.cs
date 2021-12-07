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
    public partial class ListByLetterForm : Form
    {
        public ListByLetterForm()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var Search = SearchByLetter.Text.ToUpper();
            if (Search.Length == 1)
            {
                var provider = new API();
                var repository = new Repository(provider);
                var listViewItem = provider.GetMealsByLetter(Search);
                MealsByLetter.Items.Clear();
                if (listViewItem != null)
                {
                    foreach (var i in listViewItem)
                    {
                        var item = new ListViewItem(new[] { i.strMeal, i.strCategory, i.strArea, i.strTags });
                        MealsByLetter.Items.Add(item);
                    }
                    textBox1.Text = repository.CountMealsByLetter(Search).ToString() + " meals found, which starts with letter " + Search;
                }
                else
                {
                    MessageBox.Show("No Meals with specified letter found!");
                    textBox1.Text = "0" + " meals found, which starts with letter " + Search; ;
                }
            }
            else
            {
                MessageBox.Show("Be sure to write in only one letter!");
                textBox1.Text = "Search Mistake" ;
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = new MainForm();
            main.ShowDialog();
            this.Close();
        }

       
    }
}
