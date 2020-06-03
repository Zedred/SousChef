using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SousChef.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace SousChef.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("Index")]
        public string Index()
        {
            return _userRepository.GetUser(1).Name;
        }

        [HttpGet("Details/{id}")]
        public ObjectResult Details(int id)
        {
            User user = _userRepository.GetUser(id);
            return Ok(user);
        }
    }
}