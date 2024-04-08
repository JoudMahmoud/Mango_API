using Azure.Core;
using Mango.Services.CouponAPI.Data;
using Mango.Services.CouponAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace Mango.Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponAPIController : ControllerBase
    {
        private readonly AppDbContext _db;


        public CouponAPIController(AppDbContext dbContext)
        {
            _db = dbContext;
        }

        [HttpGet]
        public object Get()
        {
            try
            {
                IEnumerable<Coupon> couponList = _db.Coupones.ToList();
                return couponList;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        [HttpGet]
        [Route("{id:int}")]
        public object Get(int id)
        {
            try
            {
                Coupon coupon = _db.Coupones.First(c=>c.CouponId==id);
                return coupon;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
