using BlogSite.Models.Entities;
using Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Service.Rules;



public class PostBusinessRules
{

    public virtual void PostIsNullCheck(Post post)
    {
        if(post is null)
        {
            throw new NotFoundException("İlgili post bulunamadı.");
        }
    }
}
