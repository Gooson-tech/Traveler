import QtQuick 2.7
import QtQuick.Controls 2.3
import QtQuick.Layouts 1.1
import QtQuick.Shapes 1.2
import test2 1.1

ApplicationWindow {
	 id: mainFrame
	 objectName: "Frame 1"
	 width: 1000
	 height: 1000
	 opacity: 1
	 visible: true
	 color: "#000000"

	 Button{
		anchors.fill: parent
	 
	 }        
	  QqqqqTest {
	  id: test2

	  Component.onCompleted: function() {
		  test2.activateCustomSignal()
	  }
   
	}

}