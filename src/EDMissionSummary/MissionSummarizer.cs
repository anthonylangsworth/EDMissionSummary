﻿using EDMissionSummary.JournalEntryProcessors;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EDMissionSummary.SummaryEntries;

namespace EDMissionSummary
{
    public class MissionSummarizer
    {
        public readonly string FactionEffectsSectionName = "FactionEffects";
        private Dictionary<string, JournalEntryProcessor> journalEntryProcessors;

        public MissionSummarizer()
        {
            journalEntryProcessors = new Dictionary<string, JournalEntryProcessor>
            {
                {  MissionAcceptedEventProcessor.EventName, new MissionAcceptedEventProcessor() },
                {  MissionCompletedEventProcessor.EventName, new MissionCompletedEventProcessor() },
                {  RedeemVoucherEventProcessor.EventName, new RedeemVoucherEventProcessor() }
            };
        }

        public IEnumerable<SummaryEntry> Convert(PilotState pilotState, GalaxyState galaxyState, string supportedFaction, JObject entry)
        {
            if (pilotState is null)
            {
                throw new ArgumentNullException(nameof(pilotState));
            }
            if (supportedFaction is null)
            {
                throw new ArgumentNullException(nameof(supportedFaction));
            }
            if (entry == null)
            {
                throw new NullReferenceException(nameof(entry));
            }

            IEnumerable<SummaryEntry> result = Enumerable.Empty<SummaryEntry>();
            if (journalEntryProcessors.TryGetValue(entry.Value<string>("event"), out JournalEntryProcessor journalEntryProcessor))
            {
                result = journalEntryProcessor.Process(pilotState, galaxyState, supportedFaction, entry);
            }
            return result;
        }
    }
}