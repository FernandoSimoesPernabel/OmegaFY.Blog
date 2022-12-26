using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaFY.Blog.Data.EF.ValueConverts;

internal class ReferenceIdValueConverter : ValueConverter<ReferenceId, Guid>
{
    public ReferenceIdValueConverter() : base(x => x.Value, x => new ReferenceId(x))
    {
    }
}