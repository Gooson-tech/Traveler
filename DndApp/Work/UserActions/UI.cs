using System;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using Myra;
using Myra.Graphics2D.Brushes;
using Myra.Graphics2D.UI;
using Myra.Graphics2D.UI.ColorPicker;
using Thickness = Myra.Graphics2D.Thickness;
namespace DndApp;

public static class UI
{
	public static bool PaintMode { get; set; }
  
	public static string PaintName { get; set; } = "Desert";
    public static string LastUsedPaintName { get; set; }
    public static int SplotchSize { get; set; } = 2;
    public static Climates ClimateType { get; set; } = Climates.Desert;
    public static Color UseColor { get; set; } = Color.Yellow;
    public static bool TimeContinue { get; set; }
    public static bool TimeSetChanged { get; set; } = false;

    public static Grid RootGrid = new Grid { RowSpacing = 8, ColumnSpacing = 8 };
    public static bool Ontop;
    public static SelectedPaint CurrentPaint = SelectedPaint.None;
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
    public static string[] Months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
    public static int Month=1;
    public static float? Year=1, Day=1, Hour=0;
    public static TextBox InformationBox;
    public static bool TempPressed;

    static UI()
    {
        MyraEnvironment.Game = Game1.Instance;
        Game1.Desktop = new Desktop();
        Game1.Desktop.Root = RootGrid;
    }
    public static void BuildUI()
		{
			/*void //TopOfUi( Widget widget) {
				widget.MouseEntered += (s, a) => UI.Ontop = true;
				widget.MouseLeft += (s, a) => UI.Ontop = false;
			}*/
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
				var imageButton1 = new ImageButton();
				imageButton1.Background = new SolidBrush(color);
				var colorPickerDialog1=  myColorPicker(ref imageButton1);
				HeightWidth(imageButton1, 20,20);
				Alignment(imageButton1, HorizontalAlignment.Center, VerticalAlignment.Center);
				ColRow(imageButton1,col, row);
				imageButton1.Left = -19;
				imageButton1.Margin = new Thickness(0, 0, -11, 0);
				imageButton1.TouchDown += (s, a) =>  Game1.Desktop.Widgets.Add(colorPickerDialog1);
			//	//TopOfUi(imageButton1);
				return imageButton1;
			}

			var textButton1 = new TextButton();
			textButton1.Text = "World Painter";
			textButton1.Toggleable = true;
			textButton1.TouchDown += (s, a) => PaintMode = !PaintMode;
			////TopOfUi(textButton1);

			var imageButton1 = ImageB(2,0,"#CF56BFFF");
			var textButton2 = new TextButton();
			textButton2.Text = "Biome1";
			textButton2.TouchDown += (s, a) => {
				CurrentPaint = SelectedPaint.ChoiceOne;
				PaintName = "Biome2";
				SolidBrush background = (SolidBrush)imageButton1.Background;
				var boxColor = background.Color;
				UseColor = boxColor;
			};
			Alignment(textButton2, HorizontalAlignment.Center, VerticalAlignment.Center);
			////TopOfUi(textButton2);

			var imageButton2 = ImageB(2,1,"#5756D5FF");
			var textButton3 = new TextButton();
			textButton3.Text = "Biome2";
			textButton3.TouchDown += (s, a) => {
				CurrentPaint = SelectedPaint.ChoiceTwo;
				SolidBrush background = (SolidBrush)imageButton2.Background;
				var boxColor = background.Color;
				UseColor = boxColor;
			};
			ColRow(textButton3,0,1);
		//	//TopOfUi(textButton3);

			var imageButton3 = ImageB(2,2,"#5BC6FAFF");
			var textButton4 = new TextButton();
			textButton4.Text = "Biome3";
			textButton4.TouchDown += (s, a) => {
				CurrentPaint = SelectedPaint.ChoiceThree;
				SolidBrush background = (SolidBrush)imageButton3.Background;
				var boxColor=background.Color;
				UseColor = boxColor;
			};
			ColRow(textButton4,0,2);
		//	//TopOfUi(textButton4);



			var imageButton4 = ImageB(2,3,"#FFFFFFFF");
			var textButton5 = new TextButton();
			textButton5.Text = "Biome4";
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
			var textButton6 = new TextButton();
			textButton6.Text = "Biome5";
			textButton6.TouchDown += (s, a) =>
			{
				CurrentPaint = SelectedPaint.ChoiceFive;
				SolidBrush background = (SolidBrush)imageButton5.Background;
				var boxColor=background.Color;
				UseColor = boxColor;
			};
			ColRow(textButton6,0,4);
			//TopOfUi(textButton6);

