#pragma checksum "E:\_6_Authentication_Authorization_Other_Project\_3_Auth_Module_AtoZ\Views\Account\Login.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6192cdfb586ead0a4d2cc2697acdadf8b5c457ad"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_Login), @"mvc.1.0.view", @"/Views/Account/Login.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "E:\_6_Authentication_Authorization_Other_Project\_3_Auth_Module_AtoZ\Views\_ViewImports.cshtml"
using _3_Auth_Module_AtoZ;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\_6_Authentication_Authorization_Other_Project\_3_Auth_Module_AtoZ\Views\_ViewImports.cshtml"
using _3_Auth_Module_AtoZ.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\_6_Authentication_Authorization_Other_Project\_3_Auth_Module_AtoZ\Views\_ViewImports.cshtml"
using _3_Auth_Module_AtoZ.ViewModel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\_6_Authentication_Authorization_Other_Project\_3_Auth_Module_AtoZ\Views\_ViewImports.cshtml"
using DML._1_clsAuthentication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "E:\_6_Authentication_Authorization_Other_Project\_3_Auth_Module_AtoZ\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "E:\_6_Authentication_Authorization_Other_Project\_3_Auth_Module_AtoZ\Views\_ViewImports.cshtml"
using DAL.Data;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6192cdfb586ead0a4d2cc2697acdadf8b5c457ad", @"/Views/Account/Login.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0cc0d59f249e30a98aa11f44e7a67ce6d56d4d06", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Account_Login : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<LoginViewModel>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<h2>Login</h2>\r\n\r\n");
#nullable restore
#line 5 "E:\_6_Authentication_Authorization_Other_Project\_3_Auth_Module_AtoZ\Views\Account\Login.cshtml"
 using (Html.BeginForm("Login", "Account", FormMethod.Post))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "E:\_6_Authentication_Authorization_Other_Project\_3_Auth_Module_AtoZ\Views\Account\Login.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "E:\_6_Authentication_Authorization_Other_Project\_3_Auth_Module_AtoZ\Views\Account\Login.cshtml"
     if (!ViewData.ModelState.IsValid)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"alert alert-danger\">\r\n            <ul>\r\n");
#nullable restore
#line 13 "E:\_6_Authentication_Authorization_Other_Project\_3_Auth_Module_AtoZ\Views\Account\Login.cshtml"
                 foreach (var error in ViewData.ModelState.Values.SelectMany(v => v.Errors))
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li>");
#nullable restore
#line 15 "E:\_6_Authentication_Authorization_Other_Project\_3_Auth_Module_AtoZ\Views\Account\Login.cshtml"
                   Write(error.ErrorMessage);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 16 "E:\_6_Authentication_Authorization_Other_Project\_3_Auth_Module_AtoZ\Views\Account\Login.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </ul>\r\n        </div>\r\n");
#nullable restore
#line 19 "E:\_6_Authentication_Authorization_Other_Project\_3_Auth_Module_AtoZ\Views\Account\Login.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"form-group\">\r\n        ");
#nullable restore
#line 22 "E:\_6_Authentication_Authorization_Other_Project\_3_Auth_Module_AtoZ\Views\Account\Login.cshtml"
   Write(Html.LabelFor(m => m.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 23 "E:\_6_Authentication_Authorization_Other_Project\_3_Auth_Module_AtoZ\Views\Account\Login.cshtml"
   Write(Html.TextBoxFor(m => m.Email, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 24 "E:\_6_Authentication_Authorization_Other_Project\_3_Auth_Module_AtoZ\Views\Account\Login.cshtml"
   Write(Html.ValidationMessageFor(m => m.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n");
            WriteLiteral("    <div class=\"form-group\">\r\n        ");
#nullable restore
#line 28 "E:\_6_Authentication_Authorization_Other_Project\_3_Auth_Module_AtoZ\Views\Account\Login.cshtml"
   Write(Html.LabelFor(m => m.Password));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 29 "E:\_6_Authentication_Authorization_Other_Project\_3_Auth_Module_AtoZ\Views\Account\Login.cshtml"
   Write(Html.PasswordFor(m => m.Password, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 30 "E:\_6_Authentication_Authorization_Other_Project\_3_Auth_Module_AtoZ\Views\Account\Login.cshtml"
   Write(Html.ValidationMessageFor(m => m.Password));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n");
            WriteLiteral("    <div class=\"form-group\">\r\n        <div class=\"checkbox\">\r\n            ");
#nullable restore
#line 35 "E:\_6_Authentication_Authorization_Other_Project\_3_Auth_Module_AtoZ\Views\Account\Login.cshtml"
       Write(Html.LabelFor(m => m.RememberMe));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 36 "E:\_6_Authentication_Authorization_Other_Project\_3_Auth_Module_AtoZ\Views\Account\Login.cshtml"
       Write(Html.CheckBoxFor(m => m.RememberMe));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <!--------- Forget Password ----------->\r\n    <p>\r\n        <a");
            BeginWriteAttribute("href", " href=\"", 1145, "\"", 1192, 1);
#nullable restore
#line 41 "E:\_6_Authentication_Authorization_Other_Project\_3_Auth_Module_AtoZ\Views\Account\Login.cshtml"
WriteAttributeValue("", 1152, Url.Action("ForgotPassword", "Account"), 1152, 40, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Forgot your password?</a>\r\n    </p>\r\n    <button type=\"submit\" class=\"btn btn-primary\">Login</button>\r\n");
#nullable restore
#line 44 "E:\_6_Authentication_Authorization_Other_Project\_3_Auth_Module_AtoZ\Views\Account\Login.cshtml"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LoginViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
