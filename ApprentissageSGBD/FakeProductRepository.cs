using System;
using System.Collections.Generic;
using System.Text;

namespace ApprentissageSGBD
{
    public class FakeProductRepository : IProductRepository
    {
        // Notre fausse table SQL en mémoire : une simple liste d'objets Product
        private readonly List<Product> _products = new List<Product>();

        // Compteur simulant l'auto-incrément des identifiants (comme IDENTITY en SQL)
        private int _currentId = 1;

        // 1. Lire tous les produits (la liste est retournée sous forme consultable IEnumerable)
        public IEnumerable<Product> GetAllProducts()
        {
            return _products;
        }

        // 2. Trouver un produit par son identifiant
        public Product? GetProductById(int productId)
        {
            // LINQ : trouve le premier produit correspondant, ou null s'il n'existe pas
            return _products.FirstOrDefault(p => p.Id == productId);
        }

        // 3. Ajouter un produit et attribuer son nouvel ID
        public int AddProduct(Product product)
        {
            product.Id = _currentId++; // On donne le numéro actuel, puis on augmente le compteur de 1
            _products.Add(product);
            return product.Id; // On renvoie l'identifiant attribué
        }

        // 4. Mettre à jour un produit existant
        public bool UpdateProduct(Product product)
        {
            Product? existant = GetProductById(product.Id);
            if (existant == null)
            {
                return false; // Échec : le produit à modifier n'existe pas
            }

            // Mise à jour des informations
            existant.Name = product.Name;
            existant.Price = product.Price;
            return true; // Succès
        }

        // 5. Supprimer un produit
        public bool DeleteProduct(int productId)
        {
            Product? aSupprimer = GetProductById(productId);
            if (aSupprimer == null)
            {
                return false; // Échec : rien à supprimer
            }

            _products.Remove(aSupprimer);
            return true; // Succès
        }
    }
}
