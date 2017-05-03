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
        public ItemServices(UnitOfWork unitOfWork,
            MonitoreoDbEntities context)
        {
            _unitOfWork = unitOfWork;
            this.Context = context;
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
    }
}