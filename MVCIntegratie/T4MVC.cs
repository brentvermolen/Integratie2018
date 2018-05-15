﻿// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments and CLS compliance
// 0108: suppress "Foo hides inherited member Foo. Use the new keyword if hiding was intended." when a controller and its abstract parent are both processed
// 0114: suppress "Foo.BarController.Baz()' hides inherited member 'Qux.BarController.Baz()'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword." when an action (with an argument) overrides an action in a parent controller
#pragma warning disable 1591, 3008, 3009, 0108, 0114
#region T4MVC

using System;
using System.Diagnostics;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4MVC;

[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
public static partial class MVC
{
    public static MVCIntegratie.Controllers.AccountController Account = new MVCIntegratie.Controllers.T4MVC_AccountController();
    public static MVCIntegratie.Controllers.AlertController Alert = new MVCIntegratie.Controllers.T4MVC_AlertController();
    public static MVCIntegratie.Controllers.BerichtController Bericht = new MVCIntegratie.Controllers.T4MVC_BerichtController();
    public static MVCIntegratie.Controllers.ConfigController Config = new MVCIntegratie.Controllers.T4MVC_ConfigController();
    public static MVCIntegratie.Controllers.FYIController FYI = new MVCIntegratie.Controllers.T4MVC_FYIController();
    public static MVCIntegratie.Controllers.GraphController Graph = new MVCIntegratie.Controllers.T4MVC_GraphController();
    public static MVCIntegratie.Controllers.HomeController Home = new MVCIntegratie.Controllers.T4MVC_HomeController();
    public static MVCIntegratie.Controllers.ManageController Manage = new MVCIntegratie.Controllers.T4MVC_ManageController();
    public static MVCIntegratie.Controllers.PersoonController Persoon = new MVCIntegratie.Controllers.T4MVC_PersoonController();
    public static MVCIntegratie.Controllers.RoleController Role = new MVCIntegratie.Controllers.T4MVC_RoleController();
    public static MVCIntegratie.Controllers.SearchController Search = new MVCIntegratie.Controllers.T4MVC_SearchController();
    public static T4MVC.SharedController Shared = new T4MVC.SharedController();
}

namespace T4MVC
{
}

#pragma warning disable 0436
namespace T4MVC
{
    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public class Dummy
    {
        private Dummy() { }
        public static Dummy Instance = new Dummy();
    }
}
#pragma warning restore 0436

[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
internal partial class T4MVC_System_Web_Mvc_ActionResult : System.Web.Mvc.ActionResult, IT4MVCActionResult
{
    public T4MVC_System_Web_Mvc_ActionResult(string area, string controller, string action, string protocol = null): base()
    {
        this.InitMVCT4Result(area, controller, action, protocol);
    }
     
    public override void ExecuteResult(System.Web.Mvc.ControllerContext context) { }
    
    public string Controller { get; set; }
    public string Action { get; set; }
    public string Protocol { get; set; }
    public RouteValueDictionary RouteValueDictionary { get; set; }
}



namespace Links
{
    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public static class Scripts {
        public const string UrlPath = "~/Scripts";
        public static string Url() { return T4MVCHelpers.ProcessVirtualPath(UrlPath); }
        public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(UrlPath + "/" + fileName); }
        public static readonly string bootstrap_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/bootstrap.min.js") ? Url("bootstrap.min.js") : Url("bootstrap.js");
        public static readonly string bootstrap_min_js = Url("bootstrap.min.js");
        public static readonly string Chart_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/Chart.min.js") ? Url("Chart.min.js") : Url("Chart.js");
        public static readonly string Config_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/Config.min.js") ? Url("Config.min.js") : Url("Config.js");
        public static readonly string datepicker_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/datepicker.min.js") ? Url("datepicker.min.js") : Url("datepicker.js");
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public static class ECharts {
            public const string UrlPath = "~/Scripts/ECharts";
            public static string Url() { return T4MVCHelpers.ProcessVirtualPath(UrlPath); }
            public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(UrlPath + "/" + fileName); }
            [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
            public static class chart {
                public const string UrlPath = "~/Scripts/ECharts/chart";
                public static string Url() { return T4MVCHelpers.ProcessVirtualPath(UrlPath); }
                public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(UrlPath + "/" + fileName); }
                public static readonly string bar_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/bar.min.js") ? Url("bar.min.js") : Url("bar.js");
                public static readonly string chord_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/chord.min.js") ? Url("chord.min.js") : Url("chord.js");
                public static readonly string eventRiver_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/eventRiver.min.js") ? Url("eventRiver.min.js") : Url("eventRiver.js");
                public static readonly string force_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/force.min.js") ? Url("force.min.js") : Url("force.js");
                public static readonly string funnel_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/funnel.min.js") ? Url("funnel.min.js") : Url("funnel.js");
                public static readonly string gauge_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/gauge.min.js") ? Url("gauge.min.js") : Url("gauge.js");
                public static readonly string k_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/k.min.js") ? Url("k.min.js") : Url("k.js");
                public static readonly string line_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/line.min.js") ? Url("line.min.js") : Url("line.js");
                public static readonly string map_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/map.min.js") ? Url("map.min.js") : Url("map.js");
                public static readonly string pie_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/pie.min.js") ? Url("pie.min.js") : Url("pie.js");
                public static readonly string radar_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/radar.min.js") ? Url("radar.min.js") : Url("radar.js");
                public static readonly string scatter_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/scatter.min.js") ? Url("scatter.min.js") : Url("scatter.js");
                public static readonly string tree_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/tree.min.js") ? Url("tree.min.js") : Url("tree.js");
                public static readonly string treemap_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/treemap.min.js") ? Url("treemap.min.js") : Url("treemap.js");
                public static readonly string venn_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/venn.min.js") ? Url("venn.min.js") : Url("venn.js");
                public static readonly string wordCloud_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/wordCloud.min.js") ? Url("wordCloud.min.js") : Url("wordCloud.js");
            }
        
            public static readonly string echarts_all_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/echarts-all.min.js") ? Url("echarts-all.min.js") : Url("echarts-all.js");
            public static readonly string echarts_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/echarts.min.js") ? Url("echarts.min.js") : Url("echarts.js");
        }
    
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public static class esm {
            public const string UrlPath = "~/Scripts/esm";
            public static string Url() { return T4MVCHelpers.ProcessVirtualPath(UrlPath); }
            public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(UrlPath + "/" + fileName); }
            public static readonly string popper_utils_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/popper-utils.min.js") ? Url("popper-utils.min.js") : Url("popper-utils.js");
            public static readonly string popper_utils_js_map = Url("popper-utils.js.map");
            public static readonly string popper_utils_min_js = Url("popper-utils.min.js");
            public static readonly string popper_utils_min_js_map = Url("popper-utils.min.js.map");
            public static readonly string popper_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/popper.min.js") ? Url("popper.min.js") : Url("popper.js");
            public static readonly string popper_js_map = Url("popper.js.map");
            public static readonly string popper_min_js = Url("popper.min.js");
            public static readonly string popper_min_js_map = Url("popper.min.js.map");
        }
    
        public static readonly string export_data_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/export-data.min.js") ? Url("export-data.min.js") : Url("export-data.js");
        public static readonly string exporting_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/exporting.min.js") ? Url("exporting.min.js") : Url("exporting.js");
        public static readonly string faq_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/faq.min.js") ? Url("faq.min.js") : Url("faq.js");
        public static readonly string highcharts_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/highcharts.min.js") ? Url("highcharts.min.js") : Url("highcharts.js");
        public static readonly string index_d_ts = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/index.d.min.js") ? Url("index.d.min.js") : Url("index.d.js");
        public static readonly string IngelogdeGebruiker_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/IngelogdeGebruiker.min.js") ? Url("IngelogdeGebruiker.min.js") : Url("IngelogdeGebruiker.js");
        public static readonly string jquery_3_0_0_vsdoc_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/jquery-3.0.0-vsdoc.min.js") ? Url("jquery-3.0.0-vsdoc.min.js") : Url("jquery-3.0.0-vsdoc.js");
        public static readonly string jquery_3_0_0_intellisense_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/jquery-3.0.0.intellisense.min.js") ? Url("jquery-3.0.0.intellisense.min.js") : Url("jquery-3.0.0.intellisense.js");
        public static readonly string jquery_3_0_0_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/jquery-3.0.0.min.js") ? Url("jquery-3.0.0.min.js") : Url("jquery-3.0.0.js");
        public static readonly string jquery_3_0_0_min_js = Url("jquery-3.0.0.min.js");
        public static readonly string jquery_3_0_0_min_map = Url("jquery-3.0.0.min.map");
        public static readonly string jquery_3_0_0_slim_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/jquery-3.0.0.slim.min.js") ? Url("jquery-3.0.0.slim.min.js") : Url("jquery-3.0.0.slim.js");
        public static readonly string jquery_3_0_0_slim_min_js = Url("jquery-3.0.0.slim.min.js");
        public static readonly string jquery_3_0_0_slim_min_map = Url("jquery-3.0.0.slim.min.map");
        public static readonly string jquery_validate_vsdoc_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/jquery.validate-vsdoc.min.js") ? Url("jquery.validate-vsdoc.min.js") : Url("jquery.validate-vsdoc.js");
        public static readonly string jquery_validate_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/jquery.validate.min.js") ? Url("jquery.validate.min.js") : Url("jquery.validate.js");
        public static readonly string jquery_validate_min_js = Url("jquery.validate.min.js");
        public static readonly string jquery_validate_unobtrusive_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/jquery.validate.unobtrusive.min.js") ? Url("jquery.validate.unobtrusive.min.js") : Url("jquery.validate.unobtrusive.js");
        public static readonly string jquery_validate_unobtrusive_min_js = Url("jquery.validate.unobtrusive.min.js");
        public static readonly string MaakGrafiek_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/MaakGrafiek.min.js") ? Url("MaakGrafiek.min.js") : Url("MaakGrafiek.js");
        public static readonly string modernizr_2_6_2_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/modernizr-2.6.2.min.js") ? Url("modernizr-2.6.2.min.js") : Url("modernizr-2.6.2.js");
        public static readonly string Over_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/Over.min.js") ? Url("Over.min.js") : Url("Over.js");
        public static readonly string popper_utils_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/popper-utils.min.js") ? Url("popper-utils.min.js") : Url("popper-utils.js");
        public static readonly string popper_utils_js_map = Url("popper-utils.js.map");
        public static readonly string popper_utils_min_js = Url("popper-utils.min.js");
        public static readonly string popper_utils_min_js_map = Url("popper-utils.min.js.map");
        public static readonly string popper_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/popper.min.js") ? Url("popper.min.js") : Url("popper.js");
        public static readonly string popper_js_map = Url("popper.js.map");
        public static readonly string popper_min_js = Url("popper.min.js");
        public static readonly string popper_min_js_map = Url("popper.min.js.map");
        public static readonly string README_md = Url("README.md");
        public static readonly string ReadOnly_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/ReadOnly.min.js") ? Url("ReadOnly.min.js") : Url("ReadOnly.js");
        public static readonly string respond_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/respond.min.js") ? Url("respond.min.js") : Url("respond.js");
        public static readonly string respond_matchmedia_addListener_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/respond.matchmedia.addListener.min.js") ? Url("respond.matchmedia.addListener.min.js") : Url("respond.matchmedia.addListener.js");
        public static readonly string respond_matchmedia_addListener_min_js = Url("respond.matchmedia.addListener.min.js");
        public static readonly string respond_min_js = Url("respond.min.js");
        public static readonly string series_label_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/series-label.min.js") ? Url("series-label.min.js") : Url("series-label.js");
        public static readonly string TypeGeladen_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/TypeGeladen.min.js") ? Url("TypeGeladen.min.js") : Url("TypeGeladen.js");
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public static class umd {
            public const string UrlPath = "~/Scripts/umd";
            public static string Url() { return T4MVCHelpers.ProcessVirtualPath(UrlPath); }
            public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(UrlPath + "/" + fileName); }
            public static readonly string popper_utils_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/popper-utils.min.js") ? Url("popper-utils.min.js") : Url("popper-utils.js");
            public static readonly string popper_utils_js_map = Url("popper-utils.js.map");
            public static readonly string popper_utils_min_js = Url("popper-utils.min.js");
            public static readonly string popper_utils_min_js_map = Url("popper-utils.min.js.map");
            public static readonly string popper_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/popper.min.js") ? Url("popper.min.js") : Url("popper.js");
            public static readonly string popper_js_map = Url("popper.js.map");
            public static readonly string popper_min_js = Url("popper.min.js");
            public static readonly string popper_min_js_map = Url("popper.min.js.map");
        }
    
        public static readonly string WijzigGrafiekType_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/WijzigGrafiekType.min.js") ? Url("WijzigGrafiekType.min.js") : Url("WijzigGrafiekType.js");
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public static class Content {
        public const string UrlPath = "~/Content";
        public static string Url() { return T4MVCHelpers.ProcessVirtualPath(UrlPath); }
        public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(UrlPath + "/" + fileName); }
        public static readonly string alles_json = Url("alles.json");
        public static readonly string bootstrap_theme_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/bootstrap-theme.min.css") ? Url("bootstrap-theme.min.css") : Url("bootstrap-theme.css");
        public static readonly string bootstrap_theme_min_css = Url("bootstrap-theme.min.css");
        public static readonly string bootstrap_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/bootstrap.min.css") ? Url("bootstrap.min.css") : Url("bootstrap.css");
        public static readonly string bootstrap_min_css = Url("bootstrap.min.css");
        public static readonly string Config_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/Config.min.css") ? Url("Config.min.css") : Url("Config.css");
        public static readonly string faq_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/faq.min.css") ? Url("faq.min.css") : Url("faq.css");
        public static readonly string Layout_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/Layout.min.css") ? Url("Layout.min.css") : Url("Layout.css");
        public static readonly string Site_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/Site.min.css") ? Url("Site.min.css") : Url("Site.css");
    }

    
    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public static partial class Bundles
    {
        public static partial class Scripts 
        {
            public static partial class ECharts 
            {
                public static partial class chart 
                {
                    public static class Assets
                    {
                        public static readonly string bar_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/ECharts/chart/bar.js"); 
                        public static readonly string chord_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/ECharts/chart/chord.js"); 
                        public static readonly string eventRiver_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/ECharts/chart/eventRiver.js"); 
                        public static readonly string force_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/ECharts/chart/force.js"); 
                        public static readonly string funnel_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/ECharts/chart/funnel.js"); 
                        public static readonly string gauge_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/ECharts/chart/gauge.js"); 
                        public static readonly string k_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/ECharts/chart/k.js"); 
                        public static readonly string line_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/ECharts/chart/line.js"); 
                        public static readonly string map_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/ECharts/chart/map.js"); 
                        public static readonly string pie_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/ECharts/chart/pie.js"); 
                        public static readonly string radar_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/ECharts/chart/radar.js"); 
                        public static readonly string scatter_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/ECharts/chart/scatter.js"); 
                        public static readonly string tree_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/ECharts/chart/tree.js"); 
                        public static readonly string treemap_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/ECharts/chart/treemap.js"); 
                        public static readonly string venn_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/ECharts/chart/venn.js"); 
                        public static readonly string wordCloud_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/ECharts/chart/wordCloud.js"); 
                    }
                }
                public static class Assets
                {
                    public static readonly string echarts_all_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/ECharts/echarts-all.js"); 
                    public static readonly string echarts_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/ECharts/echarts.js"); 
                }
            }
            public static partial class esm 
            {
                public static class Assets
                {
                    public static readonly string popper_utils_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/esm/popper-utils.js"); 
                    public static readonly string popper_utils_min_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/esm/popper-utils.min.js"); 
                    public static readonly string popper_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/esm/popper.js"); 
                    public static readonly string popper_min_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/esm/popper.min.js"); 
                }
            }
            public static partial class umd 
            {
                public static class Assets
                {
                    public static readonly string popper_utils_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/umd/popper-utils.js"); 
                    public static readonly string popper_utils_min_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/umd/popper-utils.min.js"); 
                    public static readonly string popper_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/umd/popper.js"); 
                    public static readonly string popper_min_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/umd/popper.min.js"); 
                }
            }
            public static class Assets
            {
                public static readonly string bootstrap_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/bootstrap.js"); 
                public static readonly string bootstrap_min_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/bootstrap.min.js"); 
                public static readonly string Chart_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/Chart.js"); 
                public static readonly string Config_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/Config.js"); 
                public static readonly string datepicker_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/datepicker.js"); 
                public static readonly string export_data_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/export-data.js"); 
                public static readonly string exporting_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/exporting.js"); 
                public static readonly string faq_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/faq.js"); 
                public static readonly string highcharts_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/highcharts.js"); 
                public static readonly string IngelogdeGebruiker_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/IngelogdeGebruiker.js"); 
                public static readonly string jquery_3_0_0_intellisense_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/jquery-3.0.0.intellisense.js"); 
                public static readonly string jquery_3_0_0_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/jquery-3.0.0.js"); 
                public static readonly string jquery_3_0_0_min_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/jquery-3.0.0.min.js"); 
                public static readonly string jquery_3_0_0_slim_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/jquery-3.0.0.slim.js"); 
                public static readonly string jquery_3_0_0_slim_min_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/jquery-3.0.0.slim.min.js"); 
                public static readonly string jquery_validate_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/jquery.validate.js"); 
                public static readonly string jquery_validate_min_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/jquery.validate.min.js"); 
                public static readonly string jquery_validate_unobtrusive_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/jquery.validate.unobtrusive.js"); 
                public static readonly string jquery_validate_unobtrusive_min_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/jquery.validate.unobtrusive.min.js"); 
                public static readonly string MaakGrafiek_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/MaakGrafiek.js"); 
                public static readonly string modernizr_2_6_2_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/modernizr-2.6.2.js"); 
                public static readonly string Over_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/Over.js"); 
                public static readonly string popper_utils_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/popper-utils.js"); 
                public static readonly string popper_utils_min_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/popper-utils.min.js"); 
                public static readonly string popper_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/popper.js"); 
                public static readonly string popper_min_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/popper.min.js"); 
                public static readonly string ReadOnly_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/ReadOnly.js"); 
                public static readonly string respond_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/respond.js"); 
                public static readonly string respond_matchmedia_addListener_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/respond.matchmedia.addListener.js"); 
                public static readonly string respond_matchmedia_addListener_min_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/respond.matchmedia.addListener.min.js"); 
                public static readonly string respond_min_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/respond.min.js"); 
                public static readonly string series_label_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/series-label.js"); 
                public static readonly string TypeGeladen_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/TypeGeladen.js"); 
                public static readonly string WijzigGrafiekType_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/WijzigGrafiekType.js"); 
            }
        }
        public static partial class Content 
        {
            public static class Assets
            {
                public static readonly string bootstrap_theme_css = T4MVCHelpers.ProcessAssetPath("~/Content/bootstrap-theme.css");
                public static readonly string bootstrap_theme_min_css = T4MVCHelpers.ProcessAssetPath("~/Content/bootstrap-theme.min.css");
                public static readonly string bootstrap_css = T4MVCHelpers.ProcessAssetPath("~/Content/bootstrap.css");
                public static readonly string bootstrap_min_css = T4MVCHelpers.ProcessAssetPath("~/Content/bootstrap.min.css");
                public static readonly string Config_css = T4MVCHelpers.ProcessAssetPath("~/Content/Config.css");
                public static readonly string faq_css = T4MVCHelpers.ProcessAssetPath("~/Content/faq.css");
                public static readonly string Layout_css = T4MVCHelpers.ProcessAssetPath("~/Content/Layout.css");
                public static readonly string Site_css = T4MVCHelpers.ProcessAssetPath("~/Content/Site.css");
            }
        }
    }
}

