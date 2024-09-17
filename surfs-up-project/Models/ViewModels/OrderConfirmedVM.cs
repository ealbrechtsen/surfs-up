namespace surfs_up_project.Models

{
    public class OrderConfirmedVM
    {
        public Customer Customer { get; set; }
        public List<ShoppingCartItem> Items { get; set;}
    }

    //public class Customer
    //{
    //    public int CustomerId { get; set; }
    //    public string FirstName { get; set; }
    //    public string LastName { get; set; }
    //    public string Email { get; set; }
    //    public string PhoneNumber { get; set; }
    //    public string Address { get; set; }
    //    public int ZipCode { get; set; }
    //    public string City { get; set; }
    //}

    //public class Product
    //{
    //    public int ProductId { get; set; }

    //    public string Name { get; set; }

    //    public string ImagePath { get; set; }

    //    public double Length { get; set; }

    //    public double Width { get; set; }

    //    public double Thickness { get; set; }

    //    public double Volume { get; set; }

    //    public string Type { get; set; }

    //    public double Price { get; set; }
    //}
}

