using CleanArchitecture.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Domain
{
    public class Director : BaseDomainModel
    {
        public string? Name { get; set; }

        public string? LastName { get; set; }

        public int VideoId { get; set; }

        public virtual Video? Video { get; set; }

    }
}
