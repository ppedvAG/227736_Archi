using ppedv.KurvenkönigsKarren.Model.DomainModel;

namespace ppedv.KurvenkönigsKarren.API.Model
{
    public static class CarMapper
    {
        public static Car MapToCar(CarDTO dto)
        {
            return new Car
            {
                Id = dto.Id,
                Model = dto.Model,
                KW = dto.KW,
                Color = dto.Color,
                Transmission = MapToTransmission(dto.Transmission)
            };
        }

        public static CarDTO MapToCarDTO(Car car)
        {
            return new CarDTO
            {
                Id = car.Id,
                Model = car.Model,
                KW = car.KW,
                Manufacturer = car.Manufacturer?.Name ?? string.Empty,
                Color = car.Color,
                Transmission = MapToTransmissionString(car.Transmission)
            };
        }

        private static Transmission MapToTransmission(string transmission)
        {
            if (transmission == "Automatic")
            {
                return Transmission.Automatic;
            }
            else if (transmission == "Manual")
            {
                return Transmission.Manual;
            }
            else
            {
                return Transmission.Semi;
            }
        }

        private static string MapToTransmissionString(Transmission transmission)
        {
            switch (transmission)
            {
                case Transmission.Automatic:
                    return "Automatic";
                case Transmission.Manual:
                    return "Manual";
                default:
                    return string.Empty;
            }
        }
    }
}
