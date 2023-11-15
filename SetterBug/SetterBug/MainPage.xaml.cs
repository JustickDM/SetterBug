using System.Windows.Input;

using Xamarin.Forms;

namespace SetterBug
{
	public partial class MainPage : ContentPage
	{
		public ModelUi Model { get; set; } = new ModelUi();

		public ICommand Command { get; set; }

		public MainPage()
		{
			Command = new Command(() => Model.IsSomething = !Model.IsSomething);

			InitializeComponent();

			BindingContext = this;
		}
	}
}