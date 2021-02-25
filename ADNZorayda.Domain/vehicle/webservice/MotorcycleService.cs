using System;
using ADNZorayda.Domain.vehicle.entity;
using ADNZorayda.Domain.vehicle.repository;

namespace ADNZorayda.Domain.vehicle.webservice
{
    public class MotorcycleService
    {
        MotorcycleRepository repository;
        public MotorcycleService(MotorcycleService motorcycleRepository)
        {
        }

        // Guardar por primera vez una moto
        public void saveMotorcycle(Motorcycle motorcycle)
        {
            //repository.insertMotorcycle(motorcycle)
        }
    }
}
