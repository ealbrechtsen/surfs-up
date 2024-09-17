namespace surfs_up_project.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public string ImagePath { get; set; }

        public double Length { get; set; }

        public double Width { get; set; }

        public double Thickness { get; set; }

        public double Volume { get; set; }

        public string Type { get; set; }

        public double Price { get; set; }

        public Product(int id, string name, string imagePath, double length, double width, double thickness, double volume, string type, double price)
        {
            ProductId = id;
            Name = name;
            ImagePath = imagePath;
            Length = length;
            Width = width;
            Thickness = thickness;
            Volume = volume;
            Type = type;
            Price = price;
        }

        public Product()
        { 
            // TOM KONSTRUKTOR TIL DATAASE
        }
    }

}