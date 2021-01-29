using System;
using System.Collections.Generic;
using Application.Domains;
using Application.Interfaces.DAOs;
using Infrastructure.EF;
using Microsoft.Extensions.Logging;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DAOs
{
    public class OrderDAO : AbstractDAO, IOrderDAO
    {
        public OrderDAO(ILogger<string> logger, WatchContext context) : base(logger, context)
        {
        }

        public Order Add(Order newObject)
        {
            try
            {
                _context.Add<Order>(newObject);
                _context.SaveChangesAsync().Wait();
                return newObject;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public OrderStatus AddLogStatus(OrderStatus newObject)
        {
            try
            {
                _context.Add<OrderStatus>(newObject);
                _context.SaveChangesAsync().Wait();
                return newObject;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public Order Get(string id)
        {
            try
            {
                var re = _context.Orders.Where(item => item.Id == id)
                        .Include(item => item.OrderDetails)
                        .Include(item => item.OrderStatuses)
                        .FirstOrDefaultAsync();
                return re.Result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public ICollection<Order> GetList(DateTime start, DateTime end, int status)
        {
            try
            {
                var re = _context.Orders.Where(item => item.DateCreated >= start && item.DateCreated <= end)
                        .Include(item => item.OrderDetails)
                        .Include(item => item.OrderStatuses)
                        .ToListAsync();
                return re.Result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public ICollection<OrderStatus> GetListStatusOf(string orderId)
        {
            try
            {
                var re = _context.OrderStatuses.Where(item => item.OrderId == orderId)
                                .OrderBy(item => item.DateChanged)
                                .ToListAsync();
                return re.Result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public int GetStatus(string orderId)
        {
            try
            {
                var re = _context.OrderStatuses.Where(item => item.OrderId == orderId)
                                .OrderBy(item => item.DateChanged)
                                .Select(item => item.Status)
                                .LastOrDefaultAsync();
                return (int)re.Result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }
}