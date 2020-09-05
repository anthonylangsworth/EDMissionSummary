﻿using EDMinorFactionSupport.SummaryEntries;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDMinorFactionSupport.JournalEntryProcessors
{
    public class MissionAcceptedEntryProcessor : JournalEntryProcessor
    {
        public override string EventName => "MissionAccepted";

        /// <summary>
        /// Track the mission in the <see cref="PilotState"/> because some mission relevant details are only
        /// available in this journal entry.
        /// </summary>
        /// <param name="pilotState">
        /// A <see cref="PilotState"/> representing data associated with the pilot, such as the current station or system.
        /// </param>
        /// <param name="galaxyState">
        /// A <see cref="GalaxyState"/> reoresenting the Elite: Dangerous universe the pilot plays in.
        /// </param>
        /// <param name="supportedMinorFaction">
        /// The supported minor faction name. This must <b>exactly</b> match the name in the journal.
        /// </param>
        /// <param name="entry">
        /// A <see cref="JObject"/> representing the journal entry.
        /// </param>
        /// <returns>
        /// Will never return <see cref="SummaryEntry"/> objects.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// No argument can be null.
        /// </exception>
        public override IEnumerable<SummaryEntry> Process(PilotState pilotState, GalaxyState galaxyState, string supportedMinorFaction, JObject entry)
        {
            if (pilotState is null)
            {
                throw new ArgumentNullException(nameof(pilotState));
            }
            if (galaxyState is null)
            {
                throw new ArgumentNullException(nameof(galaxyState));
            }
            if (supportedMinorFaction is null)
            {
                throw new ArgumentNullException(nameof(supportedMinorFaction));
            }
            if (entry is null)
            {
                throw new ArgumentNullException(nameof(entry));
            }

            pilotState.Missions.Add(
                entry.Value<long>("MissionID"),
                new Mission(
                    entry.Value<long>("MissionID"),
                    entry.Value<string>("LocalisedName"),
                    entry.Value<string>("Influence"))
                );

            return Enumerable.Empty<SummaryEntry>();
        }
    }
}
