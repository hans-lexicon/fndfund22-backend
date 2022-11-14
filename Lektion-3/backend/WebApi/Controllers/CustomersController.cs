﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Contexts;
using WebApi.Models;
using WebApi.Models.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly DataContext _context;

        public CustomersController(DataContext context)
        {
            _context = context;
        }



        [HttpPost]
        public async Task<IActionResult> Create(CustomerCreateModel model)
        {
            var customerEntity = new CustomerEntity
            {
                Name = model.Name,
                Email = model.Email
            };

            _context.Add(customerEntity);
            await _context.SaveChangesAsync();

            return new OkObjectResult(customerEntity);
        }





        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return new OkObjectResult(await _context.Customers.ToListAsync());
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var customerEntity = await _context.Customers.FindAsync(id);
            if (customerEntity != null)
                return new OkObjectResult(customerEntity);

            return new NotFoundResult();
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CustomerEntity customerEntity)
        {
            if (id == customerEntity.Id)
            {
                _context.Entry(customerEntity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return new OkObjectResult(customerEntity);
            }

            return new BadRequestResult();
        }




        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var customerEntity = await _context.Customers.FindAsync(id);
            if (customerEntity != null)
            {
                _context.Remove(customerEntity);
                await _context.SaveChangesAsync();
                return new OkResult();
            }

            return new NotFoundResult();
        }


    }
}
