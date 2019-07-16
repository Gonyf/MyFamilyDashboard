using System.ComponentModel.DataAnnotations;

namespace MyFamilyDashboard.Data
{
    public class SettingsDataModel
    {
        /// <summary>
        ///  The unique Id for this entry
        /// </summary>
        [Key]
        public string Id { get; set; }
        /// <summary>
        /// The name of the setting 
        /// </summary>
        [Required]
        [MaxLength(256)]
        public string Name { get; set; }
        /// <summary>
        /// The value of the setting
        /// </summary>
        [Required]
        [MaxLength(2048)]
        public string Value { get; set; }

    }
}
