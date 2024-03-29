﻿using System;
using CompleteDotNetCore.DataAccess.Repository.IRepository;
using CompleteDotNetCore.Models;

namespace CompleteDotNetCore.DataAccess.Repository
{
    public class OrderHeaderRepository : Repository<OrderHeader>,
        IOrderHeaderRepository
    {
        private readonly ApplicationDbContext _db;

        public OrderHeaderRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(OrderHeader obj)
        {
            _db.OrderHeaders.Update(obj);
        }

        public void UpdateStatus(int id, string orderStatus,
            string? paymentStatus = null)
        {
            OrderHeader orderFromDb = _db.OrderHeaders.FirstOrDefault(
                u => u.Id == id);

            if (orderFromDb != null)
            {
                orderFromDb.OrderStatus = orderStatus;
                if (paymentStatus != null)
                {
                    orderFromDb.PaymentStatus = paymentStatus;
                }
            }
        }

        public void UpdateStripePaymentId(int id, string sessionId,
            string paymentIntentId)
        {
            OrderHeader orderFromDb = _db.OrderHeaders.FirstOrDefault(
                u => u.Id == id);
            orderFromDb.PaymentDate = DateTime.UtcNow;
            orderFromDb.SessionId = sessionId;
            orderFromDb.PaymentIntentId = paymentIntentId;
        }
    }
}

