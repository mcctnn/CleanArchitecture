using CleanArchitecture.Domain.Employees;
using MediatR;
using TS.Result;

namespace CleanArchitecture.Application.Employees;

public sealed record EmployeeGetQuery(
    Guid Id):IRequest<Result<Employee>>;

internal sealed class EmployeeGetQueryHandler(
    IEmployeeRepository repository) : IRequestHandler<EmployeeGetQuery, Result<Employee>>
{
    public async Task<Result<Employee>> Handle(EmployeeGetQuery request, CancellationToken cancellationToken)
    {
        var employee = await repository.FirstOrDefaultAsync(p => p.Id == request.Id,cancellationToken);

        if (employee is null)
            return Result<Employee>.Failure("Personel bulunamadı");

        return employee;
    }
}
