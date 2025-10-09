using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Tables;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class DeliveryService
    {
        public static DeliveryDTO Get(int id)
        {
            var data = DataFactory.DeliveryData().Get(id);
            var mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Delivery, DeliveryDTO>()));
            return mapper.Map<DeliveryDTO>(data);
        }

        public static List<DeliveryDTO> Get()
        {
            var data = DataFactory.DeliveryData().Get();
            var mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Delivery, DeliveryDTO>()));
            return mapper.Map<List<DeliveryDTO>>(data);
        }

        public static void Create(DeliveryDTO dto)
        {
            var mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<DeliveryDTO, Delivery>()));
            DataFactory.DeliveryData().Create(mapper.Map<Delivery>(dto));
        }

        public static void Update(DeliveryDTO dto)
        {
            var mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<DeliveryDTO, Delivery>()));
            DataFactory.DeliveryData().Update(mapper.Map<Delivery>(dto));
        }

        public static void Delete(int id)
        {
            DataFactory.DeliveryData().Delete(id);
        }

        // Functional: Update delivery status
        public static void UpdateStatus(int id, string status)
        {
            var delivery = DataFactory.DeliveryData().Get(id);
            if (delivery == null) return;
            delivery.Status = status;
            DataFactory.DeliveryData().Update(delivery);
        }

        // Functional: Get deliveries by status


        // Functional: Assign delivery to a delivery boy
        public static void AssignDelivery(int orderId, int deliveryBoyId)
        {
            var delivery = DataFactory.DeliveryData().Get().FirstOrDefault(d => d.DeliveryId == orderId);
            if (delivery == null) return;
            delivery.DeliveryBoyId = deliveryBoyId;
            delivery.Status = "Pending";
            DataFactory.DeliveryData().Update(delivery);
        }
    }
}
