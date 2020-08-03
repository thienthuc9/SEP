using System.Web.Mvc;

namespace SEP2020.Areas.SEP
{
    public class SEPAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "SEP";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "SEP_default",
                "SEP/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}