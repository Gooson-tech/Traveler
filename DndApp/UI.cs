using System;
using System.Linq;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework;
using MonoGame.Extended;
using Myra;
using Myra.Graphics2D;
using Myra.Graphics2D.Brushes;
using Myra.Graphics2D.TextureAtlases;
using Myra.Graphics2D.UI;
using Myra.Graphics2D.UI.ColorPicker;
using Nez;
using Thickness = Myra.Graphics2D.Thickness;

namespace DndApp;

public static class UI
{






    public static bool PaintMode { get; set; }
    public static string PaintName { get; set; } = "Desert";
    public static string LastUsedPaintName { get; set; }
    public static int SplotchSize { get; set; } = 2;
    public static Climate ClimateType { get; set; } = Climate.Desert;
    public static Color useColor { get; set; }=Color.Yellow;

    public static Grid grid=new Grid { RowSpacing = 8, ColumnSpacing = 8 };
    public static bool ONTOP;

    static UI()
    {
        MyraEnvironment.Game = Game1.Instance;
        Game1.desktop = new Desktop();
        Game1.desktop.Root = grid;
    }

    public static void BuildUI()
		{
			void TopOfUi( Widget widget) {
				widget.MouseEntered += (s, a) => UI.ONTOP = true;
				widget.MouseLeft += (s, a) => UI.ONTOP = false;
			}
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
				imageButton1.TouchDown += (s, a) =>  Game1.desktop.Widgets.Add(colorPickerDialog1);
				TopOfUi(imageButton1);
				return imageButton1;
			}

			var textButton1 = new TextButton();
			textButton1.Text = "World Painter";
			textButton1.Toggleable = true;
			textButton1.TouchDown += (s, a) => PaintMode = !PaintMode;
			TopOfUi(textButton1);

			var textButton2 = new TextButton();
			textButton2.Text = "Biome1";
			Alignment(textButton2, HorizontalAlignment.Center, VerticalAlignment.Center);
			TopOfUi(textButton2);

			var imageButton1 = ImageB(2,0,"#CF56BFFF");

			var textButton3 = new TextButton();
			textButton3.Text = "Biome2";
			ColRow(textButton3,0,1);
			TopOfUi(textButton3);

			var imageButton2 = ImageB(2,1,"#5756D5FF");

			var textButton4 = new TextButton();
			textButton4.Text = "Biome3";
			ColRow(textButton4,0,2);
			TopOfUi(textButton4);

			var imageButton3 = ImageB(2,2,"#5BC6FAFF");

			var textButton5 = new TextButton();
			textButton5.Text = "Biome4";
			ColRow(textButton5,0,3);
			TopOfUi(textButton5);

			var imageButton4 = ImageB(2,3,"#FFFFFFFF");

			var textButton6 = new TextButton();
			textButton6.Text = "Biome5";
			ColRow(textButton6,0,4);
			TopOfUi(textButton6);

			var imageButton5 = ImageB(2,4,"#4BD961FF");

			var grid1 = new Grid();
			grid1.ColumnSpacing = 10;
			grid1.RowSpacing = 1;
			grid1.ColumnsProportions.Add(new Proportion { Type = ProportionType.Auto, });
			grid1.ColumnsProportions.Add(new Proportion { Type = ProportionType.Auto, });
			grid1.HorizontalAlignment = HorizontalAlignment.Left;
			grid1.MaxWidth = 1000;
			grid1.Widgets.Add(textButton2);
			grid1.Widgets.Add(imageButton1);
			grid1.Widgets.Add(textButton3);
			grid1.Widgets.Add(imageButton2);
			grid1.Widgets.Add(textButton4);
			grid1.Widgets.Add(imageButton3);
			grid1.Widgets.Add(textButton5);
			grid1.Widgets.Add(imageButton4);
			grid1.Widgets.Add(textButton6);
			grid1.Widgets.Add(imageButton5);

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
			TopOfUi(window1);

			var label1 = new Label();
			label1.Text = "Climate Type:";
			TopOfUi(label1);

			var listItem1 = new ListItem();
			listItem1.Text = "Desert";
			//TopOfUi(listItem1);

			var comboBox1 = new ComboBox();
			comboBox1.Items.Add(listItem1);
			ColRow(comboBox1, 1,0);
			TopOfUi(comboBox1);

			var label2 = new Label();
			label2.Text = "Events:";
			ColRow(label2, 0,1);
			TopOfUi(label2);

			var textButton7 = new TextButton();
			textButton7.Text = "File";
			textButton7.Left = -35;
			ColRow(textButton7, 1,1);
			TopOfUi(textButton7);

			var label3 = new Label();
			label3.Text = "Enemies:";
			ColRow(label3, 0,2);
			TopOfUi(label3);

			var checkBox1 = new CheckBox();
			ColRow(checkBox1, 1,1);
			TopOfUi(checkBox1);

