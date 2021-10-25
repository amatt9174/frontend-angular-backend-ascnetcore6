using System;
using System.Linq;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public class GroupsSpecification : BaseSpecification<Attachment>
    {


        public GroupsSpecification(GroupSpecParams groupParams)
            : base(x =>
                (string.IsNullOrEmpty(groupParams.AGroup))
            )
        {
            AddOrderBy(g => g.AGroup);
        }
    }
}