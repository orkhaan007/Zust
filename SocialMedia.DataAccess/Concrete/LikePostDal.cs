﻿using SocialMedia.Core.DataAccess.Concrete;
using SocialMedia.DataAccess.Abstract;
using SocialMedia.Entities.Data;
using SocialMedia.Entities.Models;

namespace SocialMedia.DataAccess.Concrete;
public class LikePostDal : EFEntityRepositoryBase<LikePost,ZustDBContext>,ILikePostDal
{
    public LikePostDal(ZustDBContext context) : base(context) { }
}
