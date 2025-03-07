﻿using Common.Models;

namespace DataAccess.Interfaces;

public interface IOrderRepository : IRepository<Order>
{
    Task UpdateOrderIsShipped(int id, bool isShipped);
    Task<IEnumerable<Order>> GetAllOrdersAndOrderDetails();
}