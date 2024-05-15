using Microsoft.AspNetCore.Mvc;

namespace MongoDbSampleApi.Extensions;

public static class ControllerExtension
{
    public static IActionResult CreateActionResult<TModel>(this TModel model)
        => model != null ? new OkObjectResult(model) : new BadRequestResult();
    
    public static IActionResult CreateActionResult<TModel>(this IReadOnlyCollection<TModel> models)
        where TModel : class
        => models != null && models.Any() ? new OkObjectResult(models) : new BadRequestResult();
}