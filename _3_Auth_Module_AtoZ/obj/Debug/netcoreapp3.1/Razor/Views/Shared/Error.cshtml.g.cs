#pragma checksum "E:\_6_Authentication_Authorization_Other_Project\_3_Auth_Module_AtoZ\Views\Shared\Error.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d6a5625cc8fb4476f348b0fe9041c550465d8bf9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Error), @"mvc.1.0.view", @"/Views/Shared/Error.cshtml")]
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
#line 5 "E:\_6_Authentication_Authorization_Other_Project\_3_Auth_Module_AtoZ\Views\_ViewImports.cshtml"
using DML._3_Auth_Module;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "E:\_6_Authentication_Authorization_Other_Project\_3_Auth_Module_AtoZ\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "E:\_6_Authentication_Authorization_Other_Project\_3_Auth_Module_AtoZ\Views\_ViewImports.cshtml"
using DAL.Data;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d6a5625cc8fb4476f348b0fe9041c550465d8bf9", @"/Views/Shared/Error.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"732f784f33d09b117ebac854a6b001336ee1b9e5", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared_Error : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ErrorViewModel>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "E:\_6_Authentication_Authorization_Other_Project\_3_Auth_Module_AtoZ\Views\Shared\Error.cshtml"
  
    ViewData["Title"] = "Error";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1 class=\"text-danger\">Error.</h1>\r\n<h2 class=\"text-danger\">An error occurred while processing your request.</h2>\r\n\r\n");
#nullable restore
#line 9 "E:\_6_Authentication_Authorization_Other_Project\_3_Auth_Module_AtoZ\Views\Shared\Error.cshtml"
 if (Model.ShowRequestId)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>\r\n        <strong>Request ID:</strong> <code>");
#nullable restore
#line 12 "E:\_6_Authentication_Authorization_Other_Project\_3_Auth_Module_AtoZ\Views\Shared\Error.cshtml"
                                      Write(Model.RequestId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</code>\r\n    </p>\r\n");
#nullable restore
#line 14 "E:\_6_Authentication_Authorization_Other_Project\_3_Auth_Module_AtoZ\Views\Shared\Error.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h3>Development Mode</h3>
<p>
    Swapping to <strong>Development</strong> environment will display more detailed information about the error that occurred.
</p>
<p>
    <strong>The Development environment shouldn't be enabled for deployed applications.</strong>
    It can result in displaying sensitive information from exceptions to end users.
    For local debugging, enable the <strong>Development</strong> environment by setting the <strong>ASPNETCORE_ENVIRONMENT</strong> environment variable to <strong>Development</strong>
    and restarting the app.
</p>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ErrorViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
