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
            var k = new BlockArea("ä÷ìå");
            var a = new BlockArea("ìåãû");
            var a1 = new MeasureArea("óßêÏ");
            var a2 = new MeasureArea("éOëÈ");

            k.Add(a);
            a.Add(a1);
            a.Add(a2);

            var kNode = new TreeNode(k.Name, 0, 0);
            var aNode = new TreeNode(a.Name, 0, 0);
            var a1Node = new TreeNode(a1.Name, 0, 0);
            var a2Node = new TreeNode(a2.Name, 0, 0);

            treeView1.Nodes.Add(kNode);
            kNode.Nodes.Add(aNode);
            aNode.Nodes.Add(a1Node);
            aNode.Nodes.Add(a2Node);
        }
    }
}