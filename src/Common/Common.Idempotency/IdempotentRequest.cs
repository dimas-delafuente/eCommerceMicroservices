using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Idempotency;

internal sealed class IdempotentRequest
{
    public Guid Id  { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime CreatedOnUtc { get; set; }
}
