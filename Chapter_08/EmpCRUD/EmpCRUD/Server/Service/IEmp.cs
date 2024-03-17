using EmpCRUD.Server.Models;

namespace EmpCRUD.Server.Service
{
    public interface IEmp 
    {
        Task<string> AddEmp(TblEmp emp);
        Task<string> UpdateEmp(TblEmp emp);
        Task<string> DeleteEmp(int Id);
        Task<TblEmp> GetEmpDetails(int Id);
        Task<List<TblEmp>> GetAllEmps();
    }
}
