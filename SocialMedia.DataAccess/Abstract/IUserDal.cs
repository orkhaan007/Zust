using SocialMedia.Core.DataAccess.Abstract;
using SocialMedia.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.DataAccess.Abstract;
public interface IUserDal : IEntityRepository<CustomIdentityUser> { }