using Newtonsoft.Json;
using RoboArena.Part;
using System;
using System.Collections.Generic;
using System.IO;

namespace RoboArena
{
    public class DataManager
    {
        private static string JsonPath = @"Data/Data.json";

        public static RobotData GetRobotData(string id)
        {
            dynamic data = JsonConvert.DeserializeObject(File.ReadAllText(JsonPath));
            dynamic robotData = data.RobotData[id];

            var slots = new Dictionary<RobotPartSlot, RobotPart>();
            foreach (RobotPartSlot slot in Enum.GetValues(typeof(RobotPartSlot)))
            {
                dynamic part = robotData.Slots[slot.ToString()];
                if(part != null)
                {
                    slots.Add(slot, GetRobotPart(part.ToString()));
                }
            }

            return new RobotData
            {
                Id = id,
                BaseStats = robotData.Stats.ToObject<Dictionary<RobotStat, int>>(),
                Slots = slots
            };
        }

        public static RobotPart GetRobotPart(string id)
        {
            dynamic data = JsonConvert.DeserializeObject(File.ReadAllText(JsonPath));
            dynamic partData = data.PartData[id];

            Type actionType = Type.GetType(String.Format("RoboArena.{0},{1}", partData.Action.Id.ToString(), "RoboArena"));
            Dictionary<string, int> actionArguments = partData.Action.Arguments.ToObject<Dictionary<string, int>>();
            Dictionary<RobotStat, int> stats = partData.Stats.ToObject<Dictionary<RobotStat, int>>();
            return new RobotPart
            {
                Id = id,
                ActionType = actionType,
                ActionArguments = actionArguments,
                Stats = stats
            };
        }
    }

    public class RobotData
    {
        public string Id { get; set; }
        public Dictionary<RobotPartSlot, RobotPart> Slots { get; set; }
        public Dictionary<RobotStat, int> BaseStats { get; set; }
        public IList<RobotAction> Actions { get; set; }
    }
}
