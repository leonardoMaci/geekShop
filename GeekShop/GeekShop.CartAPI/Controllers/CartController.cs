using GeekShop.CartAPI.Data.DTOs;
using GeekShop.CartAPI.Messages;
using GeekShop.CartAPI.RabbitMQSender;
using GeekShop.CartAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GeekShop.CartAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CartController : ControllerBase
    {
        private ICartRepository _cartrepository;
        private ICouponRepository _couponRepository;
        private IRabbitMQMessageSender _rabbitMQMessageSender;

        public CartController(ICartRepository cartrepository, IRabbitMQMessageSender rabbitMQMessageSender, ICouponRepository couponRepository)
        {
            _cartrepository = cartrepository ?? throw new
                ArgumentNullException(nameof(cartrepository));

            _rabbitMQMessageSender = rabbitMQMessageSender ?? throw new
                ArgumentNullException(nameof(rabbitMQMessageSender));

            _couponRepository = couponRepository ?? throw new
                ArgumentNullException(nameof(couponRepository));
        }

        [HttpGet("find-cart/{id}")]
        public async Task<ActionResult<CartDTO>> FindById(string id)
        {
            var cart = await _cartrepository.FindCartByUserId(id);
            if (cart == null) return NotFound();
            return Ok(cart);
        }

        [HttpPost("add-cart")]
        public async Task<ActionResult<CartDTO>> AddCart(CartDTO dto)
        {
            var cart = await _cartrepository.SaveOrUpdateCart(dto);
            if (cart == null) return NotFound();
            return Ok(cart);
        }

        [HttpPut("update-cart")]
        public async Task<ActionResult<CartDTO>> UpdateCart(CartDTO dto)
        {
            var cart = await _cartrepository.SaveOrUpdateCart(dto);
            if (cart == null) return NotFound();
            return Ok(cart);
        }

        [HttpDelete("remove-cart/{id}")]
        public async Task<ActionResult<CartDTO>> RemoveCart(int id)
        {
            var status = await _cartrepository.RemoveFromCart(id);
            if (!status) return BadRequest();
            return Ok(status);
        }

        [HttpPost("apply-coupon")]
        public async Task<ActionResult<CartDTO>> ApplyCoupon(CartDTO dto)
        {
            var status = await _cartrepository.ApplyCoupon(dto.CartHeader.UserId, dto.CartHeader.CouponCode);
            if (!status) return NotFound();
            return Ok(status);
        }

        [HttpDelete("remove-coupon/{userId}")]
        public async Task<ActionResult<CartDTO>> RemoveCoupon(string userId)
        {
            var status = await _cartrepository.RemoveCoupon(userId);
            if (!status) return NotFound();
            return Ok(status);
        }

        [HttpPost("checkout")]
        public async Task<ActionResult<CheckoutHeaderDTO>> Checkout(CheckoutHeaderDTO dto)
        {
            if (dto?.UserId == null) return BadRequest();

            string token = Request.Headers["Authorization"];

            var inicio = token.LastIndexOfAny(new char[] { ' ' }) + 1;

            var fim = token.Length - inicio;
            //remover a palavra bearer do inicio do token
            token = token.Substring(inicio, fim);

            var cart = await _cartrepository.FindCartByUserId(dto.UserId);
            if (cart == null) return NotFound();

            if (!string.IsNullOrEmpty(dto.CouponCode))
            {
                CouponDTO coupon = await _couponRepository.GetCoupon(
                    dto.CouponCode, token);

                if (dto.DiscountAmount != coupon.DiscountAmount)
                {
                    return StatusCode(412);
                }
            }

            dto.CartDetails = cart.CartDetails;
            dto.DateTime = DateTime.Now;

            //Envia a mensagem para a fila
            _rabbitMQMessageSender.SendMessage(dto, "checkoutqueue");

            return Ok(dto);
        }
    }
}