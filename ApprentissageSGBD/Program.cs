using ApprentissageSGBD;
/*
// Création (instanciation) d'un premier objet à partir du modèle
Product article1 = new Product();
article1.Id = 1;
article1.Name = "Stylo à bille";
article1.Price = 1.50m; // Le petit 'm' à la fin indique à C# qu'il s'agit d'un decimal

// Affichage dans la console
Console.WriteLine(article1);
*/
/*
// 1. On instancie notre gestionnaire de produits (le faux dépôt)
IProductRepository depot = new FakeProductRepository();

// 2. On crée deux produits
Product p1 = new Product { Name = "Cahier A4", Price = 2.50m };
Product p2 = new Product { Name = "Stylo 4 couleurs", Price = 1.80m };

// 3. On les enregistre dans notre dépôt
int id1 = depot.AddProduct(p1);
int id2 = depot.AddProduct(p2);

Console.WriteLine($"Produits ajoutés avec les identifiants {id1} et {id2} !");
Console.WriteLine("-------------------------------------------------");

// 4. On demande au dépôt d'afficher tout ce qu'il contient (avec notre fameux foreach)
Console.WriteLine("Contenu actuel du magasin :");
foreach (Product p in depot.GetAllProducts())
{
    Console.WriteLine(p); // Utilise automatiquement notre ToString()
}

Console.WriteLine("-------------------------------------------------");

// 5. On teste la recherche par identifiant
Console.WriteLine("Recherche du produit avec l'ID 1 :");
Product? trouve = depot.GetProductById(3);

if (trouve != null)
{
    Console.WriteLine($"Trouvé : {trouve.Name} au prix de {trouve.Price} €");
}
else
{
    Console.WriteLine("Aucun produit trouvé.");
}
*/
// 6. On teste la mise à jour d'un produitusing System

// 1. Initialisation du dépôt
IProductRepository depot = new FakeProductRepository();

// 2. Création et ajout de deux produits
Product p1 = new Product { Name = "Cahier A4", Price = 2.50m };
Product p2 = new Product { Name = "Stylo 4 couleurs", Price = 1.80m };

int id1 = depot.AddProduct(p1);
int id2 = depot.AddProduct(p2);

Console.WriteLine($"Produits ajoutés : IDs {id1} et {id2}");
Console.WriteLine("-------------------------------------------------");

// 3. Test de la mise à jour (UPDATE)
Console.WriteLine($"Mise à jour du produit n°{id1}...");

// On prépare un objet avec le MÊME identifiant, mais des infos modifiées
Product produitModifie = new Product 
{ 
    Id = id1, 
    Name = "Cahier A4 (Grand format)", 
    Price = 2.80m 
};

bool majReussie = depot.UpdateProduct(produitModifie);

if (majReussie)
{
    Console.WriteLine("Mise à jour réussie !");
    // On va vérifier dans le dépôt si la modification a bien pris
    Product? verification = depot.GetProductById(id1);
    Console.WriteLine($"Nouveau contenu : {verification}");
}
else
{
    Console.WriteLine("Échec de la mise à jour.");
}

Console.WriteLine("-------------------------------------------------");

// 4. Test de la suppression (DELETE)
Console.WriteLine($"Suppression du produit n°{id2}...");

bool suppressionReussie = depot.DeleteProduct(id2);

if (suppressionReussie)
{
    Console.WriteLine("Suppression réussie !");
}
else
{
    Console.WriteLine("Échec de la suppression.");
}

Console.WriteLine("-------------------------------------------------");

// 5. Affichage final de contrôle
Console.WriteLine("Produits restants dans le magasin :");
foreach (Product p in depot.GetAllProducts())
{
    Console.WriteLine(p);
}