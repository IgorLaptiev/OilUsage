/*
 * OilUsage.API
 *
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: 1.0
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using OpenAPIDateConverter = OilUsage.API.NetClient.Client.OpenAPIDateConverter;

namespace OilUsage.API.NetClient.Model
{
    /// <summary>
    /// OilUsageDto
    /// </summary>
    [DataContract(Name = "OilUsageDto")]
    public partial class OilUsageDto : IEquatable<OilUsageDto>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OilUsageDto" /> class.
        /// </summary>
        /// <param name="oilGuid">oilGuid.</param>
        /// <param name="usage">usage.</param>
        /// <param name="name">name.</param>
        /// <param name="issues">issues.</param>
        public OilUsageDto(Guid oilGuid = default(Guid), string usage = default(string), string name = default(string), List<string> issues = default(List<string>))
        {
            this.OilGuid = oilGuid;
            this.Usage = usage;
            this.Name = name;
            this.Issues = issues;
        }

        /// <summary>
        /// Gets or Sets OilGuid
        /// </summary>
        [DataMember(Name = "oilGuid", EmitDefaultValue = false)]
        public Guid OilGuid { get; set; }

        /// <summary>
        /// Gets or Sets Usage
        /// </summary>
        [DataMember(Name = "usage", EmitDefaultValue = true)]
        public string Usage { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = true)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Issues
        /// </summary>
        [DataMember(Name = "issues", EmitDefaultValue = true)]
        public List<string> Issues { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class OilUsageDto {\n");
            sb.Append("  OilGuid: ").Append(OilGuid).Append("\n");
            sb.Append("  Usage: ").Append(Usage).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Issues: ").Append(Issues).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as OilUsageDto);
        }

        /// <summary>
        /// Returns true if OilUsageDto instances are equal
        /// </summary>
        /// <param name="input">Instance of OilUsageDto to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(OilUsageDto input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.OilGuid == input.OilGuid ||
                    (this.OilGuid != null &&
                    this.OilGuid.Equals(input.OilGuid))
                ) && 
                (
                    this.Usage == input.Usage ||
                    (this.Usage != null &&
                    this.Usage.Equals(input.Usage))
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.Issues == input.Issues ||
                    this.Issues != null &&
                    input.Issues != null &&
                    this.Issues.SequenceEqual(input.Issues)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.OilGuid != null)
                {
                    hashCode = (hashCode * 59) + this.OilGuid.GetHashCode();
                }
                if (this.Usage != null)
                {
                    hashCode = (hashCode * 59) + this.Usage.GetHashCode();
                }
                if (this.Name != null)
                {
                    hashCode = (hashCode * 59) + this.Name.GetHashCode();
                }
                if (this.Issues != null)
                {
                    hashCode = (hashCode * 59) + this.Issues.GetHashCode();
                }
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
