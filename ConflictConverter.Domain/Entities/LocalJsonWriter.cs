using ConflictConverter.Domain.Abstractions;
using ConflictConverter.Domain.Schemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConflictConverter.Domain.Entities
{
    public class LocalJsonWriter : IJsonWriter
    {
        public LocalJsonWriter() { }

        public void OutputData(IConflict[] conflicts) 
        {
            //Превращаем полученный массив в массив объектов DTO
            ConflictSchema[] conflictsDto = new ConflictSchema[conflicts.Length];
            for (int  i = 0;  i < conflicts.Length;  i++)
            {
                conflictsDto[i] = new ConflictSchema(conflicts[i]);
            }
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(conflictsDto);
            
            //Узнаём путь к файлу для заполнения json-файла
            Console.WriteLine("Введите путь к файлу, в который запишутся данные:");
            string path = Console.ReadLine();

            if (File.Exists(path))
            {
                File.WriteAllText(path, json);
            }
            else
            {
                FileStream fs = File.Create(path);
                fs.Close();
                File.WriteAllText(path, json);
            }
        }
    }
}
