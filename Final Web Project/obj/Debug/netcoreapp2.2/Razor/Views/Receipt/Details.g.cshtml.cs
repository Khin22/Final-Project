#pragma checksum "D:\Final-Project-Without-Sender\Final-Project\Final Web Project\Views\Receipt\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "01a63ad6b2c856e6f3f9545d2cc81bc2c04abc33"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Receipt_Details), @"mvc.1.0.view", @"/Views/Receipt/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Receipt/Details.cshtml", typeof(AspNetCore.Views_Receipt_Details))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"01a63ad6b2c856e6f3f9545d2cc81bc2c04abc33", @"/Views/Receipt/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"460951bf2cddb7c5e920bb9f6d706f34d486c238", @"/Views/_ViewImports.cshtml")]
    public class Views_Receipt_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Final_Web_Project.ViewModels.Receipt.Details.ReceiptDetailsViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(77, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\Final-Project-Without-Sender\Final-Project\Final Web Project\Views\Receipt\Details.cshtml"
  
    ViewData["Title"] = "Details";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(169, 129, true);
            WriteLiteral("\r\n\r\n<h1 class=\"text-center\">Receipt Details</h1>\r\n<hr class=\"hr-2 bg-primary w-50\">\r\n<div class=\"products-holder w-50 mx-auto\">\r\n");
            EndContext();
#line 12 "D:\Final-Project-Without-Sender\Final-Project\Final Web Project\Views\Receipt\Details.cshtml"
     foreach (var order in Model.Orders)
    {

#line default
#line hidden
            BeginContext(347, 127, true);
            WriteLiteral("        <div class=\"product d-flex justify-content-between\">\r\n            <div class=\"product-name w-75\">\r\n                <h4>");
            EndContext();
            BeginContext(475, 21, false);
#line 16 "D:\Final-Project-Without-Sender\Final-Project\Final Web Project\Views\Receipt\Details.cshtml"
               Write(order.RecordAlbumName);

#line default
#line hidden
            EndContext();
            BeginContext(496, 161, true);
            WriteLiteral("</h4>\r\n            </div>\r\n            <div class=\"product-quantity-and-price d-flex justify-content-between w-25\">\r\n                <h4 class=\"text-left w-50\">x");
            EndContext();
            BeginContext(659, 14, false);
#line 19 "D:\Final-Project-Without-Sender\Final-Project\Final Web Project\Views\Receipt\Details.cshtml"
                                        Write(order.Quantity);

#line default
#line hidden
            EndContext();
            BeginContext(674, 52, true);
            WriteLiteral("</h4>\r\n                <h4 class=\"text-right w-50\">$");
            EndContext();
            BeginContext(728, 32, false);
#line 20 "D:\Final-Project-Without-Sender\Final-Project\Final Web Project\Views\Receipt\Details.cshtml"
                                         Write(order.RecordPrice.ToString("F2"));

#line default
#line hidden
            EndContext();
            BeginContext(761, 43, true);
            WriteLiteral("</h4>\r\n            </div>\r\n        </div>\r\n");
            EndContext();
#line 23 "D:\Final-Project-Without-Sender\Final-Project\Final Web Project\Views\Receipt\Details.cshtml"
    }

#line default
#line hidden
            BeginContext(811, 281, true);
            WriteLiteral(@"</div>
<hr class=""hr-2 bg-primary w-50"">
<div class=""finish-order-holder w-50 mx-auto d-flex justify-content-between"">
    <div class=""form-holder w-25"">
        <h3 class=""text-left"">Total</h3>
    </div>
    <div class=""price-holder w-25"">
        <h3 class=""text-right"">$");
            EndContext();
            BeginContext(1093, 76, false);
#line 31 "D:\Final-Project-Without-Sender\Final-Project\Final Web Project\Views\Receipt\Details.cshtml"
                           Write(Model.Orders.Sum(order => order.RecordPrice * order.Quantity).ToString("F2"));

#line default
#line hidden
            EndContext();
            BeginContext(1169, 303, true);
            WriteLiteral(@"</h3>
    </div>
</div>
<hr class=""hr-2 bg-primary w-50"">
<div class=""finish-order-holder w-50 mx-auto d-flex justify-content-between"">
    <div class=""form-holder w-25"">
        <h3 class=""text-left"">Issued On</h3>
    </div>
    <div class=""price-holder w-25"">
        <h3 class=""text-right"">");
            EndContext();
            BeginContext(1473, 37, false);
#line 40 "D:\Final-Project-Without-Sender\Final-Project\Final Web Project\Views\Receipt\Details.cshtml"
                          Write(Model.IssuedOn.ToString("dd/MM/yyyy"));

#line default
#line hidden
            EndContext();
            BeginContext(1510, 268, true);
            WriteLiteral(@"</h3>
    </div>
</div>
<div class=""finish-order-holder w-50 mx-auto d-flex justify-content-between"">
    <div class=""form-holder w-25"">
        <h3 class=""text-left"">Recipient</h3>
    </div>
    <div class=""price-holder w-25"">
        <h3 class=""text-right"">");
            EndContext();
            BeginContext(1779, 15, false);
#line 48 "D:\Final-Project-Without-Sender\Final-Project\Final Web Project\Views\Receipt\Details.cshtml"
                          Write(Model.Recipient);

#line default
#line hidden
            EndContext();
            BeginContext(1794, 301, true);
            WriteLiteral(@"</h3>
    </div>
</div>
<hr class=""hr-2 bg-primary w-50"">
<div class=""finish-order-holder w-50 mx-auto d-flex justify-content-between"">
    <div class=""form-holder w-25"">
        <h3 class=""text-left"">Receipt</h3>
    </div>
    <div class=""price-holder w-75"">
        <h3 class=""text-right"">");
            EndContext();
            BeginContext(2096, 8, false);
#line 57 "D:\Final-Project-Without-Sender\Final-Project\Final Web Project\Views\Receipt\Details.cshtml"
                          Write(Model.Id);

#line default
#line hidden
            EndContext();
            BeginContext(2104, 62, true);
            WriteLiteral("</h3>\r\n    </div>\r\n</div>\r\n<hr class=\"hr-2 bg-primary w-50\">\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Final_Web_Project.ViewModels.Receipt.Details.ReceiptDetailsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
