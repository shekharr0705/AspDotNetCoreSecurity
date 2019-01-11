using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspDotNetCoreSecurity.Models
{
    public class AttendeeModel
    {
        public int Id { get; set; }
        public int ConferenceId { get; set; }
        public string Name { get; set; }
    }
}
