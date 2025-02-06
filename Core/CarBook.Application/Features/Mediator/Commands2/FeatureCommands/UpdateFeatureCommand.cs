﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands2.FeatureCommands
{
    public class UpdateFeatureCommand : IRequest
    {
        public int ID { get; set; }
        public string? Name { get; set; }
    }
}
