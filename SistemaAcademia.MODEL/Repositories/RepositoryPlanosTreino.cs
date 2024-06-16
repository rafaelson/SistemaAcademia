using SistemaAcademia.MODEL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademia.MODEL.Repositories
{
    public class RepositoryPlanosTreino : RepositoryBase<PlanosTreino>
    {
        public RepositoryPlanosTreino(SistemaAcademiaContext context, bool saveChanges = true) : base(context, saveChanges)
        {

        }
    }
}
