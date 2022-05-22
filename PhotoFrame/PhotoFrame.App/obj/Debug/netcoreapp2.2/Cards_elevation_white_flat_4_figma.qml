//Generated by FigmaQML

import QtGraphicalEffects 1.14
import QtQuick 2.14
import QtQuick.Shapes 1.14
Rectangle {
    id: figma_5909_65
    objectName:"cards/elevation/white/flat"
    x:511
    y:19
    width:273
    height:38
    color:"#00ffffff"
    clip: false 
    property Component delegate_5700_355:     Shape {
        id: figma_5700_355
        objectName:"cards/elevation/flat"
        x:0
        y:0
        width:273
        height:38
        ShapePath {
            joinStyle: ShapePath.MiterJoin
            strokeColor: "#ff313c4e"
            strokeWidth:1
            fillColor:"#ff212936"
            id: svgpath_figma_5700_355
            fillRule: ShapePath.WindingFill
            PathSvg {
                path: "M0 4C0 1.79086 1.79086 0 4 0L269 0C271.209 0 273 1.79086 273 4L273 34C273 36.2091 271.209 38 269 38L4 38C1.79086 38 0 36.2091 0 34L0 4Z"
            } 
        }
    }
    property Item i_delegate_5700_355
    property matrix4x4 delegate_5700_355_transform: Qt.matrix4x4(Nan,Nan,Nan,Nan,Nan,Nan,Nan,Nan,Nan,Nan,Nan,Nan,Nan,Nan,Nan,Nan,)
    onDelegate_5700_355_transformChanged: {if(i_delegate_5700_355 && i_delegate_5700_355.transform != delegate_5700_355_transform) i_delegate_5700_355.transform = delegate_5700_355_transform;}
    property real delegate_5700_355_x: NaN
    onDelegate_5700_355_xChanged: {if(i_delegate_5700_355 && i_delegate_5700_355.x != delegate_5700_355_x) i_delegate_5700_355.x = delegate_5700_355_x;}
    property real delegate_5700_355_y: NaN
    onDelegate_5700_355_yChanged: {if(i_delegate_5700_355 && i_delegate_5700_355.y != delegate_5700_355_y) i_delegate_5700_355.y = delegate_5700_355_y;}
    property real delegate_5700_355_width: NaN
    onDelegate_5700_355_widthChanged: {if(i_delegate_5700_355 && i_delegate_5700_355.width != delegate_5700_355_width) i_delegate_5700_355.width = delegate_5700_355_width;}
    property real delegate_5700_355_height: NaN
    onDelegate_5700_355_heightChanged: {if(i_delegate_5700_355 && i_delegate_5700_355.height != delegate_5700_355_height) i_delegate_5700_355.height = delegate_5700_355_height;}
    Component.onCompleted: {
        const o_delegate_5700_355 = {}
        if(!isNaN(delegate_5700_355_transform.m11)) o_delegate_5700_355['transform'] = delegate_5700_355_transform;
        if(!isNaN(delegate_5700_355_x)) o_delegate_5700_355['x'] = delegate_5700_355_x;
        if(!isNaN(delegate_5700_355_y)) o_delegate_5700_355['y'] = delegate_5700_355_y;
        if(!isNaN(delegate_5700_355_width)) o_delegate_5700_355['width'] = delegate_5700_355_width;
        if(!isNaN(delegate_5700_355_height)) o_delegate_5700_355['height'] = delegate_5700_355_height;
        i_delegate_5700_355 = delegate_5700_355.createObject(this, o_delegate_5700_355)
        delegate_5700_355_x = Qt.binding(()=>i_delegate_5700_355.x)
        delegate_5700_355_y = Qt.binding(()=>i_delegate_5700_355.y)
        delegate_5700_355_width = Qt.binding(()=>i_delegate_5700_355.width)
        delegate_5700_355_height = Qt.binding(()=>i_delegate_5700_355.height)
    }
}