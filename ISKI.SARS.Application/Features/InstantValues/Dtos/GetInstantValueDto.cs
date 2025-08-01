using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISKI.SARS.Application.Features.InstantValues.Dtos;

public class GetInstantValueDto
{
    public DateTime Timestamp { get; set; }
    public int ArchiveTagId { get; set; }
    public string Value { get; set; }
    public bool Status { get; set; }
}