			var grid1 = new Grid();
			grid1.ColumnSpacing = 10;
			grid1.RowSpacing = 1;
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

			var window1 = new Window();
			window1.Title = "Biomes";
			window1.Width = 100;
			window1.MaxHeight = 15;
			window1.MaxWidth = 15;
			window1.Left = 904;
			window1.Top = 290;
			window1.Height = 144;
			window1.IsModal = false;
			window1.Content=grid1;
			//TopOfUi(window1);

			var label1 = new Label();
			label1.Text = "Climate Type:";
			//TopOfUi(label1);

			var listItem1 = new ListItem();
			listItem1.Text = "Desert";
			////TopOfUi(listItem1);

			var comboBox1 = new ComboBox();
			ColRow(comboBox1, 1,0);
			//TopOfUi(comboBox1);

			var label2 = new Label();
			label2.Text = "Events:";
			ColRow(label2, 0,1);
			//TopOfUi(label2);

			var textButton7 = new TextButton();
			textButton7.Text = "File";
			textButton7.Left = -35;
			ColRow(textButton7, 1,1);
			//TopOfUi(textButton7);

			var label3 = new Label();
			label3.Text = "Enemies:";
			ColRow(label3, 0,2);
			//TopOfUi(label3);

			var checkBox1 = new CheckBox();
			ColRow(checkBox1, 1,1);
			//TopOfUi(checkBox1);

			var textButton8 = new TextButton();
			textButton8.Text = "File";
			textButton8.Left = -35;
			ColRow(textButton8, 1,2);
			//TopOfUi(textButton8);

			var checkBox2 = new CheckBox();
			ColRow(checkBox2, 1,2);
			//TopOfUi(checkBox2);

			var label4 = new Label();
			label4.Text = "Terrain:";
			ColRow(label4, 0,3);
			//TopOfUi(label4);

			var textButton9 = new TextButton();
			textButton9.Text = "File";
			textButton9.Left = -35;
			ColRow(textButton9, 1,3);
			//TopOfUi(textButton9);
			var checkBox3 = new CheckBox();
			ColRow(checkBox3, 1,3);
			//TopOfUi(checkBox3);

			var spinButton = SplotchSizeWheel();

			var grid2 = new Grid {
					ColumnSpacing = 1,
					RowSpacing = 1,
					HorizontalAlignment = Myra.Graphics2D.UI.HorizontalAlignment.Left,
					MaxWidth = 1000
				};
			grid2.ColumnsProportions.Add(new Proportion { Type = Myra.Graphics2D.UI.ProportionType.Auto, });
			grid2.ColumnsProportions.Add(new Proportion { Type = Myra.Graphics2D.UI.ProportionType.Auto, });
			grid2.ColumnsProportions.Add(new Proportion { Type = Myra.Graphics2D.UI.ProportionType.Auto, });
			grid2.Widgets.Add(label1); grid2.Widgets.Add(comboBox1);
			grid2.Widgets.Add(label2); grid2.Widgets.Add(textButton7);
			grid2.Widgets.Add(label3); grid2.Widgets.Add(checkBox1);
			grid2.Widgets.Add(textButton8); grid2.Widgets.Add(checkBox2);
			grid2.Widgets.Add(label4); grid2.Widgets.Add(textButton9); grid2.Widgets.Add(checkBox3);

			var window2 = new Window
				{
					IsModal = false,
					Title = "Properties",
					HorizontalAlignment = Myra.Graphics2D.UI.HorizontalAlignment.Center,
					Left = 158,
					Top = 292,
					Height = 144,
					Content = grid2
				};
			//TopOfUi(window2);


			/*  WIP FOR DATES*/
			var year = new SpinButton(){GridColumn =3, GridRow = 0};
			year.MouseLeft += (s, a) => Year = year.Value;
			year.ValueChangedByUser +=(s,a)=> UI.TimeSetChanged=!UI.TimeSetChanged;
			year.Value = 1;
			
			var monthBox = new ComboBox(){GridColumn =4, GridRow = 0};
			foreach (var month in Months) {
				monthBox.Items.Add(new ListItem(month));
			}
			monthBox.SelectedIndex = 0;
			monthBox.MouseLeft += (s, a) => {
				/*for (int i = 1; i <= Months.Length; i++)
					if (monthBox.SelectedItem.Text == Months[i]) { Month = i; break;}*/ 
				Month=	monthBox.SelectedIndex.Value+1;
			};
			monthBox.SelectedItem.Changed +=(s,a)=> UI.TimeSetChanged=!UI.TimeSetChanged;

