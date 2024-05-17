using Application.BussinesLogic.UrlRecordBL.Commands;
using Application.Dto;
using Application.Interface.Repositories;
using Application.Interface.ResutRepository;
using AutoMapper;
using Domain.Entities;
using MediatR;


namespace Application.BussinesLogic.UrlRecordBL.Handler
{
    public class AddUrlRecordHandler : IRequestHandler<AddUrlRecordCommand, IResultData<UrlRecordDto>>
    {
        private readonly IUrlRecordRepository _urlRecordRepository;
        private readonly IMapper _mapper;

        public AddUrlRecordHandler(IUrlRecordRepository urlRecordRepository, IMapper mapper)
        {
            _urlRecordRepository = urlRecordRepository;
            _mapper = mapper;
        }

        public async Task<IResultData<UrlRecordDto>> Handle(AddUrlRecordCommand request, CancellationToken cancellationToken)
        {
            IResultData<UrlRecordDto> result = new ResultData<UrlRecordDto>();

            try
            {
                var map = _mapper.Map<UrlRecord>(request);

                if (request.Id == default || request.Id == Guid.Empty)
                    map.Id = Guid.NewGuid();

                var addResult = await _urlRecordRepository.AddAsync(map);
                var resultMap = _mapper.Map<UrlRecordDto>(addResult);
                result.SetData(resultMap);
                result.Message = "Addition Successful!";
                result.IsSuccess = true;
              
            }
            catch (Exception exception) { result.Message = exception.Message; result.IsSuccess = false; }

            return result;
        }
    }
}
