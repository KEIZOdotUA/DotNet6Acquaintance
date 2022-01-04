namespace Web.Modules.Apis
{
    public class ApisModule : IModule
    {
        public IServiceCollection RegisterModules(IServiceCollection services)
        {
            //services.AddSingleton(new OrderConfig());
            //services.AddScoped<IOrdersRepository, OrdersRepository>();
            //services.AddScoped<ICustomersRepository, CustomersRepository>();
            //services.AddScoped<IPayment, PaymentService>();
            return services;
        }

        private readonly string[] summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet("/summaries", () => summaries)
            .WithName("Summaries");

            return endpoints;
        }
    }
}
