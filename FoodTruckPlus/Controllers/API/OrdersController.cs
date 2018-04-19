using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Net.Http;
using System.Web.Http;
using FoodTruckPlus.Dtos;
using FoodTruckPlus.Models;
using AutoMapper;
using System.Web.Http.Results;

namespace FoodTruckPlus.Controllers.Api
{


    public class OrdersController : ApiController
    {
        private ApplicationDbContext _context;

        public OrdersController()
        {
            _context = new ApplicationDbContext();
        }


        //Get/Api/Orders
        [HttpGet]
        public IEnumerable<OrderDto> GetOrders()
        {
            return _context.Orders.ToList().Select(Mapper.Map<Order, OrderDto>);
        }

        [HttpGet]
        //Get /api/orders/1
        public IHttpActionResult GetOrder(int id)
        {
            var order = _context.Orders.SingleOrDefault(o => o.Id == id);
           
            if (order == null)
            {
                return NotFound();
            };


            return Ok(Mapper.Map<Order, OrderDto>(order));
        }

        [HttpPost]
        public IHttpActionResult CreateOrder(OrderDto orderDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var order = Mapper.Map<OrderDto, Order>(orderDto);
            _context.Orders.Add(order);
            _context.SaveChanges();

            orderDto.Id = order.Id;

            return Created(new Uri(Request.RequestUri + "/" + order.Id), orderDto);

        }



        //Put /api/messages/1

        [HttpPut]
        public void UpdateOrder(int id, OrderDto orderDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            };

            var orderInDb = _context.Orders.SingleOrDefault(o => o.Id == id);

            if (orderInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            };

            Mapper.Map<OrderDto, Order>(orderDto, orderInDb);

            orderInDb.MenuItems = orderDto.MenuItems;
            orderInDb.Paid = orderDto.Paid;
            orderInDb.TimeDesiredReady = orderDto.TimeDesiredReady;
            orderInDb.TimePurchased = orderDto.TimePurchased;


            //messageInDb.Message = messageDto.Message;
            //messageInDb.DisplayName = messageDto.DisplayName;
            _context.SaveChanges();
        }


        //Delete /api/customers/1
        [HttpDelete]
        public void DeleteOrder(int id)
        {
            var orderInDb = _context.Orders.SingleOrDefault(o => o.Id == id);

            if (orderInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            };

            _context.Orders.Remove(orderInDb);
            _context.SaveChanges();
        }


    }
}
