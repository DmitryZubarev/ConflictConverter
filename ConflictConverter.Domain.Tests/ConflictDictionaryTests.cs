using ConflictConverter.Domain.Abstractions;
using ConflictConverter.Domain.Entities;
using ConflictConverter.Domain.schemas;

namespace ConflictConverter.Domain.Tests
{
    [TestClass]
    public class ConflictDictionaryTests
    {
        [TestMethod]
        public void DeleteWithoutOnline_Deleted()
        {
            //arrange
            List<IDevice> devices1 = new List<IDevice>();
            devices1.Add(new Device("device1", true));
            devices1.Add(new Device("device2", false));

            List<IDevice> devices2 = new List<IDevice>();
            devices2.Add(new Device("device1", false));
            devices2.Add(new Device("device2", false));

            List<IDevice> devices3 = new List<IDevice>();
            devices3.Add(new Device("device1", false));
            devices3.Add(new Device("device2", false));
            devices3.Add(new Device("device3", false));

            Dictionary<IBrigade, List<IDevice>> conflictsSet = new Dictionary<IBrigade, List<IDevice>>()
            {
                { new Brigade("brigade1"), devices1 },
                { new Brigade("brigade2"), devices2 },
                { new Brigade("brigade3"), devices3 },
            };

            ConflictDictionary conflictDictionary = new ConflictDictionary(conflictsSet);

            //act
            conflictDictionary.DeleteWithoutOnline();

            //assert
            Assert.AreEqual(conflictDictionary.ConflictDict.Count, 1);
        }


        [TestMethod]
        public void ClearByLength_Deleted()
        {
            //arrange
            List<IDevice> devices1 = new List<IDevice>();
            devices1.Add(new Device("device1", true));
            devices1.Add(new Device("device2", false));

            List<IDevice> devices2 = new List<IDevice>();
            devices2.Add(new Device("device1", false));
            devices2.Add(new Device("device2", false));

            List<IDevice> devices3 = new List<IDevice>();
            devices3.Add(new Device("device1", false));
            devices3.Add(new Device("device2", false));
            devices3.Add(new Device("device3", false));

            Dictionary<IBrigade, List<IDevice>> conflictsSet = new Dictionary<IBrigade, List<IDevice>>()
            {
                { new Brigade("brigade1"), devices1 },
                { new Brigade("brigade2"), devices2 },
                { new Brigade("brigade3"), devices3 },
            };

            ConflictDictionary conflictDictionary = new ConflictDictionary(conflictsSet);

            //act
            conflictDictionary.ClearByLength(3);

            //assert
            Assert.AreEqual(conflictDictionary.ConflictDict.Count, 1);
        }


        [TestMethod]
        public void ToArray_IConflictArray()
        {
            //arrange
            List<IDevice> devices1 = new List<IDevice>();
            devices1.Add(new Device("device1", true));
            devices1.Add(new Device("device2", false));

            List<IDevice> devices2 = new List<IDevice>();
            devices2.Add(new Device("device1", false));
            devices2.Add(new Device("device2", false));

            List<IDevice> devices3 = new List<IDevice>();
            devices3.Add(new Device("device1", false));
            devices3.Add(new Device("device2", false));
            devices3.Add(new Device("device3", false));

            Dictionary<IBrigade, List<IDevice>> conflictsSet = new Dictionary<IBrigade, List<IDevice>>()
            {
                { new Brigade("brigade1"), devices1 },
                { new Brigade("brigade2"), devices2 },
                { new Brigade("brigade3"), devices3 },
            };

            ConflictDictionary conflictDictionary = new ConflictDictionary(conflictsSet);

            //act
            var array = conflictDictionary.ToArray() as Conflict[];

            bool actual = true;
            int i = 0;
            foreach (var pair in conflictDictionary.ConflictDict)
            {
                if (pair.Key.Code == array[i].Brigade.Code)
                {
                    int j = 0;
                    foreach (var device in pair.Value)
                    {
                        if (!(device.SerialNumber == array[i].Devices[j].SerialNumber)) actual = false;
                        j++;
                    }
                }
                else actual = false;
                i++;
            }
            //assert
            bool expected = true;
            
            Assert.AreEqual(expected, actual);
        }
    }
}