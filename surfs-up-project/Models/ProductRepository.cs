namespace surfs_up_project.Models
{
    public static class ProductRepository //CRUD 
    {

        private static List<Product> _products = new List<Product>() {
         new Product {ProductId = 1, Name = "The Minilog", ImagePath="/images/the_minilog.webp", Length = 6, Width = 21,
         Thickness= 2.75, Volume = 38.8, Type="Shortboard", Price= 565 },

         new Product {ProductId = 2, Name = "The Wide Glider", ImagePath="/images/the_wide_glider.webp", Length = 7.1, Width = 21.75,
         Thickness= 2.75, Volume = 44.16, Type="Funboard", Price= 685 },

          new Product {ProductId = 3, Name = "The Golden Ratio", ImagePath="/images/the_golden_ratio.webp", Length = 6.3, Width = 21.85,
         Thickness= 2.9, Volume = 43.22, Type="Funboard", Price= 695 },

          new Product {ProductId = 4, Name = "Mahi Mahi", ImagePath="/images/mahi_mahi.webp", Length = 5.4, Width = 20.75,
         Thickness= 2.3, Volume = 29.39, Type="Fish", Price= 645 },
     };

        public static void AddProduct(Product product) //CREATE 
        {
            var maxId = _products.Max(x => x.ProductId);
            product.ProductId = maxId + 1;//SER IGENNEM LISTEN OG FINDER MAX OG
                                          //TILFØJER MED 1 NÅR EN NY CATEGORY SKAL TILFØJES 
            _products.Add(product);//NY cATEGORY BLIVER TILFØJET 
        }

        public static List<Product> GetProducts() => _products;//READ

        public static Product? GetProductById(int? productId)//READ BY ID 
        {
            var product = _products.FirstOrDefault(x => x.ProductId == productId);
            if (product != null)//KONTROLLER OM CATEGORY BLEV FUNDET 
            {
                return new Product
                {
                    //RETURNERE DENNE VIDEN OM DEN FUNDNE CATEGORY 
                    ProductId = product.ProductId,
                    Name = product.Name,
                    ImagePath = product.ImagePath,
                    Length = product.Length,
                    Width = product.Width,
                    Thickness = product.Thickness,
                    Volume = product.Volume,
                    Type = product.Type,
                    Price = product.Price

                };
            }
            return null;//HVIS INGEN CATEGORY BLEV FUNDET RETURNERES NULL
        }

        public static void UpdateProduct(int productId, Product product)//UDPATE 
        {
            if (productId != product.ProductId) return; //Sikre sig at id´et er det rigtige 

            var productToUpdate = GetProductById(productId);//Henter den Category der skal opdateres 
            if (productToUpdate != null)//kontroller om den category der skal opdateres findes 
            {
                //Hvis den blev fundet opdateres disse parametre 
                productToUpdate.Name = product.Name;
                productToUpdate.Length = product.Length;
                productToUpdate.Width = product.Width;
                productToUpdate.Thickness = product.Thickness;
                productToUpdate.Volume = product.Volume;
                productToUpdate.Type = product.Type;
                productToUpdate.Price = product.Price;
            }
        }

        public static void DeleteProduct(int productId) // Metode til at slette en kategori baseret på dens ID
        {
            // Finder den første kategori i listen _categories, hvor CategoryId matcher det angivne categoryId.
            // Hvis der ikke findes en kategori, vil 'category' blive sat til null.
            var product = _products.FirstOrDefault(x => x.ProductId == productId);

            // Tjekker om kategorien blev fundet.
            if (product != null)
            {
                // Hvis kategorien blev fundet, fjernes den fra _categories-listen.
                _products.Remove(product); // Fjerner kategorien fra listen
            }
            // Hvis kategorien ikke findes, sker der ingenting.
        }

    }
}
