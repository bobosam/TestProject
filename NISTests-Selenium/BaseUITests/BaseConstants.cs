namespace BaseUITests
{
    public class BaseConstants
    {
        public const string UsersXlsxFilename = @"Users.xlsx";
        public const string TestCRMUrl = "http://dev3:8990";
        public const string TestAdminPanelUrl = "http://dev3:8995";
        public const string CRMHomePageUrl = "http://dev3:8990/#/about";
        public static readonly string[] wrongNames = new string[] { "123", "asdf", "~!@#$%^&*", "ффф ююю" };
        public static readonly string[] wrongIdCardNumber = new string[] { "12345678", "0123456789", "12A456789", "1234.6789" };
    }
}
