namespace MVCTraining.Utility
{
    public static class UtilityImporter
    {
        public static void Use(IEndpointRouteBuilder endpoints)
        {
            endpoints.MapAreaControllerRoute(name: "area_utility", areaName: "Utility",
                  pattern: "utility/{controller}/{action}/{id?}", defaults: new { controller = "Home", action = "Index" });

        }
    }
}
