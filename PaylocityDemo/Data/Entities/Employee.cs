using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PaylocityDemo.Data.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime ModifiedDate { get; set; }

        [JsonIgnore]
        public ICollection<Dependent> Dependents { get; set; }
    }
}
