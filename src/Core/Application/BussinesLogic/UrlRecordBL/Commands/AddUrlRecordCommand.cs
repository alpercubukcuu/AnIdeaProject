using Application.Dto;
using Application.Interface.ResutRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BussinesLogic.UrlRecordBL.Commands
{
    public class AddUrlRecordCommand : UrlRecordDto, IRequest<IResultData<UrlRecordDto>>
    {
    }
}
