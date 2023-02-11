namespace MauiExplorer;

public partial class MapEventManager 
{
    public MapEventManager(View mauiView)
    {
        if (mauiView.Handler != null)
        {
            SubscribeNativeTouchEvents(mauiView);
        }
        else
        {
            mauiView.HandlerChanged += MauiView_HandlerChanged;
            mauiView.HandlerChanging += MauiView_HandlerChanging;
        }

        //TODO: remove this PinchGesture and WindowsView_ManipulationStarted will not be raised
        PinchGestureRecognizer pinchGesture = new PinchGestureRecognizer();
        mauiView.GestureRecognizers.Add(pinchGesture);
    }

    partial void SubscribeNativeTouchEvents(View mauiView);

    partial void UnsubscribeNativeTouchEvents(IElementHandler handler);

    private void MauiView_HandlerChanged(object sender, EventArgs e)
    {
        if (sender is not View mauiView || mauiView.Handler == null)
            return;
        SubscribeNativeTouchEvents(mauiView);
    }

    private void MauiView_HandlerChanging(object sender, HandlerChangingEventArgs e) 
        => UnsubscribeNativeTouchEvents(e.OldHandler);

}