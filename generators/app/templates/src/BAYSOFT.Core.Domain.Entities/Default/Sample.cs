using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace <%= _ProjectName %>.Core.Domain.Entities.<%= _Context %>
{
    public class <%= _Entity %> : DomainEntity
    {
        public <%= _EntityIDType %> <%= _EntityID %> { get; set; }
        
        public <%= _Entity %>()
        {
        }
    }
}
