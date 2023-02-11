using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Input;

namespace MauiExplorer;

public partial class MapEventManager
{
    partial void SubscribeNativeTouchEvents(View mauiView)
    {
        if (mauiView == null)
            return;

        var windowsView = mauiView.Handler?.PlatformView as UIElement;
        if (windowsView == null) return;

        windowsView.ManipulationStarted += WindowsView_ManipulationStarted;
        windowsView.ManipulationDelta += WindowsView_ManipulationDelta;
    }

    private void WindowsView_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
    {
        System.Diagnostics.Debug.WriteLine($"ManipulationDelta.Y: {e.Position.Y}");
    }

    private void WindowsView_ManipulationStarted(object sender, ManipulationStartedRoutedEventArgs e)
    {
        var windowsView = sender as UIElement;
        System.Diagnostics.Debug.WriteLine($"ManipulationStarted.Y: {e.Position.Y}");
    }

    partial void UnsubscribeNativeTouchEvents(IElementHandler handler)
    {}
}