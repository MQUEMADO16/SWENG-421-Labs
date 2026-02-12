using System;
using System.Collections.Generic;
using System.Text;

namespace M5Lab
{
    public interface OperationFactoryIF
    {
        public OperationIF create(string className);
    }
}
