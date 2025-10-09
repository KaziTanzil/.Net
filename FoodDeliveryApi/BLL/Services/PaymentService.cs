using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Tables;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class PaymentService
    {
        public static PaymentDTO Get(int id)
        {
            var data = DataFactory.PaymentData().Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Payment, PaymentDTO>());
            var mapper = new Mapper(config);
            return mapper.Map<PaymentDTO>(data);
        }

        public static List<PaymentDTO> Get()
        {
            var data = DataFactory.PaymentData().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Payment, PaymentDTO>());
            var mapper = new Mapper(config);
            return mapper.Map<List<PaymentDTO>>(data);
        }

        public static void Create(PaymentDTO dto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<PaymentDTO, Payment>());
            var mapper = new Mapper(config);
            DataFactory.PaymentData().Create(mapper.Map<Payment>(dto));
        }

        public static void Update(PaymentDTO dto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<PaymentDTO, Payment>());
            var mapper = new Mapper(config);
            DataFactory.PaymentData().Update(mapper.Map<Payment>(dto));
        }

        public static void Delete(int id)
        {
            DataFactory.PaymentData().Delete(id);
        }

        // Functional: Update payment status
        public static void UpdateStatus(int id, string status)
        {
            var payment = DataFactory.PaymentData().Get(id);
            if (payment == null) return;
            payment.Status = status;
            DataFactory.PaymentData().Update(payment);
        }

        // Functional: Get payments by status
        public static List<PaymentDTO> GetByStatus(string status)
        {
            var data = DataFactory.PaymentData().Get().Where(p => p.Status == status).ToList();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Payment, PaymentDTO>());
            var mapper = new Mapper(config);
            return mapper.Map<List<PaymentDTO>>(data);
        }
    }
}
