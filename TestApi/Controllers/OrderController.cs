﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestApi.Core;
using TestApi.Interface.Repositories.Orders;
using TestApi.ModelRsDto.Users.UserDtos;
using TestApi.Models.Orders;
using TestApi.Models.Users;
using TestApi.ModelVM.Orders;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWorks;
        private readonly IMapper _mapper;

        public OrderController(IUnitOfWork unitOfWorks, IMapper mapper)
        {
            _unitOfWorks = unitOfWorks;
            _mapper = mapper;
        }
        [HttpPost]
        [Route("CreateOrder")]
        public async Task<IActionResult> CreateOrder(OrderVM orderVM)
        {
            var entity = _mapper.Map<Order>(orderVM);
            await _unitOfWorks.Orders.CreateOrder(orderVM, true);
            return Ok(entity);
        }

    }
}