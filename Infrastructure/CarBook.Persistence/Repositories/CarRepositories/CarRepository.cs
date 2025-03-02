using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CarRepositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CarBookContext _context;

        public CarRepository(CarBookContext context)
        {
            _context = context;
        }

        // CarRepository metodunu List<Car> qaytaracaq şəkildə dəyişirik
        public async Task<List<Car>> GetCarsListWithBrands()
        {
            var values = await _context.Cars
                .Include(x => x.Brand)  // Brand əlaqəsini daxil edirik
                .ToListAsync();  // Nəticə asinxron qaytarılır

            return values;  // Car obyektləri qaytarılır
        }
    }
}
