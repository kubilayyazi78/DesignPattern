using BuilderPattern.Method1;
using BuilderPattern.Method2;
var eb = new EndpointBuilder("https://localhost");
eb.Append("api").Append("v1").Append("user").AppendParam("id", "5");
var url = eb.Build();
var empBuilder = new EmployeeBuilderM1();
var emp=empBuilder.SetFullName("kubilay yazi").SetUserName("kubilayyazi78").BuildEmployee();
IEmployeeBuilderM2 employeeBuilderM2 = new InternalEmployeeBuilder();
employeeBuilderM2.SetEmailAddress("kubilayyazi@hotmail.com");
employeeBuilderM2.SetFullName("kubilay yazı");
var emp2 = employeeBuilderM2.BuildEmployee();
EmployeeM2 GenerateEmployee(string fullName,string emailAddress,int empType)
{
    IEmployeeBuilderM2 employeeBuilder;
    if (empType==0)
    {
        employeeBuilder = new InternalEmployeeBuilder();
    }
    else
    {
        employeeBuilder = new ExternalEmployeeBuilder();
    }
    employeeBuilder.SetFullName(fullName);
    employeeBuilder.SetEmailAddress(emailAddress);

    return employeeBuilder.BuildEmployee();
}
var emp3 = GenerateEmployee("kubilay yazi", "kubilayyazi@hotmail.com", 0);

Console.ReadLine();