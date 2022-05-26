using Myra;
using Myra.Graphics2D;
using Myra.Graphics2D.TextureAtlases;
using Myra.Graphics2D.UI;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Myra.Graphics2D.Brushes;
using Myra.Graphics2D.UI.ColorPicker;
using Nez;

namespace DndApp;
public class UI
{
	//private  string _lastUsedBiomeName;
	private readonly MyColorPicker _colorPicker= new();
	private TextBox _informationBox;
	public string BiomeName { get; private set; } = "";
	public int SplotchSize { get; private set; } = 32;
	private  bool TimeContinue { get; set; }
	public  bool OnTop { get; private set; }
	public enum SelectedPaint { None, ChoiceOne, ChoiceTwo, ChoiceThree, ChoiceFour, ChoiceFive, ChoiceSix, }
	public static IEnumerable<string> Months { get; } = new[]
	{
		"January", "February", "March",
		"April", "May", "June", "July",
		"August", "September", "October", 
		"November", "December",
	};
	public  int Month { get;  } = 1;
	public  int Year { get;  } = 1;
	public  int Day { get;  } = 1;
	public  int Hour { get; } = 0;

	public TextBox InformationBox
	{
		get => _informationBox;
		set => _informationBox = value;
	}

	public  Climate SelectedClimate { get; } = Climate.Grassland;
	public Mode SelectedMode { get; set; } = Mode.TravelToClicked;
	public Color UseColor { get; set; }

	public UI(Desktop desktop) { 
		Grid RootGrid = new() { RowSpacing = 8, ColumnSpacing = 8 };
		desktop.Root = RootGrid;


		//var grid1 = new Grid { ColumnSpacing = 10, RowSpacing = 1, };
		var image1 = new Image
		{
			Renderable = MyraEnvironment.DefaultAssetManager.Load<TextureRegion>(FileLocations.LocationImages1),
		};
		 _informationBox = new TextBox
		{
			VerticalAlignment = VerticalAlignment.Top,
			HorizontalAlignment = HorizontalAlignment.Left,
			Readonly = true,
			Text = "EMPTY",
			Multiline = true,
			Visible = true,
		};
		var window1 = new Window1(image1,_informationBox);
		window1.Content.TouchDoubleClick += (s, a) => {
			window1.Visible = false;
			var myQml = new ImageOnlyQml(window1);
		};
		


	

		var presentedColorSquare = new ImageButton
		{
			Tag = Mode.Paint,
			Visible = false,
			Left = -19,
			Top = 0,
			MinWidth = 100,
			MinHeight = 100,
			VerticalAlignment = VerticalAlignment.Top,
			Background = new SolidBrush("#CF56BFFF"),
			ContentHorizontalAlignment = HorizontalAlignment.Left,
			ContentVerticalAlignment = VerticalAlignment.Top,
			Margin = new Thickness(0, 0, -11, 0),
		};
		presentedColorSquare.TouchDown += (s, a) =>
		{
			_colorPicker.Set(this, ref presentedColorSquare);
			_colorPicker.ShowModal(desktop);
		};

		var textbox = new MyTextBox
		{
			Tag = Mode.Paint,
			Left = 0,
			Top = 0,
			MinWidth = 100,
			MinHeight = 100,
			VerticalAlignment = VerticalAlignment.Top,
			IsModal = false,
			AcceptsKeyboardFocus = true,
			Text = "",
			Multiline = false,
			Readonly = false,
			TextVerticalAlignment = VerticalAlignment.Top,
			HorizontalAlignment = HorizontalAlignment.Right,
		};
		textbox.MouseLeft += (s, a) =>
		{
			if (textbox.Text != null)
				BiomeName = textbox.Text.ToLower();
		};

		var painterModeButton = new TextButton { Text = "World Paint", Toggleable = false, };
		painterModeButton.TouchDown += (s, a) =>
		{
			//toggles other buttons if on
			if (!painterModeButton.IsPressed)
			{
				SelectedModeSet(Mode.Paint);
			}
		};	
		var travelButton = new TextButton { Text = "Travel", Toggleable = false, };
		travelButton.TouchDown += (s, a) =>
		{
			//toggles other buttons if on
			if (!travelButton.IsPressed)
			{
				SelectedModeSet(Mode.TravelToClicked);
			}

		};

		//RootGrid.Widgets.Add(_colorPicker);

		RootGrid.Widgets.Add(window1);
		window1.MouseEntered += (s, a) => OnTop = true;
		window1.MouseLeft += (s, a) => OnTop = false;

		RootGrid.Widgets.Add(painterModeButton);
		painterModeButton.MouseEntered += (s, a) => OnTop = true;
		painterModeButton.MouseLeft += (s, a) => OnTop = false;

		RootGrid.Widgets.Add(presentedColorSquare);
		presentedColorSquare.MouseEntered += (s, a) => OnTop = true;
		presentedColorSquare.MouseLeft += (s, a) => OnTop = false;

		RootGrid.Widgets.Add(textbox);
		textbox.MouseEntered += (s, a) => OnTop = true;
		textbox.MouseLeft += (s, a) => OnTop = false;	
		
		RootGrid.Widgets.Add(travelButton);
		travelButton.MouseEntered += (s, a) => OnTop = true;
		travelButton.MouseLeft += (s, a) => OnTop = false;

		/*RootGrid.Widgets.Add(_informationBox);
		_informationBox.MouseEntered += (s, a) => OnTop = true;
		_informationBox.MouseLeft += (s, a) => OnTop = false;*/

		void SelectedModeSet(Mode mode)
		{
			if (mode == Mode.TravelToClicked)
			{
				window1.Visible=true;
				presentedColorSquare.Visible = false;
				textbox.Visible = false;
			} 
			else 
			{
				window1.Visible = false;
				presentedColorSquare.Visible = true;
				textbox.Visible = true;

			}
			SelectedMode = mode;
		}

	}
	public enum Mode
	{
		None,
		Paint,
		TravelToClicked
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

