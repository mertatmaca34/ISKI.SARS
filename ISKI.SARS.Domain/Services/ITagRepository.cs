using ISKI.Core.Infrastructure;
using ISKI.SARS.Domain.Entities;

namespace ISKI.SARS.Domain.Services;

public interface ITagRepository : IAsyncRepository<Tag, Guid> { }