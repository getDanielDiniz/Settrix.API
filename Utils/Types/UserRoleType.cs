namespace Utils.Types;
public enum UserRoleType
{
    Employee = 0, //Only see your own calls
    WriterEmployee = 1, // Can see all calls of you company and create/update your own call
    Lead = 2, //Can define a responsible for a call and define priority
    Supervisor = 3, //Can create Leads and Employees
    Manager = 4, //Can see sensible information, and create Supervisor
    CompanyOwner = 5, //Can do anything about your own company
    SettrixDeveloper = 6, //Can do anything
}
