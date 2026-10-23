using System;
using System.Collections.Generic;
using System.Text;

namespace ApprentissageSGBD
{
    public class Product
    {
        public int Id { get; set; }

        // Nom du produit (texte, initialisé à vide pour éviter les avertissements de nullité)
        public string Name { get; set; } = string.Empty;

        // Prix du produit (décimal précis pour les devises)
        public decimal Price { get; set; }

        // Redéfinition de ToString pour afficher joliment l'objet
        public override string ToString()
        {
            return $"Produit n°{Id} : {Name} ({Price} €)";
        }
    }
}
