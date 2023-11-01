using Kettle.Internal;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Kettle
{
    [JsonConverter(typeof(PackageGroupJsonConverter))]
    public class PackageGroup
    {
        internal PackageGroup()
        {
        }

        [JsonConstructor]
        public PackageGroup(string description, string isRecurringSubscription, string name, string savetext, string selectionText, int displayType, IReadOnlyList<Sub> subs, string title) =>
            (Description, IsRecurringSubscription, Name, SaveText, SelectionText, DisplayType, Subs, Title) = (description, isRecurringSubscription, name, savetext, selectionText, displayType, subs, title);

        [JsonPropertyName("description")]
        public string Description { get; internal set; }

        [JsonPropertyName("is_recurring_subscription")]
        public string IsRecurringSubscription { get; internal set; }

        [JsonPropertyName("name")]
        public string Name { get; internal set; }

        [JsonPropertyName("save_text")]
        public string SaveText { get; internal set; }

        [JsonPropertyName("selection_text")]
        public string SelectionText { get; internal set; }

        [JsonPropertyName("display_type")]
        public int DisplayType { get; internal set; }

        [JsonPropertyName("subs")]
        public IReadOnlyList<Sub> Subs { get; internal set; }

        [JsonPropertyName("title")]
        public string Title { get; internal set; }
    }
}