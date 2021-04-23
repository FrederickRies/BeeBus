# BeeBus

BeeBus is a .NET in-memory message processing library based on a pipeline approach.
The goal of the project is to avoid the noise in a message handler himself and decorate the handling with specialized middlewares like logging, auditing, transactions, ...


## Performances

|                     Method |     Mean |   Error |  StdDev |
|--------------------------- |---------:|--------:|--------:|
|             SimpleHandling | 336.8 ns | 5.35 ns | 4.47 ns |
| SimpleHandlingWithResponse | 387.5 ns | 3.55 ns | 3.32 ns |
