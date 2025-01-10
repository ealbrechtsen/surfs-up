namespace surfs_up_project.Models
{
    public static class CsvConverter
    {
        public static List<Product> ToProducts(string csvPath)
        {
            List<Product> products = new List<Product>();
            string[] lines = File.ReadAllLines(csvPath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(';');
                Product product = new Product
                {
                    Name = parts[0],
                    ImagePath = parts[1],
                    Length = double.Parse(parts[2]),
                    Width = double.Parse(parts[3]),
                    Thickness = double.Parse(parts[4]),
                    Volume = double.Parse(parts[5]),
                    Type = parts[6],
                    Price = double.Parse(parts[7])
                };
                products.Add(product);
            }
            return products;
        }
    }
}
