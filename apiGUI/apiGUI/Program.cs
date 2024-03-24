namespace apiGUI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}

namespace StudentAPI
2 {
3 public partial class FormStudent : Form
4 {
5 private HttpClient client;
6 public Form1()
7 {
8 InitializeComponent();
9 client = new HttpClient();
10 }
11 private async void buttonDownload_ClickAsync(object sender, EventArgs e)
12 {
13 string call = " http :// radoslaw . idzikowski . staff . iiar . pwr . wroc .pl/
instruction / students.json ";
14 string response = await client.GetStringAsync(call);
15 textBoxResponse.Text = response ;
16 }
17 }
18 }