using System;
using System.Collections.Generic;
using System.Text;

namespace ApprentissageSGBD
{
    public interface IProductRepository
    {
        // 1. Lire tous les produits
        IEnumerable<Product> GetAllProducts();

        // 2. Trouver un produit par son identifiant
        Product? GetProductById(int productId);

        // 3. Ajouter un produit et renvoyer le nouvel identifiant généré
        int AddProduct(Product product);

        // 4. Mettre à jour un produit existant (vrai si réussi, faux sinon)
        bool UpdateProduct(Product product);

        // 5. Supprimer un produit par son identifiant (vrai si réussi, faux sinon)
        bool DeleteProduct(int productId);
    }
}
