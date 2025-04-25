using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISKI.SARS.Application.Features.Tags.Dtos;

public class CreateTagDto
{
    public string DisplayName { get; set; } = string.Empty;
    public string OpcPath { get; set; } = string.Empty;
    public int PullInterval { get; set; }
}
