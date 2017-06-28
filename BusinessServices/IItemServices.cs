using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices
{
    public interface IItemServices
    {
        IEnumerable<ItemEntity> GetItemByUser(string userId);
        IEnumerable<VehiculosEntity> SetVehiculos(IEnumerable<ItemEntity> items, IEnumerable<RegistroEntity>  registros);
    }
}
