using ppedv.KurvenkönigsKarren.Model.DomainModel;

namespace ppedv.KurvenkönigsKarren.Model.Contracts
{
    public interface ICarService
    {
        bool IsCarAvailable(Car car, DateTime day);
    }
}