using Qml.Net;

namespace PhotoFrame.App;


[Signal("customSignal", NetVariantType.String)] // You can define signals that Qml can listen to.
public class QmlType
{

    public QmlType CreateNetObject()
    {
        return new QmlType();
    }


    public static int Count = 0;
    public void AddOne()
    {
        Count++;
    }
    public string StringProperty { get; set; }

}
