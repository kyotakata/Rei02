using Rei02.Area;
using Rei02.Buhin.Data;
using System.Xml.Linq;

namespace Rei02
{
    public partial class Form1 : Form
    {
        private List<AreaBase> _areas = new List<AreaBase>();

        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            treeView1.HideSelection = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // データを作る
            //var k = new BlockArea("関東");
            //var a = new BlockArea("東京");
            //var a1 = new MeasureArea("立川");
            //var a2 = new MeasureArea("三鷹");

            //var s = new BlockArea("四国");
            //var b = new BlockArea("香川");
            //var b1 = new MeasureArea("高松");
            var entities = KaisouFake.GetData();

            foreach (var entity in entities)
            {
                if (entity.Kind == 1)
                {
                    _areas.Add(new BlockArea(entity));
                }
                else if (entity.Kind == 2)
                {
                    _areas.Add(new MeasureArea(entity));

                }
            }

            // 親子関係を作る
            //k.Add(a);
            //a.Add(a1);
            //a.Add(a2);

            //s.Add(b);
            //b.Add(b1);
            foreach (var area in _areas)
            {
                var parent = _areas.Find(x => x.Id == area.ParentId);
                if (parent != null)
                {
                    parent.Add(area);
                }
            }

            // ルートを投げている
            //AddNode(k, null);
            //AddNode(s, null);
            var roots = _areas.FindAll(x => x.ParentId == 0);
            foreach (var root in roots)
            {
                AddNode(root, null);
            }

            //var kNode = new TreeNode(k.Name, 0, 0);
            //var aNode = new TreeNode(a.Name, 0, 0);
            //var a1Node = new TreeNode(a1.Name, 0, 0);
            //var a2Node = new TreeNode(a2.Name, 0, 0);

            //treeView1.Nodes.Add(kNode);
            //kNode.Nodes.Add(aNode);
            //aNode.Nodes.Add(a1Node);
            //aNode.Nodes.Add(a2Node);

            treeView1.ExpandAll();
        }

        private void AddNode(AreaBase area, TreeNode? parentNode)
        {
            var node = new TreeNode(area.Name, 0, 0);     // string text, int imageIndex, int selectedImageIndex
            node.Tag = area;

            if (parentNode == null)
            {
                treeView1.Nodes.Add(node);

            }
            else
            {
                parentNode.Nodes.Add(node);
            }

            foreach (var child in area.GetChildren())
            {
                AddNode(child, node);
            }
        }

        private void AlarmButton_Click(object sender, EventArgs e)
        {
            var area = treeView1.SelectedNode.Tag as AreaBase;
            if (area == null)
            {
                return;
            }

            area.Alarm();
            SetImage();
        }

        private void ReleaseButton_Click(object sender, EventArgs e)
        {
            var area = treeView1.SelectedNode.Tag as AreaBase;
            if (area == null)
            {
                return;
            }

            area.Release();
            SetImage();

        }


        private void SetImage()
        {
            foreach (TreeNode node in treeView1.Nodes)
            {
                SetImageMethod(node);
            }
        }

        private void SetImageMethod(TreeNode node)
        {
            var area = node.Tag as AreaBase;
            if (area != null)
            {
                if (area.GetCondition() == Condition.Alarm)
                {
                    node.ImageIndex = 1;
                    node.SelectedImageIndex = 1;
                }
                else
                {
                    node.ImageIndex = 0;
                    node.SelectedImageIndex = 0;

                }
            }

            foreach (TreeNode child in node.Nodes)
            {
                SetImageMethod(child);
            }
        }

    }
}