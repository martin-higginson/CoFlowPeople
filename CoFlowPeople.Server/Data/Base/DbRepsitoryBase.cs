using CoFlowPeople.Server.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CoFlowPeople.Server.Data.Base
{
    public abstract class DbRepsitoryBase<T> where T : AppDbContext
    {
        protected readonly T Context;

        public DbRepsitoryBase(T context)
        {
            Context = context;

        }

        protected async Task UpdateRecord<TDataModel>(TDataModel dataModel, TDataModel modifiedDataModel)
           where TDataModel : class

        {
            Context.Entry(dataModel).State = EntityState.Detached;
            Context.Attach(modifiedDataModel);
            Context.Entry(modifiedDataModel).State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }
    }
}
