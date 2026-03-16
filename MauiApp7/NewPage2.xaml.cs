namespace MauiApp7;

public partial class NewPage2 : ContentPage
{
	public NewPage2()
	{
		InitializeComponent();
	}
	private List<string> ValidateRegistrationForm()

	{

		List<string> errors = new List<string>();



		string email = (FindByName("EmailEntry") as Entry)?.Text ?? string.Empty;
		string password = (FindByName("PasswordEntry") as Entry)?.Text ?? string.Empty;
		string confirmPassword = (FindByName("ConfirmPasswordEntry") as Entry)?.Text ?? string.Empty;
		string ageText = (FindByName("AgeEntry") as Entry)?.Text ?? string.Empty;
		bool termsAccepted = (FindByName("TermsCheckBox") as CheckBox)?.IsChecked ?? false;

		IsPasswordStrong(password, errors);
		IsConfirmPasswordValid(password, confirmPassword, errors);
		IsEmailValid(email, errors);
		IsAgeValid(ageText, errors);
		IsTermsAccepted(termsAccepted, errors);


		// TODO: Implementujcie wszystkie walidacje 

		// Email: nie pusty, zawiera @ i . 

		// Has³o: nie puste, min 8 znaków, cyfra, wielka litera 

		// Potwierdzenie: nie puste, zgadza siê z has³em 

		// Wiek: liczba, miêdzy 13 a 120 

		// Regulamin: musi byæ zaznaczony



		return errors;

	}



	private bool IsPasswordStrong(string password, List<string> errors)
	{
		if (!string.IsNullOrWhiteSpace(password))
		{
			if (password.Length < 8 || !password.Any(char.IsDigit) || !password.Any(char.IsUpper))
			{
				errors.Add("Haslo nie spelnia wymagan!");
				return false;
			}
			return true;
		}
		errors.Add("Haslo nie moze byc puste!");
		return false;
	}

	private bool IsConfirmPasswordValid(string password, string confirmPassword, List<string> errors)
	{
		if (string.IsNullOrWhiteSpace(confirmPassword) || password != confirmPassword)
		{
			errors.Add("Hasla nie sa zgodne!");
			return false;
		}
		return true;
	}

	private bool IsEmailValid(string email, List<string> errors)
	{
		if (string.IsNullOrWhiteSpace(email) || !email.Contains("@") || !email.Contains("."))
		{
			errors.Add("Nieprawidlowy adres email!");
			return false;
		}
		return true;
	}

	private bool IsAgeValid(string ageText, List<string> errors)
	{
		if (!int.TryParse(ageText, out int age) || age < 13 || age > 120)
		{
			errors.Add("Nieprawidlowy wiek! Musi byc liczb miedzy 13 a 120.");
			return false;
		}
		return true;
	}

	private bool IsTermsAccepted(bool termsAccepted, List<string> errors)
	{
		if (!termsAccepted)
		{
			errors.Add("Musisz zaakceptowac regulamin!");
			return false;
		}
		return true;
	}



	private void OnRegisterClicked(object sender, EventArgs e)

	{

		List<string> errors = ValidateRegistrationForm();



		if (errors.Count > 0)

		{

			string errorMessage = string.Join("\n• ", errors);

			DisplayAlert("B³êdy walidacji", "• " + errorMessage, "OK");

		}

		else

		{

			DisplayAlert("Sukces", "Rejestracja zakoñczona pomyœlnie!", "OK");



			// Czyszczenie pól 

			(FindByName("EmailEntry") as Entry).Text = string.Empty;

			(FindByName("PasswordEntry") as Entry).Text = string.Empty;

			(FindByName("ConfirmPasswordEntry") as Entry).Text = string.Empty;

			(FindByName("AgeEntry") as Entry).Text = string.Empty;

			(FindByName("TermsCheckBox") as CheckBox).IsChecked = false;

		}

	}
}