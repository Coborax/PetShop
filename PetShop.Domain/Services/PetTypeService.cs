using System.Collections.Generic;
using PetShop.Core.Models;
using PetShop.Core.Services;

namespace PetShop.Domain.Services
{
    public class PetTypeService : IPetTypeService
    {
        private IUnitOfWork _unitOfWork;

        public PetTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public PetType Find(int id)
        {
            return _unitOfWork.PetTypes.Find(id);
        }

        public List<PetType> GetAll()
        {
            return _unitOfWork.PetTypes.GetAll();
        }

        public PetType Create(PetType petType)
        {
            return _unitOfWork.PetTypes.Create(petType);
        }
    }
}