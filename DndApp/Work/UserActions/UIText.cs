using Qml.Net;

namespace DndApp;

[Signal("weatherSignal", NetVariantType.String)]
[Signal("temperatureSignal", NetVariantType.String)]
public class UIText
{
    private static string _weather = "";
    private static string _temperature = "";
    private static UIText MYUI;

    public static string Weather
    {
        get => _weather;
        set { _weather = value;
            MYUI.RaiseSignal("weatherSignal", _weather); }
    }
    public static string Temperature
    {
        get => _temperature;
        set { _temperature = value;
            MYUI.RaiseSignal("temperatureSignal", _temperature); }
    }
    public UIText()
    {
        QmlNetConfig.ShouldEnsureUIThread = false;
        MYUI = this; 
    }
    public void RaiseSignal(string signal,string message) 
        => this.ActivateSignal(signal, message);
}
