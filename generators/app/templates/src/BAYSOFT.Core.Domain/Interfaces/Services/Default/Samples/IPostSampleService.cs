﻿using BAYSOFT.Abstractions.Core.Domain.Interfaces.Services;
using <%= _ProjectName %>.Core.Domain.Entities.<%= _Context %>;

namespace <%= _ProjectName %>.Core.Domain.Interfaces.Services.<%= _Context %>.<%= _Collection %>
{
    public <%= _EntityIDType %>erface IPost<%= _Entity %>Service : IDomainService<<%= _Entity %>>
    {
    }
}