			var day = new SpinButton(){GridColumn =5, GridRow = 0};
			day.MouseLeft += (s, a) => Day = day.Value;
			day.ValueChangedByUser +=(s,a)=> UI.TimeSetChanged=!UI.TimeSetChanged;
			day.Maximum = 31;
			day.Minimum = 1;
			day.Value = 1;


			var hour = new SpinButton(){GridColumn =5, GridRow = 1};
			hour.MouseLeft += (s, a) => Hour = hour.Value;
			hour.ValueChangedByUser +=(s,a)=> UI.TimeSetChanged=!UI.TimeSetChanged;

			hour.Maximum = 23;
			hour.Minimum = 0;
			hour.Value = 0;
			
			
			var tempButton = new TextButton(){Text = "temp"};
			tempButton.TouchDown += (s, a) => { TempPressed = !TempPressed; };
			
			var continueButton = new TextButton();
			continueButton.Text = "Time Continue";
			continueButton.Left = -35;
			continueButton.Toggleable = true;
			continueButton.TouchDown += (s, a) => { TimeContinue = !TimeContinue;};
			ColRow(continueButton, 1,4);
			
			
			
			InformationBox = new TextBox { Text = "Current Weather:	", GridColumn = 6, GridRow = 0};
			InformationBox.Wrap = true;
			
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
		}


    private static SpinButton SplotchSizeWheel()
    {
	    SpinButton patchSpinButton = new SpinButton { GridColumn = 2, GridRow = 2, Value = 4, };
	    patchSpinButton.MouseEntered += (s, a) => UI.Ontop = true;
	    patchSpinButton.MouseLeft+= (s, a) => {
		    UI.Ontop = false;
		    patchSpinButton.Value = patchSpinButton.Value switch {
			    < 1 => 1, > 100 => 100, _ => patchSpinButton.Value
		    };
		    if (!patchSpinButton.IsKeyboardFocused)
			    SplotchSize = (int)patchSpinButton.Value;
	    };
	    return patchSpinButton;
    }
    private static ColorPickerDialog myColorPicker(ref ImageButton presentedColorSquare)
    {
	    SolidBrush background = (SolidBrush)presentedColorSquare.Background;
	    var boxColor=background.Color;
	    ColorPickerDialog colorPickerDialog = new ColorPickerDialog();

	    var square = presentedColorSquare;
	    colorPickerDialog.ButtonCancel.PressedChanged += (s, a) => colorPickerDialog.Color = boxColor;
	    colorPickerDialog.ButtonOk.PressedChanged += (s, a) => { square.Background = new SolidBrush(colorPickerDialog.Color); };
	    colorPickerDialog.CloseButton.PressedChanged += (s, a) => colorPickerDialog.Color = boxColor;
	    colorPickerDialog.MouseEntered += (s, a) => UI.Ontop = true;
	    colorPickerDialog.MouseLeft += (s, a) => UI.Ontop = false;
	    colorPickerDialog.Color = boxColor;
	    return colorPickerDialog;
    }
    private static TextBox PaintNameBox()
    {
	    TextBox paintNameBox = new TextBox { Text = " ", GridColumn = 4, GridRow = 0};
        paintNameBox.MouseEntered += (s, a) => UI.Ontop = true;
        paintNameBox.MouseLeft += (s, a) => UI.Ontop = false;
        paintNameBox.KeyboardFocusChanged += (s, a) => {
            if (!paintNameBox.IsKeyboardFocused) PaintName = paintNameBox.Text;
        };
       // paintNameBox.Text = "Desert";
        return paintNameBox;
    }
    private static ComboBox ClimateTypeComboBox()
    {
        ComboBox ClimateTypeComboBox = new ComboBox();
        //ClimateTypeComboBox.Items.Add(new ListItem("Desert"));
        ClimateTypeComboBox.Items.Add(new ListItem("Tundra"));
        ClimateTypeComboBox.Items.Add(new ListItem("Grassland"));
        ClimateTypeComboBox.SelectedIndex = 0;

        ClimateTypeComboBox.MouseEntered += (s, a) => UI.Ontop = true;
        ClimateTypeComboBox.MouseLeft += (s, a) => UI.Ontop = false;
        return ClimateTypeComboBox;
    }
}