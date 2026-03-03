using EcommDesignsHub.Models;

namespace EcommDesignsHub.Repositories.Interfaces
{
    public interface IProjectRepository
    {
        Task<IEnumerable<ProjectModel>> GetAll();
        Task<List<ProjectModel>> GetAllForSite();
        Task<ProjectModel> GetById(int id);
        Task Add(ProjectModel model);
        Task Update(ProjectModel model);
        Task Delete(int id);

        Task<List<ProjectCategory>> GetAllCategory();
        Task AddCategory(ProjectCategory model);
        Task<List<ProjectCategory>> GetAllCategoryForSite();


    }
}
