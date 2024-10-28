using Application.DTOs.Car;
using FluentResults;
using MediatR;

namespace Application.Contracts.Queries.CarQueries.GetByVin;

public record GetCarByVinQuery(string Vin) : IRequest<Result<CarDto>>;