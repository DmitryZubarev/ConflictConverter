using ConflictConverter.Domain.Entities;
using ConflictConverter.Domain.Enums;
using ConflictConverter.Domain.Services;

ReadService readService = new ReadService();
ConvertService convertService = new ConvertService();
OutputService outputService = new OutputService();

var data = readService.ReadData(TypesToReadEnum.FromLocalJson);
var convertData = convertService.Convert(data);

outputService.OutputData(convertData, TypesToWriteEnum.ToLocalJson);




Console.ReadKey();