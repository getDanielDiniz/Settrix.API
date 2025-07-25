namespace Settrix.Domain.Repositories.Company;

public interface IWriteOnlyCompanyRepository
{
    Task CreateCompany(Entities.Company company);
}