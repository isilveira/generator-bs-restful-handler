﻿using <%= _ProjectName %>.Core.Domain.Entities.<%= _Context %>;
using Microsoft.EntityFrameworkCore;

namespace <%= _ProjectName %>.Core.Domain.Interfaces.Infrastructures.Data.Contexts
{
    public <%= _EntityIDType %>erface I<%= _Context %>DbContextQuery
    {
        public DbSet<<%= _Entity %>> <%= _Collection %> { get; set; }
    }
}