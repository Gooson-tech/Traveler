import QtQuick 2.7
import QtQuick.Controls 2.3
import QtQuick.Layouts 1.1
import QtQuick.Shapes 1.2
import test 1.1

Item {
    anchors.fill: parent
    StackView {
        id: stackview
        anchors.fill: parent
        initialItem: "Picture.qml"
    }
}