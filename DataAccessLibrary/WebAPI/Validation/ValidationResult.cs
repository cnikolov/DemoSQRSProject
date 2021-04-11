namespace WebAPI.Validation
{
    public record ValidationResult
    {
        public bool IsSuccessful { get; set; } = true;
        public string Error { get; set; }
        public static ValidationResult Success => new();
        public static ValidationResult Fail(string error) => new() {IsSuccessful = false, Error = error};
    }
}
