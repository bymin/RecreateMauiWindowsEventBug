namespace MauiExplorer
{
    public class MapView : ContentView//, ITouchListener
    {
        private MapEventManager _mapEventManager;
        public MapView()
        {
            _mapEventManager = new MapEventManager(this);
        }
    }
}
