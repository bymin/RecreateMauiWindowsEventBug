# RecreateMauiWindowsEventBug

This demo recreates an issue where WindowsUIView.ManipulationStarted event in Windows Maui is not correctly raised. It's tested on the latest VS 2022 Beta 17.4.4, on both .NET 6 and .NET 7.  There are 3 sub issues as listed below: 

1. The argument ManipulationStartedRoutedEventArgs in WindowsView_ManipulationStarted is not correct since the events are raised for the 2nd time.  To recreate it: 
- 1. launch the solution in VS 2022, and open "Output" Window
- 2. Select "Windows Machine" in the running platform dropdown list, and hit F5 to run it
- 3. Use the mouse to drag (push the left button and move) anywhere on the main canvas (yellow area), and you will see ManipulationStartedRoutedEventArgs.Y in the output window. They should be the same if you drag at the same spot twice, however Y position is about 80 pixels off when for the 2nd time. The futher drags have the same output as the 2nd one. 

- ManipulationStarted.Y: 318.0105285644531      ManipulationDelta.Y: 317.3302307128906
- ManipulationStarted.Y: 392.660400390625     ManipulationDelta.Y: 392.6334325654443

2. remove the following lines in MapEventManager.cs, and the WindowsView_ManipulationStarted event will not be raised at all. Nothing will show up in the output window. 
<code>
  //TODO: remove this PinchGesture and WindowsView_ManipulationStarted will not be raised
  PinchGestureRecognizer pinchGesture = new PinchGestureRecognizer();
  mauiView.GestureRecognizers.Add(pinchGesture);
  
</code>
- 

3. Restore #2, go to MainPage.xaml and remove BackgroundColor="Yellow" from the following code, and the events will not be raised as well. 

<local:MapView BackgroundColor="Yellow"/>

