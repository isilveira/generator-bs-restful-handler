﻿using BAYSOFT.Abstractions.Core.Domain.Entities;

namespace <%= _ProjectName %>.Core.Domain.Entities.<%= _Context %>
{
    public class <%= _Entity %> : DomainEntity<<%= _EntityIDType %>>
    {
        public <%= _Entity %>()
        {
        }
    }
}
