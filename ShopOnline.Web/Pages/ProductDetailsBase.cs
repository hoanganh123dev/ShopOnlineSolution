using Microsoft.AspNetCore.Components;
using ShopOnline.Models.Dtos;
using ShopOnline.Web.Service;
using ShopOnline.Web.Service.Contracts;
using System.ComponentModel;

namespace ShopOnline.Web.Pages
{
    public class ProductDetailsBase:ComponentBase
    {
        [Parameter]
        public int Id { get; set; }
        [Inject]
        public IProductService ProductService { get; set; }
        [Inject]
        public IShoppingCartService shoppingCartService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public ProductDto Product { get; set; }
        public string ErrorMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                Product = await ProductService.GetItem(Id);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
        protected async Task AddToCart_Click(CartItemToAddDto cartItemToAddDto)
        {
            try
            {
                var cartItemDto = await shoppingCartService.AddItem(cartItemToAddDto);
                NavigationManager.NavigateTo("/ShoppingCart");
            }
            catch (Exception)
            {

                //Log Exception
            }
        }
    }
}
