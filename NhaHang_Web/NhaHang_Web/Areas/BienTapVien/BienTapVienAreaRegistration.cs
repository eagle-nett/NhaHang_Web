using System.Web.Mvc;

namespace NhaHang_Web.Areas.BienTapVien
{
    public class BienTapVienAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "BienTapVien";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "BienTapVien_default",
                "BienTapVien/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}