using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rei02.Area
{
    internal sealed class MeasureArea : AreaBase
    {
        public MeasureArea(string name) : base(name)
        {
        }

        public override void Add(AreaBase area)
        {
            throw new ArgumentException("Addはできません");
        }

        public override IEnumerable<AreaBase> GetChildren()
        {
            return new List<AreaBase>();
        }
    }
}
