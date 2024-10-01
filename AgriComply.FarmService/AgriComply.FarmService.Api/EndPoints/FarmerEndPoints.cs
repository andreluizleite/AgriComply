using AgriComply.FarmerService.Application.Commands;
using AgriComply.FarmService.Api.Request;
using Carter;
using MediatR;

namespace AgriComply.FarmService.Api.EndPoints
{
    public class FarmerEndPoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/farmers");
            group.MapPost("", CreateFarmer);
        }

        private static async Task<IResult> CreateFarmer(CreateFarmerRequest request, ISender sender)
        {
            try
            {
                CreateFarmerCommand command = new CreateFarmerCommand(request.FarmerName);
                var farmerResponse = await sender.Send(command);

                return Results.Ok(farmerResponse);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex);
            }
        }
    }
}
