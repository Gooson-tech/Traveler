import QtQuick 2.7
import QtQuick.Controls 2.3
import QtQuick.Layouts 1.1
import QtQuick.Shapes 1.2

ApplicationWindow {
    visible: true
    width: 1122
    height: 679
    title: qsTr("Hello World")
Rectangle {
    id: figma_5700_213
    objectName:"Frame 1"
    x:92
    y:-561
    width:1122
    height:679
    color:"#ff2b3648"
    clip: false 
    Rectangle {
        id: figma_5700_250
        objectName:"cards/elevation/white/flat"
        x:487
        y:569
        width:308
        height:102
        color:"#00ffffff"
        clip: false 
        Shape {
            id: figma_5700_251
            objectName:"cards/elevation/flat"
            x:0
            y:0
            width:308
            height:102
            ShapePath {
                joinStyle: ShapePath.MiterJoin
                strokeColor: "#ff313c4e"
                strokeWidth:1
                fillColor:"#ff212936"
                id: svgpath_figma_5700_251
                fillRule: ShapePath.WindingFill
                PathSvg {
                    path: "M0 23C0 10.2975 10.2975 0 23 0L285 0C297.703 0 308 10.2975 308 23L308 79C308 91.7025 297.703 102 285 102L23 102C10.2975 102 0 91.7025 0 79L0 23Z"
                } 
            }
        }
        Shape {
            id: figma_5700_252
            objectName:"divider"
            transform: Matrix4x4 {
                matrix: Qt.matrix4x4(
                1, 0, 0, 0,
                0, -1, 64.9911, 0,
                0, 0, 1, 0,
                0, 0, 0, 1)
            }
            x:0
            y:64
            width:308
            height:3.61062
            ShapePath {
                strokeColor: "transparent"
                strokeWidth:1
                fillColor:"#ff313c4e"
                id: svgpath_figma_5700_252
                fillRule: ShapePath.WindingFill
                PathSvg {
                    path: "M0 0L308 0L308 3.61062L0 3.61062L0 0Z"
                } 
            }
        }
    }
    Rectangle {
        id: figma_5700_347
        objectName:"cards/elevation/white/flat"
        x:512
        y:61
        width:275
        height:494
        color:"#00ffffff"
        clip: false 
        Shape {
            id: figma_5700_348
            objectName:"cards/elevation/flat"
            x:0
            y:0
            width:275
            height:494
            ShapePath {
                joinStyle: ShapePath.MiterJoin
                strokeColor: "#ff313c4e"
                strokeWidth:1
                fillColor:"#ff212936"
                id: svgpath_figma_5700_348
                fillRule: ShapePath.WindingFill
                PathSvg {
                    path: "M0 19C0 8.5066 8.50659 0 19 0L256 0C266.493 0 275 8.50659 275 19L275 475C275 485.493 266.493 494 256 494L19 494C8.50659 494 0 485.493 0 475L0 19Z"
                } 
            }
        }
    }
    Rectangle {
        id: figma_5700_396
        objectName:"cards/elevation/white/flat"
        x:798
        y:105
        width:298
        height:225
        color:"#00ffffff"
        clip: false 
        Shape {
            id: figma_5700_397
            objectName:"cards/elevation/flat"
            x:0
            y:0
            width:298
            height:225
            ShapePath {
                joinStyle: ShapePath.MiterJoin
                strokeColor: "#ff313c4e"
                strokeWidth:1
                fillColor:"#ff212936"
                id: svgpath_figma_5700_397
                fillRule: ShapePath.WindingFill
                PathSvg {
                    path: "M0 15C0 6.71573 6.71573 0 15 0L283 0C291.284 0 298 6.71573 298 15L298 210C298 218.284 291.284 225 283 225L15 225C6.71573 225 0 218.284 0 210L0 15Z"
                } 
            }
        }
    }
    Cards_elevation_white_flat_4_figma {
        id: figma_5909_68
        objectName:"cards/elevation/white/flat"
        x:810
        y:336
    }
    Cards_elevation_white_flat_2_figma {
        id: figma_5909_51
        objectName:"cards/elevation/white/flat"
    }
    Rectangle {
        id: figma_5700_272
        objectName:"navigation/elements/vertical/sheets/right divider"
        x:0
        y:3
        width:264
        height:672
        color:"#00ffffff"
        clip: false 
        Shape {
            id: figma_5700_273
            objectName:"sheet"
            x:0
            y:0
            width:264
            height:672
            ShapePath {
                strokeColor: "transparent"
                strokeWidth:1
                fillColor:"#ff212936"
                id: svgpath_figma_5700_273
                fillRule: ShapePath.WindingFill
                PathSvg {
                    path: "M0 0L264 0L264 672L0 672L0 0Z"
                } 
            }
        }
        Rectangle {
            id: figma_5701_117
            objectName:"navigation/example/vertical/avatar+title menu"
            x:-1
            y:5
            width:255
            height:672
            color:"#00ffffff"
            clip: false 
            Rectangle {
                id: figma_5701_118
                objectName:"navigation/elements/vertical/line items/with subtitle/inactive"
                x:0
                y:409
                width:254
                height:76
                color:"#00ffffff"
                clip: false 
                Rectangle {
                    id: figma_5701_119
                    objectName:"navigation/elements/vertical/line items/default/inactive"
                    x:0
                    y:36
                    width:254
                    height:40
                    color:"#00ffffff"
                    clip: false 
                    Rectangle {
                        id: figma_5701_120
                        objectName:"icon/action/settings"
                        x:16
                        y: (figma_5701_119.height - height) / 2
                        width:24
                        height:24
                        color:"#00ffffff"
                        clip: true 
                        Shape {
                            id: figma_5701_121
                            objectName:"Vector"
                            x:2
                            y:2
                            width:19.4542
                            height:20
                            ShapePath {
                                strokeColor: "transparent"
                                strokeWidth:1
                                fillColor:"#ff56657f"
                                id: svgpath_figma_5701_121
                                fillRule: ShapePath.WindingFill
                                PathSvg {
                                    path: "M17.1593 10.98C17.1993 10.66 17.2293 10.34 17.2293 10C17.2293 9.66 17.1993 9.34 17.1593 9.02L19.2693 7.37C19.4593 7.22 19.5093 6.95 19.3893 6.73L17.3893 3.27C17.2693 3.05 16.9993 2.97 16.7793 3.05L14.2893 4.05C13.7693 3.65 13.2093 3.32 12.5993 3.07L12.2193 0.42C12.1893 0.18 11.9793 0 11.7293 0L7.72933 0C7.47933 0 7.26933 0.18 7.23933 0.42L6.85933 3.07C6.24933 3.32 5.68933 3.66 5.16933 4.05L2.67933 3.05C2.44933 2.96 2.18933 3.05 2.06933 3.27L0.0693316 6.73C-0.0606684 6.95 -0.000668302 7.22 0.189332 7.37L2.29933 9.02C2.25933 9.34 2.22933 9.67 2.22933 10C2.22933 10.33 2.25933 10.66 2.29933 10.98L0.189332 12.63C-0.000668302 12.78 -0.0506684 13.05 0.0693316 13.27L2.06933 16.73C2.18933 16.95 2.45933 17.03 2.67933 16.95L5.16933 15.95C5.68933 16.35 6.24933 16.68 6.85933 16.93L7.23933 19.58C7.26933 19.82 7.47933 20 7.72933 20L11.7293 20C11.9793 20 12.1893 19.82 12.2193 19.58L12.5993 16.93C13.2093 16.68 13.7693 16.34 14.2893 15.95L16.7793 16.95C17.0093 17.04 17.2693 16.95 17.3893 16.73L19.3893 13.27C19.5093 13.05 19.4593 12.78 19.2693 12.63L17.1593 10.98L17.1593 10.98ZM9.72933 13.5C7.79933 13.5 6.22933 11.93 6.22933 10C6.22933 8.07 7.79933 6.5 9.72933 6.5C11.6593 6.5 13.2293 8.07 13.2293 10C13.2293 11.93 11.6593 13.5 9.72933 13.5Z"
                                } 
                            }
                        }
                    }
                    Text {
                        id: figma_5701_122
                        objectName:"Main Settings"
                        x:72
                        y: (figma_5701_119.height - height) / 2
                        width:150
                        height:18
                        color:"#ff56657f"
                        wrapMode: TextEdit.WordWrap
                        text:"Main Settings"
                        font.family: "MS Shell Dlg 2"
                        font.italic: false
                        font.letterSpacing: 0.1
                        font.pixelSize: 14
                        font.weight: Font.Normal
                        horizontalAlignment: Text.AlignLeft
                        verticalAlignment: Text.AlignTop
                    }
                }
                Text {
                    id: figma_5701_123
                    objectName:"Settings"
                    opacity: 0.5
                    x:16
                    y:0
                    width:222
                    height:20
                    color:"#ff56657f"
                    wrapMode: TextEdit.WordWrap
                    text:"Settings"
                    font.family: "MS Shell Dlg 2"
                    font.italic: false
                    font.letterSpacing: 0.25
                    font.pixelSize: 14
                    font.weight: Font.Normal
                    horizontalAlignment: Text.AlignLeft
                    verticalAlignment: Text.AlignTop
                }
            }
            Navigation_elements_vertical_line_items_default_selected_figma {
                id: figma_5909_70
                objectName:"navigation/elements/vertical/line items/default/selected"
            }
            Shape {
                id: figma_5701_143
                objectName:"divider"
                transform: Matrix4x4 {
                    matrix: Qt.matrix4x4(
                    1, 0, 0, 0,
                    0, -1, 401, 0,
                    0, 0, 1, 0,
                    0, 0, 0, 1)
                }
                x:0
                y:401
                width:254
                height:1
                ShapePath {
                    strokeColor: "transparent"
                    strokeWidth:1
                    fillColor:"#ff313c4e"
                    id: svgpath_figma_5701_143
                    fillRule: ShapePath.WindingFill
                    PathSvg {
                        path: "M0 0L254 0L254 1L0 1L0 0Z"
                    } 
                }
            }
            Navigation_elements_vertical_line_items_default_selected_figma {
                id: figma_5909_71
                objectName:"navigation/elements/vertical/line items/default/selected"
                x:0
                y:205
                delegate_5701_125:                Rectangle {
                    id: figma_i5909_71_5701_125
                    objectName:"icon/action/dashboard"
                    visible: false
                    x:21
                    y: (figma_5909_71.height - height) / 2
                    width:24
                    height:24
                    color:"#00ffffff"
                    clip: true 
                    Shape {
                        id: figma_i5909_71_5701_126
                        objectName:"Vector"
                        x:3
                        y:3
                        width:18
                        height:18
                        ShapePath {
                            strokeColor: "transparent"
                            strokeWidth:1
                            fillColor:"#ff56657f"
                            id: svgpath_figma_i5909_71_5701_126
                            fillRule: ShapePath.WindingFill
                            PathSvg {
                                path: "M0 10L8 10L8 0L0 0L0 10ZM0 18L8 18L8 12L0 12L0 18ZM10 18L18 18L18 8L10 8L10 18ZM10 0L10 6L18 6L18 0L10 0Z"
                            } 
                        }
                    }
                }
                delegate_5701_127:                Text {
                    id: figma_i5909_71_5701_127
                    objectName:"Dashboard"
                    x:72
                    y: (figma_5909_71.height - height) / 2
                    width:150
                    height:18
                    color:"#ff56657f"
                    wrapMode: TextEdit.WordWrap
                    text:"Play"
                    font.family: "MS Shell Dlg 2"
                    font.italic: false
                    font.letterSpacing: 0.1
                    font.pixelSize: 14
                    font.weight: Font.Normal
                    horizontalAlignment: Text.AlignLeft
                    verticalAlignment: Text.AlignTop
                }
            }
            Navigation_elements_vertical_line_items_default_selected_figma {
                id: figma_5909_105
                objectName:"navigation/elements/vertical/line items/default/selected"
                x:0
                y:252
                delegate_5701_125:                Rectangle {
                    id: figma_i5909_105_5701_125
                    objectName:"icon/action/dashboard"
                    visible: false
                    x:21
                    y: (figma_5909_105.height - height) / 2
                    width:24
                    height:24
                    color:"#00ffffff"
                    clip: true 
                    Shape {
                        id: figma_i5909_105_5701_126
                        objectName:"Vector"
                        x:3
                        y:3
                        width:18
                        height:18
                        ShapePath {
                            strokeColor: "transparent"
                            strokeWidth:1
                            fillColor:"#ff56657f"
                            id: svgpath_figma_i5909_105_5701_126
                            fillRule: ShapePath.WindingFill
                            PathSvg {
                                path: "M0 10L8 10L8 0L0 0L0 10ZM0 18L8 18L8 12L0 12L0 18ZM10 18L18 18L18 8L10 8L10 18ZM10 0L10 6L18 6L18 0L10 0Z"
                            } 
                        }
                    }
                }
                delegate_5701_127:                Text {
                    id: figma_i5909_105_5701_127
                    objectName:"Dashboard"
                    x:72
                    y: (figma_5909_105.height - height) / 2
                    width:150
                    height:18
                    color:"#ff56657f"
                    wrapMode: TextEdit.WordWrap
                    text:"Edit"
                    font.family: "MS Shell Dlg 2"
                    font.italic: false
                    font.letterSpacing: 0.1
                    font.pixelSize: 14
                    font.weight: Font.Normal
                    horizontalAlignment: Text.AlignLeft
                    verticalAlignment: Text.AlignTop
                }
            }
            Rectangle {
                id: figma_5909_90
                objectName:"icon/communication/message"
                x:20
                y: (figma_5701_117.height - height) / 2 - 116
                width:28
                height:32
                color:"#00ffffff"
                clip: true 
                Shape {
                    id: figma_5909_91
                    objectName:"Vector"
                    x:0
                    y:6
                    width:28
                    height:25.3333
                    ShapePath {
                        strokeColor: "transparent"
                        strokeWidth:1
                        fillColor:"#ff56657f"
                        id: svgpath_figma_5909_91
                        fillRule: ShapePath.WindingFill
                        PathSvg {
                            path: "M23.842 5.10467L25.2 6.33333L28 0L21 2.53333L22.358 3.762L19.81 6.06733C12.418 0.202666 1.82 2.45733 1.358 2.53333L0 2.86267L0.7 5.32L1.806 5.06667L11.368 13.7053L6.916 17.7333L4.2 17.7333L0 21.5333L2.8 22.8L4.2 25.3333L8.4 21.5333L8.4 19.076L12.852 15.048L22.4 23.6993L22.134 24.7L24.836 25.3333L25.2 24.1047C25.284 23.6867 27.776 14.098 21.294 7.41L23.842 5.10467L23.842 5.10467ZM3.5 4.788C6.37 4.43333 12.992 4.15467 17.822 7.866L12.348 12.8187L3.5 4.788ZM22.708 22.1667L13.832 14.1613L19.306 9.20867C23.408 13.5787 23.1 19.57 22.708 22.1667Z"
                        } 
                    }
                }
            }
            Rectangle {
                id: figma_5909_108
                objectName:"icon/action/assignment"
                x:6
                y: (figma_5701_117.height - height) / 2 - 64
                width:42
                height:36
                color:"#00ffffff"
                clip: true 
                Rectangle {
                    id: figma_5909_109
                    objectName:"bx:search-alt-2"
                    x:0
                    y:5
                    width:52.5
                    height:45
                    color:"#00ffffff"
                    clip: true 
                    Shape {
                        id: figma_5909_110
                        objectName:"Vector"
                        x:10
                        y:0
                        width:24
                        height:24
                        ShapePath {
                            strokeColor: "transparent"
                            strokeWidth:1
                            fillColor:"#ff56657f"
                            id: svgpath_figma_5909_110
                            fillRule: ShapePath.WindingFill
                            PathSvg {
                                path: "M21.6536 0C22.2793 0 22.8268 0.207589 23.2961 0.622768C23.7654 1.03795 24 1.55804 24 2.18304C24 2.74554 23.7989 3.41964 23.3966 4.20536C20.4291 9.82143 18.3508 13.1786 17.162 14.2768C16.295 15.0893 15.3207 15.4955 14.2391 15.4955C13.1128 15.4955 12.1453 15.0826 11.3363 14.2567C10.5274 13.4308 10.1229 12.4509 10.1229 11.317C10.1229 10.1741 10.5341 9.22768 11.3564 8.47768L19.9106 0.723214C20.438 0.241071 21.019 0 21.6536 0ZM9.46592 13.8482C9.81452 14.5268 10.2905 15.1071 10.8939 15.5893C11.4972 16.0714 12.1698 16.4107 12.9117 16.6071L12.9251 17.558C12.9609 19.4598 12.3821 21.0089 11.1888 22.2054C9.99553 23.4018 8.43799 24 6.5162 24C5.41676 24 4.44246 23.7924 3.5933 23.3772C2.74413 22.9621 2.06257 22.3929 1.5486 21.6696C1.03464 20.9464 0.648045 20.1295 0.388827 19.2188C0.129609 18.308 0 17.3259 0 16.2723C0.0625698 16.317 0.24581 16.4509 0.549721 16.6741C0.853631 16.8973 1.13073 17.096 1.38101 17.2701C1.63128 17.4442 1.89497 17.6071 2.17207 17.7589C2.44916 17.9107 2.65475 17.9866 2.78883 17.9866C3.15531 17.9866 3.40112 17.8214 3.52626 17.4911C3.74972 16.9018 4.0067 16.3996 4.29721 15.9844C4.58771 15.5692 4.89832 15.2299 5.22905 14.9665C5.55978 14.7031 5.95307 14.4911 6.40894 14.3304C6.8648 14.1696 7.32514 14.0558 7.78994 13.9888C8.25475 13.9219 8.81341 13.875 9.46592 13.8482Z"
                            } 
                        }
                    }
                }
            }
            Navigation_elements_vertical_line_items_default_selected_figma {
                id: figma_5909_131
                objectName:"navigation/elements/vertical/line items/default/selected"
                x:0
                y:347
                delegate_5701_125:                Rectangle {
                    id: figma_i5909_131_5701_125
                    objectName:"icon/action/dashboard"
                    visible: false
                    x:21
                    y: (figma_5909_131.height - height) / 2
                    width:24
                    height:24
                    color:"#00ffffff"
                    clip: true 
                    Shape {
                        id: figma_i5909_131_5701_126
                        objectName:"Vector"
                        x:3
                        y:3
                        width:18
                        height:18
                        ShapePath {
                            strokeColor: "transparent"
                            strokeWidth:1
                            fillColor:"#ff56657f"
                            id: svgpath_figma_i5909_131_5701_126
                            fillRule: ShapePath.WindingFill
                            PathSvg {
                                path: "M0 10L8 10L8 0L0 0L0 10ZM0 18L8 18L8 12L0 12L0 18ZM10 18L18 18L18 8L10 8L10 18ZM10 0L10 6L18 6L18 0L10 0Z"
                            } 
                        }
                    }
                }
                delegate_5701_127:                Text {
                    id: figma_i5909_131_5701_127
                    objectName:"Dashboard"
                    x:72
                    y: (figma_5909_131.height - height) / 2
                    width:150
                    height:18
                    color:"#ff56657f"
                    wrapMode: TextEdit.WordWrap
                    text:"Notes"
                    font.family: "MS Shell Dlg 2"
                    font.italic: false
                    font.letterSpacing: 0.1
                    font.pixelSize: 14
                    font.weight: Font.Normal
                    horizontalAlignment: Text.AlignLeft
                    verticalAlignment: Text.AlignTop
                }
            }
            Rectangle {
                id: figma_5909_136
                objectName:"icon/social/people"
                x:18
                y: (figma_5701_117.height - height) / 2 + 31
                width:24
                height:18
                color:"#00ffffff"
                clip: true 
                Shape {
                    id: figma_5909_137
                    objectName:"Vector"
                    x:3
                    y:2
                    width:18
                    height:13.5
                    ShapePath {
                        joinStyle: ShapePath.MiterJoin
                        strokeColor: "#ff56657f"
                        strokeWidth:2
                        fillColor:"transparent"
                        id: svgpath_figma_5909_137
                        fillRule: ShapePath.WindingFill
                        PathSvg {
                            path: "M18 9L18.6 9.8C18.8518 9.61115 19 9.31476 19 9L18 9ZM0 1.5L-1 1.5L0 1.5ZM0 12L-1 12L0 12ZM12 13.5L12 14.5C12.2164 14.5 12.4269 14.4298 12.6 14.3L12 13.5ZM18 9L19 9C19 8.62123 18.786 8.27497 18.4472 8.10557C18.1084 7.93618 17.703 7.97274 17.4 8.2L18 9ZM18 9.129L19 9.12928L19 9.129L18 9.129ZM17.414 10.1895L16.8141 9.38941L16.814 9.3895L17.414 10.1895ZM13.586 13.0605L12.986 12.2605L12.9859 12.2606L13.586 13.0605ZM12.172 13.5L12.172 14.5L12.1722 14.5L12.172 13.5ZM12 13.5L11.4 12.7C11.0557 12.9583 10.9152 13.4079 11.0513 13.8162C11.1874 14.2246 11.5696 14.5 12 14.5L12 13.5ZM18 9L18.6 9.8C18.9443 9.54174 19.0848 9.09211 18.9487 8.68377C18.8126 8.27543 18.4304 8 18 8L18 9ZM12 13.5L11 13.5C11 13.8788 11.214 14.225 11.5528 14.3944C11.8916 14.5638 12.297 14.5273 12.6 14.3L12 13.5ZM4 2C3.44772 2 3 2.44772 3 3C3 3.55228 3.44772 4 4 4L4 2ZM14 4C14.5523 4 15 3.55228 15 3C15 2.44772 14.5523 2 14 2L14 4ZM4 5C3.44772 5 3 5.44772 3 6C3 6.55228 3.44772 7 4 7L4 5ZM14 7C14.5523 7 15 6.55228 15 6C15 5.44772 14.5523 5 14 5L14 7ZM4 8C3.44772 8 3 8.44771 3 9C3 9.55229 3.44772 10 4 10L4 8ZM8 10C8.55229 10 9 9.55229 9 9C9 8.44771 8.55229 8 8 8L8 10ZM19 9L19 1.5L17 1.5L17 9L19 9ZM19 1.5C19 0.728892 18.5903 0.071384 18.0142 -0.36066L16.8142 1.23934C16.9883 1.3699 17 1.47546 17 1.5L19 1.5ZM18.0142 -0.36066C17.4437 -0.788575 16.717 -1 16 -1L16 1C16.3438 1 16.6346 1.10465 16.8142 1.23934L18.0142 -0.36066ZM16 -1L2 -1L2 1L16 1L16 -1ZM2 -1C1.28296 -1 0.55634 -0.788575 -0.0142137 -0.36066L1.18579 1.23934C1.36538 1.10465 1.65618 1 2 1L2 -1ZM-0.0142137 -0.36066C-0.590273 0.0713845 -1 0.728893 -1 1.5L1 1.5C1 1.47546 1.0117 1.3699 1.18579 1.23934L-0.0142137 -0.36066ZM-1 1.5L-1 12L1 12L1 1.5L-1 1.5ZM-1 12C-1 12.7711 -0.590273 13.4286 -0.0142137 13.8607L1.18579 12.2607C1.0117 12.1301 1 12.0245 1 12L-1 12ZM-0.0142137 13.8607C0.556339 14.2886 1.28296 14.5 2 14.5L2 12.5C1.65618 12.5 1.36538 12.3954 1.18579 12.2607L-0.0142137 13.8607ZM2 14.5L12 14.5L12 12.5L2 12.5L2 14.5ZM12.6 14.3L18.6 9.8L17.4 8.2L11.4 12.7L12.6 14.3ZM17 9L17 9.129L19 9.129L19 9L17 9ZM17 9.12872C17 9.15327 16.9882 9.25885 16.8141 9.38941L18.0139 10.9896C18.5899 10.5577 18.9998 9.90031 19 9.12928L17 9.12872ZM16.814 9.3895L12.986 12.2605L14.186 13.8605L18.014 10.9895L16.814 9.3895ZM12.9859 12.2606C12.8064 12.3953 12.5156 12.4999 12.1718 12.5L12.1722 14.5C12.8891 14.4999 13.6157 14.2884 14.1861 13.8604L12.9859 12.2606ZM12.172 12.5L12 12.5L12 14.5L12.172 14.5L12.172 12.5ZM12.6 14.3L18.6 9.8L17.4 8.2L11.4 12.7L12.6 14.3ZM18 8L14 8L14 10L18 10L18 8ZM14 8C13.283 8 12.5563 8.21143 11.9858 8.63934L13.1858 10.2393C13.3654 10.1046 13.6562 10 14 10L14 8ZM11.9858 8.63934C11.4097 9.07138 11 9.72889 11 10.5L13 10.5C13 10.4755 13.0117 10.3699 13.1858 10.2393L11.9858 8.63934ZM11 10.5L11 13.5L13 13.5L13 10.5L11 10.5ZM12.6 14.3L18.6 9.8L17.4 8.2L11.4 12.7L12.6 14.3ZM4 4L14 4L14 2L4 2L4 4ZM14 2L4 2L4 4L14 4L14 2ZM4 7L14 7L14 5L4 5L4 7ZM14 5L4 5L4 7L14 7L14 5ZM4 10L8 10L8 8L4 8L4 10Z"
                        } 
                    }
                }
            }
        }
        Shape {
            id: figma_5700_274
            objectName:"divider"
            x:263
            y:0
            width:1
            height:672
            ShapePath {
                strokeColor: "transparent"
                strokeWidth:1
                fillColor:"#ff313c4e"
                id: svgpath_figma_5700_274
                fillRule: ShapePath.WindingFill
                PathSvg {
                    path: "M0 0L1 0L1 672L0 672L0 0Z"
                } 
            }
        }
        Rectangle {
            id: figma_5700_275
            objectName:"akar-icons:map"
            x:26
            y:53
            width:24
            height:24
            color:"#00ffffff"
            clip: true 
            Rectangle {
                id: figma_5700_276
                objectName:"Group"
                x:3
                y:3
                width:18
                height:18
                color: "transparent"
                clip: false 
                Shape {
                    id: figma_5700_277
                    objectName:"Vector"
                    x:0
                    y:0
                    width:18
                    height:17.7831
                    ShapePath {
                        joinStyle: ShapePath.MiterJoin
                        strokeColor: "#ff000000"
                        strokeWidth:2
                        fillColor:"transparent"
                        id: svgpath_figma_5700_277
                        fillRule: ShapePath.WindingFill
                        PathSvg {
                            path: "M5.368 1.68165L5.05146 2.63023C5.49149 2.77707 5.97473 2.60201 6.21863 2.20742C6.46252 1.81283 6.40303 1.30231 6.07494 0.974373L5.368 1.68165ZM2.632 0.768648L2.94854 -0.179931L2.948 -0.180111L2.632 0.768648ZM5.80189e-08 2.66665L1 2.66665L1 2.66641L5.80189e-08 2.66665ZM5.80189e-08 14.4496L1 14.4499L1 14.4496L5.80189e-08 14.4496ZM1.368 16.3476L1.68416 15.3989L1.684 15.3989L1.368 16.3476ZM5.368 17.6806L5.05184 18.6294L5.052 18.6294L5.368 17.6806ZM6.632 17.6806L6.948 18.6294L6.94811 18.6294L6.632 17.6806ZM11.368 16.1026L11.052 15.1539L11.0519 15.1539L11.368 16.1026ZM12.632 16.1026L12.9482 15.154L12.948 15.1539L12.632 16.1026ZM15.368 17.0146L15.0518 17.9633L15.052 17.9634L15.368 17.0146ZM18 15.1156L17 15.1156L17 15.1164L18 15.1156ZM18 3.33365L17 3.33324L17 3.33365L18 3.33365ZM16.633 1.43565L16.9495 0.487056L16.9492 0.486941L16.633 1.43565ZM12.633 0.102648L12.3168 1.05132L12.3168 1.05136L12.633 0.102648ZM11.368 0.102648L11.684 1.05139L11.6842 1.05132L11.368 0.102648ZM6.631 1.68065L6.947 2.62941L6.94705 2.62939L6.631 1.68065ZM5.367 1.68065L5.683 0.731889C5.24299 0.585336 4.75995 0.76055 4.51622 1.15512C4.2725 1.54969 4.33204 2.06006 4.66006 2.38792L5.367 1.68065ZM5.68454 0.733069L2.94854 -0.179931L2.31546 1.71723L5.05146 2.63023L5.68454 0.733069ZM2.948 -0.180111C2.497 -0.330323 2.01676 -0.371214 1.54686 -0.299414L1.84895 1.67764C2.00559 1.65371 2.16567 1.66734 2.316 1.71741L2.948 -0.180111ZM1.54686 -0.299414C1.07696 -0.227613 0.630846 -0.0451764 0.245284 0.232862L1.41509 1.85506C1.54362 1.76239 1.69232 1.70157 1.84895 1.67764L1.54686 -0.299414ZM0.245284 0.232862C-0.140278 0.5109 -0.45425 0.876581 -0.670759 1.29977L1.10975 2.2107C1.18192 2.06964 1.28657 1.94774 1.41509 1.85506L0.245284 0.232862ZM-0.670759 1.29977C-0.887267 1.72295 -1.00011 2.19153 -1 2.66689L1 2.66641C0.999962 2.50796 1.03758 2.35176 1.10975 2.2107L-0.670759 1.29977ZM-1 2.66665L-1 14.4496L1 14.4496L1 2.66665L-1 2.66665ZM-1 14.4494C-1.00015 15.0793 -0.802032 15.6933 -0.433727 16.2043L1.18876 15.0348C1.06599 14.8645 0.999949 14.6599 1 14.4499L-1 14.4494ZM-0.433727 16.2043C-0.0654208 16.7153 0.454384 17.0974 1.052 17.2964L1.684 15.3989C1.48479 15.3325 1.31152 15.2052 1.18876 15.0348L-0.433727 16.2043ZM1.05184 17.2964L5.05184 18.6294L5.68416 16.7319L1.68416 15.3989L1.05184 17.2964ZM5.052 18.6294C5.66738 18.8344 6.33262 18.8344 6.948 18.6294L6.316 16.7319C6.11087 16.8002 5.88913 16.8002 5.684 16.7319L5.052 18.6294ZM6.94811 18.6294L11.6841 17.0514L11.0519 15.1539L6.31589 16.7319L6.94811 18.6294ZM11.684 17.0514C11.8891 16.9831 12.1109 16.9831 12.316 17.0514L12.948 15.1539C12.3326 14.9489 11.6674 14.9489 11.052 15.1539L11.684 17.0514ZM12.3158 17.0513L15.0518 17.9633L15.6842 16.066L12.9482 15.154L12.3158 17.0513ZM15.052 17.9634C15.5031 18.1137 15.9835 18.1545 16.4535 18.0827L16.1512 16.1056C15.9945 16.1296 15.8344 16.116 15.684 16.0659L15.052 17.9634ZM16.4535 18.0827C16.9235 18.0108 17.3697 17.8282 17.7553 17.55L16.5851 15.9281C16.4566 16.0208 16.3078 16.0817 16.1512 16.1056L16.4535 18.0827ZM17.7553 17.55C18.1409 17.2718 18.4549 16.9059 18.6713 16.4825L16.8904 15.5723C16.8183 15.7134 16.7136 15.8353 16.5851 15.9281L17.7553 17.55ZM18.6713 16.4825C18.8877 16.0591 19.0004 15.5904 19 15.1149L17 15.1164C17.0001 15.2749 16.9626 15.4311 16.8904 15.5723L18.6713 16.4825ZM19 15.1156L19 3.33365L17 3.33365L17 15.1156L19 15.1156ZM19 3.33406C19.0003 2.70435 18.8024 2.09052 18.4343 1.57955L16.8114 2.7484C16.9341 2.91873 17.0001 3.12334 17 3.33324L19 3.33406ZM18.4343 1.57955C18.0663 1.06857 17.5468 0.686359 16.9495 0.487056L16.3165 2.38424C16.5156 2.45068 16.6888 2.57808 16.8114 2.7484L18.4343 1.57955ZM16.9492 0.486941L12.9492 -0.846059L12.3168 1.05136L16.3168 2.38436L16.9492 0.486941ZM12.9493 -0.846028C12.3334 -1.05132 11.6676 -1.05132 11.0518 -0.846028L11.6842 1.05132C11.8895 0.982892 12.1115 0.982892 12.3168 1.05132L12.9493 -0.846028ZM11.052 -0.846095L6.31495 0.731905L6.94705 2.62939L11.684 1.05139L11.052 -0.846095ZM6.315 0.731889C6.10987 0.80021 5.88813 0.80021 5.683 0.731889L5.051 2.62941C5.66638 2.83437 6.33162 2.83437 6.947 2.62941L6.315 0.731889ZM4.66006 2.38792L4.66106 2.38892L6.07494 0.974373L6.07394 0.973373L4.66006 2.38792Z"
                        } 
                    }
                }
                Shape {
                    id: figma_5700_278
                    objectName:"Vector"
                    x:6
                    y:0
                    width:6
                    height:18
                    ShapePath {
                        joinStyle: ShapePath.MiterJoin
                        strokeColor: "#ff000000"
                        strokeWidth:2
                        fillColor:"transparent"
                        id: svgpath_figma_5700_278
                        fillRule: ShapePath.WindingFill
                        PathSvg {
                            path: "M1 2C1 1.44772 0.552285 1 0 1C-0.552285 1 -1 1.44772 -1 2L1 2ZM-1 18C-1 18.5523 -0.552285 19 0 19C0.552285 19 1 18.5523 1 18L-1 18ZM-1 2L-1 18L1 18L1 2L-1 2ZM1 18L1 2L-1 2L-1 18L1 18ZM5 0L5 16L7 16L7 0L5 0Z"
                        } 
                    }
                }
            }
        }
        Rectangle {
            id: figma_5700_214
            objectName:"navigation/elements/vertical/header area/avatar + title"
            x:9
            y:5
            width:255
            height:144
            color:"#00ffffff"
            clip: false 
            Shape {
                id: figma_5700_215
                objectName:"header bg"
                x:0
                y:0
                width:255
                height:144
                ShapePath {
                    strokeColor: "transparent"
                    strokeWidth:0
                    fillColor:"#ff212936"
                    id: svgpath_figma_5700_215
                    PathSvg {
                        path: "M0 0L0 144L255 144L255 0L0 0Z"
                    } 
                }
            }
            Rectangle {
                id: figma_5700_216
                objectName:"avatar/man/15"
                x:144
                y:18
                width:83
                height:54
                color: "transparent"
                clip: false 
                Item {
                anchors.fill:parent
              

                Item {
                    id: mask_figma_5700_217
                    anchors.fill:parent
                    Shape {
                        id: figma_5700_217
                        objectName:"mask"
                        x:0
                        y:0
                        width:83
                        height:54
                        ShapePath {
                            strokeColor: "transparent"
                            strokeWidth:1
                            fillColor:"#ffc4c4c4"
                            id: svgpath_figma_5700_217
                            fillRule: ShapePath.WindingFill
                            PathSvg {
                                path: "M83 27C83 41.9117 64.4198 54 41.5 54C18.5802 54 0 41.9117 0 27C0 12.0883 18.5802 0 41.5 0C64.4198 0 83 12.0883 83 27Z"
                            } 
                        }
                    }
                    visible:false
                }

                Item {
                    id: source_figma_5700_217
                    anchors.fill:parent
                    visible:false
                    Shape {
                        id: figma_5700_218
                        objectName:"Vector"
                        x:0
                        y:11
                        width:62.5692
                        height:42.5106
                        ShapePath {
                            strokeColor: "transparent"
                            strokeWidth:1
                            fillColor:"#ffffffff"
                            id: svgpath_figma_5700_218
                            fillRule: ShapePath.WindingFill
                            PathSvg {
                                path: "M1.88745 21.2387L18.8521 18.5984L9.93828 24.2942C8.94817 25.1411 9.64506 26.5691 11.033 26.5691L32.7996 26.5691C31.8712 24.3689 31.3579 22.0441 31.3579 19.6462L31.3579 16.1242L19.6634 8.86745C17.3372 7.54564 14.2584 7.7009 12.1374 9.23278L0.652999 18.8973C-0.55526 19.7608 0.324203 21.4214 1.88745 21.2387ZM56.306 24.07L46.4636 19.8978C44.8754 19.2232 43.8735 17.8428 43.8735 16.3276L43.8735 13.2846L50.1279 13.2846L52.8763 15.1627C53.4618 15.6592 54.2535 15.9415 55.0843 15.9415L58.0262 15.9415C59.1111 15.9415 60.286 15.3707 60.8118 14.4677L62.2163 12.0915C62.7416 11.1889 62.6317 10.1195 61.9232 9.31L54.6426 1.05944C54.0482 0.394386 53.2077 0 52.2303 0L29.0171 0C28.3231 0 27.981 0.716122 28.4697 1.13085L34.4025 5.31383L28.6652 7.36879C28.0911 7.61787 28.0911 8.31282 28.6652 8.56191L34.4025 10.6277L34.4024 19.6446C34.4024 25.6226 37.9201 31.2188 43.7845 34.5399C24.6666 35.1003 10.1229 37.9441 1.35565 39.5947C0.561613 39.74 0 40.3419 0 41.0377C0.0906048 41.8464 0.872425 42.5106 1.8249 42.5106L50.6068 42.5106C56.7879 42.5106 62.2965 38.5668 62.5408 33.3111C62.8644 29.3921 60.4013 25.8136 56.306 24.07L56.306 24.07ZM47.8906 5.50064L52.3612 6.44551C52.0925 7.35882 51.1395 8.01309 50.0038 7.96078C48.7312 7.90847 47.4703 6.92292 47.8906 5.50064Z"
                            } 
                        }
                    }
                    }
                }
            }
            Shape {
                id: figma_5700_219
                objectName:"divider"
                x:0
                y:143
                width:255
                height:1
                ShapePath {
                    strokeColor: "transparent"
                    strokeWidth:1
                    fillColor:"#ff313c4e"
                    id: svgpath_figma_5700_219
                    fillRule: ShapePath.WindingFill
                    PathSvg {
                        path: "M0 0L255 0L255 1L0 1L0 0Z"
                    } 
                }
            }
            Rectangle {
                id: figma_5700_220
                objectName:"icon/navigation/arrow_drop_down"
                x:215
                y:105
                width:24
                height:24
                color: "transparent"
                clip: true 
                Shape {
                    id: figma_5700_221
                    objectName:"Vector"
                    x:7
                    y:10
                    width:10
                    height:5
                    ShapePath {
                        strokeColor: "transparent"
                        strokeWidth:1
                        fillColor:"#ff56657f"
                        id: svgpath_figma_5700_221
                        fillRule: ShapePath.WindingFill
                        PathSvg {
                            path: "M0 0L5 5L10 0L0 0Z"
                        } 
                    }
                }
            }
            Text {
                id: figma_5700_222
                objectName:"Campaign"
                x:16
                y:104
                width:183
                height:26
                color:"#ffafbdd1"
                wrapMode: TextEdit.WordWrap
                text:"Campaign"
                font.family: "MS Shell Dlg 2"
                font.italic: false
                font.letterSpacing: 0.15
                font.pixelSize: 20
                font.weight: Font.Normal
                horizontalAlignment: Text.AlignLeft
                verticalAlignment: Text.AlignTop
            }
        }
    }
    Shape {
        id: figma_5700_450
        objectName:"divider"
        x:264
        y:569
        width:849
        height:4
        ShapePath {
            strokeColor: "transparent"
            strokeWidth:1
            fillColor:"#ff313c4e"
            id: svgpath_figma_5700_450
            fillRule: ShapePath.WindingFill
            PathSvg {
                path: "M0 0L849 0L849 4L0 4L0 0Z"
            } 
        }
    }
    Shape {
        id: figma_5700_481
        objectName:"divider"
        transform: Matrix4x4 {
            matrix: Qt.matrix4x4(
            7.45931e-17, -1, 491, 0,
            1, 7.45931e-17, 0, 0,
            0, 0, 1, 0,
            0, 0, 0, 1)
        }
        x:491
        y:0
        width:567.558
        height:4
        ShapePath {
            strokeColor: "transparent"
            strokeWidth:1
            fillColor:"#ff313c4e"
            id: svgpath_figma_5700_481
            fillRule: ShapePath.WindingFill
            PathSvg {
                path: "M0 0L567.558 0L567.558 4L0 4L0 0Z"
            } 
        }
    }
    Rectangle {
        id: figma_5700_430
        objectName:"cards/elevation/white/flat"
        x:813
        y:600
        width:300
        height:68
        color:"#00ffffff"
        clip: false 
        Shape {
            id: figma_5700_431
            objectName:"cards/elevation/flat"
            x:0
            y:0
            width:300
            height:68
            ShapePath {
                joinStyle: ShapePath.MiterJoin
                strokeColor: "#ff313c4e"
                strokeWidth:1
                fillColor:"#ff212936"
                id: svgpath_figma_5700_431
                fillRule: ShapePath.WindingFill
                PathSvg {
                    path: "M0 4C0 1.79086 1.79086 0 4 0L296 0C298.209 0 300 1.79086 300 4L300 64C300 66.2091 298.209 68 296 68L4 68C1.79086 68 0 66.2091 0 64L0 4Z"
                } 
            }
        }
    }
    Cards_elevation_white_flat_3_figma {
        id: figma_5909_56
        objectName:"cards/elevation/white/flat"
    }
    Cards_elevation_white_flat_3_figma {
        id: figma_5909_57
        objectName:"cards/elevation/white/flat"
        x:862
        y:421
        delegate_5700_470:        Text {
            id: figma_i5909_57_5700_470
            objectName:"Travel"
            x:37
            y:15
            width:96.983
            height:6.6
            color:"#ff56657f"
            wrapMode: TextEdit.WordWrap
            text:"Here"
            font.family: "MS Shell Dlg 2"
            font.italic: false
            font.letterSpacing: 0.4
            font.pixelSize: 24
            font.weight: Font.Normal
            horizontalAlignment: Text.AlignHCenter
            verticalAlignment: Text.AlignVCenter
        }
    }
    Cards_elevation_white_flat_3_figma {
        id: figma_5909_61
        objectName:"cards/elevation/white/flat"
        x:862
        y:459
        delegate_5700_470:        Text {
            id: figma_i5909_61_5700_470
            objectName:"Travel"
            x:37
            y:15
            width:96.983
            height:6.6
            color:"#ff56657f"
            wrapMode: TextEdit.WordWrap
            text:"Camp"
            font.family: "MS Shell Dlg 2"
            font.italic: false
            font.letterSpacing: 0.4
            font.pixelSize: 24
            font.weight: Font.Normal
            horizontalAlignment: Text.AlignHCenter
            verticalAlignment: Text.AlignVCenter
        }
    }
    Cards_elevation_white_flat_4_figma {
        id: figma_5909_65
        objectName:"cards/elevation/white/flat"
    }
    Cards_elevation_white_flat_1_figma {
        id: figma_5909_24
        objectName:"cards/elevation/white/flat"
    }
    Cards_elevation_white_flat_1_figma {
        id: figma_5909_31
        objectName:"cards/elevation/white/flat"
        x:275
        y:82
        delegate_5903_46:        Cards_elevation_white_flat_figma {
            id: figma_i5909_31_5903_46
            objectName:"cards/elevation/white/flat"
            x:0
            y:0
            Shape {
                id: figma_i5909_31_5903_46_5898_20
                objectName:"cards/elevation/flat"
                x:0
                y:0
                width:200
                height:60
                ShapePath {
                    joinStyle: ShapePath.MiterJoin
                    strokeColor: "#ff313c4e"
                    strokeWidth:1
                    fillColor:"#ff212936"
                    id: svgpath_figma_i5909_31_5903_46_5898_20
                    fillRule: ShapePath.WindingFill
                    PathSvg {
                        path: "M0 4C0 1.79086 1.79086 0 4 0L196 0C198.209 0 200 1.79086 200 4L200 56C200 58.2091 198.209 60 196 60L4 60C1.79086 60 0 58.2091 0 56L0 4Z"
                    } 
                }
            }
            Text {
                id: figma_i5909_31_5903_46_5898_21
                objectName:"Party"
                visible: false
                x:49
                y:22
                width:101
                height:16
                color:"#ff56657f"
                wrapMode: TextEdit.WordWrap
                text:"Party"
                font.family: "MS Shell Dlg 2"
                font.italic: false
                font.letterSpacing: 0.4
                font.pixelSize: 24
                font.weight: Font.Normal
                horizontalAlignment: Text.AlignHCenter
                verticalAlignment: Text.AlignVCenter
            }
        }
        delegate_5909_25:        Text {
            id: figma_i5909_31_5909_25
            objectName:"Party"
            x:15
            y:22
            width:170
            height:16
            color:"#ff56657f"
            wrapMode: TextEdit.WordWrap
            text:"DM Actions"
            font.family: "MS Shell Dlg 2"
            font.italic: false
            font.letterSpacing: 0.4
            font.pixelSize: 24
            font.weight: Font.Normal
            horizontalAlignment: Text.AlignHCenter
            verticalAlignment: Text.AlignVCenter
        }
    }
    Cards_elevation_white_flat_1_figma {
        id: figma_5909_37
        objectName:"cards/elevation/white/flat"
        x:275
        y:151
        delegate_5903_46:        Cards_elevation_white_flat_figma {
            id: figma_i5909_37_5903_46
            objectName:"cards/elevation/white/flat"
            x:0
            y:0
            Shape {
                id: figma_i5909_37_5903_46_5898_20
                objectName:"cards/elevation/flat"
                x:0
                y:0
                width:200
                height:60
                ShapePath {
                    joinStyle: ShapePath.MiterJoin
                    strokeColor: "#ff313c4e"
                    strokeWidth:1
                    fillColor:"#ff212936"
                    id: svgpath_figma_i5909_37_5903_46_5898_20
                    fillRule: ShapePath.WindingFill
                    PathSvg {
                        path: "M0 4C0 1.79086 1.79086 0 4 0L196 0C198.209 0 200 1.79086 200 4L200 56C200 58.2091 198.209 60 196 60L4 60C1.79086 60 0 58.2091 0 56L0 4Z"
                    } 
                }
            }
            Text {
                id: figma_i5909_37_5903_46_5898_21
                objectName:"Party"
                visible: false
                x:49
                y:22
                width:101
                height:16
                color:"#ff56657f"
                wrapMode: TextEdit.WordWrap
                text:"Party"
                font.family: "MS Shell Dlg 2"
                font.italic: false
                font.letterSpacing: 0.4
                font.pixelSize: 24
                font.weight: Font.Normal
                horizontalAlignment: Text.AlignHCenter
                verticalAlignment: Text.AlignVCenter
            }
        }
        delegate_5909_25:        Text {
            id: figma_i5909_37_5909_25
            objectName:"Party"
            x:15
            y:22
            width:170
            height:16
            color:"#ff56657f"
            wrapMode: TextEdit.WordWrap
            text:"Roll"
            font.family: "MS Shell Dlg 2"
            font.italic: false
            font.letterSpacing: 0.4
            font.pixelSize: 24
            font.weight: Font.Normal
            horizontalAlignment: Text.AlignHCenter
            verticalAlignment: Text.AlignVCenter
        }
    }
    Cards_elevation_white_flat_1_figma {
        id: figma_5909_46
        objectName:"cards/elevation/white/flat"
        x:276
        y:220
        delegate_5903_46:        Cards_elevation_white_flat_figma {
            id: figma_i5909_46_5903_46
            objectName:"cards/elevation/white/flat"
            x:0
            y:0
            Shape {
                id: figma_i5909_46_5903_46_5898_20
                objectName:"cards/elevation/flat"
                x:0
                y:0
                width:200
                height:60
                ShapePath {
                    joinStyle: ShapePath.MiterJoin
                    strokeColor: "#ff313c4e"
                    strokeWidth:1
                    fillColor:"#ff212936"
                    id: svgpath_figma_i5909_46_5903_46_5898_20
                    fillRule: ShapePath.WindingFill
                    PathSvg {
                        path: "M0 4C0 1.79086 1.79086 0 4 0L196 0C198.209 0 200 1.79086 200 4L200 56C200 58.2091 198.209 60 196 60L4 60C1.79086 60 0 58.2091 0 56L0 4Z"
                    } 
                }
            }
            Text {
                id: figma_i5909_46_5903_46_5898_21
                objectName:"Party"
                visible: false
                x:49
                y:22
                width:101
                height:16
                color:"#ff56657f"
                wrapMode: TextEdit.WordWrap
                text:"Party"
                font.family: "MS Shell Dlg 2"
                font.italic: false
                font.letterSpacing: 0.4
                font.pixelSize: 24
                font.weight: Font.Normal
                horizontalAlignment: Text.AlignHCenter
                verticalAlignment: Text.AlignVCenter
            }
        }
        delegate_5909_25:        Text {
            id: figma_i5909_46_5909_25
            objectName:"Party"
            x:15
            y:22
            width:170
            height:16
            color:"#ff56657f"
            wrapMode: TextEdit.WordWrap
            text:"Sound Board"
            font.family: "MS Shell Dlg 2"
            font.italic: false
            font.letterSpacing: 0.4
            font.pixelSize: 24
            font.weight: Font.Normal
            horizontalAlignment: Text.AlignHCenter
            verticalAlignment: Text.AlignVCenter
        }
    }
    Cards_elevation_white_flat_2_figma {
        id: figma_5909_52
        objectName:"cards/elevation/white/flat"
        x:899
        y:20
    }
    Cards_elevation_white_flat_2_figma {
        id: figma_5909_54
        objectName:"cards/elevation/white/flat"
        x:1000
        y:20
    }
    Navigation_elements_vertical_line_items_default_selected_figma {
        id: figma_5909_126
        objectName:"navigation/elements/vertical/line items/default/selected"
        x:0
        y:308
        delegate_5701_125:        Rectangle {
            id: figma_i5909_126_5701_125
            objectName:"icon/action/dashboard"
            visible: false
            x:21
            y: (figma_5909_126.height - height) / 2
            width:24
            height:24
            color:"#00ffffff"
            clip: true 
            Shape {
                id: figma_i5909_126_5701_126
                objectName:"Vector"
                x:3
                y:3
                width:18
                height:18
                ShapePath {
                    strokeColor: "transparent"
                    strokeWidth:1
                    fillColor:"#ff56657f"
                    id: svgpath_figma_i5909_126_5701_126
                    fillRule: ShapePath.WindingFill
                    PathSvg {
                        path: "M0 10L8 10L8 0L0 0L0 10ZM0 18L8 18L8 12L0 12L0 18ZM10 18L18 18L18 8L10 8L10 18ZM10 0L10 6L18 6L18 0L10 0Z"
                    } 
                }
            }
        }
        delegate_5701_127:        Text {
            id: figma_i5909_126_5701_127
            objectName:"Dashboard"
            x:72
            y: (figma_5909_126.height - height) / 2
            width:150
            height:18
            color:"#ff56657f"
            wrapMode: TextEdit.WordWrap
            text:"Search"
            font.family: "MS Shell Dlg 2"
            font.italic: false
            font.letterSpacing: 0.1
            font.pixelSize: 14
            font.weight: Font.Normal
            horizontalAlignment: Text.AlignLeft
            verticalAlignment: Text.AlignTop
        }
    }
    Rectangle {
        id: figma_5909_127
        objectName:"icon/social/people"
        x:17
        y: (figma_5700_213.height - height) / 2 - 9.5
        width:24
        height:24
        color:"#00ffffff"
        clip: true 
        Shape {
            id: figma_5909_128
            objectName:"Vector"
            x:0
            y:0
            width:23.825
            height:23.8275
            ShapePath {
                strokeColor: "transparent"
                strokeWidth:1
                fillColor:"#ff56657f"
                id: svgpath_figma_5909_128
                fillRule: ShapePath.WindingFill
                PathSvg {
                    path: "M21.2788 18.7212C20.6933 18.1605 20.1235 17.5836 19.57 16.9912C19.105 16.5187 18.825 16.175 18.825 16.175L15.325 14.5037C16.7262 12.9145 17.4996 10.8687 17.5 8.75C17.5 3.92625 13.575 0 8.75 0C3.925 0 0 3.92625 0 8.75C0 13.5737 3.925 17.5 8.75 17.5C10.9537 17.5 12.9625 16.675 14.5037 15.3262L16.175 18.8262C16.175 18.8262 16.5188 19.1062 16.9913 19.5712C17.475 20.025 18.1112 20.6387 18.7212 21.28L20.4187 23.02L21.1737 23.8275L23.825 21.1762L23.0175 20.4212C22.5437 19.9562 21.9113 19.3387 21.2788 18.7212L21.2788 18.7212ZM8.75 15C5.30375 15 2.5 12.1962 2.5 8.75C2.5 5.30375 5.30375 2.5 8.75 2.5C12.1962 2.5 15 5.30375 15 8.75C15 12.1962 12.1962 15 8.75 15Z"
                } 
            }
        }
    }
}

   
}
