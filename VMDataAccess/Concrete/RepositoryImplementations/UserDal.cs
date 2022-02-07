using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMDataAccess.Abstract.Repositories;
using VMEntities.VMDBEntities;
using VMEntities.VMDtos;

namespace VMDataAccess.Concrete.RepositoryImplementations
{
    public class UserDal : BaseEntityRepository<User, VMDBContext>, IUserDal
    {
        public async Task<User> GetUserByEmailAndPassword(UserLoginDto userLoginDto)
        {
            using (VMDBContext context = new VMDBContext())
            {
                return await context.Users.
                    Include(a => a.UserRoles).ThenInclude(b => b.Role).Where(d => d.EMail == userLoginDto.EMail && d.Password == userLoginDto.Password).FirstOrDefaultAsync();
            }
        }
    }
}
