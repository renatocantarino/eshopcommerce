using Discount.GRPC.Models;
using Microsoft.Extensions.Caching.Memory;

namespace Discount.GRPC.Services;

public class DiscountProtoService(DiscountContext dbContext, IMemoryCache memoryCache, ILogger<DiscountProtoService> logger) : DiscountService.DiscountServiceBase
{
    public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
    {
        var coupon = request.Coupon.Adapt<Coupon>();
        if (coupon is null)
            throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid request object."));

        coupon.ProductId = Guid.NewGuid().ToString();
        dbContext.Coupons.Add(coupon);
        await dbContext.SaveChangesAsync();

        logger.LogInformation("Discount is successfully created. ProductName : {ProductName}", coupon.ProductName);

        var couponModel = coupon.Adapt<CouponModel>();
        return couponModel;
    }

    public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
    {
        var coupon = await dbContext
            .Coupons
            .FirstOrDefaultAsync(x => x.ProductId == request.ProductName)
                    ?? throw new RpcException(new Status(StatusCode.NotFound, $"Discount with ProductName={request.ProductName} is not found."));

        dbContext.Coupons.Remove(coupon);
        await dbContext.SaveChangesAsync();

        memoryCache.Remove(coupon.ProductId);
        logger.LogInformation("cache removed on delete : {ProductName}", coupon.ProductId);

        logger.LogInformation("Discount is successfully deleted. ProductName : {ProductName}", request.ProductName);

        return new DeleteDiscountResponse { Success = true };
    }

    public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
    {
        return await memoryCache.GetOrCreateAsync(request.ProductName, async entry =>
        {
            entry.SlidingExpiration = TimeSpan.FromMinutes(5);
            var result = await dbContext.Coupons.FirstOrDefaultAsync(x => x.ProductId == request.ProductName);

            if (result is null)
            {
                result = new Coupon { ProductName = "No Discount", Amount = 0 };
            }

            logger.LogInformation("Discount is retrieved for ProductName : {productName}, Amount : {amount}", result.ProductName, result.Amount);
            logger.LogInformation("cache adds on get : {ProductName}", result.ProductName);
            var _model = result.Adapt<CouponModel>();
            return _model;
        });
    }

    public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
    {
        var coupon = request.Coupon.Adapt<Coupon>()
                            ?? throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid request object."));

        dbContext.Coupons.Update(coupon);
        await dbContext.SaveChangesAsync();

        logger.LogInformation("Discount is successfully updated. ProductName : {ProductName}", coupon.ProductName);
        memoryCache.Remove(coupon.ProductId);
        logger.LogInformation("cache removed on update : {ProductName}", coupon.ProductName);

        var couponModel = coupon.Adapt<CouponModel>();
        return couponModel;
    }
}