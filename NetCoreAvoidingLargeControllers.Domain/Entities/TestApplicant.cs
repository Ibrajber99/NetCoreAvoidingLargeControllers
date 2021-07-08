using NetCoreAvoidingLargeControllers.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreAvoidingLargeControllers.Domain.Entities
{
    public class TestApplicant : ModifiableEntity
    {
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int TestInfoID { get; set; }

        public TestInfo TestInfo { get; set; }
    }
}
