import QtQuick 2.7
import QtQuick.Controls 2.3
import QtQuick.Layouts 1.1
import QtQuick.Shapes 1.2
import test 1.1

Item {
    id: testt

 Button{
		anchors.fill: parent
		onClicked: contentFrame.push("TravelerScreen.qml")
		text: "Test"
	 }  

}