using ConflictConverter.Domain.Abstractions;
using ConflictConverter.Domain.Enums;
using ConflictConverter.Domain.Services;
using System.Data;

ReadService readService = new ReadService();
ConvertService convertService  = new ConvertService();
OutputService outputService  = new OutputService();

IReader reader = readService.GetReader(TypesToReadEnum.FromLocalJson);
IWriter writer = outputService.GetWriter(TypesToWriteEnum.ToLocalJson);

var data = reader.Read();
var convertedData = convertService.Convert(data);
writer.OutputData(convertedData);

Console.ReadKey();