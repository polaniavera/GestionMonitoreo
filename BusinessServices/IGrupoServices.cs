using BusinessEntities;
using System.Collections.Generic;

namespace BusinessServices
{
    public interface IGrupoServices
    {
        IEnumerable<GrupoEntity> GetGruposByUser(string userId);
    }
}

