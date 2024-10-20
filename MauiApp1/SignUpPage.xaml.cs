namespace MauiApp1;

public partial class SignUpPage : ContentPage
{
	public SignUpPage()
	{
		InitializeComponent();
		BindingContext = this;
	}

	public User User { get; set; } = new User();
    private async void SignUpClick(object sender, EventArgs e)
    {
		if (await DbNoEntity.Instance.CheckUserIsNotInDB(User.Login))
			DbNoEntity.Instance.AddUser(User);
		else
			DisplayAlert("Error", "User already exists in DB", "OK");
    }
}