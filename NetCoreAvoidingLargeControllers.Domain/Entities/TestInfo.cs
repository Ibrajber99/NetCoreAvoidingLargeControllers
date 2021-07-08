using NetCoreAvoidingLargeControllers.Domain.Shared;
using System;
using System.Collections.Generic;

namespace NetCoreAvoidingLargeControllers.Domain.Entities
{
    public class TestInfo : ModifiableEntity
    {
        public int ID { get; set; }

        public string TestName { get; set; }

        public DateTime TestDate { get; set; }

        public string Description { get; set; }

        public ICollection<TestApplicant> TestApplicants { get; set; }
    }
}
