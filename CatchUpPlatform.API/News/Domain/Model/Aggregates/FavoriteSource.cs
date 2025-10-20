using CatchUpPlatform.API.News.Domain.Model.Commands;

namespace CatchUpPlatform.API.News.Domain.Model.Aggregates;

public partial class FavoriteSource
{
    public int Id { get; }
    public string NewsApiKey { get; private set; }
    public string SourceId { get; private set; }

    public FavoriteSource()
    {
        NewsApiKey = string.Empty;
        SourceId = string.Empty;
    }

    public FavoriteSource(CreateFavoriteSourceCommand command)
    {
        NewsApiKey = command.NewsApiKey;
        SourceId = command.SourceId;
    }
    
}