using MVCWebAPITutorial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace MVCWebAPITutorial.Controllers { 


	public class OrdersController : ApiController{

		private MVCWebApiDbContext db = new MVCWebApiDbContext();

		[HttpGet]
		[ActionName("List")]
		public IEnumerable<Order> List()
		{
			return db.Orders.ToList();

		}
		[HttpGet]
		[ActionName("Get")]
		public Order Get(int? id)
		{  //making this int? allows null to be passed in so back side doesn;t blowup
			if (id == null)
				return null;
			return db.Orders.Find(id);
		}
		[HttpPost]
		[ActionName("Create")]
		public bool Create(Order order)
		{
			if (order == null)
				return false;
			if (!ModelState.IsValid) {
				return false;
			}
			db.Orders.Add(order);
			db.SaveChanges();
			return true;
		}
		[HttpPost]
		[ActionName("Change")]
		public bool Change(Order order)
		{
			if (order == null)
				return false;
			if (!ModelState.IsValid) {
				return false;
			}
			var ord = db.Orders.Find(order.Id);
			ord.Description = order.Description;
			ord.Total = order.Total;
			ord.CustomerId= order.CustomerId;
			
			db.SaveChanges();
			return true;
		}
		[HttpPost]
		[ActionName("Remove")]
		public bool Remove(Order order)
		{
			if (order == null)
				return false;
			if (!ModelState.IsValid) {
				return false;
			}
			var cust = db.Orders.Find(order.Id);
			db.Orders.Remove(cust);
			db.SaveChanges();
			return true;
		}

	}
}
