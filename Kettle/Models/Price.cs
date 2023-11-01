using System.Text.Json.Serialization;

namespace Kettle
{
    public class Price
    {
        [JsonConstructor]
        public Price(string currency, int discountPercent, int final, int initial, string initialFormatted, string finalFormatted) =>
            (Currency, DiscountPercent, Final, Initial, InitialFormatted, FinalFormatted) = (currency, discountPercent, final, initial, initialFormatted, finalFormatted);

        /// <summary>
        /// The currency the price is in, for example "USD".
        /// </summary>
        [JsonPropertyName("currency")]
        public string Currency { get; }

        /// <summary>
        /// The discount amount on the <see cref="Initial"/> price.
        /// </summary>
        [JsonPropertyName("discount_percent")]
        public int DiscountPercent { get; }

        /// <summary>
        /// The final price, after <see cref="DiscountPercent"/> is applied.
        /// </summary>
        [JsonPropertyName("final")]
        public int Final { get; }

        /// <summary>
        /// The starting price before any <see cref="DiscountPercent"/> is applied.
        /// </summary>
        [JsonPropertyName("initial")]
        public int Initial { get; }

        [JsonPropertyName("initial_formatted")]
        public string InitialFormatted { get; }

        [JsonPropertyName("final_formatted")]
        public string FinalFormatted { get; }
    }
}