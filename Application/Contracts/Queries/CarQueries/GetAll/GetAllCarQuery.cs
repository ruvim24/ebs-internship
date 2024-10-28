using Application.DTOs.Car;
using FluentResults;
using MediatR;

namespace Application.Contracts.Queries.CarQueries.GetAll;

public record GetAllCarQuery() : IRequest<Result<IEnumerable<CarDto>>>;