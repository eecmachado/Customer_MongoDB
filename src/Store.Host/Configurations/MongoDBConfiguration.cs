namespace Store.Host.Configurations;

public class MongoDBConfiguration
{
    public const string MongoDB = "MongoDB";

    public string? ConnectionString { get; set; }

    public string? Database { get; set; }
}