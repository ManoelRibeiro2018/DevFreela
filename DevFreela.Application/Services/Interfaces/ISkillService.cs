﻿using DevFreela.Application.InputModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Services.Interfaces
{
     public interface ISkillService
    {
        List<SkillViewModel> GetAll();
    }
}
