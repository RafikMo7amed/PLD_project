using com.calitha.goldparser;
namespace final_project
{
    public partial class Form1 : Form
    {
        MyParser P;
        public Form1()
        {
            InitializeComponent();
            P = new MyParser("final_project.cgt", listBox1, listBox2);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            P.Parse(textBox1.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
