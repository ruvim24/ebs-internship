using Application.DTOs.Car;
using Domain.Entities;
using FluentResults;
using MediatR;

namespace Application.Contracts.Queries.CarQueries.Get;

public record GetCarQuery(int Id) : IRequest<Result<CarDto>>;