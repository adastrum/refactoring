using System;
using System.Collections.Generic;

namespace TestApp
{
    public abstract class MasterBase
    {
        public virtual void TryGetData(out IEnumerable<Data> data)
        {
            throw new NotImplementedException();
        }
    }
}