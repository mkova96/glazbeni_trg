using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using GlazbeniTrg.Data;
using Microsoft.EntityFrameworkCore;

namespace GlazbeniTrg.Models
{
    public class Cart
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private Cart(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        [Key]
        [Required]
        public Guid CartID { get; set; }

        public ICollection<CartAlbum> CartAlbums { get; set; }


       
        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = services.GetService<ApplicationDbContext>();
            String cartID = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartID);

            return new Cart(context) { CartID = Guid.Parse(cartID) };
        }

        public void AddToCart(Album album, int quantity)
        {
            var cartAlbum = _applicationDbContext.CartAlbum.SingleOrDefault(s => s.Album.AlbumID == album.AlbumID && s.CartID == CartID);
            if (cartAlbum == null)
            {
                cartAlbum = new CartAlbum
                {
                    CartID = CartID,
                    Album = album,
                    quantity = 1
                };
                _applicationDbContext.CartAlbum.Add(cartAlbum);
            }
            else
            {
                cartAlbum.quantity++;
            }
            _applicationDbContext.SaveChanges();

            
        }
        public int RemoveFromCart(Album album)
        {
            var cartAlbum = _applicationDbContext.CartAlbum.SingleOrDefault(s => s.Album.AlbumID == album.AlbumID && s.CartID == CartID);

            var localAmount = 0;
            if (cartAlbum != null)
            {
                if (cartAlbum.quantity > 1)
                {
                    cartAlbum.quantity--;
                    localAmount = cartAlbum.quantity;
                }
                else
                {
                    _applicationDbContext.CartAlbum.Remove(cartAlbum);
                }
           
            }

            _applicationDbContext.SaveChanges();
            return localAmount;
        }
        public ICollection<CartAlbum> GetCartAlbums()
        {
            return CartAlbums ?? (CartAlbums = _applicationDbContext.CartAlbum.Where(c => c.CartID == CartID).Include(s => s.Album).ToList());
        }
        public void ClearCart()
        {
            var cartAlbums = _applicationDbContext.CartAlbum.Where(cart => cart.CartID == CartID);

            _applicationDbContext.CartAlbum.RemoveRange(cartAlbums);

            _applicationDbContext.SaveChanges();
        }
        public decimal getCartTotal()
        {
            var total = _applicationDbContext.CartAlbum.Where(c => c.CartID == CartID).Select(c => c.Album.Price * c.quantity).Sum();
            return total;
        }
        
    }
}

