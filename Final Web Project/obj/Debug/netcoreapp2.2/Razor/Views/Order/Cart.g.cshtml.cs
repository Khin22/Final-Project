#pragma checksum "D:\Final-Project-Without-Sender\Final-Project\Final Web Project\Views\Order\Cart.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4ef3d3ba00820dfd167c25c5745efe73244c66e4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Order_Cart), @"mvc.1.0.view", @"/Views/Order/Cart.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Order/Cart.cshtml", typeof(AspNetCore.Views_Order_Cart))]
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
#line 1 "D:\Final-Project-Without-Sender\Final-Project\Final Web Project\Views\_ViewImports.cshtml"
using Final_Web_Project;

#line default
#line hidden
#line 2 "D:\Final-Project-Without-Sender\Final-Project\Final Web Project\Views\_ViewImports.cshtml"
using Final_Web_Project.Models;

#line default
#line hidden
#line 3 "D:\Final-Project-Without-Sender\Final-Project\Final Web Project\Views\_ViewImports.cshtml"
using Final_Web_Project.Areas;

#line default
#line hidden
#line 1 "D:\Final-Project-Without-Sender\Final-Project\Final Web Project\Views\Order\Cart.cshtml"
using Final_Web_Project.ViewModels.Order.Cart;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4ef3d3ba00820dfd167c25c5745efe73244c66e4", @"/Views/Order/Cart.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"460951bf2cddb7c5e920bb9f6d706f34d486c238", @"/Views/_ViewImports.cshtml")]
    public class Views_Order_Cart : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<OrderCartViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/Order/Cart/Complete"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("d-flex justify-content-between"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
#line 3 "D:\Final-Project-Without-Sender\Final-Project\Final Web Project\Views\Order\Cart.cshtml"
  
    ViewData["Title"] = "Cart";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(168, 457, true);
            WriteLiteral(@"
<h1 class=""text-left text-primary"">Cart</h1>
<hr class=""hr-2 bg-primary"">
<div id=""orders"" class=""text-primary"">
    <div class=""order-info row mt-4"">
        <h3 class=""col-md-1 text-left"">#</h3>
        <h3 class=""col-md-3 text-left"">Image</h3>
        <h3 class=""col-md-4 text-left"">Name</h3>
        <h3 class=""col-md-2 text-left"">Price</h3>
        <h3 class=""col-md-2 text-right"">Quantity</h3>
    </div>
    <hr class=""hr-2 bg-primary"">
");
            EndContext();
#line 19 "D:\Final-Project-Without-Sender\Final-Project\Final Web Project\Views\Order\Cart.cshtml"
     for (int i = 0; i < Model.Count; i++)
    {

#line default
#line hidden
            BeginContext(676, 76, true);
            WriteLiteral("        <div class=\"order row\">\r\n            <h5 class=\"col-md-1 text-left\">");
            EndContext();
            BeginContext(754, 5, false);
#line 22 "D:\Final-Project-Without-Sender\Final-Project\Final Web Project\Views\Order\Cart.cshtml"
                                       Write(i + 1);

#line default
#line hidden
            EndContext();
            BeginContext(760, 104, true);
            WriteLiteral("</h5>\r\n            <div class=\"col-md-3\">\r\n                <img class=\"img-thumbnail product-cart-image\"");
            EndContext();
            BeginWriteAttribute("src", "\r\n                     src=\"", 864, "\"", 915, 1);
#line 25 "D:\Final-Project-Without-Sender\Final-Project\Final Web Project\Views\Order\Cart.cshtml"
WriteAttributeValue("", 892, Model[i].RecordPicture, 892, 23, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(916, 68, true);
            WriteLiteral(" />\r\n            </div>\r\n            <h5 class=\"col-md-4 text-left\">");
            EndContext();
            BeginContext(985, 24, false);
#line 27 "D:\Final-Project-Without-Sender\Final-Project\Final Web Project\Views\Order\Cart.cshtml"
                                      Write(Model[i].RecordAlbumName);

#line default
#line hidden
            EndContext();
            BeginContext(1009, 50, true);
            WriteLiteral("</h5>\r\n            <h5 class=\"col-md-2 text-left\">");
            EndContext();
            BeginContext(1060, 20, false);
#line 28 "D:\Final-Project-Without-Sender\Final-Project\Final Web Project\Views\Order\Cart.cshtml"
                                      Write(Model[i].RecordPrice);

#line default
#line hidden
            EndContext();
            BeginContext(1080, 52, true);
            WriteLiteral("</h5>\r\n            <h5 class=\"col-md-2 text-right\">x");
            EndContext();
            BeginContext(1134, 17, false);
#line 29 "D:\Final-Project-Without-Sender\Final-Project\Final Web Project\Views\Order\Cart.cshtml"
                                         Write(Model[i].Quantity);

#line default
#line hidden
            EndContext();
            BeginContext(1152, 23, true);
            WriteLiteral("</h5>\r\n        </div>\r\n");
            EndContext();
#line 31 "D:\Final-Project-Without-Sender\Final-Project\Final Web Project\Views\Order\Cart.cshtml"
    }

#line default
#line hidden
            BeginContext(1182, 38, true);
            WriteLiteral("</div>\r\n<hr class=\"hr-2 bg-primary\">\r\n");
            EndContext();
            BeginContext(1220, 282, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4ef3d3ba00820dfd167c25c5745efe73244c66e48313", async() => {
                BeginContext(1309, 109, true);
                WriteLiteral("\r\n    <button class=\"btn btn-primary font-weight-bold\">Cashout</button>\r\n    <h2 class=\"text-primary\">Total: ");
                EndContext();
                BeginContext(1419, 69, false);
#line 36 "D:\Final-Project-Without-Sender\Final-Project\Final Web Project\Views\Order\Cart.cshtml"
                               Write(Model.Sum(order => order.RecordPrice * order.Quantity).ToString("F2"));

#line default
#line hidden
                EndContext();
                BeginContext(1488, 7, true);
                WriteLiteral("</h2>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1502, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<OrderCartViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591