	public void Set( UI ui, ref ImageButton presentedColorSquare)
	{
		var background = (SolidBrush)presentedColorSquare.Background;

		var square = presentedColorSquare;
		this.ButtonOk.PressedChanged += (s, a) =>
		{
			square.Background = new SolidBrush(this.Color);
			ui.UseColor = this.Color;
		};
		this.ButtonCancel.PressedChanged += (s, a) => this.Color = background.Color;
		this.CloseButton.PressedChanged += (s, a) => this.Color = background.Color;
	}

	public override void Close()
	{
		base.Close();
	}

	public MyColorPicker()
	{
	}
	
}

public sealed class Window1 : Window 
{

	public Window1(Image image1, Widget informationBox):base()
	{
		var xDivide = 1; var yDivide = 1; 
		if (image1.Renderable.Size.X > 1000) 
			xDivide = 4;
		if (image1.Renderable.Size.Y > 1000)
			yDivide = 4;

		Tag = UI.Mode.TravelToClicked;
		Title = "Biomes";
		Left = 0; this.Top = 0;
		IsModal = false;
		Visible = false;
		MinWidth = 100; this.MinHeight = 100;
		MaxWidth = image1.Renderable.Size.X / xDivide;
		MaxHeight = image1.Renderable.Size.Y / yDivide;
		Background = new SolidBrush("#363636FF");
		Border = new SolidBrush("#5BC6FAFF");
		Grid RootGrid2 = new() { RowSpacing = 0, ColumnSpacing = 0 };
		RootGrid2.Widgets.Add(image1);
		RootGrid2.Widgets.Add(informationBox);
		Content = RootGrid2;
		//image scale scrolling
		this.Content.MouseMoved += (s, a) => { 
			var scrollValue = Input.MouseWheelDelta / 12;
			if (scrollValue == 0) return;
			this.MaxWidth += scrollValue; this.MaxHeight += scrollValue;
			this.Width += scrollValue; this.Height += scrollValue;
		};
	}
}

/*public static class UI
{
	public static bool PaintMode { get; set; }
	private static string _biomeName = "Grassland";
	private static string _lastUsedBiomeName;
	public static string BiomeName
	{
		get => _biomeName;
		set
		{
			_lastUsedBiomeName = _biomeName;
			_biomeName = value;
		} 
	}
	public static int SplotchSize { get; private set; } = 32;
	public static Color UseColor { get; private set; } = Color.Yellow;
	private static bool TimeContinue { get; set; }
	private static bool TimeSetChanged { get; set; }
	private static readonly Grid RootGrid = new() { RowSpacing = 8, ColumnSpacing = 8 };
	private static bool _ontop;
	public static SelectedPaint CurrentPaint { get; set; } = SelectedPaint.None;
	public enum SelectedPaint
	{
		None,
		ChoiceOne,
		ChoiceTwo,
		ChoiceThree,
		ChoiceFour,
		ChoiceFive,
		ChoiceSix,
	}
	public static IEnumerable<string> Months { get; } = new[] {
		"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November",
		"December",
	};
	public static int Month { get; set; } = 1;
	public static float? Year { get; set; } = 1;
	public static float? Day { get; set; } = 1;
	public static float? Hour { get; set; } = 0;
	public static TextBox InformationBox { get; set; }
  
	public static Climate SelectedClimate { get; set; } = Climate.Grassland;


	private static bool TempPressed;
	static UI()
	{
		MyraEnvironment.Game = Core.Instance;
		Game1.Desktop = new Desktop { Root = RootGrid };
	}
	public static void BuildUI()
		{
			/*void //TopOfUi( Widget widget) {
				widget.MouseEntered += (s, a) => UI.OnTop = true;
				widget.MouseLeft += (s, a) => UI.OnTop = false;
			}#1#
			void HeightWidth(Widget widget, int height, int width) {
				widget.MinWidth = width;
				widget.MinHeight = height;
			}
			void ColRow(Widget widget, int col, int row) {
				widget.GridColumn = col;
				widget.GridRow = row;
			}
			void Alignment(Widget widget, HorizontalAlignment horizontalAlignment, VerticalAlignment verticalAlignment) {
				widget.HorizontalAlignment = horizontalAlignment;
				widget.VerticalAlignment = verticalAlignment;
			}
			ImageButton ImageB(int col, int row, string color) {
				var imageButton1 = new ImageButton
				{
					Background = new SolidBrush(color),
				};
				var colorPickerDialog1=  MyColorPicker(ref imageButton1);
				HeightWidth(imageButton1, 20,20);
				Alignment(imageButton1, HorizontalAlignment.Center, VerticalAlignment.Center);
				ColRow(imageButton1,col, row);
				imageButton1.Left = -19;
				imageButton1.Margin = new Thickness(0, 0, -11, 0);
				imageButton1.TouchDown += (s, a) =>  Game1.Desktop.Widgets.Add(colorPickerDialog1);
			//	//TopOfUi(imageButton1);
				return imageButton1;
			}

			var textButton1 = new TextButton
			{
				Text = "World Painter",
				Toggleable = true,
			};
			textButton1.TouchDown += (s, a) => PaintMode = !PaintMode;
			////TopOfUi(textButton1);

			var imageButton1 = ImageB(2,0,"#CF56BFFF");
			var textButton2 = new TextButton
			{
				Text = "Biome1",
			};
			textButton2.TouchDown += (s, a) => {
				CurrentPaint = SelectedPaint.ChoiceOne;
				BiomeName = "Biome2";
				SolidBrush background = (SolidBrush)imageButton1.Background;
				var boxColor = background.Color;
				UseColor = boxColor;
			};
			Alignment(textButton2, HorizontalAlignment.Center, VerticalAlignment.Center);
			////TopOfUi(textButton2);

			var imageButton2 = ImageB(2,1,"#5756D5FF");
			var textButton3 = new TextButton
			{
				Text = "Biome2",
			};
			textButton3.TouchDown += (s, a) => {
				CurrentPaint = SelectedPaint.ChoiceTwo;
				SolidBrush background = (SolidBrush)imageButton2.Background;
				var boxColor = background.Color;
				UseColor = boxColor;
			};
			ColRow(textButton3,0,1);
		//	//TopOfUi(textButton3);

			var imageButton3 = ImageB(2,2,"#5BC6FAFF");
			var textButton4 = new TextButton
			{
				Text = "Biome3",
			};
			textButton4.TouchDown += (s, a) => {
				CurrentPaint = SelectedPaint.ChoiceThree;
				SolidBrush background = (SolidBrush)imageButton3.Background;
				var boxColor=background.Color;
				UseColor = boxColor;
			};
			ColRow(textButton4,0,2);
		//	//TopOfUi(textButton4);



			var imageButton4 = ImageB(2,3,"#FFFFFFFF");
			var textButton5 = new TextButton
			{
				Text = "Biome4",
			};
			textButton5.TouchDown += (s, a) =>
			{
				CurrentPaint = SelectedPaint.ChoiceFour;
				SolidBrush background = (SolidBrush)imageButton4.Background;
				var boxColor=background.Color;
				UseColor = boxColor;
			};
			ColRow(textButton5,0,3);
			//TopOfUi(textButton5);
			
			var imageButton5 = ImageB(2,4,"#4BD961FF");
			var textButton6 = new TextButton
			{
				Text = "Biome5",
			};
			textButton6.TouchDown += (s, a) =>
			{
				CurrentPaint = SelectedPaint.ChoiceFive;
				SolidBrush background = (SolidBrush)imageButton5.Background;
				var boxColor=background.Color;
				UseColor = boxColor;
			};
			ColRow(textButton6,0,4);
			//TopOfUi(textButton6);

			var grid1 = new Grid
			{
				ColumnSpacing = 10,
				RowSpacing = 1,
			};
			grid1.ColumnsProportions.Add(new Proportion { Type = ProportionType.Auto, });
			grid1.ColumnsProportions.Add(new Proportion { Type = ProportionType.Auto, });
			grid1.HorizontalAlignment = HorizontalAlignment.Left;
			grid1.MaxWidth = 1000;
			grid1.Widgets.Add(textButton2); grid1.Widgets.Add(imageButton1);
			grid1.Widgets.Add(textButton3); grid1.Widgets.Add(imageButton2);
			grid1.Widgets.Add(textButton4); grid1.Widgets.Add(imageButton3);
			grid1.Widgets.Add(textButton5); grid1.Widgets.Add(imageButton4);
			grid1.Widgets.Add(textButton6); grid1.Widgets.Add(imageButton5);
			////TopOfUi(grid1);

			var window1 = new Window
			{
				Title = "Biomes",
				Width = 100,
				MaxHeight = 15,
				MaxWidth = 15,
				Left = 904,
				Top = 290,
				Height = 144,
				IsModal = false,
				Content = grid1,
			};
			//TopOfUi(window1);

			var label1 = new Label
			{
				Text = "ClimateData Type:",
			};
			//TopOfUi(label1);

			var listItem1 = new ListItem
			{
				Text = "Desert",
			};
			////TopOfUi(listItem1);

			var comboBox1 = new ComboBox();
			ColRow(comboBox1, 1,0);
			//TopOfUi(comboBox1);

			var label2 = new Label
			{
				Text = "Events:",
			};
			ColRow(label2, 0,1);
			//TopOfUi(label2);

			var textButton7 = new TextButton
			{
				Text = "File",
				Left = -35,
			};
			ColRow(textButton7, 1,1);
			//TopOfUi(textButton7);

			var label3 = new Label
			{
				Text = "Enemies:",
			};
			ColRow(label3, 0,2);
			//TopOfUi(label3);

			var checkBox1 = new CheckBox();
			ColRow(checkBox1, 1,1);
			//TopOfUi(checkBox1);

			var textButton8 = new TextButton
			{
				Text = "File",
				Left = -35,
			};
			ColRow(textButton8, 1,2);
			//TopOfUi(textButton8);

			var checkBox2 = new CheckBox();
			ColRow(checkBox2, 1,2);
			//TopOfUi(checkBox2);

			var label4 = new Label
			{
				Text = "Terrain:",
			};
			ColRow(label4, 0,3);
			//TopOfUi(label4);

			var textButton9 = new TextButton
			{
				Text = "File",
				Left = -35,
			};
			ColRow(textButton9, 1,3);
			//TopOfUi(textButton9);
			var checkBox3 = new CheckBox();
			ColRow(checkBox3, 1,3);
			//TopOfUi(checkBox3);

			var spinButton = SplotchSizeWheel();

			var grid2 = new Grid {
					ColumnSpacing = 1,
					RowSpacing = 1,
					HorizontalAlignment = HorizontalAlignment.Left,
					MaxWidth = 1000,
				};
			grid2.ColumnsProportions.Add(new Proportion { Type = ProportionType.Auto, });
			grid2.ColumnsProportions.Add(new Proportion { Type = ProportionType.Auto, });
			grid2.ColumnsProportions.Add(new Proportion { Type = ProportionType.Auto, });
			grid2.Widgets.Add(label1); grid2.Widgets.Add(comboBox1);
			grid2.Widgets.Add(label2); grid2.Widgets.Add(textButton7);
			grid2.Widgets.Add(label3); grid2.Widgets.Add(checkBox1);
			grid2.Widgets.Add(textButton8); grid2.Widgets.Add(checkBox2);
			grid2.Widgets.Add(label4); grid2.Widgets.Add(textButton9); grid2.Widgets.Add(checkBox3);

			var window2 = new Window
				{
					IsModal = false,
					Title = "Properties",
					HorizontalAlignment = HorizontalAlignment.Center,
					Left = 158,
					Top = 292,
					Height = 144,
					Content = grid2,
				};
			//TopOfUi(window2);


			/*  WIP FOR DATES#1#
			var year = new SpinButton {GridColumn =3, GridRow = 0};
			year.MouseLeft += (s, a) => Year = year.Value;
			year.ValueChangedByUser +=(s,a)=> TimeSetChanged=!TimeSetChanged;
			year.Value = 1;
			
			var monthBox = new ComboBox {GridColumn =4, GridRow = 0};

			foreach (var month in Months) 
				monthBox.Items.Add(new ListItem(month));

			monthBox.SelectedIndex = 0;
			monthBox.MouseLeft += (s, a) => {
				/*for (int i = 1; i <= Months.Length; i++)
					if (monthBox.SelectedItem.Text == Months[i]) { Month = i; break;}#1# 
				Month=	monthBox.SelectedIndex.Value+1;
			};
			monthBox.SelectedItem.Changed +=(s,a)=> TimeSetChanged =! TimeSetChanged;

			var day = new SpinButton {GridColumn =5, GridRow = 0};
			day.MouseLeft += (s, a) => Day = day.Value;
			day.ValueChangedByUser +=(s,a)=> TimeSetChanged =! TimeSetChanged;
			day.Maximum = 31;
			day.Minimum = 1;
			day.Value = 1;


			var hour = new SpinButton {GridColumn =5, GridRow = 1};
			hour.MouseLeft += (s, a) => Hour = hour.Value;
			hour.ValueChangedByUser +=(s,a)=> TimeSetChanged =!TimeSetChanged;

			hour.Maximum = 23;
			hour.Minimum = 0;
			hour.Value = 0;
			
			
			var tempButton = new TextButton {Text = "temp"};
			tempButton.TouchDown += (s, a) => { TempPressed = !TempPressed; };
			
			var continueButton = new TextButton
			{
				Text = "Time Continue",
				Left = -35,
				Toggleable = true,
			};
			continueButton.TouchDown += (s, a) => { TimeContinue = !TimeContinue;};
			ColRow(continueButton, 1,4);
			
			
			
			InformationBox = new TextBox
			{
				Text = "Current Weather:	", GridColumn = 6, GridRow = 0,
				Wrap = true,
			};

			RootGrid.Widgets.Add(year);
			RootGrid.Widgets.Add(monthBox);
			RootGrid.Widgets.Add(day);
			RootGrid.Widgets.Add(hour);
			RootGrid.Widgets.Add(InformationBox);



			RootGrid.Widgets.Add(textButton1);
			RootGrid.Widgets.Add(window1);
			RootGrid.Widgets.Add(window2);
			RootGrid.Widgets.Add(spinButton);
			RootGrid.Widgets.Add(continueButton);

			ComboBox climateComboBox = ClimateTypeComboBox(); 
			TextBox biomeNamer = BiomeNamer(); 
			RootGrid.Widgets.Add(climateComboBox);
			RootGrid.Widgets.Add(biomeNamer);
		}


	private static SpinButton SplotchSizeWheel()
	{
		var patchSpinButton = new SpinButton { GridColumn = 2, GridRow = 2, Value = 32, };
		patchSpinButton.MouseEntered += (s, a) => _ontop = true;
		patchSpinButton.MouseLeft+= (s, a) => {
			_ontop = false;
			patchSpinButton.Value = patchSpinButton.Value switch
			{
				< 18 => 18,
				> 100 => 100,
				_ => patchSpinButton.Value
			};
			if (!patchSpinButton.IsKeyboardFocused)
				SplotchSize = (int)patchSpinButton.Value;
		};
		return patchSpinButton;
	}
	private static ColorPickerDialog MyColorPicker(ref ImageButton presentedColorSquare)
	{
		var background = (SolidBrush)presentedColorSquare.Background;
		var boxColor=background.Color;
		ColorPickerDialog colorPickerDialog = new();

		var square = presentedColorSquare;
		colorPickerDialog.ButtonCancel.PressedChanged += (s, a) => colorPickerDialog.Color = boxColor;
		colorPickerDialog.ButtonOk.PressedChanged += (s, a) => { square.Background = new SolidBrush(colorPickerDialog.Color); };
		colorPickerDialog.CloseButton.PressedChanged += (s, a) => colorPickerDialog.Color = boxColor;
		colorPickerDialog.MouseEntered += (s, a) => _ontop = true;
		colorPickerDialog.MouseLeft += (s, a) => _ontop = false;
		colorPickerDialog.Color = boxColor;
		return colorPickerDialog;
	}
	private static TextBox PaintNameBox()
	{
		var paintNameBox = new TextBox { Text = " ", GridColumn = 4, GridRow = 0};
		paintNameBox.MouseEntered += (s, a) => _ontop = true;
		paintNameBox.MouseLeft += (s, a) => _ontop = false;
		paintNameBox.KeyboardFocusChanged += (s, a) => {
		   // if (!paintNameBox.IsKeyboardFocused) PaintName = paintNameBox.Text;
		};
	   // paintNameBox.Text = "Desert";
		return paintNameBox;
	}
	private static ComboBox ClimateTypeComboBox()
	{
		var climateTypeComboBox = new ComboBox
		{
			
			GridColumn = 5,
			GridRow = 5,
			SelectionMode = SelectionMode.Single,
			Items = {new ListItem("Grassland"), new ListItem("Tundra")},
			SelectedIndex = 0,
		};

		climateTypeComboBox.SelectedIndexChanged += (s, a) =>
		{
			SelectedClimate = climateTypeComboBox.SelectedItem.Text.ToEnum<Climate>();
		};
		climateTypeComboBox.MouseEntered += (s, a) => _ontop = true;
		climateTypeComboBox.MouseLeft += (s, a) => _ontop = false;
		return climateTypeComboBox;
	}
	private static TextBox BiomeNamer()
	{
		var biomeText = new TextBox
		{
			GridColumn = 6,
			GridRow = 5,
			Text = "GrassLand",
			Multiline = false,
			Readonly = false,
		};

		//ClimateTypeComboBox.Items.Add(new ListItem("Desert"));
		//climateTypeComboBox.Items.Add(new ListItem("Tundra"));
		//climateTypeComboBox.Items.Add(new ListItem("Grassland"));
		//climateTypeComboBox.SelectedIndex = 0;


		biomeText.MouseEntered += (s, a) => _ontop = true;
		biomeText.MouseLeft += (s, a) =>
		{
			BiomeName = biomeText.Text.ToLower();
			_ontop = false;
		};
		return biomeText;
	}

	public static T ToEnum<T>(this string value)
	{
		return (T)Enum.Parse(typeof(T), value, true);
	}

}*/