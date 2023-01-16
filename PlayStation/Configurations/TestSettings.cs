namespace PlayStation.Configurations
{
    public class TestSettings
    {
        public static string Browser => TestContext.Parameters[nameof(Browser)];
        public static string IsHeadlessMode => TestContext.Parameters[nameof(IsHeadlessMode)];
        public static double Timeout => Convert.ToDouble(TestContext.Parameters[nameof(Timeout)]);
        public static double PollingInterval => Convert.ToDouble(TestContext.Parameters[nameof(PollingInterval)]);
    }
}