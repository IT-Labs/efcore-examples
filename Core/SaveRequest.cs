using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public abstract class SaveRequest : IRequest
    {
        private int? _id;
        public bool IsNew() => !_id.HasValue;

        public int? GetId() => _id;
        public void SetId(int? id) => _id = id;
    }
}
