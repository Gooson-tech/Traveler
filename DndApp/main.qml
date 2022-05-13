import QtQuick 2.7
import QtQuick.Controls 2.3
import QtQuick.Layouts 1.1
import QtQuick.Shapes 1.2
import test 1.1

ApplicationWindow {
	visible: true
	width: 640
	height: 480
	title: qsTr("Hello World")

	Button{
		id: button
		text: qsTr("Hello World2")
		onClicked: test.netObject.testMethod2()
	}
	Label{  
	id: label
	text: test.textField
	}
	
	QmlType {
	  id: test
	  property var netObject: test.createNetObject()
	  property var textField: ""
  
	 Component.onCompleted: function() { 
		  netObject.textF1Sig.connect(function() { textField = netObject.textField1; })
		
		  // All properties/methods/signals can be invoked on "netObject"
		  // We can also pass the .NET object back to .NET
		  netObject.testMethod(netObject)
		  
		  // We can invoke async tasks that have continuation on the UI thread
		  var task = netObject.testAsync()
		  // And we can await the task
		  Net.await(task, function(result) {
			  // With the result!
			  console.log(result)
		  })
		  
		  // We can trigger signals from .NET
		  netObject.customSignal.connect(function(message) {
			  console.log("message111: " + message)
		  })
		  netObject.activateCustomSignal("test message!")
	  }
	  function testHandler(message) {
		  console.log("Message - " + message)
	  }
	}
}