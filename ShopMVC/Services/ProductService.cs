using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ShopMVC.Models;

namespace ShopMVC.Services;

public class ProductService
{
    private readonly IMongoCollection<Product> _products;

    public ProductService(IOptions<MongoDBSettings> settings)
    {
        var client = new MongoClient(settings.Value.ConnectionString);
        var database = client.GetDatabase(settings.Value.DatabaseName);
        _products = database.GetCollection<Product>(settings.Value.CollectionName);
    }
    
    public List<Product> GetAll() => _products.Find(p => true).ToList();
    
    public Product GetById(string id) => _products.Find(p => p.Id == id).FirstOrDefault();
    
}