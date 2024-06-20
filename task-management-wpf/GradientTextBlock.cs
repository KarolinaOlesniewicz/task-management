using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace task_management_wpf
{
	public class GradientTextBlock : Control
	{
		public static readonly DependencyProperty TextProperty =
			DependencyProperty.Register(nameof(Text), typeof(string), typeof(GradientTextBlock),
				new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.AffectsRender));

		public static readonly DependencyProperty FontSizeProperty =
			DependencyProperty.Register(nameof(FontSize), typeof(double), typeof(GradientTextBlock),
				new FrameworkPropertyMetadata(12.0, FrameworkPropertyMetadataOptions.AffectsRender));

		public static readonly DependencyProperty GradientStartColorProperty =
			DependencyProperty.Register(nameof(GradientStartColor), typeof(Color), typeof(GradientTextBlock),
				new FrameworkPropertyMetadata(Colors.Black, FrameworkPropertyMetadataOptions.AffectsRender));

		public static readonly DependencyProperty GradientEndColorProperty =
			DependencyProperty.Register(nameof(GradientEndColor), typeof(Color), typeof(GradientTextBlock),
				new FrameworkPropertyMetadata(Colors.Black, FrameworkPropertyMetadataOptions.AffectsRender));

		public string Text
		{
			get { return (string)GetValue(TextProperty); }
			set { SetValue(TextProperty, value); }
		}

		public double FontSize
		{
			get { return (double)GetValue(FontSizeProperty); }
			set { SetValue(FontSizeProperty, value); }
		}

		public Color GradientStartColor
		{
			get { return (Color)GetValue(GradientStartColorProperty); }
			set { SetValue(GradientStartColorProperty, value); }
		}

		public Color GradientEndColor
		{
			get { return (Color)GetValue(GradientEndColorProperty); }
			set { SetValue(GradientEndColorProperty, value); }
		}

		protected override void OnRender(DrawingContext drawingContext)
		{
			base.OnRender(drawingContext);

			if (string.IsNullOrEmpty(Text)) return;

			Typeface typeface = new Typeface(FontFamily, FontStyle, FontWeight, FontStretch);
			FormattedText formattedText = new FormattedText(
				Text,
				System.Globalization.CultureInfo.CurrentUICulture,
				FlowDirection.LeftToRight,
				typeface,
				FontSize,
				Brushes.Black,
				new NumberSubstitution(),
				TextFormattingMode.Display);

			LinearGradientBrush gradientBrush = new LinearGradientBrush(
				GradientStartColor, GradientEndColor, new Point(0, 0), new Point(1, 0));

			drawingContext.DrawText(formattedText, new Point(0, 0));
			drawingContext.DrawGeometry(gradientBrush, null, formattedText.BuildGeometry(new Point(0, 0)));
		}
	}
}
