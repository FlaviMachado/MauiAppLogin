namespace MauiAppLogin;

public partial class Protegida : ContentPage
{
	public Protegida()
	{
		InitializeComponent();

		String? usuario_logado = null;

		Task.Run(async () =>
			{
				usuario_logado = await SecureStorage.Default.GetAsync("usuario_logado");
				lbl_boasVindas.Text = $"Bem Vindo {usuario_logado}";
			});
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		bool confirmação = await DisplayAlert("Tem Certeza", "Sai do App?", "Sim", "Não");

		if (confirmação)
		{
			SecureStorage.Default.Remove("usuario_logado");
			App.Current.MainPage = new Login();
        }
    }
}