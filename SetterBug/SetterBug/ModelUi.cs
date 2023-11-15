namespace SetterBug
{
	public sealed class ModelUi : RaisableObject
	{
		private bool _isSomething;
		public bool IsSomething
		{
			get => _isSomething;
			set => SetProperty(ref _isSomething, value);
		}
	}
}