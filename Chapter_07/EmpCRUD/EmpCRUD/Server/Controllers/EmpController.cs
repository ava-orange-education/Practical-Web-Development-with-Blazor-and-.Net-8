using EmpCRUD.Server.Models;
using EmpCRUD.Server.Service;
using Microsoft.AspNetCore.Mvc;

namespace EmpCRUD.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpController : ControllerBase
    {
        private readonly IEmp _IEmp;
        public EmpController(IEmp emp)
        {
            _IEmp = emp;
        }
        // GET: api/<EmpController>
        [HttpGet]
        public async Task<List<TblEmp>> Get()
        {
            return await Task.FromResult(await _IEmp.GetAllEmps());
        }

        // GET api/<EmpController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _IEmp.GetEmpDetails(id));
        }

        // POST api/<EmpController>
        [HttpPost]
        public async Task<string> post(TblEmp tblEmp)
        {
            return await _IEmp.AddEmp(tblEmp);

        }

        // PUT api/<EmpController>/5
        [HttpPut]
        public async Task<string> Put(TblEmp tblEmp)
        {
            return await _IEmp.UpdateEmp(tblEmp);
        }

        // DELETE api/<EmpController>/5
        [HttpDelete("{id}")]
        public async Task<string> Delete(int id)
        {
            return await _IEmp.DeleteEmp(id);
        }
    }
}
