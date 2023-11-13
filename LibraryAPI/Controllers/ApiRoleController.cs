using Library.Models;
using LibraryAPI.Datas;
using LibraryAPI.DTOS.Role;
using LibraryAPI.Interfaces;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApiRoleController : ControllerBase
    {
        private readonly IRoleService roleService;
        public readonly DataContext db;
        public ApiRoleController(IRoleService roleService)
        {
            this.roleService = roleService;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetRoleAll()
        {
            return Ok(await roleService.GetAll());
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<Role>> AddRole([FromForm] RoleRequest roleRequest)
        {
            var role = roleRequest.Adapt<Role>();
            await roleService.Create(role);
            roleService.Create(role);
            return CreatedAtAction(nameof(AddRole), role);
        }

        [HttpPut]
        public async Task<ActionResult<Role>> UpdateRole(int id, [FromForm] RoleRequest roleRequest)
        {
            if (id != roleRequest.RoleId) return BadRequest();
            var result = await roleService.GetById(id);
           

            if (result == null) return NotFound();

            var role = roleRequest.Adapt(result);
            await roleService.Update(role);
            return Ok(role);

        }
        [HttpDelete]
      
        public async Task<ActionResult<Role>> DeleteRole([FromQuery] int id)
        {
            var result = await roleService.GetById(id);
            if (result == null) return NotFound();
            await roleService.Delete(result);
      
            return Ok(new { msg = "OK" });
        }
    }
}
