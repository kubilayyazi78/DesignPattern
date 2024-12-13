namespace BuilderPattern.Method2
{
    public interface IEmployeeBuilderM2
    {
        EmployeeM2 BuildEmployee();
        void SetEmailAddress(string emailAddress);
        void SetFullName(string fullName);
        void SetUserName(string userName);
    }
}