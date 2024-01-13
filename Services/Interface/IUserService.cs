using RestfullDemo.Models;
using System.Threading.Tasks;

namespace RestfullDemo.Services
{
    public interface IUserService
    {
        //UserRequestModel Create(UserRequestModel userModel);
        Task<LoginResponseModel> Create(UserRequestModel userModel);


        Task<UserRequestModel> GetUser(int id);

        //List<UserRequestModel> GetAll();
        Task<List<UserRequestModel>> GetAll();

        void DeleteAll();

        Task<UserRequestModel> DeleteUser(int id);

        Task<LoginResponseModel> Update(int id, UserRequestModel model);

        bool IsUsernameUnique(UserRequestModel model);
    }
}
