namespace Settrix.Domain.Repositories.Company;

public interface IReadOnlyCompanyRepository
{
    Task<bool> GetByCNPJ(string cnpj);
}