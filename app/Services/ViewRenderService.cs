using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace App.Services
{
    public class ViewRenderService : IViewRenderService
    {
        private readonly IRazorViewEngine _razorViewEngine;
        private readonly ITempDataProvider _tempDataProvider;
        private readonly IServiceProvider _serviceProvider;

        public ViewRenderService(
            IRazorViewEngine razorViewEngine,
            ITempDataProvider tempDataProvider,
            IServiceProvider serviceProvider)
        {
            _razorViewEngine = razorViewEngine;
            _tempDataProvider = tempDataProvider;
            _serviceProvider = serviceProvider;
        }

        public async Task<string> Render(string viewName, object model)
        {
            var httpContext = new DefaultHttpContext { RequestServices = _serviceProvider };

            var actionContext = new ActionContext(httpContext, new RouteData(), new ActionDescriptor());

            using var sw = new StringWriter();

            var viewResult = _razorViewEngine.GetView(null, $"Views/{viewName}.cshtml", false);

            if (!viewResult.Success)
            {
                throw new ArgumentNullException($"{viewName} does not match any available view");
            }

            var viewDataDictionary = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
            {
                Model = model,
            };

            var tempDataDictionary = new TempDataDictionary(actionContext.HttpContext, _tempDataProvider);

            var viewContext = new ViewContext(actionContext, viewResult.View, viewDataDictionary, tempDataDictionary, sw, new HtmlHelperOptions());

            await viewResult.View.RenderAsync(viewContext);

            return sw.ToString();
        }
    }
}