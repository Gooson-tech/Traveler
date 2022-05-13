import QtQuick 2.7
import QtQuick.Controls 2.3
import QtQuick.Layouts 1.1
import QtQuick.Shapes 1.2
import test 1.1

ApplicationWindow {
    visible: true
    width: 1122
    height: 679
    title: qsTr("Hello World")

   id: test

Rectangle {
    id: mainFrame
    objectName: "Frame 1"
    width: 500; height: 500;
    color: "#ff2b3648"
    clip: false
    anchors.fill:parent

    TextArea {
        id:text1
        x:0; y:0;
        width: parent.width/4; height: parent.height/4;
        text: "Temperture: 105F\nSunny\nRain"
        anchors{
            left:parent.left;
            leftMargin: 10;

        }
        color: "white"
        wrapMode: TextArea.Wrap
    }


    TextArea {
        id:text2

        width: parent.width/4; height: parent.height/4;
        text: "asdasdasdasdasd"
        anchors{
            left:text1.right;

        }
        wrapMode: TextArea.Wrap
    }

 QmlType{
 id: add
   function addone() { test.AddOne() }
  }

 Button{

        width: 100; height: 50;

        id: btn
        Text {
            id: name
            text: "test"
            color: "red"
        }

        anchors{
            right:parent.right;
            rightMargin: 10;

        }

        onClicked: {
            console.log("Clicked")
            add.addone()
            name.color= "blue"
        }


  }
}
}
