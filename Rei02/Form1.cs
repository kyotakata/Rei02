using Rei02.Area;

namespace Rei02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            treeView1.HideSelection = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var k = new BlockArea("関東");
            var a = new BlockArea("東京");
            var a1 = new MeasureArea("立川");
            var a2 = new MeasureArea("三鷹");

            k.Add(a);
            a.Add(a1);
            a.Add(a2);
        }
    }
}