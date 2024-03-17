namespace BlazorComponent.Pages.CodeSeperation
{
    public partial class Hello
    {
        public string msg = string.Empty;
        private void SayHello()
        {
            msg = "Hello Blazor";
        }
    }
}
