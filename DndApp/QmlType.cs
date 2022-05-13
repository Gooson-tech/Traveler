using System;
using System.Threading.Tasks;
using Qml.Net;
namespace DndApp;

public class QmlType
{
    /// <summary>
    /// Properties are exposed to Qml.
    /// </summary>
    private string _textField;

    [NotifySignal("textF1Sig")]
    public string TextField1
    {
        get => _textField;
        set
        {
            _textField = value; this.ActivateSignal("textF1Sig");
        }
    }
    public QmlType CreateNetObject() => new();

    /// <summary>
    /// Qml can pass .NET types to .NET methods.
    /// </summary>
    /// <param name="parameter"></param>
    public void TestMethod(QmlType parameter)
    {
    }

    private int count = 0;

    public void TestMethod2()
    {
        Console.WriteLine("test");
        TextField1 = "test2" + count;
        count++;
    }
    public void TestMethodC()
    {
        TextField1 = "test2" + count;
        count++;

    }
    /// <summary>
    /// Async methods can be invoked with continuations happening on Qt's main thread.
    /// </summary>
    public async Task<string> TestAsync()
    {
        // On the UI thread
        await Task.Run(() =>
        {
            // On the background thread
        });
        // On the UI thread
        return "async result!";
    }

    /// <summary>
    /// .NET can activate signals to send notifications to Qml.
    /// </summary>
    public void ActivateCustomSignal(string message)
    {
        this.ActivateSignal("customSignal", message);
    }
}