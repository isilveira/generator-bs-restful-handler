using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Domain.Entities.<%= _Context %>
{
    public class <%= _Entity %> : DomainEntity
    {
        public int <%= _Entity %>ID { get; set; }
        
        public <%= _Entity %>()
        {
        }
    }
}
