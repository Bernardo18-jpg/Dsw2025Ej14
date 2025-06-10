using System.Text.Json;
using Dsw2025Ej14.Api.Domain;

namespace Dsw2025Ej14.Api.Data
{
    public class PersistenciaEnMemoria
    {
        private List<Product> _products = new();
        public void LoadProducts(string filePath)
        {
            string json = File.ReadAllText(filePath);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var products = JsonSerializer.Deserialize<List<Product>>(json, options);

            if (products != null)
            {
                _products.Clear();
                _products.AddRange(products);
            }
        }
        public List<Product> GetProducts()
        {
            return _products;
        }
    }   

    
  

}

