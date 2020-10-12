using System;

namespace OmegaFY.Blog.Domain.Core.Authentication
{

    public interface IUserInformation
    {
        public Guid CurrentRequestUserId { get; set; }
    }

}
