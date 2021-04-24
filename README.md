# BeeBus

BeeBus is a .NET in-memory message processing library based on a pipeline approach.
The goal of the project is to avoid the noise in a message handler himself and decorate the handling with specialized middlewares like logging, auditing, transactions, ...


## Performances
### BeeBus
|                     Method |     Mean |   Error |  StdDev |
|--------------------------- |---------:|--------:|--------:|
|             SimpleHandling | 336.8 ns | 5.35 ns | 4.47 ns |
| SimpleHandlingWithResponse | 387.5 ns | 3.55 ns | 3.32 ns |

### MediatR
|                     Method |     Mean |     Error |    StdDev |
|--------------------------- |---------:|----------:|----------:|
|             SimpleHandling | 1.115 us | 0.0183 us | 0.0171 us |
| SimpleHandlingWithResponse | 1.180 us | 0.0172 us | 0.0152 us |
