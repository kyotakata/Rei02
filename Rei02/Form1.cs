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
            var k = new BlockArea("ŠÖ“Œ");
            var a = new BlockArea("“Œ‹");
            var a1 = new MeasureArea("—§ì");
            var a2 = new MeasureArea("O‘é");

            k.Add(a);
            a.Add(a1);
            a.Add(a2);
        }
    }
}