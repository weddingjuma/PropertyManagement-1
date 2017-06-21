using System;
using PropertyManagement.Components;
using PropertyManagement.Models;
using PropertyManagement.Renderers;
using Xamarin.Forms;


namespace PropertyManagement.Cells
{
	public class PaymentHistoryCell : ViewCell
	{
		private Label DisplayTextLabel { get; set; }

public PaymentHistoryCell()
{
	
	DisplayTextLabel = new Label
	{
		BackgroundColor = Color.Transparent,
		FontFamily = ApplicationSettings.RegularFontFamily,
		FontSize = 15,
		TextColor = Color.FromHex("282830")
	};

	var textLayout = new StackLayout
	{
		Children = { DisplayTextLabel },
		HorizontalOptions = LayoutOptions.FillAndExpand,
		VerticalOptions = LayoutOptions.Center,
		Spacing = 0,
		Padding = 0
	};

	var payLabel = new Label
	{
		HorizontalOptions = LayoutOptions.End,
		BackgroundColor = Color.Transparent,
		FontFamily = ApplicationSettings.ThinFontFamily,
		FontSize = 20,
		TextColor = Color.FromHex("282830"),
		Text = "Pay >"
	};

	var frame = new ExtendedFrame
	{
		Content = new StackLayout
		{
			Children = { textLayout, payLabel },
			Orientation = StackOrientation.Horizontal,
			Spacing = 15
		},
		OutlineColor = Color.White,
		ActualBackgroundColor = Color.White,
		HasShadow = false,
		CornerRadius = 3,
		BorderWidth = 0,
		VerticalOptions = LayoutOptions.FillAndExpand,
		Padding = 20
	};

	View = new StackLayout
	{
		Children = { frame, new BoxView { HeightRequest = 0, WidthRequest = 0 } },
		Spacing = 10,
		Padding = new Thickness(0, 1)
	};
}

protected override void OnBindingContextChanged()
{
	base.OnBindingContextChanged();

	var item = BindingContext as PaymentHistoryModel;
	if (item != null)
	{
		DisplayTextLabel.Text = item.DisplayText;
	}
}
	}
}