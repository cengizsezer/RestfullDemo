using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RestfullDemo.Datas;
using RestfullDemo.Models;
using RestfullDemo.Repository.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RestfullDemo.Services
{
    public class UserService:IUserService
    {
        private readonly IGenericRepository<UserRequestModel> _userModelRepository;
        private readonly DataBaseContext _dbContext;


        public UserService(IGenericRepository<UserRequestModel> userModelRepository,DataBaseContext dbContext)
        {
            _userModelRepository = userModelRepository;
            _dbContext = dbContext;
        }

        public string GetUserDBName(UserRequestModel model)
        {
            
            var existingUser = _dbContext.ContextUser.FirstOrDefault(u => u.UserName == model.UserName);

            if (existingUser != null)
            {
                // Kullanıcı adını döndür
                return existingUser.UserName;
            }

           
            return null;
        }


        public bool IsUsernameUnique(UserRequestModel model)
        {
            // Kullanıcı adının benzersiz olup olmadığını kontrol et
            var existingUser = _dbContext.ContextUser.FirstOrDefault(u => u.UserName == model.UserName);

            // Eğer existingUser null ise, kullanıcı adı benzersizdir
            return existingUser == null;
        }

        public int GetUserId(UserRequestModel model)
        {
            var existingUser = _dbContext.ContextUser.FirstOrDefault(u => u.UserName == model.UserName);

            if (existingUser != null)
            {
                // Kullanıcı adını döndür
                return existingUser.Id;
            }


            return default;
        }

        public Task<LoginResponseModel> Create(UserRequestModel userModel)
        {
            bool isUnique = IsUsernameUnique(userModel);

            if (isUnique)
            {
                string dbName = GetUserDBName(userModel) == null ? userModel.UserName : GetUserDBName(userModel);
                var claims = new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier,userModel.UserName),
                    new Claim(ClaimTypes.NameIdentifier,userModel.Password),
                    new Claim(ClaimTypes.Name,dbName),
                };


                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("BuddySecretKeyShouldBeLonggggg"));
                var creds = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
                var expiry = DateTime.Now.AddDays(10);

                var token = new JwtSecurityToken(claims:claims,expires:expiry,signingCredentials:creds,notBefore:DateTime.Now);

                var encodedjwt=new JwtSecurityTokenHandler().WriteToken(token);

                LoginResponseModel model = new()
                {
                    UserName = userModel.UserName,
                    Password = userModel.Password,
                    Id=GetUserId(userModel),
                    UserToken = encodedjwt
                };

                _userModelRepository.Add(userModel);
                model.Id = GetUserId(userModel);

                return Task.FromResult(model);
            }

            return null;
        }
        //public UserRequestModel Create(UserRequestModel userModel)
        //{
        //    bool isUnique = IsUsernameUnique(userModel);

        //    if (isUnique)
        //    {
        //        return _userModelRepository.Add(userModel);
        //    }

        //    return null;

        //}

        public Task<UserRequestModel> DeleteUser(int id)
        {
            var model = _userModelRepository.GetbyId(id);

            if (model != null)
            {
                var deletedModel = _userModelRepository.Delete(model);
                _dbContext.SaveChanges();

                
                var deletedModelCopy = new UserRequestModel
                {
                    Id = deletedModel.Id,
                    UserName = deletedModel.UserName,
                    Password = deletedModel.Password
                   
                };

                return Task.FromResult(deletedModelCopy);
            }

            return null;
        }


        //public List<UserRequestModel> GetAll()
        //{

        //    return _userModelRepository.GetAll();
        //}

        public Task<List<UserRequestModel>> GetAll()
        {

            List<UserRequestModel> users = _userModelRepository.GetAll();
            
            if (users != null)
            {
                return Task.FromResult(users);
            }

            
            return null;
        }

        public void DeleteAll()
        {
            _userModelRepository.DeleteAll();
        }
        public Task<UserRequestModel> GetUser(int id)
        {
            var user= _userModelRepository.GetbyId(id);

            if(user!=null)
            {
                return Task.FromResult(user);
            }

            return null;
        }

        public Task<LoginResponseModel> Update(int id, UserRequestModel model)
        {
            var user = _userModelRepository.UpdateById(model, id);

            if (user != null)
            {
                LoginResponseModel mod = new()
                {
                    UserName = model.UserName,
                    Password = model.Password,
                    Id = GetUserId(model),
                    UserToken = string.Empty,
                };

                return Task.FromResult(mod);
            }

            return null;
         
        }

       
    }
}
