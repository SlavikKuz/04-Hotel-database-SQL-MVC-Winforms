#pragma checksum "d:\Repos\04 - HotelDB\HotelDb.WebUI\Views\RoomModel\ShowPricePage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7bf88e53136d04bbfba4bc62374cde23d0e34dd0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_RoomModel_ShowPricePage), @"mvc.1.0.view", @"/Views/RoomModel/ShowPricePage.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7bf88e53136d04bbfba4bc62374cde23d0e34dd0", @"/Views/RoomModel/ShowPricePage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fc48f17eb9bac3476d8060730298bf398eb2fa5e", @"/Views/_ViewImports.cshtml")]
    public class Views_RoomModel_ShowPricePage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<HotelDb.WebUI.Models.RoomPriceModel>
    {
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "d:\Repos\04 - HotelDB\HotelDb.WebUI\Views\RoomModel\ShowPricePage.cshtml"
  
    ViewData["Title"] = "ShowPrice";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"col-md-4 mx-auto\">\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7bf88e53136d04bbfba4bc62374cde23d0e34dd03516", async() => {
                WriteLiteral("\r\n        <dl class=\"row\">\r\n            <dt class=\"col-md-6\">\r\n                ");
#nullable restore
#line 12 "d:\Repos\04 - HotelDB\HotelDb.WebUI\Views\RoomModel\ShowPricePage.cshtml"
           Write(Html.DisplayNameFor(model => model.AveragePrice));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </dt>\r\n            <dd class=\"col-md-6\">\r\n                ");
#nullable restore
#line 15 "d:\Repos\04 - HotelDB\HotelDb.WebUI\Views\RoomModel\ShowPricePage.cshtml"
           Write(Html.DisplayFor(model => model.AveragePrice));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </dd>\r\n            <dt class=\"col-md-6\">\r\n                ");
#nullable restore
#line 18 "d:\Repos\04 - HotelDB\HotelDb.WebUI\Views\RoomModel\ShowPricePage.cshtml"
           Write(Html.DisplayNameFor(model => model.WeekendPrice));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </dt>\r\n            <dd class=\"col-md-6\">\r\n                ");
#nullable restore
#line 21 "d:\Repos\04 - HotelDB\HotelDb.WebUI\Views\RoomModel\ShowPricePage.cshtml"
           Write(Html.DisplayFor(model => model.WeekendPrice));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </dd>\r\n            <dt class=\"col-md-6\">\r\n                ");
#nullable restore
#line 24 "d:\Repos\04 - HotelDB\HotelDb.WebUI\Views\RoomModel\ShowPricePage.cshtml"
           Write(Html.DisplayNameFor(model => model.HolidayPrice));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </dt>\r\n            <dd class=\"col-md-6\">\r\n                ");
#nullable restore
#line 27 "d:\Repos\04 - HotelDB\HotelDb.WebUI\Views\RoomModel\ShowPricePage.cshtml"
           Write(Html.DisplayFor(model => model.HolidayPrice));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </dd>\r\n        </dl>\r\n        <div>\r\n            <span class=\"badge badge-light mx-auto\">\r\n                ");
#nullable restore
#line 32 "d:\Repos\04 - HotelDB\HotelDb.WebUI\Views\RoomModel\ShowPricePage.cshtml"
           Write(Html.ActionLink("Edit", "EditPrice", new { id = Model.Id }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </span>\r\n        </div>\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<HotelDb.WebUI.Models.RoomPriceModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
