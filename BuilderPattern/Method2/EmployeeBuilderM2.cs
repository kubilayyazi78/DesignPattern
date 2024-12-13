namespace BuilderPattern.Method2
{
    public abstract class EmployeeBuilderM2 : IEmployeeBuilderM2
    {
        protected EmployeeM2 Employee { get; set; }

        protected EmployeeBuilderM2()
        {
            Employee = new EmployeeM2();
        }

        public abstract void SetFullName(string fullName);
        public abstract void SetEmailAddress(string emailAddress);
        public abstract void SetUserName(string userName);

        public EmployeeM2 BuildEmployee() => Employee;
    }
}
