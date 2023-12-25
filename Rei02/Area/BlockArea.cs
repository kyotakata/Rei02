using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rei02.Area
{
    internal sealed class BlockArea : AreaBase
    {
        private List<AreaBase> _areas = new List<AreaBase>();
        public BlockArea(string name) : base(name)
        {
        }

        public override void Add(AreaBase area)
        {
            _areas.Add(area);
        }

        public override void Alarm()
        {
            throw new ArgumentException("一括警報設定はできません");
        }

        public override IEnumerable<AreaBase> GetChildren()
        {
            return _areas;
        }
    }
}
