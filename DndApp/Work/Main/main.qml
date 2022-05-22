import QtQuick 2.7
import QtQuick.Controls 2.3
import QtQuick.Layouts 1.1
import QtQuick.Shapes 1.2
import test 1.1

ApplicationWindow {
	 id: mainFrame
	 objectName: "Frame 1"
	 width: 1000
	 height: 1000
	 opacity: 1
	 visible: true
	 color: "#000000"

	 Image {
			id: img
			anchors.fill: parent
			fillMode: Image.Stretch
			source: "images/Forrest1.jpg"

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
				source: "images/wi-direction-up.png"
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
		Text {
			id: message
			text: ""
		} 
		Text { 
			id: message2
			y: message.y
			x: message.x + 200
			text: ""
		}
		
		 UIText {
			id: model
			
			onWeatherSignal: function(result) { text2.text = result } 
			onTemperatureSignal: function(result) { text2.text = result }
		}


}