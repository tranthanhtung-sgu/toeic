#pragma checksum "/Users/tranthanhtung/Desktop/CongNghePhanMem/Tung/mvcMovie/Views/Home/tableUser.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6578559e8c636c82a9400f99c65fb37933762e9e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_tableUser), @"mvc.1.0.view", @"/Views/Home/tableUser.cshtml")]
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
#line 1 "/Users/tranthanhtung/Desktop/CongNghePhanMem/Tung/mvcMovie/Views/_ViewImports.cshtml"
using Domain.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6578559e8c636c82a9400f99c65fb37933762e9e", @"/Views/Home/tableUser.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"37106fa2ab6bb7c306ea2371328db9c86058e300", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_tableUser : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "/Users/tranthanhtung/Desktop/CongNghePhanMem/Tung/mvcMovie/Views/Home/tableUser.cshtml"
  
    ViewData["Title"]="Khách hàng";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""row"">
    <div class=""col-xs-12"">
        <table id=""simple-table"" class=""table table-striped table-bordered table-hover"">
            <thead>
                <tr>
                    <th class=""center"">
                        <label class=""pos-rel"">
                            <input type=""checkbox"" class=""ace"">
                            <span class=""lbl""></span>
                        </label>
                    </th>
                    <th>Họ và Tên</th>
                    <th>Vai trò</th>
                    <th class=""hidden-480"">Ngày tham gia</th>

                    <th>
                        <i class=""ace-icon fa fa-clock-o bigger-200 hidden-480""></i>
                        Ngày sinh
                    </th>
                    <th class=""hidden-480"">Tình Trạng</th>

                    <th></th>
                </tr>
            </thead>

            <tbody>
                <tr");
            BeginWriteAttribute("class", " class=\"", 964, "\"", 972, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                    <td class=""center"">
                        <label class=""pos-rel"">
                            <input type=""checkbox"" class=""ace"">
                            <span class=""lbl""></span>
                        </label>
                    </td>

                    <td>
                        <a href=""#"">ace.com</a>
                    </td>
                    <td>$45</td>
                    <td class=""hidden-480"">3,330</td>
                    <td>Feb 12</td>

                    <td class=""hidden-480"">
                        <span class=""label label-sm label-warning"">Expiring</span>
                    </td>

                    <td>
                        <div class=""hidden-sm hidden-xs btn-group"">
                            <button class=""btn btn-xs btn-success"">
                                <i class=""ace-icon fa fa-check bigger-120""></i>
                            </button>

                            <button class=""btn btn-xs btn-info"">
                                <i");
            WriteLiteral(@" class=""ace-icon fa fa-pencil bigger-120""></i>
                            </button>

                            <button class=""btn btn-xs btn-danger"">
                                <i class=""ace-icon fa fa-trash-o bigger-120""></i>
                            </button>

                            <button class=""btn btn-xs btn-warning"">
                                <i class=""ace-icon fa fa-flag bigger-120""></i>
                            </button>
                        </div>

                        <div class=""hidden-md hidden-lg"">
                            <div class=""inline pos-rel"">
                                <button class=""btn btn-minier btn-primary dropdown-toggle"" data-toggle=""dropdown"" data-position=""auto"">
                                    <i class=""ace-icon fa fa-cog icon-only bigger-110""></i>
                                </button>

                                <ul class=""dropdown-menu dropdown-only-icon dropdown-yellow dropdown-menu-right dropdown-caret dropdown-close"">
   ");
            WriteLiteral("                                 <li>\n                                        <a href=\"#\" class=\"tooltip-info\" data-rel=\"tooltip\"");
            BeginWriteAttribute("title", " title=\"", 3150, "\"", 3158, 0);
            EndWriteAttribute();
            WriteLiteral(@" data-original-title=""View"">
                                            <span class=""blue"">
                                                <i class=""ace-icon fa fa-search-plus bigger-120""></i>
                                            </span>
                                        </a>
                                    </li>

                                    <li>
                                        <a href=""#"" class=""tooltip-success"" data-rel=""tooltip""");
            BeginWriteAttribute("title", " title=\"", 3629, "\"", 3637, 0);
            EndWriteAttribute();
            WriteLiteral(@" data-original-title=""Edit"">
                                            <span class=""green"">
                                                <i class=""ace-icon fa fa-pencil-square-o bigger-120""></i>
                                            </span>
                                        </a>
                                    </li>

                                    <li>
                                        <a href=""#"" class=""tooltip-error"" data-rel=""tooltip""");
            BeginWriteAttribute("title", " title=\"", 4111, "\"", 4119, 0);
            EndWriteAttribute();
            WriteLiteral(@" data-original-title=""Delete"">
                                            <span class=""red"">
                                                <i class=""ace-icon fa fa-trash-o bigger-120""></i>
                                            </span>
                                        </a>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </td>
                </tr>
            </tbody>
        </table>
    </div><!-- /.span -->
</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
