import QtQuick 2.7
import QtQuick.Controls 2.3
import QtQuick.Layouts 1.1
import QtQuick.Shapes 1.2
import test 1.1

Item {
	id: travelerRoot
	anchors.fill: parent
Rectangle {
    width: parent.width
    height: parent.height
    color: "#ff1b1f24"
    Rectangle {
        id: topTravelerPane
        layer.enabled: true
        x: 208
        width: 1079
        height: 26
        color: "#ff181818"
        radius: 40
        anchors.top: parent.top
        anchors.topMargin: 0
        clip: true
        Text {
            id: traveler
            x: 426
            y: 2
            width: 167
            height: 24
            color: "#e5ffffff"
            wrapMode: TextEdit.WordWrap
            text: "Traveler"
            font.family: "MS Shell Dlg 2"
            font.italic: false
            font.letterSpacing: 0.4
            font.pixelSize: 24
            font.weight: Font.Normal
            horizontalAlignment: Text.AlignHCenter
            verticalAlignment: Text.AlignVCenter
        }
    }
    Rectangle {
        id: mainTravel
        x: 258
        y: 32
        width: 1006.18
        height: 824.413
        color: "transparent"
        radius: 40
        clip: false
        Item {
            id: mainImage
            anchors.fill: parent
            anchors.rightMargin: -6
            anchors.leftMargin: -21
            Image {
                anchors.fill: parent
                source: "../../Content/Assets/Images/Forrest1.jpg"
                mipmap: false
                autoTransform: true
                asynchronous: true
                z: -1
                fillMode: Image.PreserveAspectCrop
            }
            Rectangle {
                id: travelInformationTextBox
                layer.enabled: true

                opacity: 0.587
                color: "#181818"
                radius: 40
                anchors.left: parent.left
                anchors.right: parent.right
                anchors.top: parent.top
                anchors.bottom: parent.bottom
                anchors.topMargin: 18
                anchors.leftMargin: 649
                anchors.rightMargin: 0
                anchors.bottomMargin: 262
                z: 1
                clip: false
            }
            Text {
                id: travelTextBoxText
                x: 649
                y: 8
                width: 384
                height: 0
                objectName: "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras tristique cursus purus vitae posuere. Aenean euismod, purus ac rutrum congue, nisl diam convallis turpis, sit amet feugiat nisl velit vel neque. Vestibulum dictum est nec vehicula condimentum. Duis feugiat nulla quis tincidunt aliquam. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Phasellus sodales elit sed orci placerat, vel mattis sapien ornare. Phasellus eu lacinia eros. Nunc sed sem et elit suscipit auctor."
                layer.enabled: true
                color: "#ffffffff"
                wrapMode: TextEdit.WordWrap
                z: 2
                anchors.bottomMargin: 127
                font.bold: false
                textFormat: Text.RichText
                font.kerning: false
                font.preferShaping: false
                layer.smooth: false
                layer.mipmap: false
                layer.textureSize.width: 1
                fontSizeMode: Text.Fit
                text: "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras tristique cursus purus vitae posuere. Aenean euismod, purus ac rutrum congue, nisl diam convallis turpis, sit amet feugiat nisl velit vel neque. Vestibulum dictum est nec vehicula condimentum. Duis feugiat nulla quis tincidunt aliquam. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Phasellus sodales elit sed orci placerat, vel mattis sapien ornare. Phasellus eu lacinia eros. Nunc sed sem et elit suscipit auctor.
"

                font.family: "MS Shell Dlg 2"
                font.italic: false
                font.letterSpacing: 0
                font.pixelSize: 15
                font.weight: Font.DemiBold
            }

            Rectangle {
                id: actionsButton
                color: "transparent"
                radius: 15
                anchors.left: parent.left
                anchors.right: parent.right
                anchors.top: parent.top
                anchors.bottom: parent.bottom
                anchors.rightMargin: 156
                anchors.leftMargin: 628
                anchors.bottomMargin: 34
                anchors.topMargin: 747
                clip: false
                Image {
                    anchors.fill: parent
                    source: "../../Content/Assets/Images/ActionsButton1.png"
                    fillMode: Image.PreserveAspectFit
                    anchors.bottomMargin: -4
                    anchors.leftMargin: 8
                    anchors.rightMargin: -8
                    anchors.topMargin: -4
                }
            }
            Rectangle {
                id: travelButton
                opacity: 1
                visible: true
                color: "transparent"
                radius: 15
                anchors.left: parent.left
                anchors.right: parent.right
                anchors.top: parent.top
                anchors.bottom: parent.bottom
                anchors.rightMargin: 387
                anchors.leftMargin: 397
                anchors.bottomMargin: 34
                anchors.topMargin: 747
                clip: false
                Image {
                    anchors.fill: parent
                    source: "../../Content/Assets/Images/TravelButton21.png"
                    mirror: false
                    mipmap: true
                    fillMode: Image.PreserveAspectFit
                    anchors.bottomMargin: -4
                    anchors.leftMargin: 0
                    anchors.rightMargin: 0
                    anchors.topMargin: -4
                }
            }
            Rectangle {
                id: partyButton
                x: 168
                width: 229
                objectName: "PartyButton"
                color: "transparent"
                radius: 15
                anchors.right: parent.right
                anchors.top: parent.top
                anchors.bottom: parent.bottom
                anchors.topMargin: 718
                anchors.rightMargin: 636
                anchors.bottomMargin: 5
                clip: false
                Image {
                    anchors.fill: parent
                    source: "../../Content/Assets/Images/PartyButton1.png"

                    fillMode: Image.PreserveAspectFit
                    layer.enabled: false
                    focus: false
                    antialiasing: true
                    smooth: true
                    mirror: false
                    mipmap: true
                }
            }
        }

        Rectangle {
            id: leftPanel
            y: -30
            layer.enabled: true
            width: 229.742
            height: 856.146
            color: "#ff181818"
            radius: 0
            border.color: "#181818"
            anchors.left: parent.left
            anchors.top: parent.top
            anchors.topMargin: -32
            anchors.leftMargin: -257
            layer.smooth: false
            layer.mipmap: false
            clip: false
            Rectangle {
                id: leftPanelTopPanel
                x: 0
                y: 0
                width: 224.714
                height: 157.353
                color: "#00ffffff"
                clip: false
                Item {
                    id: topLeftDivider
                    x: 0
                    y: 156
                    width: 225
                    height: 1
                }
                Rectangle {
                    id: campaignChoiceSelect
                    x: 3
                    y: 107
                    width: 222
                    height: 30
                    color: "#ff181818"
                    radius: 65
                    clip: false

                    Image {
                        anchors.fill: parent
                        source: "../../Content/Assets/Images/CampaignChoiceSelect111111"
                        fillMode: Image.PreserveAspectFit
                    }
                }
                Image {
                    anchors.fill: parent
                    source: "../../Content/Assets/Images/DragonIcon.png"
                    fillMode: Image.PreserveAspectFit
                    anchors.leftMargin: 15
                    anchors.topMargin: 16
                    anchors.rightMargin: 135
                    anchors.bottomMargin: 83
                }
            }
            Rectangle {
                id: menuButton
                x: 10
                y: 185
                width: 209.667
                height: 54.3584
                color: "transparent"
                radius: 7
                clip: false
                Image {
                    anchors.fill: parent
                    source: "../../Content/Assets/Images/MenuButton1.png"
                    layer.format: ShaderEffectSource.RGB
                    fillMode: Image.PreserveAspectFit
                }
            }
            Rectangle {
                id: editButton
                x: 10
                y: 262
                width: 209.667
                height: 54.3584
                color: "transparent"
                radius: 7
                clip: false
                Image {
                    anchors.fill: parent
                    source: "../../Content/Assets/Images/EditButton1"
                    anchors.rightMargin: 0
                    anchors.bottomMargin: 0
                    anchors.leftMargin: 0
                    anchors.topMargin: 0
                    layer.format: ShaderEffectSource.RGB
                    fillMode: Image.PreserveAspectFit
                }
            }
            Rectangle {
                id: travelButtonLeft
                x: 10
                y: 339
                width: 209.667
                height: 54.3584
                color: "transparent"
                radius: 7
                clip: false

                Image {
                    anchors.fill: parent
                    source: "../../Content/Assets/Images/TravelButton2.png"
                    layer.format: ShaderEffectSource.RGB
                    fillMode: Image.PreserveAspectFit
                }
            }
            Rectangle {
                id: fightButton
                x: 10
                y: 416
                width: 209.667
                height: 54.3584
                color: "transparent"
                radius: 7
                clip: false

                Image {
                    anchors.fill: parent
                    source: "../../Content/Assets/Images/FightButton1.png"
                    layer.format: ShaderEffectSource.RGB
                    fillMode: Image.PreserveAspectFit
                }
            }
            Rectangle {
                id: figma_5989_972
                objectName: "InfoButton"
                x: 10
                y: 493
                width: 209.667
                height: 54.3584
                color: "transparent"
                radius: 7
                clip: false
                Image {
                    anchors.fill: parent
                    source: "../../Content/Assets/Images/InfoButton1.png"
                    fillMode: Image.PreserveAspectFit
                }
            }

            Rectangle {
                id: notesButton
                x: 10
                y: 570
                width: 209.667
                height: 54.3584
                color: "transparent"
                radius: 7
                clip: false
                Text {
                    id: notes
                    x: 133
                    y: (notesButton.height - height) / 2 + 13.8208
                    width: 40.4965
                    height: 18
                    color: "#ff56657f"
                    wrapMode: TextEdit.WordWrap
                    text: "Notes"
                    font.family: "MS Shell Dlg 2"
                    font.italic: false
                    font.letterSpacing: 0.1
                    font.pixelSize: 14
                    font.weight: Font.Normal
                    horizontalAlignment: Text.AlignHCenter
                    verticalAlignment: Text.AlignTop
                }
                Image {
                    anchors.fill: parent
                    source: "../../Content/Assets/Images/NotesButton1.png"
                    fillMode: Image.PreserveAspectFit
                }
            }
            Rectangle {
                id: leftPanelBottomMainSettingsLowerPanel
                x: 0
                y: 688
                width: 234.203
                height: 165.34
                color: "#00ffffff"
                clip: false

                Image {
                    anchors.fill: parent
                    source: "../../Content/Assets/Images/LeftPanelBottomMainSettingsLowerPanel.png"
                    fillMode: Image.PreserveAspectFit
                    anchors.rightMargin: 15
                    anchors.topMargin: 8
                }
            }
        }
    }
}

}