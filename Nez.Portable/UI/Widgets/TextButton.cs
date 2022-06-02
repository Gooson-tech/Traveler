using System;
using Microsoft.Xna.Framework;


namespace Nez.UI
{
	public class TextButton : Button
	{
		Label label;
		TextButtonStyle style;


		public TextButton(string text, TextButtonStyle style) : base(style)
		{
			SetStyle(style);
			label = new Label(text, style.Font, style.FontColor);
			label.SetAlignment(UI.Align.Center);

			Add(label).Expand().Fill();
			SetSize(PreferredWidth, PreferredHeight);
		}


		public TextButton(string text, Skin skin, string styleName = null) : this(text,
			skin.Get<TextButtonStyle>(styleName))
		{
		}


		public override void SetStyle(ButtonStyle style)
		{
			Insist.IsTrue(style is TextButtonStyle, "style must be a TextButtonStyle");

			base.SetStyle(style);
			this.style = (TextButtonStyle) style;

			if (label != null)
			{
				var textButtonStyle = (TextButtonStyle) style;
				var labelStyle = label.GetStyle();
				labelStyle.Font = textButtonStyle.Font;
				labelStyle.FontColor = textButtonStyle.FontColor;
				label.SetStyle(labelStyle);
			}
		}


		public new TextButtonStyle GetStyle()
		{
			return style;
		}


		public override void Draw(Batcher batcher, float parentAlpha)
		{
			Color? fontColor = null;
			if (_isDisabled && style.DisabledFontColor.HasValue)
				fontColor = style.DisabledFontColor;
			else if (_mouseDown && style.DownFontColor.HasValue)
				fontColor = style.DownFontColor;
			else if (IsChecked &&
			         (!_mouseOver && style.CheckedFontColor.HasValue ||
			          _mouseOver && style.CheckedOverFontColor.HasValue))
				fontColor = (_mouseOver && style.CheckedOverFontColor.HasValue)
					? style.CheckedOverFontColor
					: style.CheckedFontColor;
			else if (_mouseOver && style.OverFontColor.HasValue)
				fontColor = style.OverFontColor;
			else
				fontColor = style.FontColor;

			if (fontColor != null)
				label.GetStyle().FontColor = fontColor.Value;

			base.Draw(batcher, parentAlpha);
		}


		public Label GetLabel()
		{
			return label;
		}


		public Cell GetLabelCell()
		{
			return GetCell(label);
		}


		public TextButton SetText(String text)
		{
			label.SetText(text);
			return this;
		}


		public string GetText()
		{
			return label.GetText();
		}


		public override string ToString()
		{
			return string.Format("[TextButton] text: {0}", GetText());
		}
	}
}