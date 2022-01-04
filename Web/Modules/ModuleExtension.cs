namespace Web.Modules
{
    /// <summary>
    /// Module extension.
    /// </summary>
    public static class ModuleExtension
    {
        static readonly List<IModule> registeredModules = new();

        /// <summary>
        /// Registers the modules.
        /// </summary>
        /// <param name="builder">Application builder.</param>
        /// <returns></returns>
        public static WebApplicationBuilder RegisterModules(this WebApplicationBuilder builder)
        {
            var modules = DiscoverModules();

            foreach (var module in modules)
            {
                module.RegisterModules(builder.Services);
                registeredModules.Add(module);
            }

            return builder;
        }

        /// <summary>
        /// Maps the endpoints.
        /// </summary>
        /// <param name="app">Web application.</param>
        /// <returns></returns>
        public static WebApplication MapEndpoints(this WebApplication app)
        {
            foreach (var module in registeredModules)
            {
                module.MapEndpoints(app);
            }

            return app;
        }

        /// <summary>
        /// Discovers the modules.
        /// </summary>
        /// <returns>
        /// List of modules.
        /// </returns>
        private static IEnumerable<IModule> DiscoverModules()
        {
            return typeof(IModule).Assembly
                .GetTypes()
                .Where(p => p.IsClass && p.IsAssignableTo(typeof(IModule)))
                .Select(Activator.CreateInstance)
                .Cast<IModule>();
        }
    }
}
