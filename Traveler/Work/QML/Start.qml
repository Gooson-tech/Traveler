import QtQuick 2.7
import QtQuick.Window 2.0
import QtQuick.Controls 1.4
import QtQuick.Controls.Styles 1.4
import QtQuick.Controls 2.3
import QtQuick.Layouts 1.1
import QtQuick.Shapes 1.2
import Qt.labs.folderlistmodel 2.1
import test 1.1

//import QtQml 2.2
ApplicationWindow  {
property int titlebar_wrapper_size:40
FontLoader { id: segoe_light; source: "fonts/segoe_light" }
id:registerWindow
width:200 * 2
height:250 * 2
x:Screen.width/2 - width/2
y:Screen.height/2 - height/2
color: "#00000000"
visible: false
flags: Qt.FramelessWindowHint |
	   Qt.WindowMinimizeButtonHint |
	   Qt.WindowStaysOnTopHint|
	   Qt.Window
MouseArea {
	id:dragparentwindow
	width: parent.width
	height: 57
	property real lastMouseX: 0
	property real lastMouseY: 0
	onPressed: {
		lastMouseX = mouseX
		lastMouseY = mouseY
	}
	onMouseXChanged: registerWindow.x += (mouseX - lastMouseX)
	onMouseYChanged: registerWindow.y += (mouseY - lastMouseY)
}
Rectangle{
	id:titlebar
	width: parent.width
	Rectangle{
		id:appclose
		height: titlebar_wrapper_size
		y:0
		width: titlebar_wrapper_size
		anchors.right: parent.right
		color: "#00000000"
		Text{
			//text: awesome.loaded ? awesome.icons.fa_money : "x"
			text: "×"
			anchors.horizontalCenter: parent.horizontalCenter
			font.pointSize: 20
		}
		MouseArea{
			width: parent.width
			height: parent.height
			hoverEnabled: true
			onEntered: appclose.color="#00000000"
			onExited: appclose.color="#00000000"
			onClicked: registerWindow.hide()
		}
	}
	Rectangle{
	id:appminimize
	height: titlebar_wrapper_size
	y:0
	width: titlebar_wrapper_size
	anchors.right: appclose.left
	color: "#00000000"

	Text{
		text: '🗕'
		font.family: segoe_light.name
		anchors.horizontalCenter: parent.horizontalCenter
		font.pointSize: 15
	}
	MouseArea{
		width: parent.width
		height: parent.height
		hoverEnabled: true
		onEntered: appminimize.color="#00000000"
		onExited: appminimize.color="#00000000"
		onClicked: registerWindow.visibility = Window.Minimized
	}
}

}

ComboBox {
		id: animals
		x: 60
		y: 172
		width: 280
		height: 57
		FolderListModel {
			id: folderModel1
			folder: "../../Biomes/Animals"
			showDirs: false
			nameFilters: ["*.txt"]
		}
		textRole: "fileName"
	   // displayText: "Animals"
		model: folderModel1
	}

	ComboBox {
		id: structures
		x: 60
		y: 235
		width: 280
		height: 57
		FolderListModel {
			id: folderModel2
			folder: "../../Biomes/Structures"
			showDirs: false
			nameFilters: ["*.txt"]
		}
		textRole: "fileName"
		//displayText: "Structures"
		model: folderModel2
	}


	ComboBox {
		id: climates
		x: 60
		y: 109
		width: 280
		height: 57
	   // displayText: "Climates"
		model: ["Deciduous", "Grassland", "Desert", "Tundra", "Temperate", "RainForest", "Savanna", "Polar"]
	}

	ComboBox {
		id: events
		x: 60
		y: 46
		width: 280
		height: 57
		//displayText: "Events"
		FolderListModel {
			id: folderModel3
			folder: "../../Biomes/Events"
			showDirs: false
			nameFilters: ["*.txt"]
		}
		model: folderModel3
		textRole: "fileName"
	}
   ComboBox {
		id: enemies
		x: 60
		y: 298
		width: 280
		height: 57
		FolderListModel {
			id: folderModel4
			folder: "../../Biomes/Enemies"
			showDirs: false
			nameFilters: ["*.txt"]
		}
		textRole: "fileName"
		//displayText: "Enemies"
		model: folderModel4
	}
	TextField {
		id: name
		x: 60
		y: 393
		width: 148
		height: 32
		text: qsTr("NAME")
		font.pixelSize: 12
		
	}

	Button {
		id: button
		x: 209
		y: 393
		width: 131
		height: 32
		text: qsTr("Create")
		onClicked: {
			if (name.text == "NAME"|| name.text=="" ) { text="ERROR, NAME REQUIRED"}
			else {
				model.createBiome(events.currentText, animals.currentText, enemies.currentText, structures.currentText, climates.currentText, name.text)
				registerWindow.hide()
			}
		} 
	
	}
	
	 

	
	  StartScreenQml {
		id: model
		  onHideSignal: function() {  registerWindow.hide() } 
		  onShowSignal: function() {  registerWindow.show() } 

		//onWeatherSignal: function(result) { text2.text = result } 
		//onTemperatureSignal: function(result) { text2.text = result }

  

	}











}