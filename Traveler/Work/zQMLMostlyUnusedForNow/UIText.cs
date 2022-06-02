using Qml.Net;


namespace Traveler;
[Signal("weatherSignal", NetVariantType.String)]
[Signal("temperatureSignal", NetVariantType.String)]
public class UIText
{
    private static string _weather = "";
    private static string _temperature = "";
    private static UIText _myui = new(1);

    public static string Weather
    {
        get => _weather;
        set { _weather = value;
            _myui.RaiseSignal("weatherSignal", _weather); }
    }
    public static string Temperature
    {
        get => _temperature;
        set { _temperature = value;
            _myui.RaiseSignal("temperatureSignal", _temperature); }
    }
    public UIText()
    {
        QmlNetConfig.ShouldEnsureUIThread = false;
        _myui = this; 
    } 
    public UIText(int i) { }
    public void RaiseSignal(string signal,string message) 
        => this.ActivateSignal(signal, message);
}
