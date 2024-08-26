using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.DeafaultComponents
{
    public class _DefaultBookATableComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
