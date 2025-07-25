using Microsoft.EntityFrameworkCore;
using Settrix.Domain.Entities;
using Settrix.Domain.Repositories.Company;
using Settrix.Infraestructure.DataAccess;

namespace Settrix.Infraestructure.Repositories;

public class CompanyRepository : IReadOnlyCompanyRepository, IWriteOnlyCompanyRepository
{
    private readonly SettrixDbContext _context;
    public CompanyRepository(SettrixDbContext context)
    {
        _context = context;   
    }
    
    public async Task<bool> GetByCNPJ(string cnpj)
    {
        return await _context.Companies.AnyAsync(comp => comp.Cnpj == cnpj);;
    }

    public async Task CreateCompany(Company company)
    {
        var comp = await _context.Companies.AddAsync(company);
        await _context.SaveChangesAsync();
    }
}