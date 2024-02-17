using Application.Interface.Repositories;
using Domain.Entities;
using Persistence.Context;


namespace Persistence.Repositories;

public class UrlRecordRepository : Repository<UrlRecord>, IUrlRecordRepository
{
    public UrlRecordRepository(DataContext context) : base(context)
    {

    }

}
