namespace MauiApp7
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnEmailTextChanged(object sender, TextChangedEventArgs e)
        {
            var email = e.NewTextValue;
            if (email.Contains("@") && email.Contains("."))
            {
                EmailErrorLabel.IsVisible = false;
            }
            else
            {
                EmailErrorLabel.IsVisible = true;
            }
        }
        private void OnPasswordTextChanged(object sender, TextChangedEventArgs e)
        {
            string password = PasswordEntry.Text;
            if (!string.IsNullOrWhiteSpace(password) && password.Length >= 6)
            {
                PasswordErrorLabel.IsVisible = false;
            }
            else
            {
                PasswordErrorLabel.IsVisible = true;
            }
            if (!EmailErrorLabel.IsVisible  && !PasswordErrorLabel.IsVisible)
            {
                LoginButton.Background = new SolidColorBrush(Color.FromHex("#22B14C"));
            }else
            {
                LoginButton.Background = new SolidColorBrush(Colors.Gray);
            }
        }
        private void OnLoginClicked(object sender, EventArgs e)
        {
            DisplayAlertAsync("Zalogowano", "Zalogowano pomyślnie", "ok");
        }
    }
}
