using surfs_up_project.Models;
using System.ComponentModel.DataAnnotations;

public class ShoppingCartItem
{
    public int Id { get; private set; }
    public Product Product { get; private set; }

    [DataType(DataType.DateTime)]
    public DateTime PickUpDate { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime ReturnDate { get; set; }

    // Ingen Quantity-felt, da vi kun tillader én af hver slags
    public ShoppingCartItem(int id, Product product, DateTime pickUpDate, DateTime returnDate)
    {
        Id = id;
        Product = product;
        PickUpDate = pickUpDate;
        ReturnDate = returnDate;
    }
}
