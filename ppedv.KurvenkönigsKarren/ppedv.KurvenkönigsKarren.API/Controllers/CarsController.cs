using Microsoft.AspNetCore.Mvc;
using ppedv.KurvenkönigsKarren.API.Model;
using ppedv.KurvenkönigsKarren.Model.Contracts;
using ppedv.KurvenkönigsKarren.Model.DomainModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ppedv.KurvenkönigsKarren.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly IUnitOfWork uow;

        public CarsController(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        // GET: api/<CarsController>
        [HttpGet]
        public IEnumerable<CarDTO> Get()
        {
            return uow.CarRepository.Query().ToList().Select(x => CarMapper.MapToCarDTO(x));
        }

        // GET api/<CarsController>/5
        [HttpGet("{id}")]
        public CarDTO Get(int id)
        {
            return CarMapper.MapToCarDTO(uow.CarRepository.GetById(id));
        }

        // POST api/<CarsController>
        [HttpPost]
        public void Post([FromBody] CarDTO car)
        {
            uow.CarRepository.Add(CarMapper.MapToCar(car));
            uow.SaveAll();
        }

        // PUT api/<CarsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CarDTO car)
        {
            uow.CarRepository.Update(CarMapper.MapToCar(car));
            uow.SaveAll();
        }

        // DELETE api/<CarsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            uow.CarRepository.Delete(uow.CarRepository.GetById(id));
            uow.SaveAll();
        }
    }
}