			var textButton8 = new TextButton();
			textButton8.Text = "File";
			textButton8.Left = -35;
			ColRow(textButton8, 1,2);
			TopOfUi(textButton8);

			var checkBox2 = new CheckBox();
			ColRow(checkBox2, 1,2);
			TopOfUi(checkBox2);

			var label4 = new Label();
			label4.Text = "Terrain:";
			ColRow(label4, 0,3);
			TopOfUi(label4);

			var textButton9 = new TextButton();
			textButton9.Text = "File";
			textButton9.Left = -35;
			ColRow(textButton9, 1,3);
			TopOfUi(textButton9);

			var checkBox3 = new CheckBox();
			ColRow(checkBox3, 1,3);
			TopOfUi(checkBox3);
			var spinButton = SplotchSizeWheel();

			var grid2 = new Grid();
			grid2.ColumnSpacing = 1;
			grid2.RowSpacing = 1;
			grid2.ColumnsProportions.Add(new Proportion { Type = Myra.Graphics2D.UI.ProportionType.Auto, });
			grid2.ColumnsProportions.Add(new Proportion { Type = Myra.Graphics2D.UI.ProportionType.Auto, });
			grid2.ColumnsProportions.Add(new Proportion { Type = Myra.Graphics2D.UI.ProportionType.Auto, });
			grid2.HorizontalAlignment = Myra.Graphics2D.UI.HorizontalAlignment.Left;
			grid2.MaxWidth = 1000;
			grid2.Widgets.Add(label1); grid2.Widgets.Add(comboBox1);
			grid2.Widgets.Add(label2); grid2.Widgets.Add(textButton7);
			grid2.Widgets.Add(label3); grid2.Widgets.Add(checkBox1);
			grid2.Widgets.Add(textButton8); grid2.Widgets.Add(checkBox2);
			grid2.Widgets.Add(label4); grid2.Widgets.Add(textButton9); grid2.Widgets.Add(checkBox3);
			
