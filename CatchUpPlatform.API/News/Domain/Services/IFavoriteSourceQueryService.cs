using CatchUpPlatform.API.News.Domain.Model.Aggregates;
using CatchUpPlatform.API.News.Domain.Model.Queries;

namespace CatchUpPlatform.API.News.Domain.Services;

public interface IFavoriteSourceQueryService
{
    Task<IEnumerable<FavoriteSource>>   Handle(GetAllFavoriteSourcesByNewsApiKeyQuery query);
    Task<FavoriteSource?>               Handle(GetFavoriteSourceByNewsApiKeyAndSourceIdQuery query);
    Task<FavoriteSource?>               Handle(GetFavoriteSourceByIdQuery query);
}