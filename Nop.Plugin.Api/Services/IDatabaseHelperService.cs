using System.Collections.Generic;
using Nop.Core;

namespace Nop.Plugin.Api.Services
{
    public interface IDatabaseHelperService
    {
        void BulkInsert<T>(IList<T> items) where T : BaseEntity, new();
    }
}