[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
internal static class T4MVCHelpers {
    // You can change the ProcessVirtualPath method to modify the path that gets returned to the client.
    // e.g. you can prepend a domain, or append a query string:
    //      return "http://localhost" + path + "?foo=bar";
    private static string ProcessVirtualPathDefault(string virtualPath) {
        // The path that comes in starts with ~/ and must first be made absolute
        string path = VirtualPathUtility.ToAbsolute(virtualPath);
        
        // Add your own modifications here before returning the path
        return path;
    }

    private static string ProcessAssetPathDefault(string virtualPath) {
        // The path that comes in starts with ~/ and should retain this prefix
        return virtualPath;
    }

    // Calling ProcessVirtualPath through delegate to allow it to be replaced for unit testing
    public static Func<string, string> ProcessVirtualPath = ProcessVirtualPathDefault;
    public static Func<string, string> ProcessAssetPath = ProcessAssetPathDefault;

    // Calling T4Extension.TimestampString through delegate to allow it to be replaced for unit testing and other purposes
    public static Func<string, string> TimestampString = System.Web.Mvc.T4Extensions.TimestampString;

    // Logic to determine if the app is running in production or dev environment
    public static bool IsProduction() { 
        return (HttpContext.Current != null && !HttpContext.Current.IsDebuggingEnabled); 
    }
}





#endregion T4MVC
#pragma warning restore 1591, 3008, 3009, 0108, 0114


