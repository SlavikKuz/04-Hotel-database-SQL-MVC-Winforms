#pragma checksum "d:\Repos\04 - HotelDB\HotelDb.WebUI\Views\ClientModel\History.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1293d205c97950bf81419b9dfdc2178bfd5c42df"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ClientModel_History), @"mvc.1.0.view", @"/Views/ClientModel/History.cshtml")]
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
#line 1 "d:\Repos\04 - HotelDB\HotelDb.WebUI\Views\_ViewImports.cshtml"
using WebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "d:\Repos\04 - HotelDB\HotelDb.WebUI\Views\_ViewImports.cshtml"
using WebApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1293d205c97950bf81419b9dfdc2178bfd5c42df", @"/Views/ClientModel/History.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fc48f17eb9bac3476d8060730298bf398eb2fa5e", @"/Views/_ViewImports.cshtml")]
    public class Views_ClientModel_History : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<HotelDb.WebUI.Models.ClientViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "d:\Repos\04 - HotelDB\HotelDb.WebUI\Views\ClientModel\History.cshtml"
  
    ViewData["Title"] = "History";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<table class=\"table col-md-6 mx-auto\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 11 "d:\Repos\04 - HotelDB\HotelDb.WebUI\Views\ClientModel\History.cshtml"
           Write(Html.DisplayNameFor(model => model.Client.ClientFullName));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            </th>
            <th>
                Order Date
            </th>
            <th>
                Status
            </th>
            <th>
                Invoice No
            </th>
            <th></th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 26 "d:\Repos\04 - HotelDB\HotelDb.WebUI\Views\ClientModel\History.cshtml"
     foreach (var b in Model.Bookings)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 30 "d:\Repos\04 - HotelDB\HotelDb.WebUI\Views\ClientModel\History.cshtml"
           Write(Html.DisplayFor(modelItem => Model.Client.ClientFullName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 33 "d:\Repos\04 - HotelDB\HotelDb.WebUI\Views\ClientModel\History.cshtml"
           Write(Html.DisplayFor(modelItem => b.OrderDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 36 "d:\Repos\04 - HotelDB\HotelDb.WebUI\Views\ClientModel\History.cshtml"
           Write(Html.DisplayFor(modelItem => b.Status));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 39 "d:\Repos\04 - HotelDB\HotelDb.WebUI\Views\ClientModel\History.cshtml"
           Write(Html.DisplayFor(modelItem => b.InvoiceId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 42 "d:\Repos\04 - HotelDB\HotelDb.WebUI\Views\ClientModel\History.cshtml"
           Write(Html.ActionLink("Show Invoice", "Invoice", new { id=b.InvoiceId }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 45 "d:\Repos\04 - HotelDB\HotelDb.WebUI\Views\ClientModel\History.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<HotelDb.WebUI.Models.ClientViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
