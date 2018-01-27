﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YYG.Entity;
using YYG.IRepository;

namespace YYG.Repository
{
   public class PoliceRepository : BaseRepository<PoliceEnity>, IPoliceRepository
    {
        public PoliceRepository(DbContext context):base(context)
        {
        }
    }
}
