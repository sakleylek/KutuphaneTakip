using KütüphaneTakip.Core.Entites;
using KütüphaneTakip.Core.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KütüphaneTakip.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepository<User> _userRepository;

        public UserController(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet]
        [Route("GetByIdUser/{id}")]
        public async Task<IActionResult> GetByIdUser(int id)
        {
            var entity = await _userRepository.GetByIdAsync(id);
            return Ok(entity);

        }
        [HttpPost]
        [Route("AddUser")]
        public async Task<IActionResult> AddUser(User user)
        {
            await _userRepository.AddAsync(user);
            return Ok(user);
        }
        [HttpGet]
        [Route("GetUser")]
        public List<User> GetAllUser()
        {
            return _userRepository.GetAll().ToList();
        }
        [HttpDelete]
        [Route("DeleteUser")]
        public IActionResult DeleteUser(int id)
        {
            _userRepository.Delete(id);
            return Ok();
        }
        [HttpPut]
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateUser(User user)
        {
            var ee = await _userRepository.GetByIdAsync(user.Id);
            ee.FullName = user.FullName; //buraya bak!!!
            ee.CDate = user.CDate;
            _userRepository.Update(ee);
            return Ok(ee);
        }

    }
}
