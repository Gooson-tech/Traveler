﻿#region NameSpace
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Myra.Graphics2D;
using Myra.Graphics2D.Brushes;
using Myra.Graphics2D.TextureAtlases;
using Myra.Graphics2D.UI;
using Myra.Graphics2D.UI.ColorPicker;
using Nez;
using H = Myra.Graphics2D.UI.HorizontalAlignment;
using V = Myra.Graphics2D.UI.VerticalAlignment;
using static Myra.MyraEnvironment;

namespace Traveler;
#endregion
//Code formatting/styling here is very different; UI code takes up a lot of space, and needs to be easy to see quickly.
//Markup-Languages exist for a reason!
public class MyraUI {

	//alias
	static IImage UILoad(string fileName) => DefaultAssetManager.Load<TextureRegion>(FileLocations.UIFiles + fileName);

				#region Properties
	public enum Mode { None, Paint, TravelToClicked }

	#region EventBooleansToCheck
	public static bool MouseIsOver { get; private set; }
	public static bool IsClicked { get; set; }
	#endregion

	#region Paint
	public Mode SelectedMode { get; set; } = Mode.TravelToClicked;
	public Climate SelectedClimate { get; } = Climate.Grassland;
	public string BiomeName { get; private set; } = "";
	public int SplotchSize { get; private set; } = 32;
	private enum SelectedPaint { None, ChoiceOne, ChoiceTwo, ChoiceThree, ChoiceFour, ChoiceFive, ChoiceSix, }
		 #region ColorPicker
	public Color UseColor { get; set; }
	private readonly MyColorPicker _colorPicker = new();
	#endregion
	#endregion
	#region InfoAndTime
	public TextBox InformationBox { get; set; }
	public uint Year = 1, Month = 0, Day = 1, Hour = 0;
	#endregion
	#region LeftPanelArea
	private readonly Image _panel = new() {
		Renderable = UILoad("LeftPanel.png"), Id = "Lpanel", 
	};
	private readonly MyButton
		_menu   = new("Menu",   105),   _edit  = new("Edit", 168),
		_travel = new("Travel", 231), _fight = new(  "Fight",  294),
		_info   = new("Info",   357),   _notes = new("Notes",420);
	#endregion

					#endregion

	public MyraUI(Desktop desktop) {


		#region GridSetup
		var grid = new Grid { ColumnSpacing = 8, RowSpacing = 8 };
		grid.ColumnsProportions.Add(new() { Type = ProportionType.Auto, });
		grid.ColumnsProportions.Add(new() { Type = ProportionType.Auto, });
		grid.RowsProportions.Add(new() { Type = ProportionType.Auto, });
		grid.RowsProportions.Add(new() { Type = ProportionType.Auto, });
		#endregion

	
		
		grid.Widgets._Add(_panel)._Add(_menu)._Add(_edit)._Add(_travel)._Add(_fight)._Add(_info)._Add(_notes);
		desktop.Root= grid;
	}
	private sealed class MyButton : ImageButton {
		#region ButtonEvents
		public override void OnMouseMoved() { base.OnMouseMoved(); MouseIsOver = true; }
		public override void OnMouseLeft() { base.OnMouseLeft(); MouseIsOver = false; }
		public override void OnTouchDown() { base.OnTouchDown(); IsClicked = true; }
		public override void OnTouchUp() { base.OnTouchUp(); IsClicked = false; }
		#endregion
		public MyButton(string name, int top) {
			Id = name; 
			Left = 75; Top = top; 
			#region ImageLoading
			Image = UILoad(name + "Button.png");
			OverImage = UILoad(name + "ButtonHovered.png");
			PressedImage = UILoad(name + "ButtonPressed.png");
			#endregion
			#region Alignment
			ImageHorizontalAlignment = H.Stretch; ImageVerticalAlignment = V.Stretch;
			ContentHorizontalAlignment = H.Stretch; ContentVerticalAlignment = V.Stretch;
			Margin = new(-8, 0, -8, -9);
			#endregion
			ClipToBounds = true;
			ZIndex = 1;
		}
	}
}
internal static class _AddExtension {
	public static T _Add<T>(this T collection, Widget itemToAdd) where T : ICollection<Widget>
	{
		collection.Add(itemToAdd); 
		return collection;
	}
}
public class MyTextBox : TextBox
{
	public override void OnChar(char c)
	{
		base.OnChar(c);
	}
}
public class MyColorPicker : ColorPickerDialog
{
	public Color UseColor { get; private set; } = Color.Red;
	protected override void OnOk()
	{
		base.OnOk();
	}
	protected override bool CanCloseByOk()=>true;

	public void Set( MyraUI myraUI, ref ImageButton presentedColorSquare)
	{
		var background = (SolidBrush)presentedColorSquare.Background;

		var square = presentedColorSquare;
		ButtonOk.PressedChanged += (s, a) =>
		{
			square.Background = new SolidBrush(Color);
			myraUI.UseColor = Color;
		};
		ButtonCancel.PressedChanged += (s, a) => Color = background.Color;
		CloseButton.PressedChanged += (s, a) => Color = background.Color;
	}

	public override void Close()
	{
		base.Close();
	}
}
public sealed class Window1 : Window 
{

	public Window1(Image image1, Widget informationBox)
	{
		var xDivide = 1; var yDivide = 1; 
		if (image1.Renderable.Size.X > 1000) 
			xDivide = 4;
		if (image1.Renderable.Size.Y > 1000)
			yDivide = 4;

		Tag = MyraUI.Mode.TravelToClicked;
		Title = "Biomes";
		Left = 0; Top = 0;
		IsModal = false;
		Visible = false;
		MinWidth = 100; MinHeight = 100;
		MaxWidth = image1.Renderable.Size.X / xDivide;
		MaxHeight = image1.Renderable.Size.Y / yDivide;
		Background = new SolidBrush("#363636FF");
		Border = new SolidBrush("#5BC6FAFF");
		Grid RootGrid2 = new() { RowSpacing = 0, ColumnSpacing = 0 };
		RootGrid2.Widgets.Add(image1);
		RootGrid2.Widgets.Add(informationBox);
		Content = RootGrid2;
		//image scale scrolling
		Content.MouseMoved += (s, a) => { 
			var scrollValue = Input.MouseWheelDelta / 12;
			if (scrollValue == 0) return;
			MaxWidth += scrollValue; MaxHeight += scrollValue;
			Width += scrollValue; Height += scrollValue;
		};
	}
}