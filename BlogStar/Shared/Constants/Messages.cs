namespace BlogStar.Shared.Constants
{
    public static class Messages
    {
        public static string Success(string entity, string operation) => $"{entity} {operation} successfully.";

        public static string NotFound(string entity) => $"{entity} not found.";

        public static string DataFound => "Data found.";

        public static string NoDataFound => "No data found.";

        public static string IssueWithData => "There is some issue with the data, please check.";

        public static string CheckCredentials => "Please check login credentials.";

        public static string UserNameOrPasswordIsIncorrect => "Username or password is incorrect.";

        public static string PasswordDontMatchWithConfirmation => "Password doesn't match its confirmation.";

        public static string IsRequired(string field) => $"{field} is required.";

        public static string AlreadyExists(string content) => $"{content} already exists.";

        public static string MaxCharLimit(string field, int limit) => $"{field} is exceeding the limit of {limit} characters.";
    }
}
