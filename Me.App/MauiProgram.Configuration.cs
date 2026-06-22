using Microsoft.AspNetCore.Components.WebView.Maui;
using System;
using System.Collections.Generic;
using System.Text;
using Me.App.Resources;
namespace Me.App;

public static partial class MauiProgram
{

    private static void SetupBlazorWebView()
    {
        BlazorWebViewHandler.BlazorWebViewMapper.AppendToMapping("CustomBlazorWebViewMapper", static (handler, view) =>
        {
            var webView = handler.PlatformView;
            var webViewBackgroundColor = AppInfo.Current.RequestedTheme == AppTheme.Dark ? ThemeColors.PrimaryDarkBgColor : ThemeColors.PrimaryLightBgColor;

#if iOS || Mac
        webView.NavigationDelegate = new CustomWKNavigationDelegate();
        webView.Configuration.AllowsInlineMediaPlayback = true;
        webView.BackgroundColor = UIColor.Clear;
        webView.ScrollView.Bounces = false;
        webView.Opaque = false;

        if ((DeviceInfo.Current.Platform == DevicePlatform.MacCatalyst && DeviceInfo.Current.Version >= new Version(13, 3))
            || (DeviceInfo.Current.Platform == DevicePlatform.iOS && DeviceInfo.Current.Version >= new Version(16, 4)))
        {
            webView.SetValueForKey(NSObject.FromObject(true), new NSString("inspectable"));
        }

#elif Android

        webView.SetBackgroundColor(Android.Graphics.Color.ParseColor(webViewBackgroundColor));
        webView.OverScrollMode = Android.Views.OverScrollMode.Never;
        webView.VerticalScrollBarEnabled = false;
        webView.HorizontalScrollBarEnabled = false;

        Android.Webkit.WebSettings settings = webView.Settings;
        settings.AllowFileAccessFromFileURLs =
            settings.AllowUniversalAccessFromFileURLs =
            settings.AllowContentAccess =
            settings.AllowFileAccess =
            settings.DatabaseEnabled =
            settings.JavaScriptCanOpenWindowsAutomatically =
            settings.DomStorageEnabled = true;

        if (AppEnvironment.IsDevelopment())
        {
            settings.MixedContentMode = Android.Webkit.MixedContentHandling.AlwaysAllow;
        }

        settings.BlockNetworkLoads = settings.BlockNetworkImage = false;
#endif
        });


        AppContext.SetSwitch("BlazorWebView.AndroidFireAndForgetAsync", isEnabled: true);
    }
#if iOS || Mac
public partial class CustomWKNavigationDelegate : WKNavigationDelegate
{
    public override void DecidePolicy(WKWebView webView, WKNavigationAction navigationAction, WKWebpagePreferences preferences, Action<WKNavigationActionPolicy, WKWebpagePreferences> decisionHandler)
    {
        if (navigationAction.NavigationType is WKNavigationType.LinkActivated)
        {
            // https://developer.apple.com/documentation/webkit/wknavigationtype/linkactivated#discussion
            _ = Browser.OpenAsync(navigationAction.Request.Url!);
            decisionHandler.Invoke(WKNavigationActionPolicy.Cancel, preferences);
        }
        else
        {
            // To open Google reCAPTCHA and similar elements directly within the webview.
            decisionHandler.Invoke(WKNavigationActionPolicy.Allow, preferences);
        }
    }
}
#endif
}