			var window2 = new Window();
			window2.IsModal = false;
			window2.Title = "Properties";
			window2.HorizontalAlignment = Myra.Graphics2D.UI.HorizontalAlignment.Center;
			window2.Left = 158;
			window2.Top = 292;
			window2.Height = 144;
			window2.Content = grid2;
			TopOfUi(window2);
			grid.Widgets.Add(textButton1);
			grid.Widgets.Add(window1);
			grid.Widgets.Add(window2);
			grid.Widgets.Add(spinButton);
		}
    private static SpinButton SplotchSizeWheel()
    {
	    SpinButton patchSpinButton = new SpinButton { GridColumn = 5, GridRow = 0, Value = 2, };

	    patchSpinButton.MouseEntered += (s, a) => UI.ONTOP = true;
	    patchSpinButton.MouseLeft+= (s, a) =>
	    {
		    UI.ONTOP = false;
		    if (patchSpinButton.Value>100) patchSpinButton.Value = 100;
		    else if (patchSpinButton.Value<1) patchSpinButton.Value = 1;
		    if (!patchSpinButton.IsKeyboardFocused) SplotchSize = (int)patchSpinButton.Value;
	    };
	    return patchSpinButton;

    }

    private static void ButtonEvents(TextButton button, bool Mode)
    {

	    button.TouchDown += (s, a) => Mode = !Mode;
    }
    private static void ButtonEvents(TextButton button)
    {
	    button.MouseEntered += (s, a) => UI.ONTOP = true;
	    button.MouseLeft += (s, a) => UI.ONTOP = false;
    }


    /*public static void UI1() {
        grid.ColumnsProportions.Add(new Proportion(ProportionType.Auto));
        grid.ColumnsProportions.Add(new Proportion(ProportionType.Auto));
        grid.RowsProportions.Add(new Proportion(ProportionType.Auto));
        grid.RowsProportions.Add(new Proportion(ProportionType.Auto));

        grid.ColumnsProportions.Add(new Proportion(ProportionType.Auto));
        grid.ColumnsProportions.Add(new Proportion(ProportionType.Auto));
        grid.RowsProportions.Add(new Proportion(ProportionType.Auto));
        grid.RowsProportions.Add(new Proportion(ProportionType.Auto));
        var paintButton=PaintButton();
        var splotchSizeWheel=SplotchSizeWheel();
        var paintNameBox=PaintNameBox();
        var climateTypeComboBox=ClimateTypeComboBox();
        TextButton colorButton=myColorPicker();

        grid.Widgets.Add(paintButton);
        grid.Widgets.Add(splotchSizeWheel);
        grid.Widgets.Add(paintNameBox);
        grid.Widgets.Add(climateTypeComboBox);
        grid.Widgets.Add(colorButton);

    }*/

    private static TextButton PaintButton()
    {
        TextButton paintButton= new TextButton{Text = "Paint", GridColumn = 1, GridRow = 0};
        paintButton.MouseEntered += (s, a) => UI.ONTOP = true;
        paintButton.MouseLeft += (s, a) => UI.ONTOP = false;
        paintButton.TouchDown += (s, a) => PaintMode = !PaintMode;
        return paintButton;
    }

    /*private static TextButton myColorPicker()
    {
        ColorPickerDialog colorPickerDialog = new ColorPickerDialog();
        colorPickerDialog.MouseEntered += (s, a) => UI.ONTOP = true;
        colorPickerDialog.MouseLeft += (s, a) => UI.ONTOP = false;

        TextButton paintColorButton= new TextButton{Text = "Color", GridColumn = 2, GridRow = 0};
        colorPickerDialog.ButtonCancel.PressedChanged += (s, a) => colorPickerDialog.Color = useColor;
        colorPickerDialog.ButtonOk.PressedChanged += (s, a) =>
        {
            useColor = colorPickerDialog.Color;
            paintColorButton.Text = useColor.ToString();
            paintColorButton.TextColor = useColor;
        };
        colorPickerDialog.CloseButton.PressedChanged += (s, a) => colorPickerDialog.Color = useColor;
        paintColorButton.TouchDown += (s, a) => Game1.desktop.Widgets.Add(colorPickerDialog);
        colorPickerDialog.Color = Color.Yellow;
        return paintColorButton;
    }*/
    private static ColorPickerDialog myColorPicker(ref ImageButton presentedColorSquare)
    {
	    SolidBrush background = (SolidBrush)presentedColorSquare.Background;
	    var boxColor=background.Color;
	    ColorPickerDialog colorPickerDialog = new ColorPickerDialog();
	    colorPickerDialog.MouseEntered += (s, a) => UI.ONTOP = true;
	    colorPickerDialog.MouseLeft += (s, a) => UI.ONTOP = false;

	    colorPickerDialog.ButtonCancel.PressedChanged += (s, a) => colorPickerDialog.Color = boxColor;
	    var square = presentedColorSquare;
	    colorPickerDialog.ButtonOk.PressedChanged += (s, a) =>
	    {
		    square.Background = new SolidBrush(colorPickerDialog.Color);
	    };
	    colorPickerDialog.CloseButton.PressedChanged += (s, a) => colorPickerDialog.Color = boxColor;
	    colorPickerDialog.Color = boxColor;
	    return colorPickerDialog;
    }



    private static TextBox PaintNameBox()
    {

        TextBox paintNameBox = new TextBox { Text = " ", GridColumn = 4, GridRow = 0};
        paintNameBox.MouseEntered += (s, a) => UI.ONTOP = true;
        paintNameBox.MouseLeft += (s, a) => UI.ONTOP = false;
        paintNameBox.KeyboardFocusChanged += (s, a) => {
            if (!paintNameBox.IsKeyboardFocused) PaintName = paintNameBox.Text;
        };
        paintNameBox.Text = "Desert";
        return paintNameBox;
    }

    private static ComboBox ClimateTypeComboBox()
    {
        ComboBox ClimateTypeComboBox = new ComboBox();
        ClimateTypeComboBox.MouseEntered += (s, a) => UI.ONTOP = true;
        ClimateTypeComboBox.MouseLeft += (s, a) => UI.ONTOP = false;
        ClimateTypeComboBox.Items.Add(new ListItem("Desert"));
        ClimateTypeComboBox.Items.Add(new ListItem("Tundra"));
        ClimateTypeComboBox.Items.Add(new ListItem("Grassland"));
        ClimateTypeComboBox.SelectedIndex = 0;
        return ClimateTypeComboBox;
    }




    /*public static void UI2() {

    }

    public static void BuildUI()
    {
        MyraEnvironment.Game = Game1.Instance;
        var grid = new Grid { RowSpacing = 8, ColumnSpacing = 8 };

        var image1 = new Image();
        image1.Renderable = MyraEnvironment.DefaultAssetManager.Load<TextureRegion>(FileLocations.UI1);
        image1.Top = -42;
        image1.ZIndex = -2;


        var window1 = new Window();

        window1.Title = "";
        window1.Left = 617;
        window1.Top = 341;
        window1.Padding = new Thickness(-7, 5, -6, -50);
        window1.Background = new SolidBrush("#00000000");
        window1.Content = image1;





        var image2 = new Image();
        image2.Renderable = MyraEnvironment.DefaultAssetManager.Load<TextureRegion>(FileLocations.UI1_2);
        image2.Left = -232;
        image2.Top = 15;
        image2.HorizontalAlignment = Myra.Graphics2D.UI.HorizontalAlignment.Center;

        var grid1 = new Grid();
        grid1.Widgets.Add(image1);
        grid1.Widgets.Add(image2);

        grid.Widgets.Add(grid1);



        PaintButton.TouchDown += (s, a) => PaintMode = !PaintMode;



        // Add it to the desktop
        Game1.desktop = new Desktop();
        Game1.desktop.Root = grid;
    }*/

}