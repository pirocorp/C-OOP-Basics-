﻿using P08_MilitaryElite.Solders.SpecialisedSoldiers.Commandos.Enums;

namespace P08_MilitaryElite.Solders.SpecialisedSoldiers.Commandos
{
    public class Mission
    {
        public Mission(string codeName, MissionState missionState)
        {
            this.CodeName = codeName;
            this.MissionState = missionState;
        }

        public string CodeName { get; private set; }
        public MissionState MissionState { get; private set; }

        public void CompleteMission()
        {
            this.MissionState = MissionState.Finished;
        }

        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.MissionState.ToString()}";
        }
    }
}