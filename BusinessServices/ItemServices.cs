using AutoMapper;
using BusinessEntities;
using DataModel;
using DataModel.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices
{
    public class ItemServices : IItemServices
    {
        private readonly UnitOfWork _unitOfWork;
        internal MonitoreoDbEntities Context;

        /// <summary>
        /// Public constructor.
        /// </summary>
        public ItemServices()
        {
            _unitOfWork = new UnitOfWork();
            this.Context = new MonitoreoDbEntities();
        }

        /// <summary>
        /// Fetches items by idUser
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>IEnumerable<ItemEntity></returns>
        public IEnumerable<ItemEntity> GetItemByUser(string userId)
        {
            int _idUsuario = Int32.Parse(userId);
            var items = _unitOfWork.ItemRepository.GetMany(c => c.IdUsuario == _idUsuario).ToList();
            if (items.Any())
            {
                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<Item, ItemEntity>();
                });
                var itemsModel = Mapper.Map<List<Item>, List<ItemEntity>>(items);

                return itemsModel;
            }
            return null;
        }

        /// <summary>
        /// Obtiene objetos item y registro y los combina
        /// en un objeto para facilidad en el front
        /// </summary>
        /// <param name="items", "registros"></param>
        /// <returns>IEnumerable<VehiculosEntity></returns>
        public IEnumerable<VehiculosEntity> SetVehiculos(IEnumerable<ItemEntity> items, IEnumerable<RegistroEntity> registros)
        {
            List<VehiculosEntity> vehiculos = new List<VehiculosEntity>();
            List<ItemEntity> itemsList = items.ToList();
            List<RegistroEntity> registrosList = registros.ToList();

            for (int i = 0; i< itemsList.Count; i++)
            {
                VehiculosEntity vehiculo = new VehiculosEntity
                {
                    IdItem = itemsList[i].IdItem,
                    IdTipoItem = itemsList[i].IdTipoItem,
                    IdRegistro = registrosList[i].IdRegistro,
                    Placa = itemsList[i].Placa,
                    Informacion = itemsList[i].Informacion,
                    Latitud = registrosList[i].Latitud,
                    Longitud = registrosList[i].Longitud,
                    TanqueConductor = registrosList[i].TanqueConductor,
                    TanquePasajero = registrosList[i].TanquePasajero,
                    BotonPanico = registrosList[i].BotonPanico,
                    Kilometraje = registrosList[i].Kilometraje,
                    Velocidad = registrosList[i].Velocidad,
                    Fecha = registrosList[i].Fecha,
                    Hora = registrosList[i].Hora,
                };
                vehiculos.Add(vehiculo);
            }

            return vehiculos;
        }
    }
}