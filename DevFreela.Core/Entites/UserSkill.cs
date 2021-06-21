using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.Entites
{
    public class UserSkill : BaseEntity
    {
        public int IdUser { get; private set; }
        public int IdSkill { get; private set; }
    }
}
