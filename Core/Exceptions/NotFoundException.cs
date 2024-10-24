using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Exceptions;

public sealed class NotFoundException(string message): Exception(message);
