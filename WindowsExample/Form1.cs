using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var jsonTask = GetJsonAsync(new Uri("http://jsonplaceholder.typicode.com/photos"));
            await Task.Delay(5000);
            jsonTask.Wait();
            textBox1.Text = jsonTask.Result;
        }

        public static async Task<string> GetJsonAsync(Uri uri)
        {
            // (real-world code shouldn't use HttpClient in a using block; this is just example code)
            using (var client = new HttpClient())
            {
                var jsonString = await client.GetStringAsync(uri).ConfigureAwait(false);
                return jsonString;
            }
        }
    }
}
