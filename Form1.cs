using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace WinFormsApp2
{

    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();

        }
        public class MySettings
        {
            public MySettings(string text, Color backColor, Size size)
            {
                Text = text;
                BackColor = backColor;
                Size = size;
            }

            public string Text { get; set; }
            public Color BackColor { get; set; }
            public Size Size { get; set; }
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (Program.Configuration != null)
            {
                string DevConnectionString = Program.Configuration.GetConnectionString("DevConnection");



                var DevCon = new SqlConnection(DevConnectionString);

                DevCon.Open();
                var sql = "EXEC usp_readtest";
                var result = DevCon.Query<string>(sql).ToList();
                listBox1.DataSource = result;



                var mySettings = Program.Configuration.GetSection("MySettings").Get<MySettings>();
                if (mySettings != null)
                {
                    label1.Text = "Windows Forms Example";
                    this.Text = mySettings.Text;
                    this.BackColor = mySettings.BackColor;
                    this.Size = mySettings.Size;
                }
            }
        }
    }
}