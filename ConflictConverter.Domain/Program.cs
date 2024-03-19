using ConflictConverter.Domain.Abstractions;
using ConflictConverter.Domain.Entities;
using ConflictConverter.Domain.Enums;
using ConflictConverter.Domain.Services;

ReadService readService = new ReadService();
ConvertService convertService = new ConvertService();
OutputService outputService = new OutputService();

IReader reader = readService.GetReader(TypesToReadEnum.FromLocalJson);
var data = reader.Read();

var convertData = convertService.Convert(data);

IWriter writer = outputService.GetWriter(TypesToWriteEnum.ToLocalJson);
writer.OutputData(convertData);



Console.ReadKey();