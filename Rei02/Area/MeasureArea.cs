using Rei02.Buhin.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rei02.Area
{
    internal sealed class MeasureArea : AreaBase
    {
        private Condition _condition = Condition.Normal;

        public MeasureArea(KaisouEntity entity) : base(entity)
        {
        }

        public override void Add(AreaBase area)
        {
            throw new ArgumentException($"Addはできません this.Id ={Id} arg.Id={area.Id}");
        }

        public override void Alarm()
        {
            // DBの登録など・・・
            _condition = Condition.Alarm;
        }

        public override IEnumerable<AreaBase> GetChildren()
        {
            return new List<AreaBase>();
        }

        public override Condition GetCondition()
        {
            return _condition;
        }

        public override void Release()
        {
            // DBの登録など・・・

            _condition = Condition.Normal;

        }
    }
}
