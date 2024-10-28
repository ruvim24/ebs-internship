using Application.DTOs.Car;
using FluentResults;
using MediatR;

namespace Application.Contracts.Queries.CarQueries.GetByCustomerId;

public record GetCarByCustomerIdQuery(int Id) : IRequest<Result<IEnumerable<CarDto>>>;