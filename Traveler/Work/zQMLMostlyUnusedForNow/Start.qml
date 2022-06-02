import QtQuick 2.7
import QtQuick.Controls 2.3
import QtQuick.Layouts 1.1
import QtQuick.Shapes 1.2
import test 1.1

ApplicationWindow {
	 id: main
	 width: 1287
	 height: 872
	 visible: true
	 //flags: Qt.FramelessWindowHint

	  
	StackView{
		width: main.width
		height: main.height
		id: contentFrame
		anchors.fill: parent
		visible: true
		initialItem: Qt.resolvedUrl("test.qml")
	}



	  StartScreenQml {
	  id: test
	
   
	}

}