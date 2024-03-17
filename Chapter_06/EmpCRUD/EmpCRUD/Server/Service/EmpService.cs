using EmpCRUD.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace EmpCRUD.Server.Service
{

    public class EmpService : IEmp
    {
        private TestContext _dbContext;
        public EmpService(TestContext context)
        {
            this._dbContext = context;
        }

        public async Task<string> AddEmp(TblEmp emp)
        {
            await _dbContext.TblEmp.AddAsync(emp);
            await _dbContext.SaveChangesAsync();
            return "Data has been added sucessfully";
        }
        public async Task<List<TblEmp>> GetAllEmps()
        {
            return await _dbContext.TblEmp.ToListAsync();
        }

        public async Task<TblEmp> GetEmpDetails(int Id)
        {
            TblEmp? emp = await _dbContext.TblEmp.FindAsync(Id);

            if (emp == null)
            {
                throw new Exception("Employee not found");
            }
            return emp;
        }

        public async Task<string> UpdateEmp(TblEmp emp)
        {
            _dbContext.Entry(emp).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return "Data has been updated sucessfully";
        }

        async Task<string> IEmp.DeleteEmp(int Id)
        {
            var emp = await _dbContext.TblEmp.FindAsync(Id);
            if (emp != null)
            {
                var result = _dbContext.TblEmp.Remove(emp);
                await _dbContext.SaveChangesAsync();
            }
            return "Data Deleted succesfully";
        }
    }
}
