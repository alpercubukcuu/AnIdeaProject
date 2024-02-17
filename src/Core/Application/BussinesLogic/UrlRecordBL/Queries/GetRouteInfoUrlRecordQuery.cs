﻿using Application.Dto;
using Application.Interface.ResutRepository;
using MediatR;

namespace Application.BussinesLogic.UrlRecordBL.Queries;

public class GetRouteInfoUrlRecordQuery : IRequest<IResultData<UrlRecordDto>>
{
    public string Route { get; set; }
}

