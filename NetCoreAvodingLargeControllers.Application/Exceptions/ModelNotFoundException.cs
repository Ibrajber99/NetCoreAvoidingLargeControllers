using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreAvodingLargeControllers.Application.Exceptions
{
    public class ModelNotFoundException : ApplicationException
    {
        public ModelNotFoundException(string name, object key)
                : base($"{name} ({key}) is not found")
        {

        }


    }
}
