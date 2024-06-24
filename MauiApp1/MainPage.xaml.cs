namespace MauiApp1;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Jueguito());
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        Navigation.PushAsync(new());
    }

    private void Button_Clicked_2(object sender, EventArgs e)
    {
        Navigation.PushAsync(new());
    }

    private void Button_Clicked_3(object sender, EventArgs e)
    {
        Navigation.PushAsync(new());
    }

    private void Button_Clicked_4(object sender, EventArgs e)
    {
        Navigation.PushAsync(new());
    }

    private void Button_Clicked_5(object sender, EventArgs e)
    {
        Navigation.PushAsync(new());
    }
}

