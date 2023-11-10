using Microsoft.AspNetCore.Mvc;

namespace _3_Auth_Module_AtoZ.Component
{
    public class AccountSettingsViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            //___ 1 ___
            //if you gave name in  View  then  Name shuld defined in Component folder for View
            //return View("AccountSettings");

            //___ 2 ___
            //if you did not give name in View ---> Then  Name of View will be      default.cshtml
            return View();
        }
    }
}
