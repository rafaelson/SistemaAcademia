using SistemaAcademia.MODEL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademia.MODEL.Repositories
{
    public class RepositoryMembros : RepositoryBase<Membros>
    {
        public RepositoryMembros(SistemaAcademiaContext context, bool saveChanges = true) : base(context, saveChanges)
        {

        }
    }
}
