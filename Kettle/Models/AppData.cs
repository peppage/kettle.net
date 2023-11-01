using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Kettle
{
    /// <summary>
    /// Details about an App
    /// </summary>
    public class AppData
    {
        /// <summary>
        /// App type, ex "game"
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; internal set; } = string.Empty;

        /// <summary>
        /// Name of the app
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; internal set; } = string.Empty;

        /// <summary>
        /// Id of the app
        /// </summary>
        [JsonPropertyName("steam_appid")]
        public uint AppId { get; internal set; }

        /// <summary>
        /// If the app is free
        /// </summary>
        [JsonPropertyName("is__free")]
        public bool IsFree { get; internal set; }

        /// <summary>
        /// The age to view the app page.
        /// </summary>
        [JsonPropertyName("required_age")]
        public string RequiredAge { get; internal set; } = string.Empty;

        /// <summary>
        /// How supported the controller is, ex "full"
        /// </summary>
        [JsonPropertyName("controller_support")]
        public string ControllerSupport { get; internal set; } = string.Empty;

        /// <summary>
        /// List of DLC App IDs for this app
        /// </summary>
        [JsonPropertyName("dlc")]
        public IReadOnlyList<uint>? Dlc { get; internal set; }

        /// <summary>
        /// Text on app store page, in main area
        /// </summary>
        [JsonPropertyName("detailed_description")]
        public string DetailedDescription { get; internal set; } = string.Empty;

        /// <summary>
        /// Text on app store page, in main area
        /// </summary>
        [JsonPropertyName("about_the_game")]
        public string AboutTheGame { get; internal set; } = string.Empty;

        /// <summary>
        /// Text in sidebar below header image
        /// </summary>
        [JsonPropertyName("short_description")]
        public string ShortDescription { get; internal set; } = string.Empty;

        /// <summary>
        /// Text describing which languages are available
        /// </summary>
        [JsonPropertyName("supported_languages")]
        public string SupportedLanguages { get; internal set; } = string.Empty;

        /// <summary>
        /// Text describing review scores/quotes for app. Optional
        /// </summary>
        [JsonPropertyName("reviews")]
        public string Reviews { get; internal set; } = string.Empty;

        /// <summary>
        /// Url to image in sidebar on app page
        /// </summary>
        [JsonPropertyName("header_image")]
        public string HeaderImage { get; internal set; } = string.Empty;

        /// <summary>
        /// Url to app external website
        /// </summary>
        [JsonPropertyName("website")]
        public string Website { get; internal set; } = string.Empty;

        /// <summary>
        /// Specifications to run app on PC
        /// </summary>
        [JsonPropertyName("pc_requirements")]
        public Requirements? PCRequirements { get; internal set; }

        /// <summary>
        /// Specifications to run app on Apple
        /// </summary>
        [JsonPropertyName("mac_requirements")]
        public Requirements? MacRequirements { get; internal set; }

        /// <summary>
        /// Specifications to run app on Linux
        /// </summary>
        [JsonPropertyName("linux_requirements")]
        public Requirements? LinuxRequirements { get; internal set; }

        /// <summary>
        /// Text under system requirements
        /// </summary>
        [JsonPropertyName("legal_notice")]
        public string LegalNotice { get; internal set; } = string.Empty;

        /// <summary>
        /// Company/people/person who created the app
        /// </summary>
        [JsonPropertyName("developers")]
        public IReadOnlyList<string>? Developers { get; internal set; }

        /// <summary>
        /// Company/people/person who distributed the app
        /// </summary>
        [JsonPropertyName("publishers")]
        public IReadOnlyList<string>? Publishers { get; internal set; }

        /// <summary>
        /// Current pricing details, null if app is free
        /// </summary>
        [JsonPropertyName("price_overview")]
        public Price? PriceOverview { get; internal set; }

        /// <summary>
        /// Packages associated with this app, see <seealso cref="Sub"/>
        /// </summary>
        [JsonPropertyName("packages")]
        public IReadOnlyList<uint>? Packages { get; internal set; }

        /// <summary>
        /// Package groups associated with this app, see <seealso cref="Sub"/>
        /// </summary>
        [JsonPropertyName("package_groups")]
        public IReadOnlyList<PackageGroup>? PackageGroups { get; internal set; }

        /// <summary>
        /// Which operating systems the app is available on
        /// </summary>
        [JsonPropertyName("platforms")]
        public Platforms Platforms { get; internal set; }

        /// <summary>
        /// Data for external site Metacritic
        /// </summary>
        [JsonPropertyName("metacritic")]
        public Metacritic? Metacritic { get; internal set; }

        /// <summary>
        /// Categories shown in the sidebar
        /// </summary>
        [JsonPropertyName("categories")]
        public IReadOnlyList<Category> Categories { get; internal set; } = new List<Category>();

        /// <summary>
        /// Genres shown in the sidebar
        /// </summary>
        [JsonPropertyName("genres")]
        public IReadOnlyList<Genre> Genres { get; internal set; } = new List<Genre>();

        /// <summary>
        /// Videos shown on the store page
        /// </summary>
        [JsonPropertyName("movies")]
        public IReadOnlyList<Movie> Movies { get; internal set; } = new List<Movie>();

        /// <summary>
        /// Links to images shown on the store page
        /// </summary>
        [JsonPropertyName("screenshots")]
        public IReadOnlyList<Screenshot> Screenshots { get; internal set; } = new List<Screenshot>();

        /// <summary>
        /// Shown on store page next to all reviews score. Can be null if the game
        /// isn't released yet.
        /// </summary>
        [JsonPropertyName("recommendations")]
        public Recommendations? Recommendations { get; internal set; }

        /// <summary>
        /// Highlighted achievements listed on the store page
        /// </summary>
        [JsonPropertyName("achievements")]
        public Achievements? Achievements { get; internal set; }

        /// <inheritdoc cref="Kettle.ReleaseDate"/>
        [JsonPropertyName("release_date")]
        public ReleaseDate ReleaseDate { get; internal set; }

        /// <inheritdoc cref="Kettle.SupportInfo"/>
        [JsonPropertyName("support_info")]
        public SupportInfo SupportInfo { get; internal set; }

        /// <summary>
        /// URL to background image of store page
        /// </summary>
        [JsonPropertyName("background")]
        public string Background { get; internal set; } = string.Empty;

        /// <summary>
        /// URL to background image of store page without effects
        /// </summary>
        [JsonPropertyName("background_raw")]
        public string BackgroundRaw { get; internal set; } = string.Empty;

        /// <inheritdoc cref="Kettle.ContentDescriptors"/>
        [JsonPropertyName("content_descriptors")]
        public ContentDescriptors ContentDescriptors { get; internal set; }
    }
}