namespace surfs_up_project.Models
{
    public static class CsvConverter
    {
        public static List<Product> ToProducts(string csvPath)
        {
            List<Product> products = new List<Product>();
            string[] lines = csvPath.Split('\n');
            foreach (string line in lines)
            {
                string[] parts = line.Split(';');
                Product product = new Product
                {
                    Name = parts[1],
                    ImagePath = parts[2],
                    Length = double.Parse(parts[3]),
                    Width = double.Parse(parts[4]),
                    Thickness = double.Parse(parts[5]),
                    Volume = double.Parse(parts[6]),
                    Type = parts[7],
                    Price = double.Parse(parts[8])
                };
                products.Add(product);
            }
            return products;
        }
    }
}
