using System;
using System.Data;
using System.Reflection;
using Microsoft.EntityFrameworkCore;


namespace EFhw
{
    public partial class Form1 : Form
    {
        fruits_and_vegetablesContext context = new();
        public Form1()
        {
            InitializeComponent();

            //comboBox1.Items.Add("Infos");
            List<DbSet<PropertyInfo>> data = new();

            var props = context.GetType().GetProperties().ToList();

            foreach (var item in props)
            {
                if(item.PropertyType.ToString().Contains("DbSet"))
                {
                    comboBox1.Items.Add(item.Name);
                }
            }
            comboBox1.SelectedIndex = 0;
        }

        private void GetBtn_Click(object sender, EventArgs e)
        {
            
            switch (comboBox1.SelectedItem.ToString())
            {
                case "Infos":
                    dataGridView1.DataSource = context.Infos.ToList();
                    break;
                case "Info2s":
                    dataGridView1.DataSource = context.Info2s.ToList();
                    break;
            }
            
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            context.SaveChanges();
        }
    }
}