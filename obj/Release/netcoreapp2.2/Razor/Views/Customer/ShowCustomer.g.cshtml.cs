#pragma checksum "C:\Users\loveh\source\repos\BankApp\BankApplication\Views\Customer\ShowCustomer.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "625e565b1d908d5d655e19b461a3a6ad5b817393"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Customer_ShowCustomer), @"mvc.1.0.view", @"/Views/Customer/ShowCustomer.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Customer/ShowCustomer.cshtml", typeof(AspNetCore.Views_Customer_ShowCustomer))]
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
#line 1 "C:\Users\loveh\source\repos\BankApp\BankApplication\Views\_ViewImports.cshtml"
using BankApplication;

#line default
#line hidden
#line 2 "C:\Users\loveh\source\repos\BankApp\BankApplication\Views\_ViewImports.cshtml"
using BankApplication.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"625e565b1d908d5d655e19b461a3a6ad5b817393", @"/Views/Customer/ShowCustomer.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f308b672152e4c7bc9e037f0d30493ba0f4632b2", @"/Views/_ViewImports.cshtml")]
    public class Views_Customer_ShowCustomer : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CustomerDetailViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Customer", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ShowCustomers", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn form-btn border-0"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "ManageCustomer", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "UpdateCustomer", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Account", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ShowAccountInfo", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(32, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 4 "C:\Users\loveh\source\repos\BankApp\BankApplication\Views\Customer\ShowCustomer.cshtml"
 if (@Model.Customers.Count == 0)
{

#line default
#line hidden
            BeginContext(74, 164, true);
            WriteLiteral("    <div class=\"row\">\r\n        <div class=\"col l4 offset-l4\">\r\n            <h3>There is no customer with that customer number..</h3>\r\n\r\n        </div>\r\n    </div>\r\n");
            EndContext();
#line 12 "C:\Users\loveh\source\repos\BankApp\BankApplication\Views\Customer\ShowCustomer.cshtml"
}
else
{

#line default
#line hidden
            BeginContext(250, 4, true);
            WriteLiteral("    ");
            EndContext();
            BeginContext(254, 67, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "625e565b1d908d5d655e19b461a3a6ad5b8173936174", async() => {
                BeginContext(310, 7, true);
                WriteLiteral("Go back");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(321, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(325, 69, true);
            WriteLiteral("    <div class=\"row\">\r\n        <div class=\"col l6\">\r\n\r\n\r\n            ");
            EndContext();
            BeginContext(394, 143, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "625e565b1d908d5d655e19b461a3a6ad5b8173937932", async() => {
                BeginContext(527, 6, true);
                WriteLiteral("Update");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 21 "C:\Users\loveh\source\repos\BankApp\BankApplication\Views\Customer\ShowCustomer.cshtml"
                                               WriteLiteral(Model.currentCustomerId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(537, 8, true);
            WriteLiteral("\r\n\r\n\r\n\r\n");
            EndContext();
#line 25 "C:\Users\loveh\source\repos\BankApp\BankApplication\Views\Customer\ShowCustomer.cshtml"
             foreach (var i in @Model.Customers)
            {

#line default
#line hidden
            BeginContext(610, 100, true);
            WriteLiteral("                <p class=\"customerDetailFont\">Customer number: <span class=\"customerDetailFontSpan\">");
            EndContext();
            BeginContext(711, 12, false);
#line 27 "C:\Users\loveh\source\repos\BankApp\BankApplication\Views\Customer\ShowCustomer.cshtml"
                                                                                               Write(i.CustomerId);

#line default
#line hidden
            EndContext();
            BeginContext(723, 132, true);
            WriteLiteral("</span></p>\r\n                <hr />\r\n                <p class=\"customerDetailFont\">Given name: <span class=\"customerDetailFontSpan\">");
            EndContext();
            BeginContext(856, 11, false);
#line 29 "C:\Users\loveh\source\repos\BankApp\BankApplication\Views\Customer\ShowCustomer.cshtml"
                                                                                          Write(i.GivenName);

#line default
#line hidden
            EndContext();
            BeginContext(867, 154, true);
            WriteLiteral("</span></p>\r\n                <hr class=\"customerDetailHr\" />\r\n                <p class=\"customerDetailFont\">Surname: <span class=\"customerDetailFontSpan\">");
            EndContext();
            BeginContext(1022, 9, false);
#line 31 "C:\Users\loveh\source\repos\BankApp\BankApplication\Views\Customer\ShowCustomer.cshtml"
                                                                                       Write(i.Surname);

#line default
#line hidden
            EndContext();
            BeginContext(1031, 158, true);
            WriteLiteral("</span></p>\r\n                <hr class=\"customerDetailHr\" />\r\n                <p class=\"customerDetailFont\">National Id: <span class=\"customerDetailFontSpan\">");
            EndContext();
            BeginContext(1190, 12, false);
#line 33 "C:\Users\loveh\source\repos\BankApp\BankApplication\Views\Customer\ShowCustomer.cshtml"
                                                                                           Write(i.NationalId);

#line default
#line hidden
            EndContext();
            BeginContext(1202, 154, true);
            WriteLiteral("</span></p>\r\n                <hr class=\"customerDetailHr\" />\r\n                <p class=\"customerDetailFont\">Address: <span class=\"customerDetailFontSpan\">");
            EndContext();
            BeginContext(1357, 9, false);
#line 35 "C:\Users\loveh\source\repos\BankApp\BankApplication\Views\Customer\ShowCustomer.cshtml"
                                                                                       Write(i.Address);

#line default
#line hidden
            EndContext();
            BeginContext(1366, 151, true);
            WriteLiteral("</span></p>\r\n                <hr class=\"customerDetailHr\" />\r\n                <p class=\"customerDetailFont\">City: <span class=\"customerDetailFontSpan\">");
            EndContext();
            BeginContext(1518, 6, false);
#line 37 "C:\Users\loveh\source\repos\BankApp\BankApplication\Views\Customer\ShowCustomer.cshtml"
                                                                                    Write(i.City);

#line default
#line hidden
            EndContext();
            BeginContext(1524, 37, true);
            WriteLiteral("</span></p>\r\n                <hr />\r\n");
            EndContext();
#line 39 "C:\Users\loveh\source\repos\BankApp\BankApplication\Views\Customer\ShowCustomer.cshtml"
            }

#line default
#line hidden
            BeginContext(1576, 48, true);
            WriteLiteral("        </div>\r\n\r\n        <div class=\"col l6\">\r\n");
            EndContext();
#line 43 "C:\Users\loveh\source\repos\BankApp\BankApplication\Views\Customer\ShowCustomer.cshtml"
             foreach (var i in @Model.CustomerAccounts)
            {

#line default
#line hidden
            BeginContext(1696, 62, true);
            WriteLiteral("                <p class=\"customerDetailFont\">Account number: ");
            EndContext();
            BeginContext(1758, 145, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "625e565b1d908d5d655e19b461a3a6ad5b81739314961", async() => {
                BeginContext(1843, 37, true);
                WriteLiteral("<span class=\"customerDetailFontSpan\">");
                EndContext();
                BeginContext(1881, 11, false);
#line 45 "C:\Users\loveh\source\repos\BankApp\BankApplication\Views\Customer\ShowCustomer.cshtml"
                                                                                                                                                                                   Write(i.AccountId);

#line default
#line hidden
                EndContext();
                BeginContext(1892, 7, true);
                WriteLiteral("</span>");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 45 "C:\Users\loveh\source\repos\BankApp\BankApplication\Views\Customer\ShowCustomer.cshtml"
                                                                                                                         WriteLiteral(i.AccountId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1903, 98, true);
            WriteLiteral("</p>\r\n                <p class=\"customerDetailFont\">Balance: <span class=\"customerDetailFontSpan\">");
            EndContext();
            BeginContext(2002, 23, false);
#line 46 "C:\Users\loveh\source\repos\BankApp\BankApplication\Views\Customer\ShowCustomer.cshtml"
                                                                                       Write(i.Balance.ToString("C"));

#line default
#line hidden
            EndContext();
            BeginContext(2025, 105, true);
            WriteLiteral("</span></p>\r\n                <p class=\"customerDetailFont\">Created: <span class=\"customerDetailFontSpan\">");
            EndContext();
            BeginContext(2131, 9, false);
#line 47 "C:\Users\loveh\source\repos\BankApp\BankApplication\Views\Customer\ShowCustomer.cshtml"
                                                                                       Write(i.Created);

#line default
#line hidden
            EndContext();
            BeginContext(2140, 37, true);
            WriteLiteral("</span></p>\r\n                <hr />\r\n");
            EndContext();
#line 49 "C:\Users\loveh\source\repos\BankApp\BankApplication\Views\Customer\ShowCustomer.cshtml"
            }

#line default
#line hidden
            BeginContext(2192, 94, true);
            WriteLiteral("            <p class=\"customerDetailFont\">Total balance: <span class=\"customerDetailFontSpan\">");
            EndContext();
            BeginContext(2287, 31, false);
#line 50 "C:\Users\loveh\source\repos\BankApp\BankApplication\Views\Customer\ShowCustomer.cshtml"
                                                                                         Write(Model.TotalAmount.ToString("C"));

#line default
#line hidden
            EndContext();
            BeginContext(2318, 41, true);
            WriteLiteral("</span></p>\r\n        </div>\r\n    </div>\r\n");
            EndContext();
#line 53 "C:\Users\loveh\source\repos\BankApp\BankApplication\Views\Customer\ShowCustomer.cshtml"
}

#line default
#line hidden
            BeginContext(2362, 6, true);
            WriteLiteral("\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CustomerDetailViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
