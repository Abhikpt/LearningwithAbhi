using LearningwithAbhi.Shared;
using System.Collections.Generic;

namespace LearningwithAbhi.Client
{
    public class CartService
    {
        public List<CartItem> CartItems { get; private set; } = new List<CartItem>();

        public void AddToCart(ProductModel product)
        {
            var existingItem = CartItems.Find(item => item.Product.Id == product.Id);
            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                CartItems.Add(new CartItem { Product = product, Quantity = 1 });
            }
        }

        public void RemoveFromCart(ProductModel product)
        {
            var existingItem = CartItems.Find(item => item.Product.Id == product.Id);
            if (existingItem != null)
            {
                CartItems.Remove(existingItem);
            }
        }

        public void ClearCart()
        {
            CartItems.Clear();
        }
    }
}
