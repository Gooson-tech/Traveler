import QtQuick 2.7
import QtQuick.Controls 2.3
import QtQuick.Layouts 1.1
import QtQuick.Shapes 1.2
import test 1.1

Item {
	 id: pic
	 anchors.fill: parent

	
	 Image {
			id: img
			anchors.fill: parent
			fillMode: Image.Stretch
			source: "../../Content/Assets/Images/Forrest1.jpg"
Button{
		id: btn
		text: "Hello"
		x:0	
		y:0
		width: 200
		height: 200
		z:1
		onClicked: {
			onClicked: contentFrame.push("Start.qml")
		}

	}
			Text {
				id: text2
				y: 668
				width: 662
				height: 286
				color: "#ffffff"
				text: qsTr("Spring Hill, TN
Thursday 10:00 PM
Clear")
				anchors.left: parent.left
				anchors.bottom: parent.bottom
				font.pixelSize: parent.width/13
				anchors.leftMargin: 38
				anchors.bottomMargin: 46
			}
			Image {
				id: arrow
				rotation: 0
				x: 832
				y: 66
				width: 123
				height: 144
				opacity: 1
				source: "../../Content/Assets/Images/wi-direction-up.png"
				layer.format: ShaderEffectSource.RGB
				focus: false
				antialiasing: false
				autoTransform: false
				mipmap: false
				fillMode: Image.PreserveAspectCrop


				Text{
					id: text3


					color: "#ffffff"
					text: qsTr("10 MPH")
					anchors.top: parent.top
					font.pixelSize: 20
					anchors.left: parent.left
					anchors.right: parent.right
					anchors.topMargin: 10
					horizontalAlignment: Text.AlignHCenter

				}



			}

		}

		////////
	
		 UIText {
			id: model
			onWeatherSignal: function(result) { text2.text = result } 
			onTemperatureSignal: function(result) { text2.text = result }
		}


}