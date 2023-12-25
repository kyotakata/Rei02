using Rei02.Buhin.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rei02.Area
{
    internal sealed class LargeBlockArea : AreaBase
    {
        private List<AreaBase> _areas = new List<AreaBase>();
        public LargeBlockArea(KaisouEntity entity) : base(entity)
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

        public override Condition GetCondition()
        {
            foreach (var area in _areas)
            {
                if (area.GetCondition() == Condition.Alarm)
                {
                    return Condition.Alarm;
                }
            }

            return Condition.Normal;
        }

        public override void Release()
        {
            throw new ArgumentException("ラージブロックエリアでの一括警報解除禁止");
        }
    }
}
