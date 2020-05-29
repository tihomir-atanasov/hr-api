using System;
using AutoMapper;

namespace Demo.HR.Services
{
    public abstract class BaseService
    {
        private readonly IMapper _mapper;

        public BaseService(IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException("AutoMapper DI failed");
        }

        protected IMapper Mapper => _mapper;
    }
}
