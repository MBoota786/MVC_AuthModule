#pragma checksum "E:\_6_Authentication_Authorization_Other_Project\_3_Auth_Module_AtoZ\Views\Shared\Components\IdentityProfileComponent\Profile\Profile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4a02276f907bcac5dc24d77273e5e1c7f6e29672"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_IdentityProfileComponent_Profile_Profile), @"mvc.1.0.view", @"/Views/Shared/Components/IdentityProfileComponent/Profile/Profile.cshtml")]
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
using _3_Auth_Module_AtoZ.Component;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\_6_Authentication_Authorization_Other_Project\_3_Auth_Module_AtoZ\Views\_ViewImports.cshtml"
using DML._1_clsAuthentication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "E:\_6_Authentication_Authorization_Other_Project\_3_Auth_Module_AtoZ\Views\_ViewImports.cshtml"
using DML._3_Auth_Module;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "E:\_6_Authentication_Authorization_Other_Project\_3_Auth_Module_AtoZ\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "E:\_6_Authentication_Authorization_Other_Project\_3_Auth_Module_AtoZ\Views\_ViewImports.cshtml"
using DAL.Data;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a02276f907bcac5dc24d77273e5e1c7f6e29672", @"/Views/Shared/Components/IdentityProfileComponent/Profile/Profile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"492afc239bb4084beb8971b83429b3ae72afa4a5", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared_Components_IdentityProfileComponent_Profile_Profile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProfileViewModel>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<h1>Profile</h1>\r\n<p><strong>Username:</strong> ");
#nullable restore
#line 4 "E:\_6_Authentication_Authorization_Other_Project\_3_Auth_Module_AtoZ\Views\Shared\Components\IdentityProfileComponent\Profile\Profile.cshtml"
                         Write(Model.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n<p><strong>Email:</strong> ");
#nullable restore
#line 5 "E:\_6_Authentication_Authorization_Other_Project\_3_Auth_Module_AtoZ\Views\Shared\Components\IdentityProfileComponent\Profile\Profile.cshtml"
                      Write(Model.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProfileViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591